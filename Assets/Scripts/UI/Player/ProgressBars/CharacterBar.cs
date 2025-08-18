using CharacterSystem;
using PlayerScripts;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public class CharacterBar : ProgressBar
    {
        [SerializeField] private Image _currentCharacter;
        [SerializeField] private Image _nextCharacter;

        [SerializeField] private Sprite _levelComplete;

        private ICharacterChanger _changer;

        private int _currentCharacterMinLevel;
        private int _nextCharacterMinLevel;
        private float _startRequirement;
        private float _endRequirement;
        private bool _hasNextCharacter = false;

        public void Initialize(ICharacterChanger changer)
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

        protected override void OnLevelChanged(int level)   {  }

        protected override void OnScoreChanged(float score, float needScore)
        {
            UpdateFill();
        }

        private void OnCharacterChanged(CharacterData current, CharacterData next)
        {
            _currentCharacter.sprite = current.Icon;
            _currentCharacterMinLevel = current.MinLevel;

            _startRequirement = CumulativeRequirement(_currentCharacterMinLevel);

            if (next == null)
            {
                _hasNextCharacter = false;
                _nextCharacter.sprite = _levelComplete;

                _endRequirement = _startRequirement;
            }
            else
            {
                _hasNextCharacter = true;
                _nextCharacter.sprite = next.Icon;
                _nextCharacterMinLevel = next.MinLevel;

                _endRequirement = CumulativeRequirement(_nextCharacterMinLevel);
            }

            UpdateFill();
        }

        private float CumulativeRequirement(int level)
        {
            if (level <= 0 || Stats == null)
                return 0f;

            float basePoints = Stats.BasePointsPerLevel;

            return basePoints * (level * (level - 1) / 2f);
        }

        private void UpdateFill()
        {
            if (FiledImage == null || Stats == null)
                return;

            if (!_hasNextCharacter)
            {
                FiledImage.fillAmount = 1f;
                return;
            }

            float totalScore = Stats.TotalScore;
            float clamped = Mathf.Clamp(totalScore, _startRequirement, _endRequirement);

            float range = _endRequirement - _startRequirement;

            if (range <= Mathf.Epsilon)
            {
                FiledImage.fillAmount = 1f;
                return;
            }

            float progress = (clamped - _startRequirement) / range;

            FiledImage.fillAmount = Mathf.Clamp01(progress);
        }
    }
}