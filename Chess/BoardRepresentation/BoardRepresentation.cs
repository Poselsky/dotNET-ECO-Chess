using Chess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class BoardRepresentation
    {
        public ChessPiece[,] BoardMatrix { get; private set; } = new ChessPiece[8, 8];

        public King BlackKing { get; private set; }
        public King WhiteKing { get; private set; }

        public BoardRepresentation()
        {
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
            BoardMatrix[0, 0] = new Rook(new Position(0, 0), ChessColor.Black);
            BoardMatrix[0, 1] = new Horse(new Position(0, 1), ChessColor.Black);
            BoardMatrix[0, 2] = new Bishop(new Position(0, 2), ChessColor.Black);
            BoardMatrix[0, 3] = new Queen(new Position(0, 3), ChessColor.Black);

            BoardMatrix[0, 4] = BlackKing;
            BoardMatrix[0, 5] = new Bishop(new Position(0, 5), ChessColor.Black);
            BoardMatrix[0, 6] = new Horse(new Position(0, 6), ChessColor.Black);
            BoardMatrix[0, 7] = new Rook(new Position(0, 7), ChessColor.Black);

            // Army of peasants

            BoardMatrix[1, 0] = new Pawn(new Position(1, 0), ChessColor.Black);
            BoardMatrix[1, 1] = new Pawn(new Position(1, 1), ChessColor.Black);
            BoardMatrix[1, 2] = new Pawn(new Position(1, 2), ChessColor.Black);
            BoardMatrix[1, 3] = new Pawn(new Position(1, 3), ChessColor.Black);
            BoardMatrix[1, 4] = new Pawn(new Position(1, 4), ChessColor.Black);
            BoardMatrix[1, 5] = new Pawn(new Position(1, 5), ChessColor.Black);
            BoardMatrix[1, 6] = new Pawn(new Position(1, 6), ChessColor.Black);
            BoardMatrix[1, 7] = new Pawn(new Position(1, 7), ChessColor.Black);
        }

        private void WhiteInit()
        {
            WhiteKing = new King(new Position(7, 4), ChessColor.White);

            //WHITE
            BoardMatrix[7, 0] = new Rook(new Position(7, 0), ChessColor.White);
            BoardMatrix[7, 1] = new Horse(new Position(7, 1), ChessColor.White);
            BoardMatrix[7, 2] = new Bishop(new Position(7, 2), ChessColor.White);
            BoardMatrix[7, 3] = new Queen(new Position(7, 3), ChessColor.White);

            BoardMatrix[7, 4] = WhiteKing;
            BoardMatrix[7, 5] = new Bishop(new Position(7, 5), ChessColor.White);
            BoardMatrix[7, 6] = new Horse(new Position(7, 6), ChessColor.White);
            BoardMatrix[7, 7] = new Rook(new Position(7, 7), ChessColor.White);

            // Army of peasants

            BoardMatrix[6, 0] = new Pawn(new Position(6, 0), ChessColor.White);
            BoardMatrix[6, 1] = new Pawn(new Position(6, 1), ChessColor.White);
            BoardMatrix[6, 2] = new Pawn(new Position(6, 2), ChessColor.White);
            BoardMatrix[6, 3] = new Pawn(new Position(6, 3), ChessColor.White);
            BoardMatrix[6, 4] = new Pawn(new Position(6, 4), ChessColor.White);
            BoardMatrix[6, 5] = new Pawn(new Position(6, 5), ChessColor.White);
            BoardMatrix[6, 6] = new Pawn(new Position(6, 6), ChessColor.White);
            BoardMatrix[6, 7] = new Pawn(new Position(6, 7), ChessColor.White);
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
