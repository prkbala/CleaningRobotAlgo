using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public interface IRobotMovementHandler
    {
        void SetNextMovementHandler(IRobotMovementHandler robotMovementHandler);
        bool HandleMovement();
    }
}
