using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public enum CleanStatus
    {
        NotStarted,
        Partial,
        Complete
    }

    public enum ReturnStatus
    {
        NotStarted,
        InBetween,
        Complete
    }

    class CleaningManager
    {
        private CleaningAlgorithm cleaningAlgorithm;
        private ReturnAlgorithm returnAlgorithm;

        public CleaningManager(CleaningAlgorithm inCleaningAlgorithm, ReturnAlgorithm inReturnAlgorithm)
        {
            cleaningAlgorithm = inCleaningAlgorithm;
            returnAlgorithm = inReturnAlgorithm;
        }

        public bool Clean()
        {
            CleanStatus cleanStatus = CleanTheFloor();
            ReturnStatus returnStatus = ReturnBackToStartPosition();

            if ((cleanStatus != CleanStatus.Complete) || (returnStatus != ReturnStatus.Complete))
                return false;

            return true;
        }

        private CleanStatus CleanTheFloor()
        {
            if (cleaningAlgorithm == null)
                return CleanStatus.NotStarted;

            return cleaningAlgorithm.Clean();
        }

        private ReturnStatus ReturnBackToStartPosition()
        {
            if (returnAlgorithm == null)
                return ReturnStatus.NotStarted;

            return returnAlgorithm.ReturnToStartPoint();
        }

        public CleanStatus GetCleanStatus()
        {
            return cleaningAlgorithm.Status;
        }

        public ReturnStatus GetReturnStatus()
        {
            return returnAlgorithm.Status;
        }
    }
}
