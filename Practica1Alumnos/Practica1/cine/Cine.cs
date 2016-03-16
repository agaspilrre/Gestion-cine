using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cine
{
   public class Cine
    {

        //atributos

        private string nombre;
        private Sala[] salas;

        //constructor

        public Cine(string nombre,Sala[]salas)
        {
            this.nombre = nombre;
            this.salas = salas;

        }


        //metodos

        public void comprarEntrada(int sala,int sesion,int fila,int columna)
        {

            salas[sala-1].comprarEntrada(sesion, fila, columna);//en la posicion sala llamo al metodo comprar entrada de Sala y le paso los parametros sesion fila y columna
        }


        public void comprarEntradasRecomendadas(int sala,int sesion,ButacasContiguas butacas)
        {
            salas[sala - 1].comprarEntradasRecomendadas(sesion, butacas);//llamo al metodo comprar entradas de sala y le paso como parametros la sesion y las butacas recibidas

        }


        public int getButacasDisponiblesSesion(int sala,int sesion)
        {
            return salas[sala-1].getButacasDisponiblesSesion(sesion);//en la posicion sala llamo al metodo dela clase Sala y este a su vez al de la clase Sesion para retornar de forma inversa un integer con los asientos disponibles de la sala

        }

        public char[,] getEstadoSesion(int sala, int sesion)
        {

            return salas[sala-1].getEstadoSesion(sesion);//en la posicion sala llama al metodo estadosesion dela clase Sala este metodo llamara asu vez al metodo estado sesion de la clase Sesion y recibiremos de vuelta un array de char

        }

        public string[] getHorasDeSesionesDeSala(int sala)
        {


            return salas[sala-1].getHorasDeSesionesDeSala();//en la sala especificada en la posicion llamo al metodo de Sala para que me devuelva los horarios

      
        }

        public int getIdEntrada(int sala, int sesion, int fila, int columna)
        {

            return salas[sala-1].getIdEntrada(sesion, fila, columna);//en la posicion sala llama al metodo id entrada de Sala y este a su vez llama al metodo identrada de Sesion
        }



        public string[] getPeliculas()
        {
            string[] cartelera=new string[salas.Length] ;//creo array de string cartelera y le doy el tamaño que tiene el array de salas 

            for(int i=0;i<salas.Length;i++)
            {
                //recorro el array salas y en cada una de susposiciones llamo al metodogetpelicula para que me devuelva un string este lo guardo en la posicion de mi array de strings
                 cartelera[i] = salas[i].getPelicula();

            }

            return cartelera;//devuelvo el array de strings con todas las peliculas.
        }


        public string recogerEntradas(int id, int sala, int sesion)
        {

            string entrada = "";

            if (salas[sala - 1].recogerEntradas(id,sesion) == null)

                return null;//si el string que recibo del metodo recogerentradas esta vacio devuelvo un null

            else
            {
                entrada +=  this.nombre + "#" + salas[sala - 1].recogerEntradas(id, sesion);
                return entrada;//si no esta vacio cojo el string que venga y le añado el nombre del cine

            }


        }

        public ButacasContiguas recomendarButacasContiguas(int noButacas,int sala, int sesion)
        {
            return salas[sala-1].recomendarButacasContiguas(noButacas,sesion);//en la posicion del array salas llamo al metodo recomendarbutacasc de la clase sala y lo que me devuelva es lo que devuelve este metodo

        }
















    }
}
