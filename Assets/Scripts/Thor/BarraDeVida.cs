using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider; // Referencia al componente Slider que representa la barra de vida

    // Este m�todo se llama cuando el script empieza
    private void Start()
    {
        // Obtiene el componente Slider que debe estar adjunto al mismo GameObject
        slider = GetComponent<Slider>();
    }

    // M�todo para cambiar el valor m�ximo de la barra de vida (por ejemplo, cuando el jugador sube de nivel)
    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima; // Establece el valor m�ximo de la barra de vida
    }

    // M�todo para cambiar la vida actual del jugador (la barra se ajusta seg�n esta cantidad)
    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida; // Establece el valor actual de la barra de vida
    }

    // M�todo para inicializar la barra de vida, estableciendo tanto el valor m�ximo como el valor actual
    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida); // Establece el valor m�ximo de la vida
        CambiarVidaActual(cantidadVida); // Establece la vida actual igual a la vida m�xima al principio
    }
}

