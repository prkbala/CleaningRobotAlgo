using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class AlgorithmEssentials
    {
        private Room _room;
        private RobotHardware.IHardwareRobot _robot;
        private IRobotVisitMonitor _robotVisitMonitor;

        public AlgorithmEssentials(Room inRoom, RobotHardware.IHardwareRobot inRobot, IRobotVisitMonitor inRobotVisitMonitor)
        {
            _room = inRoom;
            _robot = inRobot;
            _robotVisitMonitor = inRobotVisitMonitor;
        }

        public IRobotVisitMonitor RobotVisitMonitor
        {
            get { return _robotVisitMonitor; }
            private set { _robotVisitMonitor = value; }
        }

        public RobotHardware.IHardwareRobot Robot
        {
            get { return _robot; }
            private set { _robot = value; }
        }

        public Room Room
        {
            get { return _room; }
            private set { _room = value; }
        }
    }
}
