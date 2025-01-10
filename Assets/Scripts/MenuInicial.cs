using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuInicial : MonoBehaviour
{
    // Método que se llama cuando el jugador presiona el botón "Jugar"
    public void Jugar()
    {
        // Carga la siguiente escena en la lista de escenas del build
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método que se llama cuando el jugador presiona el botón "Salir"
    public void Salir()
    {
        Debug.Log("Salir"); // Muestra en la consola que se presionó el botón "Salir"

#if UNITY_EDITOR
        // Si el juego se está ejecutando en el editor de Unity, se detiene la simulación
        EditorApplication.isPlaying = false;
#else
        // Si el juego no se está ejecutando en el editor (es un build), cierra la aplicación
        Application.Quit();
#endif
    }
}






