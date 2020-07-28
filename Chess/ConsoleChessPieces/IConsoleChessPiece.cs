using System;
using System.Collections.Generic;
using System.Text;
using Chess.ChessPieces;

namespace Chess.ConsoleChessPieces
{
    public interface IConsoleChessPiece
    {
        char GetCharPresentation { get; }

        //Dependency injection
        ChessPiece ChessPiece { get; }
    }
}
