namespace KickAss.Tools.Activities
{
    public interface IActivityWithoutResult
    {
        void Execute();
    }

    public interface IActivityWithoutResult<in TContext>
        where TContext : ActivityContext
    {
        void Execute(TContext context);
    }
}