using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public abstract class CleaningAlgorithm
    {
        protected CleanStatus _status = CleanStatus.NotStarted;
        protected AlgorithmEssentials _algorithmEssentials;

        protected AlgorithmEssentials AlgorithmEssentials
        {
            get { return _algorithmEssentials; }
            set { _algorithmEssentials = value; }
        }

        public CleanStatus Status
        {
            get { return _status; }
            protected set { _status = value; }
        }

        public virtual CleanStatus Clean()
        {
            return _status;
        }
    }
}
