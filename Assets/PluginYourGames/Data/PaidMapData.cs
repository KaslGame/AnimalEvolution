using System;

namespace YG
{
    [Serializable]
    public class PaidMapData
    {
        public string Name;
        public bool IsPurchased;

        public PaidMapData(string name, bool isPurchased)
        {
            Name = name;
            IsPurchased = isPurchased;
        }
    }
}