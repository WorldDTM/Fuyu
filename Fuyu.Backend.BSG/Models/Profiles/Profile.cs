using System.Collections.Generic;
using System.Runtime.Serialization;
using Fuyu.Common.Collections;
using Fuyu.Common.Hashing;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.BSG.Models.Profiles
{
    // Assembly-CSharp.dll: EFT.Profile
    [DataContract]
    public class Profile
    {
        [DataMember]
        public MongoId _id;

        [DataMember]
        public int aid;

        [DataMember(EmitDefaultValue = false)]
        public MongoId? savage;

        [DataMember]
        public ProfileInfo Info;

        [DataMember]
        public CustomizationInfo Customization;

        [DataMember]
        public HealthInfo Health;

        [DataMember]
        public InventoryInfo Inventory;

        [DataMember]
        public SkillInfo Skills;

        [DataMember]
        public StatsInfo Stats;

        [DataMember]
        public Dictionary<MongoId, bool> Encyclopedia;

        [DataMember]
        public Dictionary<string, ConditionCounter> TaskConditionCounters;

        [DataMember]
        public List<InsuredItem> InsuredItems;

        [DataMember]
        public HideoutInfo Hideout;

        [DataMember]
        public List<BonusInfo> Bonuses;

        [DataMember]
        public Union<Dictionary<MongoId, EWishlistGroup>, object[]> WishList;

        [DataMember(EmitDefaultValue = false)]
        public NotesInfo Notes;

        [DataMember(EmitDefaultValue = false)]
        public List<QuestInfo> Quests;

        [DataMember(EmitDefaultValue = false)]
        public Dictionary<MongoId, int> Achievements;

        [DataMember(EmitDefaultValue = false)]
        public RagfairInfo RagfairInfo;

        [DataMember(EmitDefaultValue = false)]
        public Union<Dictionary<MongoId, TraderInfo>, object[]>? TradersInfo;

        [DataMember(EmitDefaultValue = false)]
        public UnlockedInfo UnlockedInfo;

        [DataMember(EmitDefaultValue = false)]
        public MoneyTransferLimitInfo moneyTransferLimitData;

        // NOTE: Deserialization works but is deserialized as
        // an array because the profile has "WishList": [] by default
        // instead we should access it from this method which will
        // turn it into a Dictionary if it isn't one already
        // -- nexus4880, 2024-10-31
        public Dictionary<MongoId, EWishlistGroup> GetWishList()
        {
            if (!WishList.IsValue1)
            {
                WishList = new Dictionary<MongoId, EWishlistGroup>();
            }

            return WishList.Value1;
        }

        // NOTE: Write proper clone method later
        // -- nexus4880, 2024-11-1
        public Profile Clone()
        {
            return Json.Clone<Profile>(this);
        }
    }
}