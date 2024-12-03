using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Grafos
{
    public partial class Simulator : Form
    {
        private CGrafo grafo;
        private CVertice nuevoNodo;
        private CVertice NodoOrigen;
        private CVertice NodoDestino;
        private int var_control;
        private Vertice ventanaVertice;
        private EliminarVertice VentanaEliminar;
        private EliminarArco vEliminarArco;
        private Peso vPeso;
        public Simulator()
        {
            InitializeComponent();
            grafo = new CGrafo();
            nuevoNodo = null;
            /*
            * Variable de control, para saber que accion se esta realizando en la pizarra.
            * Si es 0 -> sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
            */
            var_control = 0;
            ventanaVertice = new Vertice();
            VentanaEliminar = new EliminarVertice();
            vEliminarArco = new EliminarArco();
            vPeso = new Peso();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DataDemo();
        }

        private void DataDemo()
        {
            /* 
             * Se agregan nodos al grafo de ejemplo
            */
            CVertice nodoSanSalvador = new CVertice("SAN SALVADOR");
            nodoSanSalvador.Posicion = new Point(270, 150);
            grafo.AgregarVertice(nodoSanSalvador);

            CVertice nodoSoyapango = new CVertice("SOYAPANGO");
            nodoSoyapango.Posicion = new Point(65, 230);
            grafo.AgregarVertice(nodoSoyapango);

            CVertice nodoMejicanos = new CVertice("MEJICANOS");
            nodoMejicanos.Posicion = new Point(230, 250);
            grafo.AgregarVertice(nodoMejicanos);

            CVertice nodoSantaTecla = new CVertice("SANTA TECLA");
            nodoSantaTecla.Posicion = new Point(460, 80);
            grafo.AgregarVertice(nodoSantaTecla);

            CVertice nodoApopa = new CVertice("APOPA");
            nodoApopa.Posicion = new Point(270, 400);
            grafo.AgregarVertice(nodoApopa);

            /* 
             * Se agregan los arcos partiendo de San Salvador
             */
            grafo.AgregarArco(nodoSanSalvador, nodoSoyapango, 6);
            grafo.AgregarArco(nodoSanSalvador, nodoSantaTecla, 10);
            grafo.AgregarArco(nodoSanSalvador, nodoMejicanos, 4);

            /* 
             * Se agregan los arcos partiendo de Soyapango
             */
            grafo.AgregarArco(nodoSoyapango, nodoMejicanos, 5);

            /* 
             *Se agregan los arcos partiendo de Mejicanos
             */
            grafo.AgregarArco(nodoMejicanos, nodoApopa, 9);

            /* 
             *Se agregan los arcos partiendo de Apopa
             */
            grafo.AgregarArco(nodoApopa, nodoSanSalvador, 13);

            /* 
             *Se agregan los arcos partiendo de Santa Tecla
             */
            grafo.AgregarArco(nodoSantaTecla, nodoApopa, 18);
        }

        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh();
        }

        private void Simulator_Load(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            nuevoNodo = new Grafos.CVertice();
            var_control = 2;
        }

        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1:
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        int distancia = 0;

                        vPeso.Visible = false;
                        vPeso.control = false;
                        vPeso.ShowDialog();
                        distancia = int.Parse(vPeso.txtPeso.Text.Trim());
                        if (grafo.AgregarArco(NodoOrigen, NodoDestino))
                        {
                            NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                        }
                    }
                    var_control = 0;
                    NodoDestino = null;
                    NodoOrigen = null;
                    Pizarra.Refresh();
                    break;
            }
        }

        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control) //Utilizamos la variable de control para saber si al mover el mouse, 
                                 //si el valor es 2, se crea un nuevo vertice
            {
                case 2: //Creando nuevo nodo
                    if (nuevoNodo != null) //nuevoNodo es una instancia de la clase CVertice, si es diferente de null procedemos a dibujarlo
                    {
                        int posX = e.Location.X;    //Obtenemos la posicion del mouse en un instante (x,y)
                        int posY = e.Location.Y;

                        if (posX < nuevoNodo.Dimensiones.Width / 2) //Verificamos con todas estas condiciones si el espacio en el que se intenta colocar
                            posX = nuevoNodo.Dimensiones.Width / 2; //el vertice es suficiente, o si no se sale del espacio especificado para este
                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;

                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Width / 2;

                        nuevoNodo.Posicion = new Point(posX, posY); //Una vez verificado el espacio creamos un nuevo punto y lo 
                                                                    //pasamos a la clase CVertice como La posicion en la que debe estar el vertice
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics()); //Redibujamos el grafico y mantenemos el valor de la variable de control en 2
                    }
                    break;

                case 1: // En el caso que movamos el mouse y el valor de la variable de control sea 1, entonces Dibujamos un arco
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, false); //instanciamos esta clase para dibujar una flecha
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;
                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.AliceBlue, 2) { CustomEndCap = bigArrow }, NodoOrigen.Posicion, e.Location);
                    break;
            }
        }


        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                { //La funcion DetectarPunto nos devuelve null si el lugar donde se esta dando click
                  //no esta sobre un vertice, es decir que no podra salir de este lugar un arco
                    var_control = 1;
                    // recordemos que es usado para indicar el estado en la pizarra:
                    // 0 -> sin accion, 1 -> Dibujando arco, 2 -> Nuevo vértice
                }

                if (nuevoNodo != null && NodoOrigen == null)
                { //si los valores de nuevoNodo es diferente de null (Este valor cambia cuando damos click en Nuevo vertice en el menu)
                  //y ademas el nodo origen Es igual a null
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    grafo.AgregarVertice(nuevoNodo);          //Llamamos a la funcion agregar vertice perteneciente a la clase CGrafo
                    ventanaVertice.ShowDialog();              //Mostramoso el form que nos pedira el valor del vertice

                    if (ventanaVertice.control) //control el una variable tipo Bool que pertenece al form Vertice
                    {
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text.ToUpper().Trim()) == null) //si ese nodo no existe aun lo creamos
                        {
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text.ToUpper().Trim();
                        }
                        else //si ese nodo ya existe enviamos un error
                        {
                            MessageBox.Show("El Nodo " + ventanaVertice.txtVertice.Text + " ya existe en el " + "grafo", "Error nuevo Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            grafo.EliminarVertice(""); //el vertice se crea o se dibuja desde antes que abramos el form, por lo cual lo eliminamos con esta funcion.
                        }
                    }
                    else
                    {
                        grafo.EliminarVertice("");
                    }

                    nuevoNodo = null; //Dejamos las variables de control en su valor inicial
                    var_control = 0;
                    Pizarra.Refresh();
                }
            }

            // Si se ha presionado el botón derecho del mouse
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (var_control == 0)
                {
                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "Nodo " + NodoOrigen.Valor;
                    }
                    else
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                }
            }
        }

        private void eliminarVerticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaEliminar.Visible = false;
            VentanaEliminar.Econtrol = false;
            VentanaEliminar.ShowDialog();  //Mostramos el Form donde especificaremos el valor del nodo que queremos borrar
            CVertice VerticeOrigen = grafo.BuscarVertice(VentanaEliminar.txtVertice.Text.ToUpper().Trim());
            if (VerticeOrigen != null) //si existe entonces lo eliminamos
            {
                grafo.EliminarVertice(VerticeOrigen); //Para eliminar el vertice llamamos al procedimiento EliminarVerice de la clase CGrafo
                Pizarra.Refresh();
            }
            else //sino existe mostramos un error
            {
                MessageBox.Show("El Nodo " + VentanaEliminar.txtVertice.Text + " No existe en el grafo", "Error Eliminar Nodo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Pizarra.Refresh();
        }

        private void eliminarArcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vEliminarArco.Visible = false;
            vEliminarArco.Econtrol = false;
            vEliminarArco.ShowDialog();
            CVertice eNodoOrigen = grafo.BuscarVertice(vEliminarArco.txtVerticeOrigen.Text.ToUpper().Trim());
            CVertice eNodoDestino = grafo.BuscarVertice(vEliminarArco.txtVerticeDestino.Text.ToUpper().Trim());

            if (eNodoOrigen == null || eNodoDestino == null)
            {
                MessageBox.Show("Este arco no existe", "Error al eliminar de arco");
            }
            else
            {
                try
                {
                    grafo.EliminarArco(eNodoOrigen, eNodoDestino);
                    Pizarra.Refresh();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAncho_Click(object sender, EventArgs e)
        {
            recorridoAnchura();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        // Recorrido en anchura utilizando una cola
        private void recorridoAnchura()
        {
            // Cola para almacenar los nodos a visitar
            Queue<CVertice> cola = new Queue<CVertice>();

            // Lista de nodos Visitados
            List<CVertice> visitados = new List<CVertice>();

            // Nodo actual
            CVertice nodoActual = buscarNodo(txtVerticeOrigen.Text.ToUpper().Trim());

            // Si el nodo no existe, informamos que no se encontro el nodo
            if (nodoActual == null)
            {
                MessageBox.Show("El nodo " + txtVerticeOrigen.Text.ToUpper().Trim() + " no existe en el grafo", "Error al buscar el nodo");
                return;
            }

            // Agregamos el nodo actual a la cola
            cola.Enqueue(nodoActual);

            // Mientras la cola no esté vacía
            while (cola.Count > 0)
            {
                // Sacamos el primer elemento de la cola
                nodoActual = cola.Dequeue();

                if (visitados.Find(v => v.Valor == nodoActual.Valor) == null)
                {
                    // Agregamos el nodo actual a la lista de visitados
                    visitados.Add(nodoActual);
                    nodoActual.Color = Color.Green;
                    Pizarra.Refresh();
                    // Esperamos 2 segundo
                    System.Threading.Thread.Sleep(2000);

                    // Recorremos los nodos adyacentes al nodo actual
                    foreach (CArco arco in nodoActual.ListaAdyacencia)
                    {
                        // Si el nodo adyacente no ha sido visitado
                        if (visitados.Find(v => v.Valor == arco.nDestino.Valor) == null)
                        {
                            CVertice nodoDestino = arco.nDestino;
                            // nodoDestino.Color = Color.Red;
                            // Agregamos el nodo adyacente a la cola
                            cola.Enqueue(arco.nDestino);
                            // Pizarra.Refresh();
                            // esperamos 2 segundos
                            // System.Threading.Thread.Sleep(2000);

                        }
                    }
                }
            }

            // Esperar 2 segundos
            System.Threading.Thread.Sleep(2000);
            // Limpiamos los colores de los nodos
            foreach (CVertice v in visitados)
            {
                v.Color = Color.SlateBlue;
            }
            Pizarra.Refresh();
        }

        // Recorrido en profundidad utilizando una pila
        private void recorridoProfundidad()
        {
            // Pila para almacenar los nodos a visitar
            Stack<CVertice> pila = new Stack<CVertice>();

            // Lista de nodos Visitados
            List<CVertice> visitados = new List<CVertice>();

            // Nodo actual
            CVertice nodoActual = buscarNodo(txtVerticeOrigen.Text.ToUpper().Trim());

            // Si el nodo no existe, informamos que no se encontro el nodo
            if (nodoActual == null)
            {
                MessageBox.Show("El nodo " + txtVerticeOrigen.Text.ToUpper().Trim() + " no existe en el grafo", "Error al buscar el nodo");
                return;
            }

            // Agregamos el nodo actual a la pila
            pila.Push(nodoActual);

            // Mientras la pila no esté vacía
            while (pila.Count > 0)
            {
                // Sacamos el primer elemento de la pila
                nodoActual = pila.Pop();

                if (visitados.Find(v => v.Valor == nodoActual.Valor) == null)
                {
                    // Agregamos el nodo actual a la lista de visitados
                    visitados.Add(nodoActual);
                    nodoActual.Color = Color.Green;
                    Pizarra.Refresh();
                    // Esperamos 2 segundo
                    System.Threading.Thread.Sleep(2000);

                    // Recorremos los nodos adyacentes al nodo actual
                    foreach (CArco arco in nodoActual.ListaAdyacencia)
                    {
                        // Si el nodo adyacente no ha sido visitado
                        if (visitados.Find(v => v.Valor == arco.nDestino.Valor) == null)
                        {
                            CVertice nodoDestino = arco.nDestino;
                            // nodoDestino.Color = Color.Red;
                            // Agregamos el nodo adyacente a la pila
                            pila.Push(arco.nDestino);
                            //Pizarra.Refresh();
                            // esperamos 2 segundos
                            // System.Threading.Thread.Sleep(2000);

                        }
                    }
                }
            }

            // Esperar 2 segundos
            System.Threading.Thread.Sleep(2000);
            // Limpiamos los colores de los nodos
            foreach (CVertice v in visitados)
            {
                v.Color = Color.SlateBlue;
            }
            Pizarra.Refresh();
        }

        private CVertice buscarNodo(string valor)
        {
            return grafo.nodos.Find(v => v.Valor == valor);
        }

        private void btnProfundidad_Click(object sender, EventArgs e)
        {
            recorridoProfundidad();
        }

        private void txtVerticeOrigen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
