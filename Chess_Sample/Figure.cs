using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Sample
{
    public enum Type { Rook, Knight, Bishop, Queen, King, Pawn}

    public class Figure
    {
        public Type figureType { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }

        public Figure(Type type, int y, int x)
        {
            figureType = type;
            startX = x;
            startY = y;
        }

        public string getWhiteFigureName()
        {
            return "W" + figureType.ToString() + ".png";
        }

        public string GetFigureImageName()
        {
            return "B" + figureType.ToString() + ".png";
        }
    }
}
