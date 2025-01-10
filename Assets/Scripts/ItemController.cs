using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Referencia al BossController, que maneja la l�gica relacionada con el jefe.
    public BossController bossController;

    // M�todo que se ejecuta cuando otro objeto entra en el �rea de colisi�n del item.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colision� tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Llama a la funci�n que maneja la recolecci�n del item.
            CollectItem();

            // Destruye el objeto (el item) despu�s de ser recolectado.
            Destroy(gameObject);
        }
    }

    // M�todo que maneja la recolecci�n del item.
    void CollectItem()
    {
        // Incrementa el contador de items recolectados en el BossController.
        bossController.itemsRecolectados++;
        // Muestra en la consola cu�ntos items han sido recolectados.
        Debug.Log("Items recolectados: " + bossController.itemsRecolectados);
    }
}



