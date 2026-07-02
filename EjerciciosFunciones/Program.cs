static void Ejercicio1()
{
    for(int i = 1; i <= 20; i++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

static void Ejercicio2(string cadena, int inferior=1, int superior=10)
{
    if(cadena.Length >= inferior && cadena.Length <= superior)
        Console.WriteLine("La cadena está en el rango.");
    else
        Console.WriteLine("La cadena NO está en el rango.");
}

static void Ejercicio3(int peque=0, int grande=20)
{
    if(peque > grande)
    {
        Console.WriteLine("El valor de 'peque' no puede ser mayor que 'grande'.");
        return;
    }

    for (int i = peque; i <= grande; i++)
        Console.Write(i+" ");
    Console.WriteLine();
}

static void Ejercicio5(string nombre, params string[] trabajos)
{
    Console.WriteLine($"Nombre: {nombre}");
    if(trabajos.Length == 0)
        Console.WriteLine("No ha trabajado nunca.");
    else
    {
        Console.WriteLine("Trabajos realizados:");
        foreach (string trabajo in trabajos)
            Console.WriteLine($"- {trabajo}");
    }
}

static bool Ejercicio6(ref int numero)
{
    if (numero <= 1)
        return false;
    for(int i = 2; i < numero; i++)
        if(numero % i == 0)
        {
            numero = -1;
            return false;
        }
            
    return true;
}

static double Ejercicio7(int[] numeros)
{
    int suma = 0;
    foreach(int numero in numeros)
        suma += numero;
    return (double)suma / numeros.Length;
}


static string PalabraAzar(string[] palabras)
{
    Random random = new Random();
    int indice = random.Next(0, palabras.Length);
    return palabras[indice];
}

static void Ejercicio8()
{
    string[] palabras = { "manzana", "banana", "cereza", "durazno", "frambuesa" };
    int intentos = 3;
    bool adivina = false;
    string palabraSecreta = PalabraAzar(palabras);

    for (int i = 0; i < intentos; i++)
    {

        //Console.WriteLine("Adivina la palabra secreta que empieza por las letras "+palabraSecreta[0]+ palabraSecreta[1]+palabraSecreta[2]);
        Console.WriteLine("Adivina la palabra secreta que empieza por las letras " + palabraSecreta.Substring(0,3));

        Console.WriteLine($"Intento {i + 1}/{intentos}: Ingresa tu adivinanza:");
        string respuesta = Console.ReadLine();

        if(respuesta.ToUpper() == palabraSecreta.ToUpper())
        {
            Console.WriteLine("¡Correcto! Has adivinado la palabra secreta.");
            adivina = true;
            return;
        }
        else
            Console.WriteLine("Incorrecto. Intenta de nuevo.");
    }
    if(!adivina)
        Console.WriteLine("Has agotado tus intentos. La palabra secreta era: " + palabraSecreta);
}

/*
Ejercicio1();
Ejercicio1();
Ejercicio1();

Ejercicio2("Pablo", 8, 10);// NO ESTA EN RANGO
Ejercicio2("Pablo", 2, 10);// SI ESTA EN RANGO
Ejercicio2(inferior: 2, cadena: "Hola que tal", superior: 10);// SI ESTA EN RANGO
Ejercicio2("TEXTO");

Ejercicio3();
Ejercicio3(80, 100);
Ejercicio3(10);
Ejercicio3(grande: 5);
Ejercicio3(10, 2);


Ejercicio5("Pablo", "Programador", "Diseñador", "Tester");
Ejercicio5("Alazne");
Ejercicio5("Tiago", "Ingenieria");



if(Ejercicio6(19))    
    Console.WriteLine("El número 19 es primo.");
else
    Console.WriteLine("El número 19 NO es primo.");
if (Ejercicio6(30))
    Console.WriteLine("El número 30 es primo.");
else
    Console.WriteLine("El número 30 NO es primo.");



int[] numeros = { 4, 7};
Console.WriteLine($"La media de los números es: {Ejercicio7(numeros)}");

*/
int num = 30;
if (Ejercicio6(ref num))
    Console.WriteLine("El número 30 es primo.");
else
    Console.WriteLine("El número 30 NO es primo.");

Console.WriteLine("El valor del num es: " + num);

//Ejercicio8();

static int Ejercicio9(int[] numeros, out int primero, out int ultimo)
{
    int maximo = numeros[0];
    foreach(int numero in numeros)
        if(numero > maximo)
            maximo = numero;
    primero = numeros[0];
    ultimo = numeros[numeros.Length - 1];

    return maximo;
}

int[] numeros = { 4, 7, 2, 9, 1 };
int x, y;
int max = Ejercicio9(numeros, out x, out y);

//enum meses { Enero = 1, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre };

Console.WriteLine($"El maximo es {max}, el primer número es: {x} y el último es: {y}");