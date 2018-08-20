using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    abstract class ReturnAlgorithm
    {
        private ReturnStatus _status = ReturnStatus.NotStarted;        

        public ReturnStatus Status
        {
            get { return _status; }
            protected set { _status = value; }
        }        

        public virtual ReturnStatus ReturnToStartPoint()
        {
            return _status;
        }
    }
}
