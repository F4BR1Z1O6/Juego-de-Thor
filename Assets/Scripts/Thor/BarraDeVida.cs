using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider; // Referencia al componente Slider que representa la barra de vida

    // Este método se llama cuando el script empieza
    private void Start()
    {
        // Obtiene el componente Slider que debe estar adjunto al mismo GameObject
        slider = GetComponent<Slider>();
    }

    // Método para cambiar el valor máximo de la barra de vida (por ejemplo, cuando el jugador sube de nivel)
    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima; // Establece el valor máximo de la barra de vida
    }

    // Método para cambiar la vida actual del jugador (la barra se ajusta según esta cantidad)
    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida; // Establece el valor actual de la barra de vida
    }

    // Método para inicializar la barra de vida, estableciendo tanto el valor máximo como el valor actual
    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida); // Establece el valor máximo de la vida
        CambiarVidaActual(cantidadVida); // Establece la vida actual igual a la vida máxima al principio
    }
}

