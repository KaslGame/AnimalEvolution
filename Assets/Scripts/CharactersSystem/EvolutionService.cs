using CommonInterfaces;
using PlayerScripts;
using System;

namespace CharacterSystem
{
    public class EvolutionService : ISubscribable, ICharacterChanger, IContextChanger
    {
        private readonly EvolutionConfig _config;
        private readonly IFormApplier _applier;
        private readonly PlayerStats _stats;

        public EvolutionService(EvolutionConfig config, IFormApplier applier, PlayerStats stats)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _applier = applier ?? throw new ArgumentNullException(nameof(applier));
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public event Action<CharacterData, CharacterData> CharacterChanged;
        public event Action<CharacterContext> ContextChanged;

        public void Subscribe()
        {
            _stats.LevelChanged += OnLevelChanged;
        }

        public void Unsubscribe()
        {
            _stats.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            CharacterData currentCharacter = _config.GetCharacterByLevel(level);
            CharacterData nextCharacter = _config.GetNextCharacter(level);

            if (currentCharacter == null)
                return;

            CharacterContext context = _applier.ApplyForm(currentCharacter);
            context?.PickUper?.Initialize(_stats);
            
            ContextChanged?.Invoke(context);
            CharacterChanged?.Invoke(currentCharacter, nextCharacter);
        }
    }
}