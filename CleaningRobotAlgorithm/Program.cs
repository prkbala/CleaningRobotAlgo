using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the min and max co-ordinate for the room
            CoOrdinate currentRoom = new CoOrdinate(1, 5);

            // Create the Robot
            RobotHardware.IHardwareRobot cleaningRobot = new RobotHardware.Hardware(currentRoom.X, currentRoom.Y);

            // Create the required robot visit monitor. Current visit monitor can print the robot path to console
            IRobotVisitMonitor robotVisitMonitor = RobotVisitMonitorFactory.CreateRobotVisitMonitor(
                RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput, cleaningRobot);

            // Create a simple room
            Room room = new SimpleRoom();

            // Create the algorithm essentials with the above robot, visit monitor and room.
            AlgorithmEssentials algorithmEssentials = new AlgorithmEssentials(room, cleaningRobot, robotVisitMonitor);

            // Ask the CleaningAlgorithmFactory to create the CleaningAlgorithm instance by passing the required
            // required CleaningAlgorithmType
            CleaningAlgorithm cleaningAlgorithm = CleaningAlgorithmFactory.CreateCleaningAlgorithm(
                CleaningAlgorithmType.CircularCleaningAlgorithm, algorithmEssentials);

            // Ask the ReturnAlgorithmFactory to create the ReturnAlgorithm instance by passing the required
            // required ReturnAlgorithmType
            ReturnAlgorithm returnAlgorithm = ReturnAlgorithmFactory.CreateReturnAlgorithm(
                ReturnAlgorithmType.SimpleReturnAlgorithm,  algorithmEssentials);

            // Create a CleaningManager to manage the cleaning and returning process
            CleaningManager manager = new CleaningManager(cleaningAlgorithm, returnAlgorithm);

            bool overallOperationStatus = manager.Clean();

            Console.WriteLine("Cleaning Status : {0}", manager.GetCleanStatus());
            Console.WriteLine("Return Status : {0}", manager.GetReturnStatus());

            robotVisitMonitor.PrintRobotPath();

            Console.ReadKey();
        }
    }
}
