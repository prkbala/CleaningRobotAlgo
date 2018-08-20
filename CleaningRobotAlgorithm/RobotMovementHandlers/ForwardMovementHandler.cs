using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class ForwardMovementHandler : IRobotMovementHandler
    {
        private AlgorithmEssentials _algorithmEssentials;
        private IRobotMovementHandler _nextHandler;
        private bool _canReUseVisitedCells;

        public ForwardMovementHandler(AlgorithmEssentials inAlgorithmEssentials, bool inCanReUseVisitedCells = false)
        {
            _algorithmEssentials = inAlgorithmEssentials;
            _canReUseVisitedCells = inCanReUseVisitedCells;
        }

        public void SetNextMovementHandler(IRobotMovementHandler inRightTurner)
        {
            _nextHandler = inRightTurner;
        }

        public bool HandleMovement()
        {
            //If can't handle the move operation then give the control to the ObstacleHandler.

            if (RobotUtility.CanRobotMoveForward(_algorithmEssentials, _canReUseVisitedCells))
            {
                RobotUtility.MoveForward(_algorithmEssentials);
                return true;
            }

            if ((null != _nextHandler))
            {
                return _nextHandler.HandleMovement();
            }

            return false;
        }
    }
}
