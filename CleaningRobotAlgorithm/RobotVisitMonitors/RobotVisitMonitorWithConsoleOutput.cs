using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    class RobotVisitMonitorWithConsoleOutput : RobotVisitMonitor
    {
        public RobotVisitMonitorWithConsoleOutput(RobotHardware.IHardwareRobot inRobot)
        {
            _robotVisitList = new List<CoOrdinate>();
            _robot = inRobot;
            _pathLogger = new List<string>();
        }

        public override void PrintRobotPath()
        {
            foreach (string path in _pathLogger)
            {
                Console.WriteLine(path);
            }
        }
    }
}
