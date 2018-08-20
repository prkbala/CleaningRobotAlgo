using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    class CircularCleaningAlgorithm : CleaningAlgorithm
    {
        private HandlerContainer _handlerManager;

        public CircularCleaningAlgorithm(AlgorithmEssentials inAlgorithmEssentials, HandlerContainer inHandlerManager)
        {
            _algorithmEssentials = inAlgorithmEssentials;

            _handlerManager = inHandlerManager;
        }

        public override CleanStatus Clean()
        {
            _algorithmEssentials.RobotVisitMonitor.AddCurrentPositionToVisitList();

            RobotUtility.TurnLeft(_algorithmEssentials);

            bool canMove = true;
            while (canMove)
            {
                canMove = _handlerManager.HandleNextMove();
            }

            Status = CleanStatus.Complete;

            return CleanStatus.Complete;
        }
    }   
}
