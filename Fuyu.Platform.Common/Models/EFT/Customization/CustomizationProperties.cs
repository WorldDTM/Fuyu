using System.Runtime.Serialization;
using Fuyu.Platform.Common.Models.EFT.Common;

namespace Fuyu.Platform.Common.Models.EFT.Customization
{
    [DataContract]
    public struct CustomizationProperties
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string ShortName;

        [DataMember]
        public string Description;

        [DataMember]
        public string[] Side;

        [DataMember]
        public string BodyPart;

        [DataMember]
        public object Prefab;   // can be String or BundleAddress

        [DataMember]
        public BundleAddress WatchPrefab;

        [DataMember]
        public bool IntegratedArmorVest;

        [DataMember]
        public Vector3 WatchPosition;

        [DataMember]
        public Vector3 WatchRotation;

        [DataMember]
        public bool AvailableAsDefault;

        [DataMember]
        public string Body;
        
        [DataMember]
        public string Hands;

        [DataMember]
        public string Feet;
    }
}