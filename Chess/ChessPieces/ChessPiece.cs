using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ChessPieces
{
    public abstract class ChessPiece
    {
        public ChessPiece(Position p, ChessColor b)
        {
            if (p.IsOnBoard())
                Position = p;
            else
                throw new Exception("Figurka v autu");

            Color = b;
        }

        public ChessColor Color { get; protected set; }
        public Position Position { get; set; }

        //In this format to specify directions
        public abstract Position[][] PossibleTurns();
        public virtual string Info()
        {
            return string.Format("figurka {0} na pozici {1}", Color, Position);
        }

    }
}
