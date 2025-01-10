using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    [SerializeField] private float maximoVida; // Vida máxima del jugador
    [SerializeField] private float vida; // Vida actual del jugador
    [SerializeField] private BarraDeVida barraDeVida; // Referencia a la barra de vida del jugador

    // Este método se ejecuta al inicio del juego
    private void Start()
    {
        vida = maximoVida; // Inicializa la vida del jugador con el valor máximo
        barraDeVida.InicializarBarraDeVida(vida); // Inicializa la barra de vida con el valor actual de vida
    }

    // Método para que el jugador tome daño
    public void TomarDaño(int daño)
    {
        vida -= daño; // Reduce la vida del jugador
        barraDeVida.CambiarVidaActual(vida); // Actualiza la barra de vida

        // Si la vida es menor o igual a 0, reinicia la escena (muere el jugador)
        if (vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
        }
    }
}


