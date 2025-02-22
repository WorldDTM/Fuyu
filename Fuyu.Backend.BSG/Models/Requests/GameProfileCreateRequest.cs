using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.Models.Requests
{
    [DataContract]
    public class GameProfileCreateRequest
    {
        [DataMember]
        public string side;

        [DataMember]
        public string nickname;

        [DataMember]
        public string headId;

        [DataMember]
        public string voiceId;
    }
}