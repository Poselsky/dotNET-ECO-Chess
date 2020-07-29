using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessPieces;

namespace ConsoleChess
{
    public interface IConsoleChessPiece
    {
        char GetCharPresentation { get; }

        //Dependency injection
        ChessPiece ChessPiece { get; }
    }
}
