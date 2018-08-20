using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public abstract class RobotVisitMonitor : CleaningRobotAlgorithm.IRobotVisitMonitor
    {
        protected List<CoOrdinate> _robotVisitList;
        protected RobotHardware.IHardwareRobot _robot;
        protected List<string> _pathLogger;

        public bool IsFrontCellVisited()
        {
            CoOrdinate frontCell = _robot.GetFrontCell();
            return IsCellVisited(frontCell);
        }

        public void AddCurrentPositionToVisitList()
        {
            _robotVisitList.Add(_robot.GetCurrentCell());
        }

        public void AddToRobotPath(string movement)
        {
            _pathLogger.Add(movement);
        }

        private bool IsCellVisited(CoOrdinate inCoOr)
        {
            CoOrdinate findList = _robotVisitList.Find(s => ((s.X == inCoOr.X) && (s.Y == inCoOr.Y)));
            return (findList != null);
        }

        public abstract void PrintRobotPath();

        public string GetPathAt(int inIndex)
        {
            if (_pathLogger.Count > inIndex)
                return _pathLogger[inIndex];

            return string.Empty;
        }
    }
}
