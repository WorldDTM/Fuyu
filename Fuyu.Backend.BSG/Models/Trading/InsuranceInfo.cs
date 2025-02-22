﻿using System.Runtime.Serialization;
using Fuyu.Common.Hashing;

namespace Fuyu.Backend.BSG.Models.Trading
{
    [DataContract]
    public class InsuranceInfo
    {
        [DataMember(Name = "availability")]
        public bool Availability { get; set; }

        [DataMember(Name = "min_payment")]
        public int MinPayment { get; set; }

        [DataMember(Name = "min_return_hour")]
        public int MinReturnHours { get; set; }

        [DataMember(Name = "max_return_hour")]
        public int MaxReturnHours { get; set; }

        [DataMember(Name = "excluded_category")]
        public MongoId[] ExcludedCategories { get; set; }
    }
}
