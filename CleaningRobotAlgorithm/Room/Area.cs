using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class Area
    {
        protected CoOrdinate _minCoOrdinate;
        protected CoOrdinate _maxCoOrdinate;

        public CoOrdinate MaxCoOrdinate
        {
            get { return _maxCoOrdinate; }
            set { _maxCoOrdinate = value; }
        }

        public CoOrdinate MinCoOrdinate
        {
            get { return _minCoOrdinate; }
            set { _minCoOrdinate = value; }
        }
    }
}
