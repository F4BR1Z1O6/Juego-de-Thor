using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuInicial : MonoBehaviour
{
    // M�todo que se llama cuando el jugador presiona el bot�n "Jugar"
    public void Jugar()
    {
        // Carga la siguiente escena en la lista de escenas del build
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // M�todo que se llama cuando el jugador presiona el bot�n "Salir"
    public void Salir()
    {
        Debug.Log("Salir"); // Muestra en la consola que se presion� el bot�n "Salir"

#if UNITY_EDITOR
        // Si el juego se est� ejecutando en el editor de Unity, se detiene la simulaci�n
        EditorApplication.isPlaying = false;
#else
        // Si el juego no se est� ejecutando en el editor (es un build), cierra la aplicaci�n
        Application.Quit();
#endif
    }
}






