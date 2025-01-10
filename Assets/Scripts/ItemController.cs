using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Referencia al BossController, que maneja la lógica relacionada con el jefe.
    public BossController bossController;

    // Método que se ejecuta cuando otro objeto entra en el área de colisión del item.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisionó tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Llama a la función que maneja la recolección del item.
            CollectItem();

            // Destruye el objeto (el item) después de ser recolectado.
            Destroy(gameObject);
        }
    }

    // Método que maneja la recolección del item.
    void CollectItem()
    {
        // Incrementa el contador de items recolectados en el BossController.
        bossController.itemsRecolectados++;
        // Muestra en la consola cuántos items han sido recolectados.
        Debug.Log("Items recolectados: " + bossController.itemsRecolectados);
    }
}



