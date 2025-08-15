namespace PlayerScripts
{
    public interface ICollector
    {
        void PickUp(float score);
        int Level { get; }
    }
}
