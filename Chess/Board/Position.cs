using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public struct Position
    {
        private const string Columns = "ABCDEFGH";
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Position(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }

        public Position ToLeft(ChessColor b)
        {
            return new Position(Row, Column + (b == ChessColor.Black ? -1 : +1));
        }

        public Position ToRight(ChessColor b)
        {
            return new Position(Row, Column + (b == ChessColor.Black ? +1 : -1));
        }

        public Position Forward(ChessColor b)
        {
            return new Position(Row + (b == ChessColor.Black ? +1 : -1), Column);
        }

        public Position Backwards(ChessColor b)
        {
            return new Position(Row + (b == ChessColor.Black ? -1 : +1), Column);
        }

        public bool IsOnBoard()
        {
            return Row >= 0 && Row < 8 && Column >= 0 && Column < 8;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Columns[Column], Row + 1);
        }


        public static bool operator ==(Position a, Position b)
        {
            return a.Row == b.Row && a.Column == b.Column;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }

        //Litter,,,,
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
