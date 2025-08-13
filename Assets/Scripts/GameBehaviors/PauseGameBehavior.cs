using Input;
using System;
using UI.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace GameBehaviors
{
    public class PauseGameBehavior : IGameBehavior
    {
        private const float StopTime = 0f;
        private const float RunTime = 1f;

        private IDevice _device;
        private IMenu _pauseMenu;
        private Button _pauseButton;

        public PauseGameBehavior(IDevice device, IMenu pauseMenu, Button pauseButton)
        {
            _device = device ?? throw new ArgumentNullException(nameof(device));  
            _pauseMenu = pauseMenu ?? throw new ArgumentNullException(nameof(pauseMenu));
            _pauseButton = pauseButton ?? throw new ArgumentNullException(nameof(pauseButton));
        }

        public void Enter()
        {
            _device.Disable();
            _pauseMenu.Enable();
            _pauseButton.gameObject.SetActive(false);
            SetTimeScale(StopTime);
        }

        public void Exit()
        {
            _device.Enable();
            _pauseMenu.Disable();
            _pauseButton.gameObject.SetActive(true);
            SetTimeScale(RunTime);
        }

        private void SetTimeScale(float timeScale)
        {
            if (timeScale < 0f || timeScale > 1f)
                return;

            Time.timeScale = timeScale;
        }
    }
}
