using System;

namespace mutantDetector
{
    class Program
    {
        public static Boolean IsMutant(string[] adn)
        {
            // Se obtiene el tamaño de la cadena de ADN
            int longitud = adn[0].Length;
            // Se define la matriz que albergará las secuencias de ADN
            string[,] adnMatriz = new string[longitud, longitud];
            // Se pobla la matriz
            for (int fila = 0; fila < longitud; fila++)
            {
                for (int columna = 0; columna < longitud; columna++)
                {
                    // Se debería validar que el valor de la secuencia corresponda a los valores válidos de la base nitrogenada del ADN

                    adnMatriz[fila, columna] = adn[fila].Substring(columna, 1);
                }
            }
            //Console.WriteLine("Matriz[0,4]: " + adnMatriz[0, 4]);
            //Console.WriteLine("Matriz[1,4]: " + adnMatriz[1, 4]);
            //Console.WriteLine("Matriz[2,4]: " + adnMatriz[2, 4]);
            //Console.WriteLine("Matriz[3,4]: " + adnMatriz[3, 4]);
            //Console.WriteLine("Matriz[4,4]: " + adnMatriz[4, 4]);
            //Console.WriteLine("Matriz[5,4]: " + adnMatriz[5, 4]);

            // Iniciamos la validación de la secuencia de ADN
            for (int fila = 0; fila < longitud - 3; fila++)
                for (int columna = 0; columna < longitud; columna++)
                {
                    // Evaluación oblícua de la secuencia de ADN
                    if ((adnMatriz[fila, fila].Equals(adnMatriz[fila + 1, fila + 1])) & (adnMatriz[fila, fila].Equals(adnMatriz[fila + 2, fila + 2])) & (adnMatriz[fila, fila].Equals(adnMatriz[fila + 3, fila + 3])))
                        return true;

                    // Evaluación vertical de la secuencia de ADN
                    if ((adnMatriz[fila, columna].Equals(adnMatriz[fila + 1, columna])) & (adnMatriz[fila, columna].Equals(adnMatriz[fila + 2, columna])) & (adnMatriz[fila, columna].Equals(adnMatriz[fila + 3, columna])))
                        return true;

                    // Evaluación horizontal de la secuencia de ADN
                    if ((adnMatriz[columna, fila].Equals(adnMatriz[columna, fila + 1])) & (adnMatriz[columna, fila].Equals(adnMatriz[columna, fila + 2])) & (adnMatriz[columna, fila].Equals(adnMatriz[columna, fila + 3])))
                        return true;
                }

                return false;
        }

        static void Main(string[] args)
        {
            //string AdnImput = new string("ATGCGA,CCGTGC,TTATGT,AGAAGG,CCCCAA,TCACTA");
            string AdnImput = new string("ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG"); //Mutante
            //string AdnImput = new string("ATGCGA,CAGTGC,TTATTT,AGACGG,CCGTCA,TCACTG"); //No Mutante
            string[] adnArray = AdnImput.Split(',');
            Console.WriteLine("Secuencia 1: " + adnArray[0]);
            Console.WriteLine("Secuencia 2: " + adnArray[1]);
            Console.WriteLine("Secuencia 3: " + adnArray[2]);
            Console.WriteLine("Secuencia 4: " + adnArray[3]);
            Console.WriteLine("Secuencia 5: " + adnArray[4]);
            Console.WriteLine("Secuencia 6: " + adnArray[5]);
            bool resultadoAdn = IsMutant(adnArray);
            Console.WriteLine("Es Mutante?: " + resultadoAdn.ToString());
        }

        
    }
}
