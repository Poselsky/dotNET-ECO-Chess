using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public static class Extensions
    {
        public static IEnumerable<Position> RepeatMove(this Position StartPosition, Func<Position, Position> ChangePosition)
        {
            //Struct -> pass by value, creates copy
            Position copyPosition = StartPosition;
            while (copyPosition.IsOnBoard())
            {
                Position nextMove = ChangePosition(copyPosition);
                yield return nextMove;
                copyPosition = nextMove;
            }
        }

        public static IEnumerable<Position> RepeatMove(this Position StartPosition, Func<Position, Position> ChangePosition, int HowManyTimes)
        {
            //Struct -> pass by value, creates copy
            Position copyPosition = StartPosition;
            for (int i = 0; i < HowManyTimes; i++)
            {
                if (copyPosition.IsOnBoard())
                {
                    Position nextMove = ChangePosition(copyPosition);
                    yield return nextMove;
                    copyPosition = nextMove;
                }
            }
        }


        public static Position[][] Wrap(this Position[] Positions)
        {
            Position[][] wrapper = new Position[Positions.Length][];

            for (int i = 0; i < Positions.Length; i++)
            {
                wrapper[i] = new Position[] { Positions[i] };
            }

            return wrapper;
        }

    }
}
