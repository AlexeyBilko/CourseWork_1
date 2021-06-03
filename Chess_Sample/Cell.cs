using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Sample
{
    public struct Location
    {
        public byte x;
        public byte y;
    }

    public partial class Cell : UserControl
    {
        public Figure figure;
        Location location;
        Color color;
        public FigureMovement figureMovement;

        /*словник з назвами зображень*/
        public static Dictionary<string, Image> FiguresImages = new Dictionary<string, Image>
        {
            { "BBishop.png",Properties.Resources.Black_Bishop},
            { "BKnight.png",Properties.Resources.Black_Knight },
            { "BRook.png",Properties.Resources.Black_Rook },
            { "BKing.png",Properties.Resources.Black_King },
            { "BQueen.png",Properties.Resources.Black_Queen },
            { "BPawn.png",Properties.Resources.Black_Pawn },
            { "WBishop.png",Properties.Resources.White_Bishop },
            { "WKnight.png",Properties.Resources.WKnight },
            { "WRook.png",Properties.Resources.White_Rook },
            { "WKing.png",Properties.Resources.WKing},
            { "WQueen.png",Properties.Resources.White_Queen },
            { "WPawn.png",Properties.Resources.White_Pawn }
        };

        /*перевіряє чи є в данній клітинці фігури*/
        public bool isEmpty() => figure == null;

        public Cell(byte y, byte x, Color c)
        {
            InitializeComponent();
            figure = null;
            color = c;
            location.x = x;
            location.y = y;
            Location = new Point(x * Size.Width, y * Size.Height);
        }

        /*Відбувається при завантаженні клітинки на шахівницю*/
        private void Cell_Load(object sender, EventArgs e)
        {
            image.BackColor = color;
            BackColor = color;
            Click += ClickOnCell;
            image.Click += ClickOnCell;
        }

        static int click = 0;

        /*відбувається при натисканні на дану клітинку*/
        private void ClickOnCell(object sender, EventArgs e)
        {
            ShowClick();
        }

        /*відображає всі можливі ходи даної фігури*/
        public void ShowClick()
        {
            if (figure != null)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (ChessBoard.cells[y, x].figure != null)
                            ChessBoard.cells[y, x].image.BackgroundImage = Cell.FiguresImages[ChessBoard.cells[y, x].figure.GetFigureImageName()];
                    }
                }
                image.BackgroundImage = Cell.FiguresImages[figure.getWhiteFigureName()];
                figureMovement = new FigureMovement(this);
                figureMovement.ShowMove(true);
            }
        }

        /*додає на дану клітинку зображення про можливості ходу або про можливість побити фігуру на данній клітинці*/
        public void CanMoveHere(bool can)
        {
            if (image.BackgroundImage != null)
            {
                image.Image = Properties.Resources.PossibleBeat;
            }
            else
            {
                if (!can)
                    image.Image = null;
                else
                {
                    image.Image = Properties.Resources.PossibleMove;
                }
            }
        }
        /*прибирає зображення можливості ходу*/
        public void ClearCanMove()
        {
            image.Image = null;
        }
    }
}
