namespace KickAss.Tools.Activities
{
    public interface IActivityWithResult<out TResult> : IActivity
    {
        TResult Execute();
    }

    public interface IActivityWithResult<in TContext, out TResult> : IActivity
        where TContext : ActivityContext
    {
        TResult Execute(TContext context);
    }
}