using System.Collections.Generic;

namespace MessengerComparison
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Aspect> Aspects { get; set; } = new List<Aspect>();
    }

    public class Aspect
    {
        public string AspectName { get; set; }
        public string Telegram { get; set; }
        public string Viber { get; set; }
        public string WhatsApp { get; set; }
        public List<Feature> Features { get; set; } = new List<Feature>();
    }

    public class Feature
    {
        public string FeatureName { get; set; }
        public string Telegram { get; set; }
        public string Viber { get; set; }
        public string WhatsApp { get; set; }
    }
}
