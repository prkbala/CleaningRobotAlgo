using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public enum CleaningAlgorithmType
    {
        CircularCleaningAlgorithm
    }

    public static class CleaningAlgorithmFactory
    {
        public static CleaningAlgorithm CreateCleaningAlgorithm(CleaningAlgorithmType inAlgorithmType, AlgorithmEssentials inAlgorithmEssentials)
        {
            CleaningAlgorithm cleaningAlgorithm;

            switch (inAlgorithmType)
            {
                case CleaningAlgorithmType.CircularCleaningAlgorithm:
                    {
                        cleaningAlgorithm = new CircularCleaningAlgorithm(inAlgorithmEssentials,
                            HandlerContainerFactory.CreateHandlerContainer(HandlerContainerType.CircularCleaningAlgorithm, inAlgorithmEssentials));
                        break;
                    }
                default:
                    cleaningAlgorithm = null;
                    break;
            }

            return cleaningAlgorithm;
        }
    }
}
