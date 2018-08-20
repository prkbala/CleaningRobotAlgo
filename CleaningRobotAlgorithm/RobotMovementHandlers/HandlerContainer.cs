using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    class HandlerContainer
    {
        private IRobotMovementHandler _initialHandler;

        public HandlerContainer(IRobotMovementHandler inInitialHandler)
        {
            _initialHandler = inInitialHandler;
        }

        public bool HandleNextMove()
        {
            if (_initialHandler == null)
                return false;

            return _initialHandler.HandleMovement();
        }
    }
}
