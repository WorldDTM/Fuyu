using System.Runtime.Serialization;

namespace Fuyu.Backend.BSG.Models.Servers
{
    [DataContract]
    public class Backends
    {
        [DataMember]
        public string Lobby;

        [DataMember]
        public string Trading;

        [DataMember]
        public string Messaging;

        [DataMember]
        public string Main;

        [DataMember]
        public string RagFair;
    }
}