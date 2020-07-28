using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(Position p, ChessColor b)
                : base(p, b) { }

        public override Position[][] PossibleTurns()
        {
            return new Position[][]
            {
                //Forwards
                Position.RepeatMove((turnPosition) => turnPosition.Forward(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                //Backwards
                Position.RepeatMove((turnPosition) => turnPosition.Backwards(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                //To left
                Position.RepeatMove((turnPosition) => turnPosition.ToLeft(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                //To right
                Position.RepeatMove((turnPosition) => turnPosition.ToRight(Color)).Where(pos => pos.IsOnBoard()).ToArray()
            };
        }
    }
}
