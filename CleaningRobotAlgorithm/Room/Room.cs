using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleaningRobotAlgorithm
{
    public class CoOrdinate
    {
        private int _x;
        private int _y;

        public CoOrdinate()
        {
            _x = 0;
            _y = 0;
        }

        public CoOrdinate(int inX, int inY)
        {
            _x = inX;
            _y = inY;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public static bool IsCoOrdinatesInLine(CoOrdinate first, CoOrdinate second)
        {
            if (first == null)
                return false;

            if (second == null)
                return false;

            return ((first.X - second.X == 0) || (first.Y - second.Y == 0));
        }
    }

    public abstract class Room : Area
    {
        protected List<CoOrdinate> _obstacles;

        virtual public void AddObstacle(CoOrdinate inCoOr)
        {
            CoOrdinate findList = _obstacles.Find(s => ((s.X == inCoOr.X) && (s.Y == inCoOr.Y)));
            if(findList == null)
                _obstacles.Add(inCoOr);
        }
    }
}
