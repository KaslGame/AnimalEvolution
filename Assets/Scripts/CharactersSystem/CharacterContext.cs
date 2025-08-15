using System;
using PlayerScripts;

namespace CharacterSystem
{
    public class CharacterContext
    {
        public IPickUper PickUper { get; private set; }
        public ICollector Collector { get; private set; }

        public CharacterContext(IPickUper pickUper, ICollector collector)
        {
            PickUper = pickUper ?? throw new ArgumentNullException(nameof(pickUper));
            Collector = collector ?? throw new ArgumentNullException(nameof(collector));
        }
    }
}
