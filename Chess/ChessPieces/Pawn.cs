using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public new Position Position
        {
            get => base.Position;
            set
            {
                base.Position = value;
                HasMoved = true;
            }
        }
        private bool HasMoved { get; set; } = false;

        public Pawn(Position p, ChessColor b)
                : base(p, b) { }

        public override Position[][] PossibleTurns()
        {
            Position[] MoveTwice = HasMoved ? new Position[] { Position.Forward(Color) } : Position.RepeatMove((pos) => pos.Forward(Color), 2).ToArray();

            return MoveTwice
            .Where(singlePosition => singlePosition.IsOnBoard())
            .ToArray()
            .Wrap();
        }

        public override string Info()
        {
            return string.Format("pesak {0} na pozici {1}", Color, Position);
        }
    }
}
