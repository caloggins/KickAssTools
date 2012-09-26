namespace KickAss.Tools.Activities
{
    public interface IActivityFactory
    {
        TActivity Create<TActivity>()
            where TActivity : IActivity;

        void Release(IActivity activity);
    }
}