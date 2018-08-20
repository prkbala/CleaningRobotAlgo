using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class SimpleRoom : Room
    {
        public SimpleRoom()
        {
            _obstacles = new List<CoOrdinate>();
            _minCoOrdinate = new CoOrdinate(0, 0);
            _maxCoOrdinate = new CoOrdinate(0, 0);
        }
    }
}
