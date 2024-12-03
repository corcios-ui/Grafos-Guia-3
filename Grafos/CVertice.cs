﻿using System;
using System.Collections.Generic;
using System.Drawing;           //Libreria agregada, para poder dibujar
using System.Drawing.Drawing2D; //Libreria agregada, para poder dibujar

namespace Grafos
{
    class CVertice
    {
        //Atributos
        public string Valor;                    //Valor que almacena (representa) el nodo
        public List<CArco> ListaAdyacencia;     //Lista de adyacencia del nodo
        /* Los diccionarios representan una coleccion de claves y valores. El primer parametro representa
           el tipo de las claves del diccionario, el segundo, el tipo de valores del diccionario*/
        Dictionary<string, short> _banderas;
        Dictionary<string, short> _banderas_predeterminado;

        //Propiedades que nos permiten modificar el color del nodo, de la fuente, la posicion del nodo, las dimensiones
        public Color Color
        {
            get { return color_nodo; }
            set { color_nodo = value; }
        }

        public Color FontColor
        {
            get { return color_fuente; }
            set { color_fuente = value; }
        }

        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public Size Dimensiones
        {
            get { return dimensiones; }
            set
            {
                radio = value.Width / 2;
                dimensiones = value;
            }
        }

        static int size = 35;       //Tamaño del nodo
        Size dimensiones;
        Color color_nodo;           //Color definido para el nodo
        Color color_fuente;         //Color definido para la fuente del nombre del nodo
        Point _posicion;            //Donde se dibujara el nodo
        int radio;                  //Radio del objeto que representa el nodo

        //Metodos

        //Constructor de la clase, recibe como parametros el nombre del nodo (el valor que tendra)
        public CVertice(string Valor)
        {
            this.Valor = Valor;
            this.ListaAdyacencia = new List<CArco>();
            this._banderas = new Dictionary<string, short>();
            this._banderas_predeterminado = new Dictionary<string, short>();
            this.Color = Color.SlateBlue;                       //Definimos el color del nodo
            this.Dimensiones = new Size(size, size);        //Definimos las dimensiones del circulo
            this.FontColor = Color.White;                   //Color de la fuente
        }

        public CVertice() : this("") { } //Constructor por defecto

        //Metodo para dibujar el nodo
        public void DibujarVertice(Graphics g)
        {
            SolidBrush b = new SolidBrush(this.color_nodo);

            //Definimos donde dibujaremos el nodo
            Rectangle areaNodo = new Rectangle(this._posicion.X - radio, this._posicion.Y - radio, this.dimensiones.Width, this.dimensiones.Height);
            g.FillEllipse(b, areaNodo); //rellenamos el circulo dandole como parametros la brocha y el rectangulo en el que esta encerrado
            //Definimos la fuente que se usara
            g.DrawString(this.Valor, new Font("Times New Roman", 14), new SolidBrush(color_fuente), this._posicion.X, this._posicion.Y, new StringFormat()
            { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
            );
            g.DrawEllipse(new Pen(Brushes.Black, (float)1.0), areaNodo);//Dibujamos la elipse o la linea que se ve a la orilla del circulo
            b.Dispose(); //Para liberar los recursos utilizados por el objeto
        }

        //Metodo para dibujar los arcos
        public void DibujarArco(Graphics g)
        {
            float distancia;
            int difY, difX;

            foreach (CArco arco in ListaAdyacencia)
            {
                difX = this.Posicion.X - arco.nDestino.Posicion.X;
                difY = this.Posicion.Y - arco.nDestino.Posicion.Y;
                //Se calcula la distancia realizando la raiz de la suma de los cuadrados que se forman al encontrar las diferencias en Y y en X
                distancia = (float)Math.Sqrt((difX * difX + difY * difY));
                //configuramos una flecha para poder dibujarla
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                //dibujamos la flecha indicando el destino, la posicion y otros paramentros
                g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha)
                {
                    CustomEndCap = bigArrow,
                    Alignment = PenAlignment.Center
                }, _posicion, new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia), arco.nDestino.Posicion.Y + (int)(radio * difY / distancia))
                );

                g.DrawString(
                    arco.peso.ToString(),
                    new Font("Times New Roman", 12),
                    new SolidBrush(Color.White),
                    this._posicion.X - (int)((difX / 3)),
                    this._posicion.Y - (int)((difY / 3)),
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    }
                    );
            }
        }

        //nos devuelve null si el lugar donde se esta dando click
        //no esta sobre un vertice, es decir que no podra salir de este lugar un arco

        //Metodo para detectar posicion en el panel donde se dibujara el nodo
        public bool DetectarPunto(Point p)
        {
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(this._posicion.X - this.dimensiones.Width / 2, this._posicion.Y - this.dimensiones.Height / 2, this.dimensiones.Width, this.dimensiones.Height));
            bool retval = posicion.IsVisible(p);//identificamos si hay un vertice en esa posicion o no, si no hay regresa false sino regresa true;
            posicion.Dispose();
            return retval;
        }

        public string ToString()
        {
            return this.Valor;
        }
    }
}
