using System;
using YG;

namespace ItemScripts
{
    public class CoinStorage : ICoinStorage, ICoinIncreaser
    {
        public event Action<int> CoinsChanged;

        public int CoinCount => YG2.saves.Coins;

        public void Increase(int value)
        {
            if (value < 0)
                return;

            YG2.saves.Coins += value;
            YG2.SaveProgress();

            CoinsChanged?.Invoke(CoinCount);
        }
    }
}