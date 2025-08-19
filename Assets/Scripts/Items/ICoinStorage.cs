using System;

namespace ItemScripts
{
    public interface ICoinStorage
    {
        event Action<int> CoinsChanged;
        int CoinCount { get; }
    }
}