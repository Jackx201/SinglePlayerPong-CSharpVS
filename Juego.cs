using System;
/* using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public partial class Juego : Form
    {

        public Juego()
        {
            InitializeComponent();
            SetStyle( //Codigo para evitar lineas en el movimiento de los componentes
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
        }

        int i = 0;
        int puntaje = 0;
        int velocidad = 5;
        int ataque = 0;
        int nivel;
        bool izquierda;
        bool arriba;

        private void Juego_Load(object sender, EventArgs e)
        {
            if(ataque >= 100)
            {
                MessageBox.Show("GANASTE");
                this.Close();
            }
            Puntos.Text = "PUNTAJE: 0";
            pictureBox3.Image = null;
            Random aleatorio = new Random();
            pictureBox1.Location = new Point(0, aleatorio.Next(this.Height));
            arriba = true;
            izquierda = true;
            timer1.Enabled = true;
            puntaje = 0;
            nivel = 1;
            textBox1.Enabled = false;
            textBox1.Visible = false;
            button2.Visible = false;
            button2.Enabled = false;
            finalboss.Visible = false;
            finalboss.Enabled = false;

        }

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Top = e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Left > pictureBox2.Left)
            {
                timer1.Enabled = false;
               
                #region SCORES 
                switch (nivel)
                {
                    case 1:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nLAMENTABLE");
                        break;
                    case 2:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nNada mal");
                        break;
                    case 3:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \n¿Por qué sigues aquí?");
                        break;
                    case 4:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nNo deberías seguir aquí");
                        break;
                    case 5:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nNo hay nada que ver aquí\n¡LARGO!");
                        break;
                    case 6:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \n¿Por qué no me dejas solo?");
                        break;
                    case 7:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nNos vengaremos por esto");
                        break;
                    case 8:
                        MessageBox.Show("Llegaste lejos, pero no lo suficiente");
                        break;
                    case 9:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nAunque lo intentaras, no podrías hacerme daño");
                        break;
                    case 10:
                        MessageBox.Show("Hiciste: " + puntaje.ToString() + " puntos \nNo puedes hacerme daño\n1573ZIFFLOM6482");
                        break;
                    case 11:
                        MessageBox.Show("Felicidades :D");
                        break;
                }
                #endregion
                puntaje = 0;
                velocidad = 5;
                i = 0;
                ataque = 0;
                textBox1.Enabled = false;
                textBox1.Visible = false;
                button2.Visible = false;
                button2.Enabled = false;
                finalboss.Visible = false;
                finalboss.Enabled = false;
                Puntos.Visible = true;

            }


            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                izquierda = false;
                puntaje += 1;
                Puntos.Text = "PUNTAJE: " + puntaje.ToString();
                i++;
                if(i>5)
                {
                    velocidad++;
                    i = 0;           
                }
                #region Niveles
                switch(puntaje)
                {
                    case 3:
                        nivel = 2;
                        pictureBox1.Parent = pictureBox3;
                        pictureBox1.Visible = true;    
                        pictureBox3.Image = Pong.Properties.Resources.Eye_Png;
                    break;

                    case 7:
                        nivel = 3;
                    pictureBox3.Image = Pong.Properties.Resources.original;
                    break;

                    case 17:
                        nivel = 4;
                        pictureBox3.Image = Pong.Properties.Resources.Eye_Png;
                    break;

                    case 24:
                        nivel = 5;
                    pictureBox3.Image = Pong.Properties.Resources.Loading;
                    break;

                    case 28:
                        nivel = 6;
                        pictureBox3.Image = Pong.Properties.Resources.Error;
                    break;
                    
                    case 33:
                        nivel = 7;
                        pictureBox3.Image = Pong.Properties.Resources.Eye_Png;
                       // pictureBox1.Image = Pong.Properties.Resources.Bola_Final;
                        break;

                    case 35: //35
                        nivel = 8;
                        pictureBox3.Image = Pong.Properties.Resources.PreFinale;
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        button2.Visible = true;
                        button2.Enabled = true;
                        break;

                    case 42:
                        nivel = 9;
                        textBox1.Enabled = false;
                        textBox1.Visible = false;
                        button2.Visible = false;
                        button2.Enabled = false;
                        pictureBox3.Image = Pong.Properties.Resources.Eye_Png;
                    break;

                    case 46:
                        nivel = 10;
                         pictureBox3.Image = Pong.Properties.Resources.Debugger;
                    break;

                    case 50:
                        pictureBox3.Image = Pong.Properties.Resources.Interlude;
                        break;
                }
                #endregion

            }

            #region Movimiento de la pelota
            if (izquierda)
            {
                pictureBox1.Left += velocidad;
            }
            else
            {
                pictureBox1.Left -= velocidad;
            }

            if(arriba)
            {
                pictureBox1.Top += velocidad;
            }
            else
            {
                pictureBox1.Top -= velocidad;
            }

            if(pictureBox1.Top >= this.Height - 40)
            {
                arriba = false;
            }
            if(pictureBox1.Top <= 40) //0
            {
                arriba = true;
            }
            if(pictureBox1.Left <= 0)
            {
                izquierda = true;
            }
            
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "1573ZIFFLOM6482")
            {
                puntaje = 666;
                pictureBox3.Image = null;
                textBox1.Enabled = false;
                textBox1.Visible = false;
                button2.Visible = false;
                button2.Enabled = false;
                finalboss.Visible = true;
                finalboss.Enabled = true;
                finalboss.Parent = pictureBox3;
                finalboss.Visible = true;
                Puntos.Visible = false;
               
            }
        }

        private void finalboss_Click(object sender, EventArgs e)
        {
            
            ataque++;

            switch (ataque)
            {
                case 1:
                    finalboss.Image = Pong.Properties.Resources.Panic;
                    break;
                case 99:
                    finalboss.Image = Pong.Properties.Resources.FinalBossFinalStage;
                    break;
                case 101:
                    nivel = 11;
                    pictureBox3.Image = Pong.Properties.Resources.Congrats;
                    pictureBox1.Parent = pictureBox3;
                    finalboss.Visible = false ;
                    break;
            }
            
        }
    }
}
