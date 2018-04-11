namespace WorkForce.Events
{
    using System;
    using Models;

    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(IJob job) => this.Job = job;

        public IJob Job { get; }
    }
}