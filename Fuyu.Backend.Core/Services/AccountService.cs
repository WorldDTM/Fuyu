using System;
using System.Linq;
using Fuyu.Common.IO;
using Fuyu.Common.Hashing;
using Fuyu.Backend.Core.DTO.Accounts;
using Fuyu.Common.Serialization;
using System.Collections.Generic;

namespace Fuyu.Backend.Core.Services
{
    public static class AccountService
    {
        // TODO:
        // * account login state tracking
        // -- seionmoya, 2024/09/02

        public static int AccountExists(string username, string password)
        {
            var lowerUsername = username.ToLowerInvariant();
            var accounts = CoreOrm.GetAccounts();
            var found = new List<Account>();

            foreach (var account in accounts)
            {
                if (account.Username == lowerUsername && account.Password == password)
                {
                    found.Add(account);
                }
            };

            if (found.Count > 1)
            {
                throw new Exception($"Multiple accounts found with username {username}.");
            }

            if (found.Count == 0)
            {
                return -1;
            }

            return found[0].Id;
        }

        public static string LoginAccount(string username, string password)
        {
            var accountId = AccountExists(username, password);

            if (accountId == -1)
            {
                return string.Empty;
            }

            var sessions = CoreOrm.GetSessions();

            foreach (var kvp in sessions)
            {
                if (kvp.Value == accountId)
                {
                    // session already exists
                    return kvp.Key;
                }
            }

            // NOTE: MongoId's are used internally, but EFT's launcher uses
            //       a different ID system (hwid+timestamp hash). Instead of
            //       fully mimicking this, I decided to generate a new MongoId
            //       for each login.
            // -- seionmoya, 2024/09/02
            var sessionId = new MongoId(true).ToString();
            CoreOrm.AddSession(sessionId, accountId);
            return sessionId.ToString();
        }

        private static int GetNewAccountId()
        {
            var accounts = CoreOrm.GetAccounts();

            // using linq because sorting otherwise takes up too much code
            var sorted = accounts.OrderBy(account => account.Id).ToArray();
            
            // NOTE: I know multi-threading is overkill for most systems, but I
            //       want to keep in mind large server workloads
            // -- seionmoya, 2024/09/02
            var found = new List<int>();

            for (var i = 0; i < sorted.Length; ++i)
            {
                if (sorted[i].Id != i)
                {
                    found.Add(sorted[i].Id);
                }
            }

            if (found.Count != 0)
            {
                // use gap entry
                return found[0];
            }
            else
            {
                // use new entry
                return sorted.Length;
            }
        }

        public static ERegisterStatus RegisterAccount(string username, string password)
        {
            if (AccountExists(username, password) != -1)
            {
                return ERegisterStatus.AlreadyExists;
            }

            var id = GetNewAccountId();
            var account = new Account()
            {
                Id = id,
                Username = username.ToLowerInvariant(),
                Password = password,
                Games = new Dictionary<EGame, List<int>>()
                {
                    { EGame.EFT,   new List<int>() },
                    { EGame.Arena, new List<int>() },
                }
            };

            CoreOrm.AddAccount(account);
            WriteToDisk(account);

            return ERegisterStatus.Success;
        }

        public static ERegisterStatus RegisterGame(string sessionId, EGame game, string edition)
        {
            var account = CoreOrm.GetAccount(sessionId);
            var id = 0;

            switch (game)
            {
                case EGame.EFT:
                    // TODO: request
                    account.Games[EGame.EFT].Add(id);
                    break;
                
                case EGame.Arena:
                    // TODO: request
                    account.Games[EGame.Arena].Add(id);
                    break;
            }

            CoreOrm.SetAccount(account);
            WriteToDisk(account);

            return ERegisterStatus.Success;
        }

        public static void WriteToDisk(Account account)
        {
            VFS.WriteTextFile(
                $"./Fuyu/Accounts/Core/{account.Id}.json",
                Json.Stringify(account));
        }
    }
}