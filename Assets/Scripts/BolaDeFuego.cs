using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{
    // Velocidad de rotaci�n de la bola de fuego.
    public float rotationSpeed;

    // La rotaci�n actual de la bola de fuego.
    private float actualRotation;

    // Referencia a la puerta que se desactivar� al tocar la bola de fuego.
    public GameObject puerta;

    // Este m�todo se llama en cada frame.
    void Update()
    {
        // Incrementa la rotaci�n de la bola de fuego bas�ndose en la velocidad de rotaci�n.
        actualRotation += rotationSpeed * Time.deltaTime;

        // Aplica la rotaci�n a la bola de fuego, rotando alrededor del eje Y (horizontalmente).
        transform.eulerAngles = new Vector3(0, actualRotation, 0);
    }

    // Este m�todo se llama cuando la bola de fuego entra en contacto con otro collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colision� tiene la etiqueta "Player".
        if (collision.CompareTag("Player"))
        {
            // Si la puerta est� asignada y no es nula, desact�vala.
            if (puerta != null)
            {
                puerta.SetActive(false);
            }

            // Destruye la bola de fuego (el objeto en el que este script est� adjunto).
            Destroy(gameObject);
        }
    }
}



