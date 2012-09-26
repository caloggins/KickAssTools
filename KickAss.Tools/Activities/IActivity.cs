namespace KickAss.Tools.Activities
{
    public interface IActivity<out TResult> : IActivity
    {
        TResult Execute();
    }

    public interface IActivity
    {
    }
}