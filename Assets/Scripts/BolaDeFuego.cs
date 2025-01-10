using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{
    // Velocidad de rotación de la bola de fuego.
    public float rotationSpeed;

    // La rotación actual de la bola de fuego.
    private float actualRotation;

    // Referencia a la puerta que se desactivará al tocar la bola de fuego.
    public GameObject puerta;

    // Este método se llama en cada frame.
    void Update()
    {
        // Incrementa la rotación de la bola de fuego basándose en la velocidad de rotación.
        actualRotation += rotationSpeed * Time.deltaTime;

        // Aplica la rotación a la bola de fuego, rotando alrededor del eje Y (horizontalmente).
        transform.eulerAngles = new Vector3(0, actualRotation, 0);
    }

    // Este método se llama cuando la bola de fuego entra en contacto con otro collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player".
        if (collision.CompareTag("Player"))
        {
            // Si la puerta está asignada y no es nula, desactívala.
            if (puerta != null)
            {
                puerta.SetActive(false);
            }

            // Destruye la bola de fuego (el objeto en el que este script está adjunto).
            Destroy(gameObject);
        }
    }
}



