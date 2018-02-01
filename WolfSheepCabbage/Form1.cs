using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfSheepCabbage
{
    public partial class Form1 : Form
    {
        private List<string> _leftList;
        private List<string> _rightList;
        private bool leftSide, rightSide;
        public Form1()
        {
            InitializeComponent();
            listBox1.BackColor = Color.Cyan;
            leftSide = true;
            rightSide = false;
            button1.Enabled = true;
            button2.Enabled = false;
            CreateList();
            SetListBoxDataSource();
            ChangeData();
        }

        private void CreateList()
        {
            _leftList = new List<string>
            {
                "狼","菜","羊"
            };
            _rightList = new List<string>();
        }

        private void SetListBoxDataSource()
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox2.SelectionMode = SelectionMode.One;
        }

        private void ChangeData()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            listBox1.DataSource = _leftList;
            listBox2.DataSource = _rightList;
            listBox1.ClearSelected();
            listBox2.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string item = (string)listBox1.SelectedItem;
                _leftList.Remove(item);
                _rightList.Add(item);
                ChangeData();
                LeftToRight();
            }
            else
            {
                LeftToRight();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string item = (string)listBox2.SelectedItem;
                _rightList.Remove(item);
                _leftList.Add(item);
                ChangeData();
                RightToLeft();
            }
            else
            {
                RightToLeft();
            }
        }

        public void LeftToRight()
        {
            rightSide = true;
            leftSide = false;
            button1.Enabled = false;
            button2.Enabled = true;
            listBox1.BackColor = Color.White;
            listBox2.BackColor = Color.Cyan;
            CheckWin();
        }

        public void RightToLeft()
        {
            rightSide = false;
            leftSide = true;
            button1.Enabled = true;
            button2.Enabled = false;
            listBox1.BackColor = Color.Cyan;
            listBox2.BackColor = Color.White;
            CheckWin();
        }

        public void CheckWin()
        {
            if(leftSide == false)
            {
                if (_leftList.Count == 2)
                {
                    if (_leftList[0] == "羊" && _leftList[1] == "菜" ||
                        _leftList[0] == "菜" && _leftList[1] == "羊")
                    {
                        MessageBox.Show("羊吃掉菜了");
                        Application.Restart();
                    }

                    if (_leftList[0] == "狼" && _leftList[1] == "羊" ||
                        _leftList[0] == "羊" && _leftList[1] == "狼")
                    {
                        MessageBox.Show("狼吃掉羊了");
                        Application.Restart();
                    }
                }
                if(_leftList.Count == 3)
                {
                    MessageBox.Show("狼吃掉羊，羊吃掉草");
                    Application.Restart();
                }
            }
            if(rightSide == false)
            {
                if (_rightList.Count == 2)
                {
                    if (_rightList[0] == "羊" && _rightList[1] == "菜" ||
                        _rightList[0] == "菜" && _rightList[1] == "羊")
                    {
                        MessageBox.Show("羊吃掉菜了");
                        Application.Restart();
                    }

                    if (_rightList[0] == "狼" && _rightList[1] == "羊" ||
                        _rightList[0] == "羊" && _rightList[1] == "狼")
                    {
                        MessageBox.Show("狼吃掉羊了");
                        Application.Restart();
                    }
                }
            }

            if(_rightList.Count == 3)
            {
                MessageBox.Show("成功渡河");
                Application.Restart();
            }
        }
    }
}
