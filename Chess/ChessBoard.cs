using Chess.ChessPieces;
using Chess.ConsoleChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public abstract class ChessBoard
    {
        public readonly static string Columns = "ABCDEFGH";
        public readonly static string Rows = "12345678";

        protected BoardRepresentation BoardMatrix { get; private set; }

        //White starts
        public ChessColor CurrentPlayer { get; private set; } = ChessColor.White;


        public ChessBoard()
        {
            BoardMatrix = new BoardRepresentation();
        }

        protected abstract void GameStart();
        protected abstract void GameFrame();
        protected abstract void Win(ChessColor Player);

        protected abstract Tuple<Position, Position> Move();

        protected abstract void OnError(ChessPiece SelectedPiece, string message);
        protected abstract void OnPick(ChessPiece SelectedPiece);
        protected abstract void OnMoving(ChessPiece SelectedPiece, Position MoveTo);
        protected abstract void OnDrop(ChessPiece SelectedPiece);
        protected abstract void OnCheck(King King, ChessPiece PieceWhichTriggersCheck);
        protected abstract void OnPlayersToggled();

        public void PlayGame()
        {
            GameStart();
            //Here should be condition for ending the game
            while (true)
            {
                GameFrame();

                Tuple<Position, Position> move;
                do
                {
                    move = Move();

                }
                while (!PossibleMove(move.Item1, move.Item2));

            }
                    
            Win(CurrentPlayer);
        }

        public bool PossibleMove(Position SelectedPiece, Position PositionToMove)
        {
            ChessPiece currentPiece = BoardMatrix[SelectedPiece.Row, SelectedPiece.Column];

            OnPick(currentPiece);

            int row = PositionToMove.Row;
            int column = PositionToMove.Column;

            //If piece is not blank space
            if (currentPiece == null)
            {
                OnError(null, "Select a piece");
                return false;
                // If piece belongs to player
            }
            else if (!DoesPieceBelongToPlayer(currentPiece))
            {
                OnError(currentPiece, "Piece doesn't belong to this player");
                return false;
            }
            else
            {
                // TODO: Collision
                Position[] possibleMoves = PossibleMovesWithCollission(currentPiece);

                if (possibleMoves.Any(move => move.Row == row && move.Column == column))
                {
                    BoardMatrix.UpdateBoard(currentPiece, currentPiece.Position, PositionToMove, OnMoving, OnDrop);

                    TogglePlayers();
                    OnPlayersToggled();

                    ChessPiece DetectsKing;
                    switch (CurrentPlayer)
                    {
                        case ChessColor.White:
                            DetectsKing = CheckDetection(BoardMatrix.WhiteKing);
                            break;
                        default:
                            DetectsKing = CheckDetection(BoardMatrix.BlackKing);
                            break;
                    }

                    if (DetectsKing != null && DetectsKing.Color == CurrentPlayer) 
                    {
                        BoardMatrix.UpdateBoard(currentPiece, currentPiece.Position, SelectedPiece, OnMoving, OnDrop);
                        return false;
                    };

                    return true;
                }
                else
                {
                    OnError(currentPiece, "You can't move there");
                    return false;
                }
            }
        }

        protected Position[] PossibleMovesWithCollission(ChessPiece Piece)
        {
            switch (Piece)
            {
                case Pawn _:
                    return AddCollisionPawn(Piece);
                case Horse _:
                    return AddCollisionHorse(Piece);
                default:
                    return AddCollisionRookBishopQueenKing(Piece);
            }
        }

        private bool DoesPieceBelongToPlayer(ChessPiece piece)
        {
            return piece.Color == CurrentPlayer;
        }

        private void TogglePlayers()
        {
            switch (CurrentPlayer)
            {
                case ChessColor.Black:
                    CurrentPlayer = ChessColor.White;
                    break;
                case ChessColor.White:
                    CurrentPlayer = ChessColor.Black;
                    break;
            }
        }

        //Collisions for these pieces are same
        private Position[] AddCollisionRookBishopQueenKing(ChessPiece CurrentPiece)
        {
            Position[][] allTurns = CurrentPiece.PossibleTurns();
            List<Position> Builder = new List<Position>();

            foreach (Position[] Direction in allTurns)
            {
                foreach (Position singlePosition in Direction)
                {
                    ChessPiece chessPiece = this[singlePosition];
                    if (chessPiece != null)
                    {
                        //Check if piece belongs to player or not
                        if (chessPiece.Color == CurrentPiece.Color)
                        {
                            break;
                        }
                        else
                        {
                            //Enemy
                            Builder.Add(singlePosition);
                            break;
                        }
                    }
                    else
                    {
                        //Empty space
                        Builder.Add(singlePosition);
                    }
                }
            }
            return Builder.ToArray();
        }

        private Position[] AddCollisionHorse(ChessPiece CurrentPiece)
        {
            Position[] allTurns = CurrentPiece.PossibleTurns().SelectMany(x => x).ToArray();
            List<Position> Builder = new List<Position>();

            foreach (Position position in allTurns)
            {
                ChessPiece chessPiece = this[position];
                if (chessPiece != null)
                {
                    //Enemy
                    if (chessPiece.Color != CurrentPiece.Color)
                    {
                        Builder.Add(position);
                    }

                }
                else
                {
                    //Empty space
                    Builder.Add(position);
                }
            }

            return Builder.ToArray();
        }
        private Position[] AddCollisionPawn(ChessPiece CurrentPiece)
        {
            Position[] allTurns = CurrentPiece.PossibleTurns().SelectMany(x => x).ToArray();
            List<Position> Builder = new List<Position>();

            if (allTurns.Length == 0)
            {
                // Change to any piece except pawn and king
            }
            else
            {
                //Check forward, left forward, right forward

                foreach(Position forwardDirection in allTurns)
                {
                    if (this[forwardDirection] == null)
                        Builder.Add(forwardDirection);
                    else
                        break;
                }

                Position forward = allTurns[0];


                //If there're pieces right or left corners, take them.
                Position ForwardLeft = forward.ToLeft(CurrentPiece.Color);
                if (ForwardLeft.IsOnBoard())
                {
                    ChessPiece PieceForwardLeft = this[ForwardLeft];
                    if (PieceForwardLeft != null && PieceForwardLeft.Color != CurrentPiece.Color)
                    {
                        Builder.Add(ForwardLeft);
                    }
                }

                Position ForwardRight = forward.ToRight(CurrentPiece.Color);
                if (ForwardRight.IsOnBoard())
                {
                    ChessPiece PieceForwardRight = this[ForwardRight];
                    if (PieceForwardRight != null && PieceForwardRight.Color != CurrentPiece.Color)
                    {
                        Builder.Add(ForwardRight);
                    }
                }
            }
            return Builder.ToArray();
        }

        private ChessPiece CheckDetection(King king)
        {
            //Checking from other perspective - If king can't see pieces , pieces can't see king -> Big Brain
           
            List<Tuple<Type,Position[]>> universalPieceTurn = new List<Tuple<Type, Position[]>>()
            {
                new Tuple<Type,Position[]>(typeof(Rook),PossibleMovesWithCollission(new Rook(king.Position, king.Color))),
                new Tuple<Type,Position[]>(typeof(Queen),PossibleMovesWithCollission(new Queen(king.Position, king.Color))),
                new Tuple<Type,Position[]>(typeof(Bishop),PossibleMovesWithCollission(new Bishop(king.Position, king.Color))),
                new Tuple<Type,Position[]>(typeof(King),PossibleMovesWithCollission(new King(king.Position, king.Color))),
                new Tuple<Type,Position[]>(typeof(Horse),PossibleMovesWithCollission(new Horse(king.Position, king.Color))),
                new Tuple<Type,Position[]>(typeof(Pawn),PossibleMovesWithCollission(new Pawn(king.Position, king.Color))),
            };

            foreach (Tuple<Type, Position[]> possibleTurnsOfPiece in universalPieceTurn)
                foreach (Position pos in possibleTurnsOfPiece.Item2)
                {
                    ChessPiece pieceOnPos = this[pos];
                    if (pieceOnPos != null && pieceOnPos.GetType() == possibleTurnsOfPiece.Item1 && pieceOnPos.Color != king.Color)
                    {
                        //Found the piece which triggers check
                        OnCheck(king, pieceOnPos);
                        return pieceOnPos;
                    }
                }
            //Found nothing
            return null;
        }

        public ChessPiece this[int Row, int Column]
        {
            get => BoardMatrix[Row, Column];
        }

        public ChessPiece this[Position DesiredPosition]
        {
            get => BoardMatrix[DesiredPosition.Row, DesiredPosition.Column];
        }
    }
}
