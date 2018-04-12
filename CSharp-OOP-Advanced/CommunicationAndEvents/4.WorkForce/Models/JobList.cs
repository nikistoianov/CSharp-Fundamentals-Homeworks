namespace _4.WorkForce.Models
{
    using System.Collections.Generic;
    
    public class JobList : List<Job>
    {
        private delegate void JobStatusHandler();
        private event JobStatusHandler JobStatus;

        private delegate void JobUpdateHandler();
        private event JobUpdateHandler JobUpdate;

        public void AddJob(Job job)
        {
            job.JobComplete += OnJobComplete;
            this.JobStatus += job.Status;
            this.JobUpdate += job.Update;
            this.Add(job);
        }

        public void Status()
        {
            if (this.JobStatus != null)
                this.JobStatus.Invoke();
        }

        public void Update()
        {
            if (this.JobUpdate != null)
                this.JobUpdate.Invoke();
        }

        public void OnJobComplete(Job job)
        {
            this.JobStatus -= job.Status;
            this.JobUpdate -= job.Update;
            this.Remove(job);
        }
    }
}
