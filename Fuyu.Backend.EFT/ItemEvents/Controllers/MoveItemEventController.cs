﻿using Fuyu.Backend.BSG.ItemEvents;
using Fuyu.Backend.EFT.ItemEvents.Models;
using Fuyu.Common.IO;
using Fuyu.Backend.BSG.ItemEvents.Controllers;
using System.Threading.Tasks;

namespace Fuyu.Backend.EFT.ItemEvents.Controllers
{
    public class MoveItemEventController : ItemEventController<MoveItemEvent>
    {
        public MoveItemEventController() : base("Move")
        {
        }

        public override Task RunAsync(ItemEventContext context, MoveItemEvent request)
        {
            var profile = EftOrm.GetActiveProfile(context.SessionId);
            var item = profile.Pmc.Inventory.Items.Find(i => i.Id == request.Item);

            if (item != null)
            {
                item.Location = request.To.Location;
                item.ParentId = request.To.Id;
                item.SlotId = request.To.Container;
                Terminal.WriteLine($"{request.Item} moved to {request.To.Location}");
            }
            else
            {
                Terminal.WriteLine($"Failed to find {request.Item} in inventory");
            }

            return Task.CompletedTask;
        }
    }
}
