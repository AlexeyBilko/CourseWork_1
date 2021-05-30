using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Sample
{
    public partial class ChessWindow : Form
    {
        public ChessWindow()
        {
            InitializeComponent();
            Height = 545;
            Width = 800;
        }

        ChessBoard board;

        private void ChessWindow_Load(object sender, EventArgs e)
        {
            board = new ChessBoard(this);
            numericUpDown_X.ReadOnly = true;
            numericUpDown_X_R.ReadOnly = true;
            numericUpDown_Y.ReadOnly = true;
            numericUpDown_Y_R.ReadOnly = true;
            comboBox_FigureName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FigureName.Items.Add(Type.Queen.ToString());
            comboBox_FigureName.Items.Add(Type.Rook.ToString());
            comboBox_FigureName.Items.Add(Type.Bishop.ToString());
            comboBox_FigureName.Items.Add(Type.King.ToString());
            comboBox_FigureName.Items.Add(Type.Knight.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.ClearCanMove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Text files(*.txt)|*.txt";
            if (f.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = f.FileName;
            string tmp = filename.Substring(filename.LastIndexOf(@"\") + 1);
            if (tmp.Length >= 12)
                tmp = tmp.Substring(0, 7)+ "(...)" + tmp.Substring(tmp.LastIndexOf('.'));
            filename_label.Text = tmp;
            board = new ChessBoard(this, filename);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            board.ClearCanMove();
            board.ClearBoard();
            filename_label.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown_Y.Value >= 1 && (int)numericUpDown_Y.Value <= 8 && (int)numericUpDown_X.Value >= 1 && (int)numericUpDown_X.Value <= 8)
                if (comboBox_FigureName.SelectedItem != null)
                    board.AddNewFigure(comboBox_FigureName.SelectedItem.ToString(), (int)numericUpDown_Y.Value - 1, (int)numericUpDown_X.Value - 1);
                else return;
            else return;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text files(*.txt)|*.txt";
            if (s.ShowDialog() == DialogResult.Cancel)
                return;
            string filepath = s.FileName;
            board.SaveFiguresToFile(filepath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown_Y.Value >= 1 && (int)numericUpDown_Y.Value <= 8 && (int)numericUpDown_X.Value >= 1 && (int)numericUpDown_X.Value <= 8)
                board.RemoveFigure((int)numericUpDown_Y_R.Value - 1, (int)numericUpDown_X_R.Value - 1);
            else return;
        }
    }
}
