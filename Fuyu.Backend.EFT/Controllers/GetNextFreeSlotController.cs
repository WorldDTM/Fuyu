﻿using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Items;
using Fuyu.Backend.EFT.Networking;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers
{
    [DataContract]
    public class GetNextFreeSlotRequest
    {
        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "rotation")]
        public EItemRotation Rotation { get; set; }
    }

    // TODO: Delete later
    // -- nexus4880, 2024-11-26
    public class GetNextFreeSlotController : EftHttpController<GetNextFreeSlotRequest>
    {
        public GetNextFreeSlotController() : base("/get/next/free/slot")
        {
        }

        public override Task RunAsync(EftHttpContext context, GetNextFreeSlotRequest body)
        {
            var profile = EftOrm.GetActiveProfile(context.GetSessionId());
            var freeSlot = profile.Pmc.Inventory.GetNextFreeSlot(body.Width, body.Height, out var gridName, body.Rotation);
            if (freeSlot == null)
            {
                return context.SendStatus(HttpStatusCode.InternalServerError);
            }

            return context.SendJsonAsync(Json.Stringify(new
            {
                freeSlot,
                gridName
            }));
        }
    }
}
