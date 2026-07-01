// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Hello, World!");

int x = 5;
string ciudad = "Alicante";
float y = 3.14f;


int nota1 = 8;
int nota2 = 7;
int nota3 = 9;
int nota4 = 10;

//int[] notas = new int[4];
int[] notas = {8,7,9,10};
/*
notas[0] = 8;
notas[1] = 7;
notas[2] = 9;
notas[3] = 10;

for (int i = 0; i < notas.Length; i++)
{
    Console.Write("Dame la nota "+(i+1)+": ");
    notas[i] = Convert.ToInt32(Console.ReadLine());
}


Console.Write("nota 1" + nota1);
Console.Write("nota 2" + nota2);
Console.Write("nota 3" + nota3);
Console.Write("nota 4" + nota4);
Console.Write("nota 5" + nota5);
... hasta 300
*/

for(int i = 0; i < notas.Length; i++)
{
    Console.WriteLine("nota " + (i+1) + ": " + notas[i]);
}

foreach(int nota in notas)
{
    Console.WriteLine("nota: " + nota);
}


string[] nombre = new string[5];

//Ejercicio3();
//Ejercicio4();
//Ejercicio5();
//Ejercicio6();
//Ejercicio7();
Ejercicio8();

static void Ejercicio3()
{
    double[] numeros = new double[10];
    double suma = 0;

    for (int i = 0; i < numeros.Length; i++)
    {
        Console.Write("Dame el número " + (i + 1) + ": ");
        numeros[i] = Convert.ToDouble(Console.ReadLine());
        suma += numeros[i];
    }

    double media = suma / numeros.Length;

    Console.WriteLine("La media de los números es: " + media);

    for (int i = 0; i < numeros.Length; i++)
        if (numeros[i] > media)
            Console.WriteLine("Número mayor que la media: " + numeros[i]);

}

static void Ejercicio4()
{
    int[] numeros = {31,28,31,30,31,30,31,31,30,31,30,31};

    Console.Write("Introduce el mes (1-12): ");
    int mes = int.Parse(Console.ReadLine());

    Console.Write("Introduce el día: ");
    int dia = int.Parse(Console.ReadLine());

    int cantidadDias = 0;

    for(int i = 0; i < mes - 1; i++)
        cantidadDias += numeros[i];

    cantidadDias += dia;

    Console.Write("El día " + dia + " del mes " + mes + " es el día número " + cantidadDias + " del año.");
}

static void Ejercicio5()
{

    bool esNumero = false;
    int cantidad = -1;
    while (!esNumero || cantidad <= 0)
    {
        Console.Write("¿Cuántos alumnos hay en total?");
        //int cantidad = int.Parse(Console.ReadLine());
        string cantidadString = Console.ReadLine();
      
        esNumero = int.TryParse(cantidadString, out cantidad);

        if (!esNumero || cantidad <= 0)
            Console.WriteLine("Por favor, introduce un número válido mayor que 0.");

    }



    string[] nombres = new string[cantidad];
    int[] notas = new int[cantidad];



    for (int i = 0; i < cantidad; i++)
    {
        Console.Write("Dame el nombre del alumno " + (i + 1) + ": ");
        nombres[i] = Console.ReadLine();
        Console.Write("Dame la nota del alumno " + (i + 1) + ": ");
        notas[i] = int.Parse(Console.ReadLine());
    }

    for (int i = 0; i < cantidad; i++)
    {
        Console.WriteLine("Alumno: " + nombres[i] + ", Nota: " + notas[i]);
    }

    int indice = 0;
    foreach (string nombre in nombres)
    {
        Console.WriteLine("Alumno: " + nombre + ", Nota: " + notas[indice]);
        indice++;
    }

}

static void Ejercicio6()
{
    int numero = 0;
    bool esNumero = false;
    while (!esNumero || numero < 2 || numero>10)
    {
        Console.Write("¿Dime qué tabla de multiplicar quieres?");
        
        string cantidadString = Console.ReadLine();

        esNumero = int.TryParse(cantidadString, out numero);

        if (!esNumero || numero < 2 || numero > 10)
            Console.WriteLine("Por favor, introduce un número válido entre 2 y 10.");

    }
    //int numero = int.Parse(Console.ReadLine());

    int[] tablaMultiplicar = new int[10];

    for(int i = 0; i < tablaMultiplicar.Length; i++)
        tablaMultiplicar[i] = numero * (i + 1);

    for (int i = 0; i < tablaMultiplicar.Length; i++)
        Console.WriteLine(numero + " x " + (i + 1) + " = " + tablaMultiplicar[i]);
        /*
            6 x 1 = 6
            6 x 2 = 12 
            6 x 3 = 18
            ....
        */


}

static void Ejercicio7()
{
    int[] array1 = new int[10] {5,6,4,7,5,8,9,6,4,10};
    int[] array2 = { 15, 4, 7, 5, 80, 9, 6, 4, 10, 25 };

    int[] array3 = new int[10];

    for(int i= 0; i < array1.Length; i++)
        array3[i] = array1[i] + array2[i];

    foreach(int numero in array3)
        Console.Write(numero+" ");
    Console.WriteLine();
}

static void Ejercicio8()
{
    string contrasena = "";

    while(contrasena.Length != 8)
    {
        Console.Write("Introduce una contraseña de 8 caracteres: ");
        contrasena = Console.ReadLine();
        if(contrasena.Length != 8)
            Console.WriteLine("La contraseña debe tener exactamente 8 caracteres. Inténtalo de nuevo.");
    }


    string contrasenaInvertida = "";
    for(int i = contrasena.Length - 1; i >= 0; i--)
        contrasenaInvertida = contrasenaInvertida + contrasena[i];

    contrasenaInvertida = "";
    for (int i= 0; i < contrasena.Length; i++)
        contrasenaInvertida = contrasena[i] + contrasenaInvertida;

    Console.WriteLine("Contraseña invertida: " + contrasenaInvertida);

}