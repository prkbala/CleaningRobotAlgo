using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    enum ReturnAlgorithmType
    {
        SimpleReturnAlgorithm
    }

    static class ReturnAlgorithmFactory
    {
        public static ReturnAlgorithm CreateReturnAlgorithm(ReturnAlgorithmType inReturnAlgorithm, AlgorithmEssentials inAlgorithmEssentials)
        {
            ReturnAlgorithm returnAlgorithm;

            switch (inReturnAlgorithm)
            {
                case ReturnAlgorithmType.SimpleReturnAlgorithm:
                    {
                        returnAlgorithm = new SimpleReturnAlgorithm(inAlgorithmEssentials,
                            HandlerContainerFactory.CreateHandlerContainer(HandlerContainerType.SimpleReturnAlgorithm, inAlgorithmEssentials));
                        break;
                    }
                default:
                    returnAlgorithm = null;
                    break;
            }

            return returnAlgorithm;
        }
    }
}
