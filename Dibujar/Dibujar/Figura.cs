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
    abstract class Figura
    {   
        public Punto punto1 { get; set; }
        public Punto punto2 { get; set; }
        public SolidBrush brocha { get; set; }
        public Pen pluma { get; set; }
        public Color colorRelleno { get; set; }
        public Color colorContorno { get; set; }
        public int anchopluma { get; set; }
        public Figura(Punto punto1, Punto punto2)
        {
            this.punto1 = punto1;
            this.punto2 = punto2;
            colorRelleno = Color.White;
            colorContorno = Color.Black;
            anchopluma = 1;
        }
        public abstract void Dibuja(Form forma);

        public bool EstaDentro(int x, int y)
        {
            return (x >= punto1.X && x <= punto2.X && x >= punto1.Y && x <= punto2.Y);
        }
        
    }
    class Rectangulo : Figura
    {
        public Rectangulo(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {
            Graphics graphics = forma.CreateGraphics();
            graphics.FillRectangle(new SolidBrush(colorRelleno), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
            graphics.DrawRectangle(new Pen(colorContorno,anchopluma), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);

        }
        
    }
    class Elipse : Figura
    {
        public Elipse(Punto punto1, Punto punto2) : base(punto1, punto2)
        {

        }
        public override void Dibuja(Form forma)
        {
            Graphics graphics = forma.CreateGraphics();

            graphics.FillEllipse(new SolidBrush(colorRelleno), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
            graphics.DrawEllipse(new Pen(colorContorno, anchopluma), punto1.X, punto1.Y, punto2.X - punto1.X, punto2.Y - punto1.Y);
           
        }

    }
}
