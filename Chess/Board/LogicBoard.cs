using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public sealed class LogicBoard
    {
        public ChessPiece[,] BoardMatrix { get; private set; }

        public King BlackKing { get; private set; }
        public King WhiteKing { get; private set; }

        public LogicBoard()
        {
            BoardMatrix = new ChessPiece[8, 8];
            Init();
        }

        public void UpdateBoard(ChessPiece Picked, Position From, Position To)
        {
            ChessPiece temp = Picked;
            temp.Position = To;
            this[From] = null;
            this[To] = temp;
        }

        public void UpdateBoard(ChessPiece Picked, Position From, Position To, Action<ChessPiece, Position> OnMoving)
        {
            ChessPiece temp = Picked;
            temp.Position = To;
            this[From] = null;
            OnMoving(temp, To);
            this[To] = temp;
        }
        public void UpdateBoard(ChessPiece Picked, Position From, Position To, Action<ChessPiece, Position> OnMoving, Action<ChessPiece> OnDrop)
        {
            ChessPiece temp = Picked;
            temp.Position = To;
            this[From] = null;
            OnMoving(temp, To);
            this[To] = temp;
            OnDrop(temp);
        }

        private void AddToBoard(ChessPiece Piece)
        {
            if (Piece.Position == null)
                throw new ArgumentException("Position of piece is not specified");
            BoardMatrix[Piece.Position.Row, Piece.Position.Column] = Piece;
        }


        private void Init()
        {
            //BlackInit();
            //WhiteInit();

            TestCheckInit();
        }


        private void BlackInit()
        {
            BlackKing = new King(new Position(0, 4), ChessColor.Black);

            //BLACK
            AddToBoard(new Rook(new Position(0, 0), ChessColor.Black));
            AddToBoard(new Horse(new Position(0, 1), ChessColor.Black));
            AddToBoard(new Bishop(new Position(0, 2), ChessColor.Black));
            AddToBoard(new Queen(new Position(0, 3), ChessColor.Black));
            AddToBoard(BlackKing);
            AddToBoard(new Bishop(new Position(0, 5), ChessColor.Black));
            AddToBoard(new Horse(new Position(0, 6), ChessColor.Black));
            AddToBoard(new Rook(new Position(0, 7), ChessColor.Black));

            // Army of peasants

            AddToBoard(new Pawn(new Position(1, 0), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 1), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 2), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 3), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 4), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 5), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 6), ChessColor.Black));
            AddToBoard(new Pawn(new Position(1, 7), ChessColor.Black));
        }

        private void WhiteInit()
        {
            WhiteKing = new King(new Position(7, 4), ChessColor.White);

            //WHITE
            AddToBoard(new Rook(new Position(7, 0), ChessColor.White));
            AddToBoard(new Horse(new Position(7, 1), ChessColor.White));
            AddToBoard(new Bishop(new Position(7, 2), ChessColor.White));
            AddToBoard(new Queen(new Position(7, 3), ChessColor.White));

            AddToBoard(WhiteKing);
            AddToBoard(new Bishop(new Position(7, 5), ChessColor.White));
            AddToBoard(new Horse(new Position(7, 6), ChessColor.White));
            AddToBoard(new Rook(new Position(7, 7), ChessColor.White));

            // Army of peasants

            AddToBoard(new Pawn(new Position(6, 0), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 1), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 2), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 3), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 4), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 5), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 6), ChessColor.White));
            AddToBoard(new Pawn(new Position(6, 7), ChessColor.White));
        }

        private void TestCheckInit()
        {
            BlackKing = new King(new Position(0, 4), ChessColor.Black);
            WhiteKing = new King(new Position(7, 4), ChessColor.White);

            BoardMatrix[0, 4] = BlackKing;
            BoardMatrix[7, 4] = WhiteKing;
            BoardMatrix[2, 3] = new Pawn(new Position(2, 3), ChessColor.White);
            BoardMatrix[1, 4] = new Pawn(new Position(1, 4), ChessColor.Black);
        }

        public ChessPiece this[int row, int column]
        {
            get => BoardMatrix[row, column];
            private set
            {
                BoardMatrix[row, column] = value;
            }
        }

        public ChessPiece this[Position position]
        {
            get => BoardMatrix[position.Row, position.Column];
            private set
            {
                BoardMatrix[position.Row, position.Column] = value;
            }
        }

    }
}
