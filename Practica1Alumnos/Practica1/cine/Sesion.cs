using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cine
{
   public class Sesion
    {

        //atributos
        private int asientosDisponibles;
        private int[,] estadoAsientos;
        private string hora;
        private int sigIdCompra;

        private char[,] ocupacion;//array que usare para la funcion getEstadoSesion


        //constructor

        public Sesion(string hora, int filas, int columnas)
        {
            this.hora = hora;
            this.estadoAsientos = new int[filas, columnas];
            this.sigIdCompra = 1;
            

            this.asientosDisponibles = estadoAsientos.Length;//le doy el tamaño del array de estadoAsientos a asientos disponibles ya que al principio el cine estara vacio y por lo tanto todos los asientos disponibles sera el tamaño que tenga el array que le pase
            this.ocupacion = new char[filas, columnas];//inicializo el array ocupacion con las mismas filas y columnas que me pasen como parametro el constructor y asi tendra el mismo tamaño que el array estado asientos

        }

        //metodos

        public string getHora()
        {

            return this.hora;//devuelve la hora de la sesion especificada
        }

        /*
        private ButacasContiguas buscarButacasContiguasEnFila(int fila, int noButacas)
        {
            return null;
            //no implimentado
        }
        */

        public void comprarEntrada(int fila, int columna)
        {

            estadoAsientos[fila - 1, columna - 1] = sigIdCompra;//guardo el int sigcompra en la posicion especificada del array
            asientosDisponibles--;//decremento los asientos disponibles que me quedan.
            sigIdCompra++;//incremento el codigo de compra en uno


        }


        public void comprarEntradasRecomendadas(ButacasContiguas butacas)
        {
            int i, j;
            //empiezo el bucle en la posicion i le doy la fila que tiene el objeto guardada y en la j le paso la columna
            for ( i = butacas.getFila(), j = butacas.getColumna();j <= butacas.getNoButacas();j++)
            {
                estadoAsientos[i-1, j-1] = this.sigIdCompra;
                //recorro las columnas desde lasposiciones indicadas por el objeto y voy guardando los sigIdcompra en cada posicion
                asientosDisponibles--;
                //decremento asientos disponibles por cada posicion que le asigno indicador de compra
            }


            this.sigIdCompra++;//incremento el indicador de compra

        }

        public int getButacasDisponiblesSesion()
        {
           

            return asientosDisponibles;//devuelve los asientos disponibles
        }

        public char[,] getEstadoSesion()
        {
            //recorro todas las posiciones del array estadoAsientos si la posicion contiene un cero en la misma posicion del array ocupacion guarda la letra O si no guarda la letra X
            for(int i=0;i<estadoAsientos.GetLength(0);i++)
            {
                for(int j=0;j<estadoAsientos.GetLength(1);j++)
                {
                    if (estadoAsientos[i, j] == 0)
                        ocupacion[i, j] = 'O';

                    
                        

                    else
                        ocupacion[i, j] = 'X';

                }

            }

            return ocupacion;//devuelvo el array ocupacion

        }

        public int getIdEntrada(int fila, int columna)
        {


            return estadoAsientos[fila - 1, columna - 1];//devuelve si hay algun codigo guardado de compra en las posiciones registradas

        }

        public string recogerEntradas(int id)
        {
            
            string entrada = null;

            int contador=0;

            //recorro el array estadoAsientos si en alguna de sus posiciones encuentra el mismo numero de identificador que pasamos en el argumento nos devuelve un string con los datos de la entrada, si no devuelve un null
            for (int i = 0; i < estadoAsientos.GetLength(0); i++)
            {
                for (int j = 0; j < estadoAsientos.GetLength(1); j++)
                {
                    if (estadoAsientos[i, j] == id)
                    {

                        if(contador>0)
                            entrada += "--" + (i + 1) + "," + (j + 1);
                        //si se mete una segunda vez en el i el contador ya sera mayor de cero y ejecutara el codigo de este if que añade la nueva fila y columna en la posicion que este el bucle

                        else
                        entrada +=   this.hora + "--" + (i+1)
                        + ","+ (j+1);

                        contador++;//incrementa el contador cuando se mete en este if
                    }

                    
                       
                }

            }





            return entrada;

        }

        public ButacasContiguas recomendarButacasContiguas(int noButacas)
        {

            int contador;
            ButacasContiguas bContiguas;
            int i;
            //recorro el array pero empiezo desde una fila mas de la mitad
            for ( i = (estadoAsientos.GetLength(0)+1) / 2; i < estadoAsientos.GetLength(0); i++)
            {
                contador = 0;//cada vez que salga del bucle inferior el contador se pondra a cero de nuevo para que nos cuente bien las butacas contiguas de una misma fila y no sume con otras filas

                for(int j=0;j<estadoAsientos.GetLength(1);j++)
                {
                    //si los asientos estan vacios incremento el contador si en la siguiente vuelta no encuentra un asiento vacio entonces se mete en el else y pone el contador a cero de nuevo ya que queremos butacas juntas
                    if (estadoAsientos[i, j] == 0)
                        contador++;
                    else
                        contador = 0;

                    if(contador==noButacas)
                    {
                        //si el contador llega a ser igual que el numero de butacas que recibe como parametro entonces devuelvo la posicion desde la cual empezo a contar el contador y para ello le resto el numero de butacas y le sumo dos para anular el numero negativo 
                        return  bContiguas = new ButacasContiguas(i+1,(j-noButacas+2),noButacas);

                    }

                }

            }

            //si salimos del bucle sera porque no ha retornado nada entonces comenzaremos a recorrer el array desde la mitad de las filas y ahora de manera inversa, decrementando para asi ir registrando desde la mitad hacia las primeras filas

            for (i = estadoAsientos.GetLength(0) / 2; i >= 0; i--)
            {
                contador = 0;//hago la misma operacion con las posiciones de columna que hice en el bucle anterior

                for (int j = 0; j < estadoAsientos.GetLength(1); j++)
                {

                    if (estadoAsientos[i, j] == 0)
                        contador++;
                    else
                        contador = 0;
                    if (contador == noButacas)
                    {
                        return bContiguas = new ButacasContiguas(i+1, (j - noButacas+2), noButacas);

                    }


                }

            }
                

            //si no encuentra las butacas contiguas saldra del bucle y nos devolvera un null.

          
            return null;
            


        }




















    }
}
