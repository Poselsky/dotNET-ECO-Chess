using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess
{
    class ConsoleKing : IConsoleChessPiece
    {
        public char GetCharPresentation => 'K';
        ChessPiece King;

        public ChessPiece ChessPiece => this.King;

        public ConsoleKing(ChessPiece King)
        {
            this.King = King;
        }

    }
}
