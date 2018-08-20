using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CleaningRobotAlgorithm;

namespace CleaningRobotTesting
{
    [TestFixture]
    class ObstacleHandlerTest
    {
        private ObstacleHandler _firstObstacleHandler;
        private ObstacleHandler _secondObstacleHandler;
        private ObstacleHandler _thirdObstacleHandler;

        private ObstacleHandler _obstacleHandlerWithCellRevisit;
        AlgorithmEssentials _algorithmEssentials;

        [SetUp]
        public void InitHandlers()
        {
            CoOrdinate currentRoom = new CoOrdinate(3, 3);
            RobotHardware.IHardwareRobot cleaningRobot = new RobotHardware.Hardware(currentRoom.X, currentRoom.Y);
            IRobotVisitMonitor robotVisitMonitor = RobotVisitMonitorFactory.CreateRobotVisitMonitor(
                RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput, cleaningRobot);
            Room room = new SimpleRoom();

            _algorithmEssentials = new AlgorithmEssentials(room, cleaningRobot, robotVisitMonitor);

            _firstObstacleHandler = new ObstacleHandler(_algorithmEssentials);
            _obstacleHandlerWithCellRevisit = new ObstacleHandler(_algorithmEssentials, true);
        }

        [Test]
        public void ObstacleHandlerWithoutCellRevisit()
        {
            //Move 3 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 2 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 2 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 1 cell forward to reach the visited cell
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 1 cell forward to reach the center cell
            RobotUtility.MoveForward(_algorithmEssentials);

            _secondObstacleHandler = new ObstacleHandler(_algorithmEssentials);
            _thirdObstacleHandler = new ObstacleHandler(_algorithmEssentials);
            _firstObstacleHandler.SetNextMovementHandler(_secondObstacleHandler);
            _secondObstacleHandler.SetNextMovementHandler(_thirdObstacleHandler);

            //all the three obstacle handlers will fail to handle the case
            Assert.False(_firstObstacleHandler.HandleMovement());
        }

        [Test]
        public void ForwardMovementHandlerWithCellRevisit()
        {
            //Move 3 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 2 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 2 cells forward to reach the corner
            RobotUtility.MoveForward(_algorithmEssentials);
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 1 cell forward to reach the visited cell
            RobotUtility.MoveForward(_algorithmEssentials);

            // now ask the obstacle handler to handle it
            Assert.True(_firstObstacleHandler.HandleMovement());

            //Move 1 cell forward to reach the center cell
            RobotUtility.MoveForward(_algorithmEssentials);

            //when cell revisit is enabled the obstacle handler can handle
            Assert.True(_obstacleHandlerWithCellRevisit.HandleMovement());
        }

    }
}
