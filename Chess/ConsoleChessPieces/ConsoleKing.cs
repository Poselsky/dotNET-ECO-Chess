using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
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
