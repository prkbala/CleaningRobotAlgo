using System;
namespace CleaningRobotAlgorithm
{
    public interface IRobotVisitMonitor
    {
        void AddCurrentPositionToVisitList();
        void AddToRobotPath(string path);
        bool IsFrontCellVisited();
        void PrintRobotPath();
        string GetPathAt(int index);
    }
}
