using System.Collections.Generic;
using System.Drawing;           //Libreria agregada, para poder dibujar

namespace Grafos
{
    class CGrafo
    {
        /**
         * Lista de nodos del grafo
         **/
        public List<CVertice> nodos;

        // Constructor
        public CGrafo()
        {
            nodos = new List<CVertice>();
        }

        //=====================Operaciones Básicas=================================
        //Construye un nodo a partir de su valor y lo agrega a la lista de nodos
        public CVertice AgregarVertice(string valor)
        {
            CVertice nodo = new CVertice(valor);
            nodos.Add(nodo);
            return nodo;
        }

        //Agrega un nodo a la lista de nodos del grafo
        public void AgregarVertice(CVertice nuevonodo)
        {
            nodos.Add(nuevonodo);
        }

        //Busca un nodo en la lista de nodos del grafo
        public CVertice BuscarVertice(string valor)
        {
            return nodos.Find(v => v.Valor == valor); // por medio de esta linea recorremos la lista nodos hasta que 
            //encontramos un valor que sea igual a la variable "valor", si existe regresa el nodo sino regresa null
        }

        // Crea la arista a partir de los nodos de origen y de destino
        public bool AgregarArco(CVertice origen, CVertice nDestino, int peso = 0)
        {
            if (origen.ListaAdyacencia.Find(v => v.nDestino == nDestino) == null)
            {
                origen.ListaAdyacencia.Add(new CArco(nDestino, peso)); //si ese arco aun no existe se crea uno nuevo
                return true;
            }
            return false;
        }

        //Busca un nodo y si existe lo elimina
        public void EliminarVertice(CVertice Evalor)
        {
            if (Evalor != null)
            {//si la encontramos el nodo lo removemos de la lista, al re-dibujar el grafo ya no aparece el nodo
                nodos.Remove(Evalor);
                EliminarArco(Evalor);
            }
        }

        //Busca un nodo y si existe lo elimina
        public void EliminarVertice(string sEvalor)
        {
            if (this.BuscarVertice(sEvalor) != null)
            {//si la encontramos el nodo lo removemos de la lista, al re-dibujar el grafo ya no aparece el nodo
                nodos.Remove(this.BuscarVertice(sEvalor));
            }
        }

        //Busca un arco y si existe lo elimina
        public void EliminarArco(CVertice Nodo)
        {
            foreach (CVertice esteNodo in nodos)
            {//si la encontramos el nodo que es el de origen con el nodo que tiene de destino este lo 
                this.EliminarArco(esteNodo, Nodo);
            }
        }

        public void EliminarArco(CVertice nOrigen, CVertice nDestino)
        {
            CArco nuevoArco = nOrigen.ListaAdyacencia.Find(d => d.nDestino == nDestino);
            nOrigen.ListaAdyacencia.Remove(nuevoArco);
        }

        public void ColorearNodo(string valorEscogido)
        {
            CVertice nodoEscogido = this.BuscarVertice(valorEscogido);
            nodoEscogido.Color = Color.SlateBlue;
        }

        public void ReestablecerColorNodo(string valorEscogido)
        {
            CVertice nodoEscogido = this.BuscarVertice(valorEscogido);
            nodoEscogido.Color = Color.LightBlue;
        }

        // Método para dibujar el grafo
        public void DibujarGrafo(Graphics g)
        {
            // Dibujando los arcos
            foreach (CVertice nodo in nodos)
                nodo.DibujarArco(g);

            // Dibujando los vértices
            foreach (CVertice nodo in nodos)
                nodo.DibujarVertice(g);
        }

        // Método para detectar si se ha posicionado sobre algún nodo y lo devuelve
        public CVertice DetectarPunto(Point posicionMouse)
        { //Esta funcion es de tipo CVertice por lo que devuelve un dato del mismo tipo
            foreach (CVertice nodoActual in nodos)
                if (nodoActual.DetectarPunto(posicionMouse)) return nodoActual;
            return null;
        }

        //Metodo para regresar al estado original
        public void ReestablecerGrafo(Graphics g)
        {
            foreach (CVertice nodo in nodos)
            {
                nodo.Color = Color.White;
                nodo.FontColor = Color.White;
                foreach (CArco arco in nodo.ListaAdyacencia)
                {
                    arco.grosor_flecha = 1;
                    arco.color = Color.White;
                }
            }
            DibujarGrafo(g);
        }

    }
}
