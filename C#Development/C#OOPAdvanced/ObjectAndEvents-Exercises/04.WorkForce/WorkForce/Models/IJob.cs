using System;
using WorkForce.Events;

namespace WorkForce.Models
{
    public interface IJob
    {
        string Name { get; }

        event EventHandler<JobEventArgs> JobDone;

        void OnJobDone();
        string ToString();
        void Update();
    }
}