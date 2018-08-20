using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CleaningRobotAlgorithm;

namespace CleaningRobotTesting
{
    [TestFixture]
    class CircularCleaningAlgorithmTest
    {
        private CoOrdinate _currentRoom;
        RobotHardware.IHardwareRobot _cleaningRobot;
        IRobotVisitMonitor _robotVisitMonitor;
        Room _room;
        AlgorithmEssentials _algorithmEssentials;
        CleaningAlgorithm _cleaningAlgorithm;


        [Test]
        public void CircularCleaningAlgorithmOnSquareShapeTest()
        {
            // Define the min and max co-ordinate for the room
            _currentRoom = new CoOrdinate(3, 3);

            // Create the Robot
            _cleaningRobot = new RobotHardware.Hardware(_currentRoom.X, _currentRoom.Y);

            // Create the required robot visit monitor. Current visit monitor can print the robot path to console
            _robotVisitMonitor = RobotVisitMonitorFactory.CreateRobotVisitMonitor(
                RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput, _cleaningRobot);

            // Create a simple room
            _room = new SimpleRoom();

            // Create the algorithm essentials with the above robot, visit monitor and room.
            _algorithmEssentials = new AlgorithmEssentials(_room, _cleaningRobot, _robotVisitMonitor);

            // Ask the CleaningAlgorithmFactory to create the CleaningAlgorithm instance by passing the required
            // required CleaningAlgorithmType
            _cleaningAlgorithm = CleaningAlgorithmFactory.CreateCleaningAlgorithm(
                CleaningAlgorithmType.CircularCleaningAlgorithm, _algorithmEssentials);

            Assert.AreEqual(CleanStatus.Complete, _cleaningAlgorithm.Clean());

            Assert.AreEqual("Turn Left", _algorithmEssentials.RobotVisitMonitor.GetPathAt(0));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(1));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(2));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(3));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(4));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(5));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(6));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(7));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(8));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(9));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(10));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(11));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(12));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(13));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(14));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(15));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(16));
        }

        [Test]
        public void CircularCleaningAlgorithmOnRectangularShapeTest()
        {
            // Define the min and max co-ordinate for the room
            _currentRoom = new CoOrdinate(1, 5);

            // Create the Robot
            _cleaningRobot = new RobotHardware.Hardware(_currentRoom.X, _currentRoom.Y);

            // Create the required robot visit monitor. Current visit monitor can print the robot path to console
            _robotVisitMonitor = RobotVisitMonitorFactory.CreateRobotVisitMonitor(
                RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput, _cleaningRobot);

            // Create a simple room
            _room = new SimpleRoom();

            // Create the algorithm essentials with the above robot, visit monitor and room.
            _algorithmEssentials = new AlgorithmEssentials(_room, _cleaningRobot, _robotVisitMonitor);

            // Ask the CleaningAlgorithmFactory to create the CleaningAlgorithm instance by passing the required
            // required CleaningAlgorithmType
            _cleaningAlgorithm = CleaningAlgorithmFactory.CreateCleaningAlgorithm(
                CleaningAlgorithmType.CircularCleaningAlgorithm, _algorithmEssentials);

            Assert.AreEqual(CleanStatus.Complete, _cleaningAlgorithm.Clean());

            Assert.AreEqual("Turn Left", _algorithmEssentials.RobotVisitMonitor.GetPathAt(0));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(1));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(2));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(3));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(4));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(5));
            Assert.AreEqual("Move Forward", _algorithmEssentials.RobotVisitMonitor.GetPathAt(6));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(7));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(8));
            Assert.AreEqual("Turn Right", _algorithmEssentials.RobotVisitMonitor.GetPathAt(9));
        }
    }
}
