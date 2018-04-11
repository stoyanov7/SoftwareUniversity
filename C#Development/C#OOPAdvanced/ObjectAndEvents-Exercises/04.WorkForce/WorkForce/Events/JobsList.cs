namespace WorkForce.Events
{
    using System.Collections.Generic;
    using Models;

    public class JobsList : List<IJob>, IJobsList
    {
        public void OnJobDone(object source, JobEventArgs args)
        {
            args.Job.JobDone -= this.OnJobDone;
            this.Remove(args.Job);
        }
    }
}