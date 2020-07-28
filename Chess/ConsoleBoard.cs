using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chess.ConsoleChessPieces;
using Chess.ChessPieces;

namespace Chess
{
    class ConsoleBoard : ChessBoard
    {
        public ConsoleBoard() : base() 
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void PrettyPrint()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}  ", (i+1));
                Console.ResetColor();
                for (int j = 0; j < 8; j++)
                {
                    if ((j + i) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.Gray;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;

                    IConsoleChessPiece piece = base.BoardMatrix[i, j].ConvertToConsoleChessPiece();
                    if (piece != null)
                    {
                        switch (piece.ChessPiece.Color)
                        {
                            case ChessColor.White:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case ChessColor.Black:
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                        }
                        Console.Write(piece != null ? piece.GetCharPresentation : ' ');

                    }
                    else
                    {

                        Console.Write(' ');
                    }
                    Console.Write(' ');
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            string ag = "ABCDEFGH";
            Console.Write("\n   ");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int j = 0; j < 8; j++)
            {
                Console.Write("{0} ", ag[j]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        protected override void OnCheck(King King, ChessPiece PieceWhichTriggersCheck)
        {
            Console.WriteLine("Watch out for check");
            Console.WriteLine(PieceWhichTriggersCheck.Position);
        }

        protected override void OnDrop(ChessPiece SelectedPiece)
        {
        }

        protected override void OnError(ChessPiece SelectedPiece, string message)
        {
            Console.WriteLine("{0}: {1}", SelectedPiece, message);
        }

        protected override void OnMoving(ChessPiece SelectedPiece, Position MoveTo)
        {
        }

        protected override void OnPick(ChessPiece SelectedPiece)
        {
            Console.WriteLine("Picked {0} {1}", SelectedPiece.Color, SelectedPiece.GetType());
        }

        protected override void OnPlayersToggled()
        {
        }

        protected override void GameStart()
        {
            //throw new NotImplementedException();
        }

        protected override void GameFrame()
        {
            PrettyPrint();
        }

        protected override void Win(ChessColor Player)
        {
            Console.WriteLine("{0} Player Won!", Player);
        }

        protected override Tuple<Position, Position> Move()
        {
            Console.WriteLine("What's your move? ColumnRow - ColumnRow");

            try
            {
                var input = Console.ReadLine();
                if (input.Length == 5)
                {
                    var splitInput = input.Split('-');
                    //Parse Input
                    var firstRow = ChessBoard.Rows.IndexOf(splitInput[0][1].ToString().ToUpper());
                    var firstColumn = ChessBoard.Columns.IndexOf(splitInput[0][0].ToString().ToUpper());
                    var secondRow = ChessBoard.Rows.IndexOf(splitInput[1][1].ToString().ToUpper());
                    var secondColumn = ChessBoard.Columns.IndexOf(splitInput[1][0].ToString().ToUpper());

                    return new Tuple<Position, Position>
                        (
                            new Position(firstRow, firstColumn), 
                            new Position(secondRow, secondColumn)
                        );

                } else
                {
                    var firstColumn = ChessBoard.Columns.IndexOf(input[0].ToString().ToUpper());
                    var firstRow = ChessBoard.Rows.IndexOf(input[1].ToString().ToUpper());

                    var piece = base[firstRow, firstColumn];

                    if (piece != null)
                    {
                        var turns = base.PossibleMovesWithCollission(piece);
                        Console.Write("Possible turns: ");

                        foreach(var turn in turns)
                        {
                            Console.Write("{0}, ", turn);
                        }

                        Console.Write('\n');

                    }

                    //Recursion
                    return Move();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SeparateInputWith    '-' ");
                //Recursion
                return Move();
            }
        }


        public new IConsoleChessPiece this[int Row, int Column]
        {
            get => base[Row, Column].ConvertToConsoleChessPiece();
        }

        public new IConsoleChessPiece this[Position DesiredPosition]
        {
            get => this[DesiredPosition.Row, DesiredPosition.Column];
        }
    }
}
