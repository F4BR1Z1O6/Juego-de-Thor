using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public string enemyTag = "Enemigo"; // Etiqueta que identifica a los enemigos
    public string deathAnimationName = "Death"; // Nombre de la animaci�n de muerte que se activa en los enemigos
    public float destroyDelay = 2f; // Tiempo de retraso antes de destruir a los enemigos despu�s de la animaci�n de muerte

    // Este m�todo se llama cuando el objeto con este script entra en contacto con otro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto con el que colision� tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            KillEnemies(); // Llama a la funci�n que mata a los enemigos
            Destroy(gameObject); // Destruye el objeto del rayo (despu�s de que hace su efecto)
        }
    }

    // Funci�n para destruir a todos los enemigos cercanos
    private void KillEnemies()
    {
        // Encuentra todos los objetos con la etiqueta de enemigo
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            // Obtiene el componente Animator del enemigo para reproducir la animaci�n de muerte
            Animator animator = enemy.GetComponent<Animator>();
            if (animator != null)
            {
                // Reproduce la animaci�n de muerte
                animator.Play("Death");
            }
            // Destruye al enemigo despu�s del retraso especificado
            Destroy(enemy, destroyDelay);
        }
    }
}

