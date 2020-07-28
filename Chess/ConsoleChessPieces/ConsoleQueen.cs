using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
{
    public class ConsoleQueen : IConsoleChessPiece
    {
        public char GetCharPresentation => 'Q';
        ChessPiece Queen;

        public ChessPiece ChessPiece => this.Queen;

        public ConsoleQueen(ChessPiece Queen)
        {
            this.Queen = Queen;
        }
    }
}
