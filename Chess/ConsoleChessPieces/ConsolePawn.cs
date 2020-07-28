using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.ConsoleChessPieces
{
    public class ConsolePawn : IConsoleChessPiece
    {
        public char GetCharPresentation => 'P';
        ChessPiece Pawn;

        public ChessPiece ChessPiece => this.Pawn;

        public ConsolePawn(ChessPiece Pawn)
        {
            this.Pawn = Pawn;
        }
    }
}
