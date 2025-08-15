using CharacterSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public class CharacterBar : ProgressBar
    {
        private const int CostLevelScore = 50;

        [SerializeField] private Image _currentCharacter;
        [SerializeField] private Image _nextCharacter;

        [SerializeField] private Sprite _levelComplete;

        private ICharacterChanger _changer;

        private int _needLevel;

        public void SetChanger(ICharacterChanger changer)
        {
            _changer = changer ?? throw new ArgumentNullException(nameof(changer));
        }

        public override void Start()
        {
            base.Start();

            _changer.CharacterChanged += OnCharacterChanged;
        }

        public override void OnDisable()
        {
            base.OnDisable();

            _changer.CharacterChanged -= OnCharacterChanged;
        }

        protected override void OnLevelChanged(int level) { }

        protected override void OnScoreChanged(float score, float needScore)
        {
            var scoreToNextCharacter = _needLevel * CostLevelScore;

            FiledImage.fillAmount = Mathf.Clamp01(score / scoreToNextCharacter);
        }

        private void OnCharacterChanged(CharacterData current, CharacterData next)
        {
            _currentCharacter.sprite = current.Icon;

            if (next == null)
            {
                _nextCharacter.sprite = _levelComplete;
                return;
            }

            _nextCharacter.sprite = next.Icon;
            _needLevel = next.MinLevel;
        }
    }
}