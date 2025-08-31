namespace ItemScripts
{
    public interface ICoinReducer
    {
        int CoinCount { get; }
        void Reduce(int coint);
    }
}