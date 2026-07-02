static int Ejercicio1(params int[] numeros)
{
    if(numeros.Length == 0)
        return 0;

    int maximo = numeros[0];
    for(int i = 1; i < numeros.Length; i++)
        if(numeros[i] > maximo)
            maximo = numeros[i];
    return maximo;
}

static int Ejercicio2(string cadena, string subcadena) {
    int cantidad = 0;
    int posicion = 0;

    while (posicion != -1)
    {
        posicion = cadena.IndexOf(subcadena, posicion);
        if (posicion != -1)
        {
            cantidad++;
            posicion++;
        }
    }
    return cantidad;
}

static double Ejercicio4(string cadena)
{
    string[] numerosArray = cadena.Split(';');

    double suma = 0;

    foreach (string numero in numerosArray)
        suma += double.Parse(numero);

    return suma / numerosArray.Length;
}

/*
int[] arrayNumeros = {3, 5, 17, 2, 8};
Console.WriteLine($"El número máximo es: {Ejercicio1(arrayNumeros)}");
int[] arrayNumeros2 = new int[10];
Console.WriteLine($"El número máximo es: {Ejercicio1(arrayNumeros2)}");

Console.WriteLine($"El número máximo es: {Ejercicio1(8,3,5,65,23,12,3)}");


int c = Ejercicio2("Hola, ¿cómo estás? Hola, ¿qué tal?, Hola", "a");
Console.WriteLine($"La subcadena 'Hola' aparece {c} veces en la cadena");

*/

Console.WriteLine($"La media de los números es: {Ejercicio4("3;5;17;2;8")}");