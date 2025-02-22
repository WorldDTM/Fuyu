using System.Runtime.Serialization;
using Fuyu.Backend.BSG.Models.Common;

namespace Fuyu.Backend.BSG.Models.Locations
{
    [DataContract]
    public class ColliderProperties
    {
        [DataMember]
        public Vector3 Center;

        [DataMember]
        public float Radius;
    }
}