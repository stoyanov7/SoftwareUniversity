namespace WorkForce.Events
{
    using System.Collections.Generic;
    using Models;

    public interface IJobsList : IList<IJob>
    {
        void OnJobDone(object source, JobEventArgs args);
    }
}