using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
{
    public class ConsoleRook : IConsoleChessPiece
    {
        public char GetCharPresentation => 'R';
        ChessPiece Rook;

        public ChessPiece ChessPiece => this.Rook;

        public ConsoleRook(ChessPiece Rook)
        {
            this.Rook = Rook;
        }
    }
}
