using BoostersScripts;
using GameBehaviors;
using Input;
using PlayerScripts;
using System.Collections.Generic;
using UI.Menu;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class InputBoostrap : MonoBehaviour
{
    private const int MinLevel = 1;

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _busterButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _returnButton;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private MagnetBooster _booster;

    public bool IsMobile;

    private IInputController _controller;
    private IDevice _device;
    private List<ISubscribable> _subscribables = new List<ISubscribable>();

    private void Awake()
    {
        InputInitialize();
        GameBehaviorInitialize();
    }

    private void OnEnable()
    {
        foreach (ISubscribable subscribable in _subscribables)
            subscribable.Subscribe();
    }

    private void OnDisable()
    {
        foreach (ISubscribable subscribable in _subscribables)
            subscribable.Unsubscribe();
    }

    private void GameBehaviorInitialize()
    {
        var gameBehaviorChanger = new GameBehaviorChanger();

        gameBehaviorChanger.AddBehavior(new PauseGameBehavior(_device, _pauseMenu, _pauseButton));
        gameBehaviorChanger.AddBehavior(new ResumeGameBehavior());

        gameBehaviorChanger.SetBehavior<ResumeGameBehavior>();

        var gameBehaviorObserver = new GameBehaviorObserver(gameBehaviorChanger, _pauseButton, _returnButton);
        _subscribables.Add(gameBehaviorObserver);
    }

    private void InputInitialize()
    {
        if (IsMobile)
        {
            var mobileController = new MobileController(_joystick, _busterButton);
            _device = new MobileDevice(_joystick, _busterButton);

            _controller = mobileController;
            _subscribables.Add(mobileController);
        }
        else
        {
            PlayerInputSystem playerInput = new PlayerInputSystem();
            _device = new DesktopDevice(playerInput);
            var desktopController = new DesktopController(playerInput);

            _controller = desktopController;
            _subscribables.Add(desktopController);

            HideMobileUI();
        }

        TryMagnet(_controller);
        _movement.SetController(_controller);
    }

    private void TryMagnet(IInputController controller)
    {
        int level = YG2.saves.LevelMagnet;

        if (level < MinLevel)
        {
            HideButton();
            return;
        }

        _booster.SetInputController(_controller);
        _booster.SetLevel(level);
    }

    private void HideMobileUI()
    {
        _joystick.gameObject.SetActive(false);
        HideButton();
    }

    private void HideButton()
    {
        _busterButton.gameObject.SetActive(false);
    }
}
