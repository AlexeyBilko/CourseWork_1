﻿using System;
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
            Width = 1030;
        }

        ChessBoard board;
        List<string> list;

        /*Відбувається коли вікно запускається*/
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
            list = new List<string>();
            listBox.Enabled = true;
        }

        /*Видаляє зображення можливих ходів на шахівниці*/
        private void ClearCanMove_Click(object sender, EventArgs e)
        {
            board.ClearCanMove();
        }

        /*Відбувається при натисканні на кнопку, що відкриває вікно для вибору текстового файлу з розстановкою фігур*/
        private void OpenFile_Click(object sender, EventArgs e)
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
            
            list = board.CanBeatInfoToListBox();
            listBox.Items.Clear();
            foreach (var item in list)
            {
                listBox.Items.Add(item);
            }
        }

        /*Прибирає всі фігури з шахівниці*/
        private void ClearBoard_Click(object sender, EventArgs e)
        {
            board.ClearCanMove();
            board.ClearBoard();
            filename_label.Text = "-";
            listBox.Items.Clear();
        }

        /*Відбувається при натисканні на кнопку, що додає нову фігуру на шахівницю*/
        private void AddFigure_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown_Y.Value >= 1 && (int)numericUpDown_Y.Value <= 8 && (int)numericUpDown_X.Value >= 1 && (int)numericUpDown_X.Value <= 8)
                if (comboBox_FigureName.SelectedItem != null)
                {
                    board.AddNewFigure(comboBox_FigureName.SelectedItem.ToString(), (int)numericUpDown_Y.Value - 1, (int)numericUpDown_X.Value - 1);
                    list = board.CanBeatInfoToListBox();
                    listBox.Items.Clear();
                    foreach (var item in list)
                    {
                        listBox.Items.Add(item);
                    }
                }
                else return;
            else return;
        }

        /*Відбувається при натисканні на кнопку, що відкриває вікно для вибору місця куди зберегти розстановку фігур*/
        private void SaveInFile_Click(object sender, EventArgs e)
        {
            if(ChessBoard.figuresOnBoard == null || ChessBoard.figuresOnBoard.Count < 1)
            {
                MessageBox.Show("There are no figures to save");
                return;
            }
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Text files(*.txt)|*.txt";
            if (s.ShowDialog() == DialogResult.Cancel)
                return;
            string filepath = s.FileName;
            board.SaveFiguresToFile(filepath);
        }

        /*Відбувається при натисканні на кнопку, що видалає фігуру з шахівниці*/
        private void RemoveFigure_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDown_Y.Value >= 1 && (int)numericUpDown_Y.Value <= 8 && (int)numericUpDown_X.Value >= 1 && (int)numericUpDown_X.Value <= 8)
            {
                board.RemoveFigure((int)numericUpDown_Y_R.Value - 1, (int)numericUpDown_X_R.Value - 1);
                board.ClearCanMove();
                list = board.CanBeatInfoToListBox();
                listBox.Items.Clear();
                foreach (var item in list)
                {
                    listBox.Items.Add(item);
                }
            }
            else return;
        }

        /*Відбувається при зміненні вибраного елемента в списку*/
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox.SelectedItem.ToString().Substring(0, 2) != "->")
                {
                    string tmp = listBox.SelectedItem.ToString();
                    int Y = int.Parse(tmp.Substring(tmp.IndexOf(' ') + 5, 1));
                    int X = int.Parse(tmp.Substring(tmp.IndexOf(' ') + 10, 1));
                    ChessBoard.cells[Y - 1, X - 1].ShowClick();
                }
                else
                {
                    board.ClearCanMove();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You should click on text");
            }
        }
    }
}
