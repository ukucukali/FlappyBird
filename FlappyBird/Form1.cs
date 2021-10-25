﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int yercekimi = 5, hiz = 10;
        int score;
        bool pbPipe1Control, pbPipe3Control;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void tmrGame_Tick(object sender, EventArgs e)
        {
            pbBird.Top += yercekimi;
            pbPipe1.Left -= hiz;
            pbPipe2.Left -= hiz;
            pbPipe3.Left -= hiz;
            pbPipe4.Left -= hiz;

            if (pbPipe1.Right < 0)
            {
                pbPipe1.Left = ClientSize.Width + rnd.Next(200);
                pbPipe1Control = false;
            }
            if (pbPipe2.Right < 0)
            { pbPipe2.Left = ClientSize.Width + rnd.Next(200); }
            if (pbPipe3.Right < 0)
            {
                pbPipe3.Left = ClientSize.Width + rnd.Next(200);
            }
            if (pbPipe4.Right < 0)
            {
                pbPipe4.Left = ClientSize.Width + rnd.Next(200);
            }
            if (pbPipe1.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe2.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe3.Bounds.IntersectsWith(pbBird.Bounds) || pbPipe4.Bounds.IntersectsWith(pbBird.Bounds) || pbGround.Bounds.IntersectsWith(pbBird.Bounds))
            {
                tmrGame.Stop();
                DialogResult dr = MessageBox.Show("Tekrar oynamak ister misiniz?", "FlappyBird", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (dr == DialogResult.Yes)
                {
                    pbBird.Left = 0;
                    pbBird.Top = 170;
                    pbPipe1.Left += ClientSize.Width;
                    pbPipe2.Left += ClientSize.Width;
                    pbPipe3.Left += ClientSize.Width;
                    pbPipe4.Left += ClientSize.Width;

                    pbPipe1Control = false;
                    pbPipe3Control = false;
                    score = 0;
                    tmrGame.Start();
                }
                else
                {
                    Close();


                }
            }
            if (pbBird.Right > pbPipe1.Left && !pbPipe1Control)
            {
                score++;
                pbPipe1Control = true;
            }
            if (pbBird.Right > pbPipe3.Left && !pbPipe3Control)
            {
                score++;
                pbPipe3Control = true;
            }
            lblScore.Text = "Score: " + score;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && tmrGame.Enabled)
            {
                if (pbBird.Top > 0)
                {
                    pbBird.Top -= yercekimi * 10;

                }
            }
        }



    }
}