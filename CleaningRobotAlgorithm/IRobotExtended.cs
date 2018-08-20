using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    internal static class IRobotExtended
    {
        internal static CoOrdinate GetCurrentCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate currCell = new CoOrdinate();
            currCell.X = inRobot.X;
            currCell.Y = inRobot.Y;
            return currCell;
        }

        internal static CoOrdinate GetFrontCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate nextCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    nextCell.X = inRobot.X + 1;
                    nextCell.Y = inRobot.Y;
                    break;
                case 1:
                    nextCell.X = inRobot.X;
                    nextCell.Y = inRobot.Y + 1;
                    break;
                case 2:
                    nextCell.X = inRobot.X - 1;
                    nextCell.Y = inRobot.Y;
                    break;
                case 3:
                    nextCell.X = inRobot.X;
                    nextCell.Y = inRobot.Y - 1;
                    break;
            }
            return nextCell;
        }

        internal static CoOrdinate GetBackCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate prevCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    prevCell.X = inRobot.X - 1;
                    prevCell.Y = inRobot.Y;
                    break;
                case 1:
                    prevCell.X = inRobot.X;
                    prevCell.Y = inRobot.Y - 1;
                    break;
                case 2:
                    prevCell.X = inRobot.X + 1;
                    prevCell.Y = inRobot.Y;
                    break;
                case 3:
                    prevCell.X = inRobot.X;
                    prevCell.Y = inRobot.Y + 1;
                    break;
            }
            return prevCell;
        }

        internal static CoOrdinate GetLeftCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate leftCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    leftCell.X = inRobot.X;
                    leftCell.Y = inRobot.Y - 1;
                    break;
                case 1:
                    leftCell.X = inRobot.X + 1;
                    leftCell.Y = inRobot.Y;
                    break;
                case 2:
                    leftCell.X = inRobot.X;
                    leftCell.Y = inRobot.Y + 1;
                    break;
                case 3:
                    leftCell.X = inRobot.X - 1;
                    leftCell.Y = inRobot.Y;
                    break;
            }
            return leftCell;
        }

        internal static CoOrdinate GetRightCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate rightCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    rightCell.X = inRobot.X;
                    rightCell.Y = inRobot.Y + 1;
                    break;
                case 1:
                    rightCell.X = inRobot.X - 1;
                    rightCell.Y = inRobot.Y;
                    break;
                case 2:
                    rightCell.X = inRobot.X;
                    rightCell.Y = inRobot.Y - 1;
                    break;
                case 3:
                    rightCell.X = inRobot.X + 1;
                    rightCell.Y = inRobot.Y;
                    break;
            }
            return rightCell;
        }

        internal static CoOrdinate GetTopLeftCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate topLeftCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    topLeftCell.X = inRobot.X + 1;
                    topLeftCell.Y = inRobot.Y - 1;
                    break;
                case 1:
                    topLeftCell.X = inRobot.X + 1;
                    topLeftCell.Y = inRobot.Y + 1;
                    break;
                case 2:
                    topLeftCell.X = inRobot.X - 1;
                    topLeftCell.Y = inRobot.Y + 1;
                    break;
                case 3:
                    topLeftCell.X = inRobot.X - 1;
                    topLeftCell.Y = inRobot.Y - 1;
                    break;
            }
            return topLeftCell;
        }

        internal static CoOrdinate GetTopRightCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate topRightCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    topRightCell.X = inRobot.X + 1;
                    topRightCell.Y = inRobot.Y + 1;
                    break;
                case 1:
                    topRightCell.X = inRobot.X - 1;
                    topRightCell.Y = inRobot.Y + 1;
                    break;
                case 2:
                    topRightCell.X = inRobot.X - 1;
                    topRightCell.Y = inRobot.Y - 1;
                    break;
                case 3:
                    topRightCell.X = inRobot.X + 1;
                    topRightCell.Y = inRobot.Y - 1;
                    break;
            }
            return topRightCell;
        }

        internal static CoOrdinate GetBottomLeftCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate bottomLeftCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    bottomLeftCell.X = inRobot.X - 1;
                    bottomLeftCell.Y = inRobot.Y - 1;
                    break;
                case 1:
                    bottomLeftCell.X = inRobot.X + 1;
                    bottomLeftCell.Y = inRobot.Y - 1;
                    break;
                case 2:
                    bottomLeftCell.X = inRobot.X + 1;
                    bottomLeftCell.Y = inRobot.Y + 1;
                    break;
                case 3:
                    bottomLeftCell.X = inRobot.X - 1;
                    bottomLeftCell.Y = inRobot.Y + 1;
                    break;
            }
            return bottomLeftCell;
        }

        internal static CoOrdinate GetBottomRightCell(this RobotHardware.IHardwareRobot inRobot)
        {
            CoOrdinate bottomRightCell = new CoOrdinate();

            switch (inRobot.FaceTo)
            {
                case 0:
                    bottomRightCell.X = inRobot.X - 1;
                    bottomRightCell.Y = inRobot.Y + 1;
                    break;
                case 1:
                    bottomRightCell.X = inRobot.X - 1;
                    bottomRightCell.Y = inRobot.Y - 1;
                    break;
                case 2:
                    bottomRightCell.X = inRobot.X + 1;
                    bottomRightCell.Y = inRobot.Y - 1;
                    break;
                case 3:
                    bottomRightCell.X = inRobot.X + 1;
                    bottomRightCell.Y = inRobot.Y + 1;
                    break;
            }
            return bottomRightCell;
        }
    }
}
