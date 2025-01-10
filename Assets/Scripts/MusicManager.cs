using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null; // Variable estática para almacenar la única instancia del MusicManager
    public static MusicManager Instance
    {
        get { return instance; } // Propiedad que devuelve la instancia del MusicManager
    }

    // Este método se llama al despertar el objeto
    void Awake()
    {
        // Si ya existe una instancia y no es este objeto, destruye este objeto
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Destruye el objeto duplicado
            return;
        }
        else
        {
            instance = this; // Si no existe la instancia, asigna esta como la instancia principal
        }
        DontDestroyOnLoad(this.gameObject); // Evita que este objeto sea destruido al cambiar de escena
    }
}


