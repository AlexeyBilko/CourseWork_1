using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Sample
{
    public class ChessBoard
    {
        public static List<Figure> figuresOnBoard;
        public static Cell[,] cells = new Cell[8,8];

        public static ChessWindow window;

        public static List<string> figuresCanBeat;

        public List<string> CanBeatInfoToListBox()
        {
            figuresCanBeat = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (cells[i, j].figure != null)
                    {
                        List<string> buf = cells[i, j].figureMovement.CanBeat();
                        if (buf != null)
                        {
                            foreach (var item in buf)
                            {
                                figuresCanBeat.Add(item);
                            }
                        }
                    }
                }
            }
            return figuresCanBeat;
        }

        public ChessBoard(ChessWindow chess)
        {
            window = chess;
            figuresOnBoard = new List<Figure>();
            for (byte x = 0; x < 8; x++)
            {
                for (byte y = 0; y < 8; y++)
                {
                    if (x % 2 == 0)
                    {
                        if (y % 2 == 0)
                        {
                            cells[y, x] = new Cell(y, x, Color.White);
                            chess.Controls.Add(cells[y, x]);
                        }
                        else
                        {
                            cells[y, x] = new Cell(y, x, Color.LightGray);
                            chess.Controls.Add(cells[y, x]);
                        }
                    }
                    else
                    {
                        if (y % 2 == 0)
                        {
                            cells[y, x] = new Cell(y, x, Color.LightGray);
                            chess.Controls.Add(cells[y, x]);
                        }
                        else
                        {
                            cells[y, x] = new Cell(y, x, Color.White);
                            chess.Controls.Add(cells[y, x]);
                        }
                    }
                }
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[j, i].figure = null;
                    cells[j, i].image.BackgroundImage = null;
                }
            }
            figuresOnBoard = new List<Figure>();
        }

        public void RemoveFigure(int y, int x)
        {
            if (cells[y, x].figure != null)
            {
                figuresOnBoard.Remove(cells[y, x].figure);
                cells[y, x].figure = null;
                cells[y, x].image.BackgroundImage = null;
            }
        }

        public void AddNewFigure(string type, int y, int x)
        {
            if(figuresCanBeat == null)
            {
                figuresCanBeat = new List<string>();
            }
            if(figuresOnBoard.Count == 10)
            {
                MessageBox.Show("There are 10 figures on chess board, to add a new figure, remove some figure");
                return;
            }
            if (cells[y, x].figure == null)
            {
                figuresOnBoard.Add(new Figure((Type)Enum.Parse(typeof(Type), type), y, x));
                SetFigures();
                cells[y, x].image.BackgroundImage = Cell.FiguresImages[cells[y, x].figure.GetFigureImageName()];
                List<string> buf = cells[y, x].figureMovement.CanBeat();
                if (buf != null)
                {
                    foreach (var item in buf)
                    {
                        figuresCanBeat.Add(item);
                    }
                }
            }
            else MessageBox.Show($"The figure \"{cells[y,x].figure.figureType.ToString()}\" is already located at the Y - {(y + 1)}, X - {(x + 1)}");
        }

        public ChessBoard(ChessWindow chess, string path)
        {
            window = chess;
            GetFiguresFromFile(path);
            SetFigures();
            SetImages();
        }

        private void SetImages()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (cells[y, x].figure != null)
                        cells[y, x].image.BackgroundImage = Cell.FiguresImages[cells[y, x].figure.GetFigureImageName()];
                }
            }
        }

        public void ClearCanMove()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j].ClearCanMove();
                }
            }
            SetImages();
        }

        private void SetFigures()
        {
            foreach (var item in figuresOnBoard)
            {
                cells[item.startY, item.startX].figure = item;
                cells[item.startY, item.startX].figureMovement = new FigureMovement(cells[item.startY, item.startX]); //
            }
        }

        /*Work with file*/
        public void GetFiguresFromFile(string path)
        {
            List<string> data = File.ReadAllLines(path).ToList();
            if (data.Count >= 1 && data.Count <= 10)
            {
                foreach (var figure in data)
                {
                    string[] buffer = figure.Split(' ');
                    figuresOnBoard.Add(new Figure((Type)Enum.Parse(typeof(Type), buffer[0]), Convert.ToInt32(buffer[1]) - 1, Convert.ToInt32(buffer[2]) - 1));
                }
            }
            else if(data.Count > 10)
            {
                int tmp = figuresOnBoard.Count;
                for (int i = 0; i < 10 - tmp; i++)
                {
                    string[] buffer = data[i].Split(' ');
                    figuresOnBoard.Add(new Figure((Type)Enum.Parse(typeof(Type), buffer[0]), Convert.ToInt32(buffer[1]) - 1, Convert.ToInt32(buffer[2]) - 1));
                }
            }

            IfDataCorrect(figuresOnBoard);
        }

        public void SaveFiguresToFile(string path)
        {
            List<string> buf = new List<string>();

            foreach (var item in figuresOnBoard)
            {
                buf.Add(item.figureType.ToString() + " " + (item.startY + 1) + " " + (item.startX + 1));
            }

            File.WriteAllText(path, "");
            File.AppendAllLines(path, buf);
        }

        private void IfDataCorrect(List<Figure> figures)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures.Count; j++)
                {
                    if(i != j && figures[i].startX == figures[j].startX && figures[i].startY == figures[j].startY)
                    {
                        MessageBox.Show("Input data error", "Some of figures have the same coordinates!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (result == DialogResult.OK)
                        //    Environment.Exit(0);
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                        //
                    }
                }
            }
        }
        /***/
    }
}
