using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Sample
{
    public struct Move
    {
        public int y, x;
        public Move(int y, int x)
        {
            this.y = y;
            this.x = x;
        }
    }

    public class FigureMovement
    {
        Cell currentCell;
        public List<Move> figureCanBeat;

        public FigureMovement(Cell cell)
        {
            currentCell = cell;
            figureCanBeat = FigureCanMoveHere();
        }

        List<Move> FigureCanMoveHere()
        {
            List<Move> buf = new List<Move>();
            switch (currentCell.figure.figureType)
            {
                case Type.Rook:
                    Line(ref buf);

                    break;
                case Type.Knight:
                    if(currentCell.figure.startY - 2 > 0 || currentCell.figure.startX - 1 > 0)
                        buf.Add(new Move(currentCell.figure.startY - 2,currentCell.figure.startX - 1));
                    if (currentCell.figure.startY - 2 > 0 && currentCell.figure.startX + 1 < 8)
                        buf.Add(new Move(currentCell.figure.startY - 2, currentCell.figure.startX + 1));
                    if (currentCell.figure.startY - 1 > 0 && currentCell.figure.startX - 2 > 0)
                        buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 2));
                    if (currentCell.figure.startY - 1 > 0 && currentCell.figure.startX + 2 < 8)
                        buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 2));
                    if (currentCell.figure.startY + 1 < 8 && currentCell.figure.startX - 2 > 0)
                        buf.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX - 2));
                    if (currentCell.figure.startY + 1 < 8 && currentCell.figure.startX + 2 < 8)
                        buf.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX + 2));
                    if (currentCell.figure.startY + 2 < 8 && currentCell.figure.startX - 1 > 0)
                        buf.Add(new Move(currentCell.figure.startY + 2, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY + 2 < 8 && currentCell.figure.startX + 1 < 8)
                        buf.Add(new Move(currentCell.figure.startY + 2, currentCell.figure.startX + 1));
                    break;
                case Type.Bishop:
                    Diagonal(ref buf);

                    break;
                case Type.Queen:
                    Line(ref buf);
                    Diagonal(ref buf);
                    break;
                case Type.King:
                    buf.Add(new Move(currentCell.figure.startY, currentCell.figure.startX - 1));
                    buf.Add(new Move(currentCell.figure.startY, currentCell.figure.startX + 1));
                    buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX));
                    buf.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX));
                    buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 1));
                    buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 1));
                    buf.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX - 1));
                    buf.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX + 1));
                    break;
                case Type.Pawn:
                    if(currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX - 1 >= 0)
                        buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX + 1 < 8)
                        buf.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 1));
                    break;
                default:
                    break;
            }
            return buf;
        }

        private void Line(ref List<Move> buf)
        {
            for (int x = currentCell.figure.startX; x >= 0; x--)
            {
                foreach (var item in ChessBoard.figuresOnBoard)
                {
                    if (x == item.startX && currentCell.figure.startY == item.startY && x != currentCell.figure.startX)
                    {
                        buf.Add(new Move(currentCell.figure.startY, x)); //
                        goto St5;
                    }
                }
                if (x != currentCell.figure.startX)
                    buf.Add(new Move(currentCell.figure.startY, x));
            }

        St5:

            for (int x = currentCell.figure.startX; x < 8; x++)
            {
                foreach (var item in ChessBoard.figuresOnBoard)
                {
                    if (x == item.startX && currentCell.figure.startY == item.startY && x != currentCell.figure.startX)
                    {
                        buf.Add(new Move(currentCell.figure.startY, x)); //
                        goto St6;
                    }
                }
                if (x != currentCell.figure.startX)
                    buf.Add(new Move(currentCell.figure.startY, x));
            }

        St6:

            for (int y = currentCell.figure.startY; y >= 0; y--)
            {
                foreach (var item in ChessBoard.figuresOnBoard)
                {
                    if (y == item.startY && currentCell.figure.startX == item.startX && y != currentCell.figure.startY)
                    {
                        buf.Add(new Move(y, currentCell.figure.startX)); //
                        goto St7;
                    }
                }
                if (y != currentCell.figure.startY)
                    buf.Add(new Move(y, currentCell.figure.startX));
            }

        St7:

            for (int y = currentCell.figure.startY; y < 8; y++)
            {
                foreach (var item in ChessBoard.figuresOnBoard)
                {
                    if (y == item.startY && currentCell.figure.startX == item.startX && y != currentCell.figure.startY)
                    {
                        buf.Add(new Move(y, currentCell.figure.startX)); //
                        goto St8;
                    }
                }
                if (y != currentCell.figure.startY)
                    buf.Add(new Move(y, currentCell.figure.startX));
            }

        St8:
            return;
        }

        private void Diagonal(ref List<Move> buf)
        {
            List<Figure> tmp = new List<Figure>();
            for (int y = currentCell.figure.startY + 1; y < 8; y++)
            {
                for (int x = 0; x < currentCell.figure.startX; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        foreach (var item in ChessBoard.figuresOnBoard)
                        {
                            if (y == item.startY && x == item.startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                            {
                                buf.Add(new Move(y, x));
                                goto St9;
                            }
                        }
                        buf.Add(new Move(y, x));
                    }
                }
            }

        St9:

            for (int y = currentCell.figure.startY + 1; y < 8; y++)
            {
                for (int x = currentCell.figure.startX + 1; x < 8; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        foreach (var item in ChessBoard.figuresOnBoard)
                        {
                            if (y == item.startY && x == item.startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                            {
                                buf.Add(new Move(y, x));
                                goto St10;
                            }
                        }
                        buf.Add(new Move(y, x));
                    }
                }
            }

        St10:

            tmp = new List<Figure>();
            for (int y = 0; y < currentCell.figure.startY; y++)
            {
                for (int x = currentCell.figure.startX + 1; x < 8; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        foreach (var item in ChessBoard.figuresOnBoard)
                        {
                            if (y == item.startY && x == item.startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                            {
                                tmp.Add(item);
                            }
                        }
                    }
                }
            }

            tmp = tmp.OrderBy(item => item.startX).ToList();


            for (int y = currentCell.figure.startY + 1; y >= 0; y--)
            {
                for (int x = currentCell.figure.startX + 1; x < 8; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        if (tmp.Count != 0 && y == tmp[0].startY && x == tmp[0].startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                        {
                            buf.Add(new Move(y, x));
                            goto St11;
                        }
                        buf.Add(new Move(y, x));
                    }
                }
            }

        St11:

            tmp = new List<Figure>();
            for (int y = 0; y < currentCell.figure.startY; y++)
            {
                for (int x = 0; x < currentCell.figure.startX; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        foreach (var item in ChessBoard.figuresOnBoard)
                        {
                            if (y == item.startY && x == item.startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                            {
                                tmp.Add(item);
                            }
                        }
                    }
                }
            }


            tmp = tmp.OrderByDescending(item => item.startX).ToList();

            for (int y = currentCell.figure.startY + 1; y >= 0; y--)
            {
                for (int x = 0; x < currentCell.figure.startX; x++)
                {
                    if (currentCell.figure.startY != y && currentCell.figure.startX != x && Math.Pow(currentCell.figure.startY - y, 2) == Math.Pow(currentCell.figure.startX - x, 2))
                    {
                        if (tmp.Count != 0 && y == tmp[0].startY && x == tmp[0].startX && y != currentCell.figure.startY && x != currentCell.figure.startX)
                        {
                            buf.Add(new Move(y, x));
                            goto St12;
                        }
                        buf.Add(new Move(y, x));
                    }
                }
            }

        St12:
            return;
        }

        public void ShowMove(bool ifCan)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessBoard.cells[i, j].ClearCanMove();
                }
            }
            for (int i = 0; i < figureCanBeat.Count; i++)
            {
                ChessBoard.cells[figureCanBeat[i].y, figureCanBeat[i].x].CanMoveHere(ifCan);
            }
        }

        //Move? Destination(int y, int x)
        //{
        //    int Y = currentCell.location.y + y;
        //    int X = currentCell.location.x + x;
        //    move++;

        //    if (isAccessAble(y, x))
        //    {
        //        if (!ChessBoard.cells[y, x].isEmpty())
        //        {
        //            return new Move(Y, X);
        //        }
        //        return previousMove = new Move(Y, X);
        //    }
        //    else return previousMove = null;
        //}

        public bool isAccessAble(int y, int x) => y < 8 && y >= 0 && x < 8 && x >= 0;
        public bool isCellEmpty(int y, int x) => ChessBoard.cells[y, x].isEmpty();
    }
}
