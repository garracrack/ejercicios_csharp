// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.Write("Introduce el primer número entero: ");
int numero1 = int.Parse(Console.ReadLine());

Console.Write("Introduce el segundo número entero: ");
int numero2 = int.Parse(Console.ReadLine());

int menor;
int mayor;

if (numero1<numero2)
{
    menor = numero1;
    mayor = numero2;
}
else
{
    menor = numero2;
    mayor = numero1;
}

int cantidadNegativos = 0;
int cantidadPositivos = 0;
int cantidadPares = 0;
int cantidadImpares = 0;
int sumaTotal = 0;

string numerosString = "";
int cantidadDenumeros = mayor - menor + 1;
int[] numerosArray = new int[cantidadDenumeros];
//int[] notas = new int[6];
// notas[5]=10;
int indiceArray = 0;

for(int i = menor; i <= mayor; i++)
{
    // i = -2
    numerosArray[indiceArray] = i;
    
    indiceArray =indiceArray + 1;
    // FORMAS DE INCREMENTAR EL INDICE DEL ARRAY en +1
    //numerosArray[indiceArray++] = i;
    //indiceArray += i;
    //indiceArray++;
    //++indiceArray;

    if(i < 0)
        cantidadNegativos++;
    else if(i > 0)
        cantidadPositivos++;

    if (i % 2 == 0)
        cantidadPares++;
    else
        cantidadImpares++;

    sumaTotal = sumaTotal + i;
    //sumaTotal += i;
}
string cadena="";
for(int j = 0; j < numerosArray.Length; j++)
{
    if(cadena == "")
        cadena = numerosArray[j].ToString();
    else
        cadena = cadena + ", " + numerosArray[j];
}

Console.WriteLine(cadena);
Console.WriteLine("Cantidad de números negativos: " + cantidadNegativos);
Console.WriteLine("Cantidad de números positivos: " + cantidadPositivos);
Console.WriteLine("Cantidad de números pares: " + cantidadPares);
Console.WriteLine("Cantidad de números impares: " + cantidadImpares);
Console.WriteLine("Suma total de los números: " + sumaTotal);

// Ejercicio 9
Console.WriteLine("\n\nEjercicio 9: ");
ejercicio9();

// Ejercicio 15
ejercicio15();
ejercicio15Tuneado();

static void ejercicio9()
{
    Console.Write("Introduce un número entero: ");
    int numero = int.Parse(Console.ReadLine());

    string divisores = "";
    int contadorDivisores = 0;

    for(int i = 1; i <= numero; i++)
    {
        if(numero % i == 0)
        {
            contadorDivisores++;
            if(divisores == "")
                divisores = i.ToString();
            else
                divisores = divisores + ", " + i;
        }
    }

    Console.WriteLine("Cantidad de divisores: " + contadorDivisores);
    Console.WriteLine("Divisores: " + divisores);

}


static void ejercicio15()
{
    Console.Write("Dime el ancho del rectángulo: ");
    int ancho = int.Parse(Console.ReadLine());

    Console.Write("Dime el alto del rectángulo: ");
    int alto = int.Parse(Console.ReadLine());

    Console.WriteLine();

    for(int fila=1; fila<=alto; fila++)
    {
        for(int columna=1; columna<=ancho; columna++)
        {
            if(fila == 1 || fila == alto)
                Console.Write("*");
            else
            {
                if(columna == 1 || columna == ancho)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

}


static void ejercicio15Tuneado()
{

    int ancho = 0;
    while (ancho <= 2) {
        Console.Write("Dime el ancho del rectángulo: ");
        string anchoTexto = Console.ReadLine();

        bool esNumero = int.TryParse(anchoTexto, out ancho);
        if(!esNumero || ancho <= 2) {
            Console.WriteLine("Por favor, introduce un número entero mayor que 2.");
            ancho = 0; // Reiniciar ancho para continuar el bucle
        }

    }




    
    int alto = 0;
    while (alto <= 2)
    {
        Console.Write("Dime el alto del rectángulo: ");
        string altoTexto = Console.ReadLine();

        bool esNumero = true;

        if(altoTexto.Length == 0)
            esNumero = false;
        else
        {
            for(int i = 0; i < altoTexto.Length; i++)
            {
                char c = altoTexto[i];
                if(c!='0' && c!='1' && c!='2' && c!='3' && c!='4' && c!='5' && c!='6' && c!='7' && c!='8' && c!='9')
                {
                    esNumero = false;
                }
            }
        }

        if (esNumero)
        {
            alto = int.Parse(altoTexto);

            if (alto <= 2)
            {
                Console.WriteLine("Por favor, introduce un número entero mayor que 2.");
                alto = 0; // Reiniciar alto para continuar el bucle
            }
        }
        else
        {
            Console.WriteLine("Por favor, introduce un número entero mayor que 2.");
            alto = 0; // Reiniciar alto para continuar el bucle

        }
    }

    Console.WriteLine();

    Console.Write("Dime el caracter con el que quieres dibujar el rectángulo: ");
    string caracter = Console.ReadLine();

    for (int fila = 1; fila <= alto; fila++)
    {
        for (int columna = 1; columna <= ancho; columna++)
        {
            if (fila == 1 || fila == alto)
                Console.Write(caracter);
            else
            {
                if (columna == 1 || columna == ancho)
                    Console.Write(caracter);
                else
                    Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

}