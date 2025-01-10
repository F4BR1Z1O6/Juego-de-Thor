using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo; // El punto desde donde se dispara
    public float distanciaLinea; // Distancia a la que el rayo detecta al jugador
    public LayerMask capaJugador; // Capa en la que se encuentra el jugador para detectarlo
    public bool jugadorEnRango; // Si el jugador est� dentro del rango de disparo
    public GameObject balaEnemigo; // Prefab de la bala que el enemigo disparar�
    public float tiempoEntreDisparo; // Tiempo entre disparos consecutivos
    public float tiempoUltimoDisparo; // Almacena el tiempo del �ltimo disparo
    public float tiempoEsperaDisparo; // Tiempo que el enemigo espera antes de disparar
    public Animator animator; // Animador para activar la animaci�n de disparo

    private void Update()
    {
        // Detectar si el jugador est� dentro del rango utilizando un rayo
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);

        if (jugadorEnRango)
        {
            // Si el jugador est� en rango y ha pasado suficiente tiempo desde el �ltimo disparo
            if (Time.time > tiempoEntreDisparo + tiempoUltimoDisparo)
            {
                // Actualiza el tiempo del �ltimo disparo
                tiempoUltimoDisparo = Time.time;

                // Activa la animaci�n de disparo
                animator.SetTrigger("Disparar");

                // Invoca el m�todo Disparar despu�s de un tiempo de espera
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        }
    }

    private void Disparar()
    {
        // Instancia el prefab de la bala en la posici�n del controladorDisparo
        Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
    }

    // Dibuja una l�nea en el editor para visualizar el rango de disparo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }
}

