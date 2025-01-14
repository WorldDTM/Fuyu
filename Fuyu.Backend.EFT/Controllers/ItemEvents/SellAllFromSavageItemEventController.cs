﻿using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.ItemEvents;
using Fuyu.Backend.BSG.Networking;

namespace Fuyu.Backend.EFT.Controllers.ItemEvents
{
    public class SellAllFromSavageEventController : ItemEventController<SellAllFromSavageItemEvent>
    {
        public SellAllFromSavageEventController() : base("SellAllFromSavage")
        {
        }

        public override Task RunAsync(ItemEventContext context, SellAllFromSavageItemEvent request)
        {
            return Task.CompletedTask;
        }
    }
}
