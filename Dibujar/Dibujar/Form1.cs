using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dibujar

{

    public partial class Form1 : Form
    {
        List<Figura> figuras = new List<Figura>();
        private string estado = "Dibujando";
        private Punto p1_actual;
        private Figura FiguraSeleccionada;
        private Figura Selecciona(int x, int y)
        {
            for (int i = figuras.Count - 1; i >= 0; i-- )
            {
                if (figuras[i].EstaDentro(x, y))
                    return figuras[i];
            }
            return null;
        }
        private void DibujaFiguras() 
        {
            foreach (var figura in figuras)
                figura.Dibuja(this);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(estado == "Dibujando")
            {
                estado = "Moviendo";
                label1.Text = string.Format($"x:{e.X}, y:{e.Y}");
                p1_actual = new Punto(e.X, e.Y);
            }
            else if(estado == "Seleccionando")
            {
                FiguraSeleccionada = Selecciona(e.X, e.Y);
                if(FiguraSeleccionada != null)
                {
                    button2.Text = string.Format($"x:{FiguraSeleccionada.punto1.X}, y:{FiguraSeleccionada.punto1.Y}");
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (estado == "Moviendo") 
            {

                estado = "Dibujando";
                label1.Text = string.Format($"x:{e.X}, y:{e.Y}");


                if (e.Button == MouseButtons.Left)
                {
                    Rectangulo r = new Rectangulo(p1_actual, new Punto(e.X, e.Y));
                    figuras.Add(r);
                    r.Dibuja(this);
                }
            else if (e.Button == MouseButtons.Right)
            {
                Elipse e1 = new Elipse(p1_actual, new Punto(e.X, e.Y));
                figuras.Add(e1);
                e1.Dibuja(this);
            }
            }
            
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if(estado=="Moviendo")
            label1.Text = string.Format($"x:{e.X}, y:{e.Y}");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.DibujaFiguras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = "Seleccionando";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            estado = "Dibujando";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(FiguraSeleccionada != null)
                FiguraSeleccionada.colorRelleno = Color.Red;
        }
    }
}
