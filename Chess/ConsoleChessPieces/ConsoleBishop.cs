using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
{
    public class ConsoleBishop : IConsoleChessPiece
    {
        public char GetCharPresentation => 'B';
        ChessPiece Bishop;

        public ChessPiece ChessPiece => this.Bishop;

        public ConsoleBishop(ChessPiece Bishop)
        {
            this.Bishop = Bishop;
        }
    }
}
