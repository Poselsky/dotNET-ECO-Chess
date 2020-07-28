using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
{
    public class ConsoleHorse : IConsoleChessPiece
    {
        public char GetCharPresentation => 'H';
        ChessPiece Horse;

        public ChessPiece ChessPiece => this.Horse;

        public ConsoleHorse(ChessPiece Horse)
        {
            this.Horse = Horse;
        }
    }
}
