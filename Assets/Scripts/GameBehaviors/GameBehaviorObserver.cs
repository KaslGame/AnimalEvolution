using Input;
using UnityEngine.UI;
using System;

namespace GameBehaviors
{
    public class GameBehaviorObserver : ISubscribable
    {
        private GameBehaviorChanger _changer;
        private Button _pauseButton;
        private Button _returnButton;

        public GameBehaviorObserver(GameBehaviorChanger changer, Button pauseButton, Button returnButton)
        {
            _changer = changer ?? throw new ArgumentNullException(nameof(changer));
            _pauseButton = pauseButton ?? throw new ArgumentNullException(nameof(pauseButton));
            _returnButton = returnButton ?? throw new ArgumentNullException(nameof(returnButton));
        }

        public void Subscribe()
        {
            _pauseButton.onClick.AddListener(Pause);
            _returnButton.onClick.AddListener(Return);
        }

        public void Unsubscribe()
        {
            _pauseButton.onClick.RemoveListener(Pause);
            _returnButton.onClick.RemoveListener(Return);
        }

        private void Pause()
        {
            _changer.SetBehavior<PauseGameBehavior>();
        }

        private void Return()
        {
            _changer.SetBehavior<ResumeGameBehavior>();
        }
    }
}