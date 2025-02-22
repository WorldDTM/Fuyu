﻿using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Items;
using Fuyu.Backend.BSG.Models.ItemEvents;
using Fuyu.Backend.BSG.Networking;

namespace Fuyu.Backend.EFT.Controllers.ItemEvents
{
    public class TagItemEventController : ItemEventController<TagItemEvent>
    {
        public TagItemEventController() : base("Tag")
        {
        }

        public override Task RunAsync(ItemEventContext context, TagItemEvent request)
        {
            var profile = EftOrm.GetActiveProfile(context.SessionId);
            var item = profile.Pmc.Inventory.Items.Find(i => i.Id == request.Item);

            if (item != null)
            {
                var tag = item.GetUpdatable<ItemTagComponent>();
                tag.Name = request.Name;
                tag.Color = request.Color;
            }
            else
            {
                context.Response.ProfileChanges[profile.Pmc._id].Items.Delete.Add(new ItemInstance { Id = request.Item });
                context.AppendInventoryError($"Failed to find item on backend: {request.Item}, removing it");
            }

            return Task.CompletedTask;
        }
    }
}
