using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.ChessPieces
{
    public class King : ChessPiece
    {
        public King(Position p, ChessColor b)
                : base(p, b) { }

        public override Position[][] PossibleTurns()
        {
            return new Position[] {Position.ToLeft (Color), Position.ToRight (Color),
                        Position.Forward (Color), Position.Backwards (Color),
                        Position.Forward (Color).ToLeft (Color),
                        Position.Forward (Color).ToRight (Color),
                        Position.Backwards (Color).ToLeft (Color), Position.Backwards (Color).ToRight (Color)
                }.Where(singlePosition => singlePosition.IsOnBoard()).ToArray().Wrap();
        }

        public override string Info()
        {
            return string.Format("kral {0} na pozici {1}", Color, Position);
        }
    }
}
