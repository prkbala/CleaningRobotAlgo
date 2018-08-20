using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public enum RobotVisitMonitorType
    {
        RobotVisitMonitorWithConsoleOutput
    }

    public static class RobotVisitMonitorFactory
    {
        public static IRobotVisitMonitor CreateRobotVisitMonitor(RobotVisitMonitorType inRobotVisitMonitorType, RobotHardware.IHardwareRobot inRobot)
        {
            IRobotVisitMonitor robotVisitMonitor;

            switch (inRobotVisitMonitorType)
            {
                case RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput:
                    robotVisitMonitor = new RobotVisitMonitorWithConsoleOutput(inRobot);
                    break;
                default:
                    robotVisitMonitor = null;
                    break;
            }

            return robotVisitMonitor;
        }
    }
}
