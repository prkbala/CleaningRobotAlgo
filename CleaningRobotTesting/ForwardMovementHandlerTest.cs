using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CleaningRobotAlgorithm;

namespace CleaningRobotTesting
{
    [TestFixture]
    class ForwardMovementHandlerTest
    {
        private ForwardMovementHandler _forwardMovementHandler;
        private ForwardMovementHandler _forwardMovementHandlerWithCellRevisit;
        private AlgorithmEssentials _algorithmEssentials;

        [SetUp]
        public void InitHandlers()
        {
            CoOrdinate currentRoom = new CoOrdinate(4, 4);

            RobotHardware.IHardwareRobot cleaningRobot = new RobotHardware.Hardware(currentRoom.X, currentRoom.Y);

            IRobotVisitMonitor robotVisitMonitor = RobotVisitMonitorFactory.CreateRobotVisitMonitor(
                RobotVisitMonitorType.RobotVisitMonitorWithConsoleOutput, cleaningRobot);

            Room room = new SimpleRoom();

            _algorithmEssentials = new AlgorithmEssentials(room, cleaningRobot, robotVisitMonitor);

            _forwardMovementHandler = new ForwardMovementHandler(_algorithmEssentials);
            _forwardMovementHandlerWithCellRevisit = new ForwardMovementHandler(_algorithmEssentials, true);
        }

        [Test]
        public void ForwardMovementHandlerWithoutCellRevisit()
        {
            //Move 3 cells forward
            bool isHandled = false;
            isHandled = _forwardMovementHandler.HandleMovement();
            isHandled = _forwardMovementHandler.HandleMovement();
            isHandled = _forwardMovementHandler.HandleMovement();

            //turn to face the visited cell
            RobotUtility.TurnLeft(_algorithmEssentials);
            RobotUtility.TurnLeft(_algorithmEssentials);

            //Robot shouldn't be able to move forward
            Assert.AreEqual(false, _forwardMovementHandler.HandleMovement());
        }

        [Test]
        public void ForwardMovementHandlerWithCellRevisit()
        {
            //Move 3 cells forward
            bool isHandled = false;
            isHandled = _forwardMovementHandlerWithCellRevisit.HandleMovement();
            isHandled = _forwardMovementHandlerWithCellRevisit.HandleMovement();
            isHandled = _forwardMovementHandlerWithCellRevisit.HandleMovement();

            //turn to face the visited cell
            RobotUtility.TurnLeft(_algorithmEssentials);
            RobotUtility.TurnLeft(_algorithmEssentials);

            //Robot should be able to move forward
            Assert.AreEqual(true, _forwardMovementHandlerWithCellRevisit.HandleMovement());
        }
    }
}
