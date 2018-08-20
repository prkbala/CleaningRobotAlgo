using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class ObstacleHandler : IRobotMovementHandler
    {
        private AlgorithmEssentials _algorithmEssentials;
        private IRobotMovementHandler _nextHandler;
        private bool _canReUseVisitedCells;

        public ObstacleHandler(AlgorithmEssentials inAlgorithmEssentials, bool inCanReUseVisitedCells = false)
        {
            _algorithmEssentials = inAlgorithmEssentials;
            _canReUseVisitedCells = inCanReUseVisitedCells;
        }

        public void SetNextMovementHandler(IRobotMovementHandler inNextHandler)
        {
            _nextHandler = inNextHandler;
        }

        public bool HandleMovement()
        {
            // Handle the obstacle by turning right. If 3 right turns can't find a way,
            // then the Robot completed cleaning the room.

            RobotUtility.TurnRight(_algorithmEssentials);

            if (RobotUtility.CanRobotMoveForward(_algorithmEssentials, _canReUseVisitedCells))
            {
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
