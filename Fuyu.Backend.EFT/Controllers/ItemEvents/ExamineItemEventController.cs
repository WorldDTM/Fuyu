﻿using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.ItemEvents;
using Fuyu.Backend.BSG.Networking;

namespace Fuyu.Backend.EFT.Controllers.ItemEvents
{
    public class ExamineItemEventController : ItemEventController<ExamineItemEvent>
    {
        public ExamineItemEventController() : base("Examine")
        {
        }

        public override Task RunAsync(ItemEventContext context, ExamineItemEvent request)
        {
            var profile = EftOrm.GetActiveProfile(context.SessionId);

            profile.Pmc.Encyclopedia[request.TemplateId] = true;

            return Task.CompletedTask;
        }
    }
}
