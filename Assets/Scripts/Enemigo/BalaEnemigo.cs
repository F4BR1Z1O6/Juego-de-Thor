using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad;  // La velocidad a la que la bala se moverá
    public int daño;  // La cantidad de daño que la bala causará al jugador

    private void Update()
    {
        // Mover la bala hacia la derecha
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la bala colisiona con un objeto que tiene el componente VidaJugador
        if (other.TryGetComponent(out VidaJugador vidaJugador))
        {
            // Llama al método TomarDaño de la clase VidaJugador para reducir la salud del jugador
            vidaJugador.TomarDaño(daño);

            // Destruye la bala después de que haya golpeado al jugador
            Destroy(gameObject);
        }
    }
}
