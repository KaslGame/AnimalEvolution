using FoodScripts;
using ItemScripts;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using YG;

namespace UI.Menu 
{
    [RequireComponent(typeof(CanvasGroup))]
    public class RewardMenu : MonoBehaviour
    {
        private const string RewardID = "Coins";

        [SerializeField] private Button _rewardButton;
        [SerializeField] private TMP_Text _reward;
        [SerializeField] private float _fadeDuration;

        private FadeAnimation _animation;
        private CanvasGroup _group;

        private IFoodsViewer _viewer;
        private ILevelRewarder _rewarder;

        public void SetRewarder(ILevelRewarder rewarder)
        {
            _rewarder = rewarder ?? throw new ArgumentNullException(nameof(rewarder));
        }

        public void SetViewer(IFoodsViewer viewer)
        {
            _viewer = viewer ?? throw new ArgumentNullException(nameof(viewer));
        }

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            _animation = new FadeAnimation(_group, _fadeDuration);
        }

        private void OnEnable()
        {
            _rewardButton.onClick.AddListener(ShowReward);
            YG2.onRewardAdv += OnReward;
        }

        private void Start()
        {
            _viewer.FoodsEmpty += OnFoodsEmpty;
        }

        private void OnDisable()
        {
            _viewer.FoodsEmpty -= OnFoodsEmpty;
            _rewardButton.onClick.RemoveListener(ShowReward);
            YG2.onRewardAdv -= OnReward;
        }

        private void OnFoodsEmpty()
        {
            _animation.FadeIn();
            _reward.text = _rewarder.TotalReward.ToString();

            Time.timeScale = 0f;
        }

        private void OnReward(string id)
        {
            int doubleReward = 2;

            if (id != RewardID)
                return;

            _rewardButton.interactable = false;
            _reward.text = $"{_rewarder.TotalReward * doubleReward}";
        }

        private void ShowReward()
        {
            if (YG2.nowAdsShow == true)
                return;

            YG2.RewardedAdvShow(RewardID);
        }
    }
}
