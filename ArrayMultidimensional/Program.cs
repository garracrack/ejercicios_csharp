namespace ArrayMultidimensional
{
    internal class Program
    {


        
        static void ejemploMultidimensional()
        {
            int[,] notas = new int[3, 4] { { 10, 9, 8, 7 }, { 6, 5, 4, 3 }, { 2, 4, 0, 6 } };

            for (int i = 0; i < notas.GetLength(0); i++) //alumnos
            {
                for (int j = 0; j < notas.GetLength(1); j++)//notas de cada alumno
                {
                    Console.WriteLine($"Notas[{i},{j}] = {notas[i, j]}");
                }
            }

        }
        static void Ejercicio4()
        {
            string [] nombres = new string[5] { "Juan", "Pedro", "Maria", "Ana", "Luis" };
            int[,] notas = new int[5, 4] { { 10, 9, 8, 7 }, { 6, 5, 4, 3 }, { 2, 4, 0, 6 }, { 8, 7, 6, 5 }, { 9, 8, 7, 6 } };
        
        
            for(int i=0; i < nombres.Length; i++)
            {
                int suma = 0;
                for(int j=0; j < notas.GetLength(1); j++)
                    suma=suma + notas[i,j];
                double media = (double)suma / notas.GetLength(1);
                Console.WriteLine($"El alumno {nombres[i]} tiene una nota media de {media}");
            }

        }
        static void Ejercicio5()
        {
            Console.Write("Dime cuantos alumnos quieres");
            int cantidadAlumnos= int.Parse(Console.ReadLine());

            string[] nombres = new string[cantidadAlumnos];
            int[][] notas = new int[nombres.Length][];

            for (int i = 0; i < nombres.Length; i++)
            {
                Console.Write("Dame el nombre del alumno " + (i + 1) + ": ");
                nombres[i] = Console.ReadLine();

                int suma = 0;
                for (int j = 0; j < 4; j++)
                {
                    notas[i] = new int[4];
                    Console.Write("Dame la nota "+(j+1)+" del alumno " + (i + 1) + ": ");
                    notas[i][j] = int.Parse(Console.ReadLine());
                    suma = suma + notas[i][j];
                }
                double media = (double)suma / 4;
                Console.WriteLine($"El alumno {nombres[i]} tiene una nota media de {media}");
            }

        }
        static void ejemploEscalonado()
        {
            int[][] notas = new int[3][];

            int[] notasAlumno1 = { 10, 9, 8, 7 };
            int[] notasAlumno2 = { 6, 4, 3 };
            int[] notasAlumno3 = { 2, 4 };

            for (int i = 0; i < notas.Length; i++) //alumnos
            {
                for (int j = 0; j < notas[i].Length; j++)//notas de cada alumno
                {
                    Console.WriteLine($"Notas[{i},{j}] = {notas[i][j]}");
                }
            }

        }

        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese un nombre: ");
            string nombre = Console.ReadLine();
            int contadorVocales = 0;

            for (int i = 0; i < nombre.Length; i++)
                if (nombre[i].ToString().ToUpper() == "A" || nombre[i].ToString().ToUpper() == "E"
                    || nombre[i].ToString().ToUpper() == "I" || nombre[i].ToString().ToUpper() == "O"
                    || nombre[i].ToString().ToUpper() == "U")
                {
                    Console.Write(nombre[i] + " ");
                    contadorVocales++;
                }
            Console.WriteLine($"\nCantidad de vocales: {contadorVocales}");
        }

        static void Ejercicio3(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Debe ingresar dos parametros para el programa");
                return;
            }

            int parametro1;
            int parametro2;

            bool esNumero = int.TryParse(args[0], out parametro1);
            if (!esNumero)
            {
                Console.WriteLine("El primer parametro debe ser un numero");
                return;
            }
            esNumero = int.TryParse(args[1], out parametro2);
            if (!esNumero)
            {
                Console.WriteLine("El segundo parametro debe ser un numero");
                return;
            }
            Console.WriteLine("La suma de los parámetros es: " + (parametro1 + parametro2));
        }

        static void Main(string[] args)
        {

            // See https://aka.ms/new-console-template for more information
            //using System.Net.NetworkInformation;

            //ejemploMultidimensional()
            //ejemploEscalonado()
            //Ejercicio2();
            //Ejercicio3(args);
            Ejercicio4();
            Ejercicio5();


        }
    }

}



