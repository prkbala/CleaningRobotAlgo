using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    enum HandlerContainerType
    {
        CircularCleaningAlgorithm,
        SimpleReturnAlgorithm
    }

    static class HandlerContainerFactory
    {
        public static HandlerContainer CreateHandlerContainer(HandlerContainerType inHandlerType, AlgorithmEssentials inAlgorithmEssentials)
        {
            HandlerContainer handlerManager;

            switch (inHandlerType)
            {
                case HandlerContainerType.CircularCleaningAlgorithm:
                    {
                        ForwardMovementHandler initialHandler = new ForwardMovementHandler(inAlgorithmEssentials);

                        ObstacleHandler firstObstacleHandler = new ObstacleHandler(inAlgorithmEssentials);
                        ObstacleHandler secondObstacleHandler = new ObstacleHandler(inAlgorithmEssentials);
                        ObstacleHandler thirdObstacleHandler = new ObstacleHandler(inAlgorithmEssentials);

                        initialHandler.SetNextMovementHandler(firstObstacleHandler);
                        firstObstacleHandler.SetNextMovementHandler(secondObstacleHandler);
                        secondObstacleHandler.SetNextMovementHandler(thirdObstacleHandler);
                        thirdObstacleHandler.SetNextMovementHandler(null);
                        handlerManager = new HandlerContainer(initialHandler);
                        break;
                    }
                case HandlerContainerType.SimpleReturnAlgorithm:
                    {
                        ForwardMovementHandler returnInitialHandler = new ForwardMovementHandler(inAlgorithmEssentials, true);
                        ObstacleHandler returnFirstObstacleHandler = new ObstacleHandler(inAlgorithmEssentials, true);
                        returnInitialHandler.SetNextMovementHandler(returnFirstObstacleHandler);

                        handlerManager = new HandlerContainer(returnInitialHandler);
                        break;
                    }
                default:
                    handlerManager = null;
                    break;
            }

            return handlerManager;
        }
    }
}
