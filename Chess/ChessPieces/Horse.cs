using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.ChessPieces
{
    public class Horse : ChessPiece
    {
        public Horse(Position p, ChessColor b)
                : base(p, b) { }

        public override Position[][] PossibleTurns()
        {
            Position DoubleForwards = Position.RepeatMove((oneTurn) => oneTurn.Forward(Color), 2).Last();
            Position DoubleRight = Position.RepeatMove((oneTurn) => oneTurn.ToRight(Color), 2).Last();
            Position DoubleBackwards = Position.RepeatMove((oneTurn) => oneTurn.Backwards(Color), 2).Last();
            Position DoubleLeft = Position.RepeatMove((oneTurn) => oneTurn.ToLeft(Color), 2).Last();

            return new Position[]
            {
                DoubleForwards.ToLeft(Color),
                DoubleForwards.ToRight(Color),
                DoubleRight.Forward(Color),
                DoubleRight.Backwards(Color),
                DoubleBackwards.ToRight(Color),
                DoubleBackwards.ToLeft(Color),
                DoubleLeft.Forward(Color),
                DoubleLeft.Backwards(Color),
            }.Where(singlePosition => singlePosition.IsOnBoard()).ToArray().Wrap();
        }
    }
}
