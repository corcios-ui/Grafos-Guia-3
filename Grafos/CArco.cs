using System.Drawing;               //Libreria agregada, para poder dibujar

namespace Grafos
{
    class CArco
    {
        // Atributos
        public CVertice nDestino;   //creamos un objeto llamado nDestino del tipo CVertice el cual representa el nodo destino del arco
        public int peso;            //Esta variable representara el peso del arco
        public float grosor_flecha; //Esta variable nos sirve simplemente para darle un grosor al dibujo de la flecha que haremos
        public Color color;

        // Métodos
        public CArco(CVertice destino) : this(destino, 1)
        {
            this.nDestino = destino;    //constructor cuyo parametro es un dato tipo CVertice el cual almacenamos en la variable nDestino
        }

        public CArco(CVertice destino, int peso)
        {
            this.nDestino = destino;    //Constructor cuyos parametros son un dato de tipo CVertice el cual almacenamos en nDestino y 
            this.peso = peso;           // un dato de tipo entero que representa el peso del arco
            this.grosor_flecha = 2;     //Ademas les damos grosor a la flecha y color
            this.color = Color.LightGray;
        }
    }
}
