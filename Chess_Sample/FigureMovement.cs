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

        public List<string> canbeat;

        /*Описує в список рядків, які фігури дана фігура(що знаходиться на currentCell) може побити*/
        public List<string> CanBeat()
        {
            canbeat = new List<string>();
            canbeat.Add($"{currentCell.figure.figureType.ToString()} (Y: {currentCell.figure.startY + 1} X: {currentCell.figure.startX + 1}) can beat: ");
            int counter = 0;
            if (figureCanBeat == null)
                return null;
            for (int i = 0; i < figureCanBeat.Count; i++)
            {
                for (int j = 0; j < figureCanBeat.Count; j++)
                {
                    if(figureCanBeat[i].x == figureCanBeat[j].x && figureCanBeat[i].y == figureCanBeat[j].y && i != j)
                    {
                        figureCanBeat.RemoveAt(j);
                    }
                }
            }
            foreach (var item in figureCanBeat)
            {
                if (item.y >= 0 && item.y <= 7 && item.x >= 0 && item.y <= 7 && ChessBoard.cells[item.y, item.x].figure != null)
                {
                    canbeat.Add("->" + ChessBoard.cells[item.y, item.x].figure.figureType.ToString() + " (Y: " + (ChessBoard.cells[item.y, item.x].figure.startY + 1) + " X: " + (ChessBoard.cells[item.y, item.x].figure.startX + 1) + ")");
                    counter++;
                }
            }
            if(counter == 0)
            {
                canbeat.RemoveAt(0);
                canbeat.Add($"{currentCell.figure.figureType.ToString()} (Y: {currentCell.figure.startY + 1} X: {currentCell.figure.startX + 1}) can not beat any figure");
            }

            return canbeat;
        }

        /*Описує куди може походити дана фігура(що знаходиться на currentCell), залежно від її типу*/
        List<Move> FigureCanMoveHere()
        {
            List<Move> moves = new List<Move>();
            switch (currentCell.figure.figureType)
            {
                case Type.Rook:
                    Line(ref moves);

                    break;
                case Type.Knight:
                    if(currentCell.figure.startY - 2 >= 0 && currentCell.figure.startX - 1 >= 0)
                        moves.Add(new Move(currentCell.figure.startY - 2,currentCell.figure.startX - 1));
                    if (currentCell.figure.startY - 2 >= 0 && currentCell.figure.startX + 1 < 8)
                        moves.Add(new Move(currentCell.figure.startY - 2, currentCell.figure.startX + 1));
                    if (currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX - 2 >= 0)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 2));
                    if (currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX + 2 < 8)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 2));
                    if (currentCell.figure.startY + 1 < 8 && currentCell.figure.startX - 2 >= 0)
                        moves.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX - 2));
                    if (currentCell.figure.startY + 1 < 8 && currentCell.figure.startX + 2 < 8)
                        moves.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX + 2));
                    if (currentCell.figure.startY + 2 < 8 && currentCell.figure.startX - 1 >= 0)
                        moves.Add(new Move(currentCell.figure.startY + 2, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY + 2 < 8 && currentCell.figure.startX + 1 < 8)
                        moves.Add(new Move(currentCell.figure.startY + 2, currentCell.figure.startX + 1));
                    break;
                case Type.Bishop:
                    Diagonal(ref moves);

                    break;
                case Type.Queen:
                    Line(ref moves);
                    Diagonal(ref moves);
                    break;
                case Type.King:
                    if(currentCell.figure.startX >= 1)
                        moves.Add(new Move(currentCell.figure.startY, currentCell.figure.startX - 1));
                    if (currentCell.figure.startX <= 6)
                        moves.Add(new Move(currentCell.figure.startY, currentCell.figure.startX + 1));
                    if(currentCell.figure.startY >= 1)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX));
                    if (currentCell.figure.startY <= 6)
                        moves.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX));
                    if (currentCell.figure.startY >= 1 && currentCell.figure.startX >= 1)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY >= 1 && currentCell.figure.startX <= 6)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 1));
                    if (currentCell.figure.startY <= 6 && currentCell.figure.startX >= 1)
                        moves.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY <= 6 && currentCell.figure.startX <= 6)
                        moves.Add(new Move(currentCell.figure.startY + 1, currentCell.figure.startX + 1));
                    break;
                case Type.Pawn:
                    if(currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX - 1 >= 0)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX - 1));
                    if (currentCell.figure.startY - 1 >= 0 && currentCell.figure.startX + 1 < 8)
                        moves.Add(new Move(currentCell.figure.startY - 1, currentCell.figure.startX + 1));
                    break;
                default:
                    break;
            }
            return moves;
        }

        /*знаходить можливі ходи по прямій (для тури, королеви)*/
        private void Line(ref List<Move> buf)
        {
            for (int x = currentCell.figure.startX; x >= 0; x--)
            {
                foreach (var item in ChessBoard.figuresOnBoard)
                {
                    if (x == item.startX && currentCell.figure.startY == item.startY && x != currentCell.figure.startX)
                    {
                        buf.Add(new Move(currentCell.figure.startY, x));
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
                        buf.Add(new Move(currentCell.figure.startY, x));
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
                        buf.Add(new Move(y, currentCell.figure.startX));
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
                        buf.Add(new Move(y, currentCell.figure.startX));
                        goto St8;
                    }
                }
                if (y != currentCell.figure.startY)
                    buf.Add(new Move(y, currentCell.figure.startX));
            }

        St8:
            return;
        }

        /*знаходить можливі ходи по діагоналям (для слона, королеви)*/
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

        /*додає зображення на місце, куда може походити дана фігура*/
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
                if (figureCanBeat[i].y >= 0 && figureCanBeat[i].y <= 7 && figureCanBeat[i].x >= 0 && figureCanBeat[i].x <= 7)
                {
                    ChessBoard.cells[figureCanBeat[i].y, figureCanBeat[i].x].CanMoveHere(ifCan);
                }
            }
        }

        /*перевіряє чи задані координати належать шахівниці*/
        public bool isAccessable(int y, int x) => y < 8 && y >= 0 && x < 8 && x >= 0;
        /*перевіряє чи є на даній клітинці фігура*/
        public bool isCellEmpty(int y, int x) => ChessBoard.cells[y, x].isEmpty();
    }
}
