namespace KickAss.Tools.Activities
{
    public interface IActivityWithResult<out TResult> : IActivity
        where TResult : IActivityResult
    {
        TResult Execute();
    }

    public interface IActivityWithResult<in TContext, out TResult> : IActivity
        where TContext : ActivityContext
        where TResult : IActivityResult
    {
        TResult Execute(TContext context);
    }
}