using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidroMiel : MonoBehaviour
{
    public float speedBoost = 2f; // Aumento de velocidad que se aplica al jugador
    public float duration = 3f; // Duración durante la cual se mantiene el aumento de velocidad

    // Este método se llama cuando un objeto entra en el área del collider del objeto (en este caso, el objeto de la miel)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se verifica si el objeto que colisionó tiene el componente PlayerController
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Si el jugador tiene el componente PlayerController, se activa el aumento de velocidad
            StartCoroutine(BoostPlayerSpeed(player));
            Destroy(gameObject); // Destruye el objeto de la miel después de que el jugador lo recoge
        }
    }

    // Corutina para aumentar la velocidad del jugador
    private IEnumerator BoostPlayerSpeed(PlayerController player)
    {
        // Aumenta la velocidad de movimiento del jugador
        player.moveSpeed += speedBoost;
        yield return new WaitForSeconds(duration); // Espera el tiempo especificado en duration
        // Restaura la velocidad original del jugador después de la duración
        player.moveSpeed -= speedBoost;
    }
}




