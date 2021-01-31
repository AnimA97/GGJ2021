using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMessages
{

    private static string[] policeMessages = new string[] 
    {
        "¡Perro malo!\n¡Busca, busca!",
        "¿Eres un Gato o qué?",
        "Los perros no cobran despido\n¡Así que ponte a trabajar!",
        "¿A eso le llamas olfatear?",
        "¡Hasta Voldemort haría un mejor trabajo olfateando!",
        "No hay palabras que describan lo malo que eres...",
        "¡Olfatea con la nariz no con los ojos!",
        "GRRRRR\n¡Ahora entiendes lo enojado que estoy!",
        "!Creo que alguien con Covid olfatea mejor que tú, perro!"
    };

    public static string OneForPolice()
    {
        return policeMessages[Random.Range(0, policeMessages.Length-1)];
    }

}
