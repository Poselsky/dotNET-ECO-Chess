using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChess
{
    public static class ConsoleChessPieceExtensions
    {
        private static Dictionary<Type, Func<ChessPiece, IConsoleChessPiece>> Converter = new Dictionary<Type, Func<ChessPiece, IConsoleChessPiece>>()
        {
            { typeof(Pawn), (chessPiece) => new ConsolePawn(chessPiece) },
            { typeof(King), (chessPiece) => new ConsoleKing(chessPiece) },
            { typeof(Queen), (chessPiece) => new ConsoleQueen(chessPiece) },
            { typeof(Bishop), (chessPiece) => new ConsoleBishop(chessPiece) },
            { typeof(Horse), (chessPiece) => new ConsoleHorse(chessPiece) },
            { typeof(Rook), (chessPiece) => new ConsoleRook(chessPiece) },
        };

        public static IConsoleChessPiece ConvertToConsoleChessPiece(this ChessPiece chessPiece)
        {
            return chessPiece != null ? Converter[chessPiece.GetType()](chessPiece) : null;
        }
    }
}
