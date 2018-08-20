using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    class SimpleReturnAlgorithm : ReturnAlgorithm
    {
        private AlgorithmEssentials _algorithmEssentials;
        private HandlerContainer _handlerManager;

        public SimpleReturnAlgorithm(AlgorithmEssentials inAlgorithmEssentials, HandlerContainer inHandlerManager)
        {
            _algorithmEssentials = inAlgorithmEssentials;
            _handlerManager = inHandlerManager;
        }

        public override ReturnStatus ReturnToStartPoint()
        {
            TurnRobotToFaceTheCorrectSide();

            bool canMove = true;
            while (canMove)
            {
                canMove = _handlerManager.HandleNextMove();

                // check if the robot had reached (0,0) and come out of the loop
                if ((_algorithmEssentials.Robot.GetCurrentCell().X == 0) && (_algorithmEssentials.Robot.GetCurrentCell().Y == 0))
                    canMove = false;
            }

            Status = ReturnStatus.Complete;
            return ReturnStatus.Complete;
        }

        private void TurnRobotToFaceTheCorrectSide()
        {
            int diffInX = _algorithmEssentials.Robot.GetCurrentCell().X - _algorithmEssentials.Room.MinCoOrdinate.X;
            int diffInY = _algorithmEssentials.Robot.GetCurrentCell().Y - _algorithmEssentials.Room.MinCoOrdinate.Y;

            if (diffInX > 0)
            {
                //turn to the left side
                RobotUtility.TurnToFaceLeft(_algorithmEssentials);
            }

            if (diffInX == 0)
            {
                if (diffInY > 0)
                {
                    //turn to the top side
                    RobotUtility.TurnToFaceUp(_algorithmEssentials);
                }
                if (diffInY < 0)
                {
                    //turn to the bottom side
                    RobotUtility.TurnToFaceDown(_algorithmEssentials);
                }
            }

            if (diffInX < 0)
            {
                //turn to the right side
                RobotUtility.TurnToFaceRight(_algorithmEssentials);
            }
        }
    }
}
