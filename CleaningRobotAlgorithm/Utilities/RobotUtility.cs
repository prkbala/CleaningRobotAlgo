using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public static class RobotUtility
    {
        public static void MoveForward(AlgorithmEssentials inAlgorithmEssentials)
        {
            inAlgorithmEssentials.Robot.Walk();

            if (inAlgorithmEssentials.Robot.X > inAlgorithmEssentials.Room.MaxCoOrdinate.X)
            {
                inAlgorithmEssentials.Room.MaxCoOrdinate.X = inAlgorithmEssentials.Robot.X;
            }

            if (inAlgorithmEssentials.Robot.Y > inAlgorithmEssentials.Room.MaxCoOrdinate.Y)
            {
                inAlgorithmEssentials.Room.MaxCoOrdinate.Y = inAlgorithmEssentials.Robot.Y;
            }

            inAlgorithmEssentials.RobotVisitMonitor.AddCurrentPositionToVisitList();

            inAlgorithmEssentials.RobotVisitMonitor.AddToRobotPath("Move Forward");
        }

        public static void TurnRight(AlgorithmEssentials inAlgorithmEssentials)
        {
            inAlgorithmEssentials.Robot.TurnRight();
            inAlgorithmEssentials.RobotVisitMonitor.AddToRobotPath("Turn Right");
        }

        public static void TurnLeft(AlgorithmEssentials inAlgorithmEssentials)
        {
            inAlgorithmEssentials.Robot.TurnLeft();
            inAlgorithmEssentials.RobotVisitMonitor.AddToRobotPath("Turn Left");
        }

        public static bool CanRobotMoveForward(AlgorithmEssentials inAlgorithmEssentials, bool inCanReUseVisitedCells)
        {
            if (inCanReUseVisitedCells)
            {
                return (!inAlgorithmEssentials.Robot.IsObstacle());
            }
            else
            {
                return ((!inAlgorithmEssentials.Robot.IsObstacle()) && (!inAlgorithmEssentials.RobotVisitMonitor.IsFrontCellVisited()));
            }
        }

        public static void TurnToFaceLeft(AlgorithmEssentials inAlgorithmEssentials)
        {
            // Turn to the left side.
            switch (inAlgorithmEssentials.Robot.FaceTo)
            {
                case 0:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
                case 1:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
                case 3:
                    RobotUtility.TurnLeft(inAlgorithmEssentials);
                    break;
            }
        }

        public static void TurnToFaceRight(AlgorithmEssentials inAlgorithmEssentials)
        {
            // Turn to the right side.
            switch (inAlgorithmEssentials.Robot.FaceTo)
            {
                case 1:
                    RobotUtility.TurnLeft(inAlgorithmEssentials);
                    break;
                case 2:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
                case 3:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
            }
        }

        public static void TurnToFaceUp(AlgorithmEssentials inAlgorithmEssentials)
        {
            // Turn to the top side.
            switch (inAlgorithmEssentials.Robot.FaceTo)
            {
                case 0:
                    RobotUtility.TurnLeft(inAlgorithmEssentials);
                    break;
                case 1:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
                case 2:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
            }
        }

        public static void TurnToFaceDown(AlgorithmEssentials inAlgorithmEssentials)
        {
            // Turn to the bottom side.
            switch (inAlgorithmEssentials.Robot.FaceTo)
            {
                case 0:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
                case 2:
                    RobotUtility.TurnLeft(inAlgorithmEssentials);
                    break;
                case 3:
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    RobotUtility.TurnRight(inAlgorithmEssentials);
                    break;
            }
        }
    }
}
