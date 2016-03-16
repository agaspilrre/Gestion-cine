using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cine
{
   public class Sala
    {

        //atributos
        private string pelicula;
        private Sesion[] sesiones;


        //constructor

        public Sala(string pelicula,string[]horasSesiones,int filas,int columnas)
        {
            this.pelicula = pelicula;
           // al array sesiones le doy el tamaño que tiene el array que le paso de string
           //recorro el array y en cada posicion inicializo el objeto y le paso la hora que tiene la posicion i en horassesiones y las filas y columnas
            this.sesiones = new Sesion[horasSesiones.Length];
            for (int i = 0; i < sesiones.Length; i++)
            {

                sesiones[i] = new Sesion(horasSesiones[i],filas, columnas);
            }
        }


        //metodos

        public void comprarEntrada(int sesion,int fila,int columna)
        {

            sesiones[sesion-1].comprarEntrada(fila, columna);//en la posicion de sesion llamo al metodo comprar entrada de Sesion y le pasola fila y columna
        }


        public void comprarEntradasRecomendadas(int sesion,ButacasContiguas butacas)
        {

            sesiones[sesion - 1].comprarEntradasRecomendadas(butacas);//en la posicion de sesion llamo al metodocomprar entradasrecomendadas y le paso las butacas como parametro

        }


        public int getButacasDisponiblesSesion(int sesion)
        {

            return sesiones[sesion-1].getButacasDisponiblesSesion();//en la posicion sesion llamo al metodo de la clase Sesion y este me devuelve un integer con los asientos disponibles a su vez con esta funcion lo devolvemos a cine
        }


        public char[,] getEstadoSesion(int sesion)
        {

            return sesiones[sesion-1].getEstadoSesion();//en la posicion sesion indicada llama al metodo estadosesion de la clase Sesion que nos devuelve un array char.
        }

        public string[] getHorasDeSesionesDeSala()
        {
            string[] horarios = new string[sesiones.Length];//creo array de string y lo inicializo con el tamaño que tiene el array de sesiones para que tengan el mismo tamaño


            for(int i=0;i<sesiones.Length;i++)
            {
                //recorro el array sesiones y en cada una de sus posiciones llamo al metodogethora y el string que obtengo lo guardo en la posicion de horarios
                horarios[i]=sesiones[i].getHora();

            }


            return horarios;//devuelvo el array de strings horarios

        }


        public int getIdEntrada(int sesion,int fila,int columna)
        {

            return sesiones[sesion-1].getIdEntrada(fila, columna);//en la posicion sesion llama al metodo identrada de Sesion y devuelve la ejecucion de dicho codigo
        }


        public string getPelicula()
        {

            return this.pelicula;//retorna la pelicula de la sala
        }


        public string recogerEntradas(int id,int sesion)
        {

            string entrada = "";

            if (sesiones[sesion - 1].recogerEntradas(id) == null)

                return null;//si el string que recibo de llamar al metodo recogerentradas de la clase sesion esta vacio retorno un null

            else
            {
                entrada +=  this.pelicula + "#" + sesiones[sesion - 1].recogerEntradas(id);
                return entrada;//si el string llega con contenido le añado el titulo de la pelicula y retorno entrada

            }
               

        }

        public ButacasContiguas recomendarButacasContiguas(int noButacas, int sesion)
        {
            return sesiones[sesion-1].recomendarButacasContiguas(noButacas);//en la posicion sesion llamo al metodo rbc de la clase sesion y le paso el numero de butacas y lo que reciba al llamar este metodo se la retorno a la clase cine

        }
































    }
}
