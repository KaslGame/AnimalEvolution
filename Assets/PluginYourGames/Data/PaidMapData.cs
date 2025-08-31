using Map;
using System;

namespace YG
{
    [Serializable]
    public class PaidMapData
    {
        public NameScene Name;
        public bool IsPurchased;

        public PaidMapData(NameScene name, bool isPurchased)
        {
            Name = name;
            IsPurchased = isPurchased;
        }
    }
}