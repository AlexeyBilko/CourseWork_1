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

        /*збирає інформацію про те які фігури б'ють одна одну і записує всі в один список*/
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

        /*прибирає всі фігури*/
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
        /*видалає фігуру з шахівниці*/
        public void RemoveFigure(int y, int x)
        {
            if(figuresOnBoard == null || figuresOnBoard.Count == 1)
            {
                MessageBox.Show("You can not remove this figure, on chessboard must be at least one figure");
                return;
            }
            if (cells[y, x].figure != null)
            {
                figuresOnBoard.Remove(cells[y, x].figure);
                cells[y, x].figure = null;
                cells[y, x].image.BackgroundImage = null;
            }
        }

        /*додає нову фігуру на шахівницю*/
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
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (ChessBoard.cells[y, x].figure != null)
                            ChessBoard.cells[y, x].image.BackgroundImage = Cell.FiguresImages[ChessBoard.cells[y, x].figure.GetFigureImageName()];
                        cells[i, j].ClearCanMove();
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

        /*задає зображення для фігури*/
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
        /*прибирає зображення можливості ходу на усіх клітинках*/
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

        /*присвоює клітинкам, фігури що на них розташовані*/
        private void SetFigures()
        {
            foreach (var item in figuresOnBoard)
            {
                cells[item.startY, item.startX].figure = item;
                cells[item.startY, item.startX].figureMovement = new FigureMovement(cells[item.startY, item.startX]); //
            }
        }

        /*обробляє текстовий файл, дістаючи звідти розстановку фігур (path - путь файла на комп'ютері)*/
        public void GetFiguresFromFile(string path)
        {
            try
            {
                List<string> data = File.ReadAllLines(path).ToList();
                if (data.Count >= 1 && figuresOnBoard.Count + data.Count <= 10)
                {
                    foreach (var figure in data)
                    {
                        string[] buffer = figure.Split(' ');
                        if (Convert.ToInt32(buffer[2]) >= 1 && Convert.ToInt32(buffer[2]) <= 8 && Convert.ToInt32(buffer[1]) >= 1 && Convert.ToInt32(buffer[1]) <= 8)
                            figuresOnBoard.Add(new Figure((Type)Enum.Parse(typeof(Type), buffer[0]), Convert.ToInt32(buffer[2]) - 1, Convert.ToInt32(buffer[1]) - 1));
                        else
                        {
                            figuresOnBoard = new List<Figure>();
                            MessageBox.Show("Input data error", "Wrong File!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            cells[i, j].figure = null;
                        }
                    }
                    ClearBoard();
                    for (int i = 0; i < data.Count && i < 10; i++)
                    {
                        string[] buffer = data[i].Split(' ');

                        figuresOnBoard.Add(new Figure((Type)Enum.Parse(typeof(Type), buffer[0]), Convert.ToInt32(buffer[2]) - 1, Convert.ToInt32(buffer[1]) - 1));
                    }
                }
                IfDataCorrect(figuresOnBoard);
            }
            catch (Exception)
            {
                MessageBox.Show("Input data error", "Wrong File!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /*зберігає розстановку в файл (path - путь файла на комп'ютері)*/
        public void SaveFiguresToFile(string path)
        {
            List<string> buf = new List<string>();

            foreach (var item in figuresOnBoard)
            {
                buf.Add(item.figureType.ToString() + " " + (item.startX + 1) + " " + (item.startY + 1));
            }

            File.WriteAllText(path, "");
            File.AppendAllLines(path, buf);
        }

        /*Перевіряє вхідний файл на корректність (figures - фігури які вже розставлені на шахівниці)*/
        private void IfDataCorrect(List<Figure> figures)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures.Count; j++)
                {
                    if(i != j && figures[i].startX == figures[j].startX && figures[i].startY == figures[j].startY)
                    {
                        MessageBox.Show("Input data error", "Some of figures have the same coordinates!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        figuresOnBoard = new List<Figure>();
                        return;
                    }
                }
            }
        }
        /***/
    }
}
