using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t4
{
    public partial class Form1 : Form
    {
        int pow =0, g=-3;
        int movent = 1, storepow = 2, move = 3, directionset = 4, onfloor = 5, state = 1, left = 6, right = 7, direct = 9, vertical = 9 ;
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up&&state == movent)
            {
                state = storepow;
            }
            else if (e.KeyCode == Keys.Left && state == storepow)
            {
                Console.WriteLine("dire");
                state = directionset;
                direct = left;
            }
            else if (e.KeyCode == Keys.Right && state == storepow)
            {
                Console.WriteLine("dire");
                state = directionset;
                direct = right;
            }
            else if (e.KeyCode == Keys.Left && state == movent)
            {
                man.Left -= 10;
            }
            else if (e.KeyCode == Keys.Right && state == movent)
            {
                man.Left += 10;
            }
        }

        public void iffell(PictureBox man,PictureBox floor)
        {
            if (man.Right < floor.Left || man.Left > floor.Right)
                state = move;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int var=10;
            if (state == storepow)
            {
                if(pow<=40)
                    pow+=3;
            }
            if(state == move && direct ==vertical)
            {
                Console.WriteLine("move");
                pow += g;
                man.Top -= pow;
                if(man.Top>=this.Height-100)
                {
                    pow = 0;
                    state = movent;
                    man.Top = this.Height - man.Height -30;
                }
            }
            if (state == move && direct!= vertical)
            { 
                if(direct == left)
                {
                    man.Left -= var;
                    Console.WriteLine("Lmove");
                    pow += g;
                    man.Top -= pow;
                    if (man.Top >= this.Height - 100)
                    {
                        pow = 0;
                        state = movent;
                        man.Top = this.Height - man.Height - 30;
                        direct = vertical;
                    }
                }
                else 
                {
                    man.Left += var;
                    Console.WriteLine("Rmove");
                    pow += g;
                    man.Top -= pow;
                    if (man.Top >= this.Height - 100)
                    {
                        pow = 0;
                        state = movent;
                        man.Top = this.Height - man.Height - 40;
                        direct = vertical;
                    }
                }
            }
           
            foreach (PictureBox x in Controls)
            {
                int many = man.Top-man.Height/2;
                if (man.Bounds.IntersectsWith(x.Bounds) && x.Tag == "floor")
                {
                    int py = x.Top - man.Height / 2; 
                    if(many<py&&pow<0)
                    {
                        direct = vertical;
                        state = movent;
                        Console.WriteLine("S");
                        man.Top = x.Top-man.Height-4;
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up&&state == storepow)
            {
                state = move;
            }
            if (e.KeyCode == Keys.Up && direct !=vertical)
            {
                state = move;
            }
        }
    }
}
