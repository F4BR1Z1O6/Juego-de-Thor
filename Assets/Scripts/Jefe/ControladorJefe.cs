using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator para controlar las animaciones del jefe
    public float attackRange = 5f; // Rango de ataque del jefe
    public Transform player; // Referencia al jugador para calcular la distancia
    public float damageAmount = 10f; // Cantidad de da�o que el jefe inflige (aunque no se usa en este script)
    public int itemsRecolectados = 0; // Contador de los items recolectados por el jugador

    void Start()
    {
        // Verifica que el componente Animator est� asignado
        if (animator == null)
        {
            Debug.LogError("No Animator component found on " + gameObject.name);
        }

        // Verifica que el jugador (player) est� asignado
        if (player == null)
        {
            Debug.LogError("No player Transform assigned in " + gameObject.name);
        }
    }

    void Update()
    {
        // Si falta el Animator o el jugador, se detiene el script
        if (animator == null || player == null) return;

        // Si el jefe ha recolectado 4 items, muere
        if (itemsRecolectados >= 4)
        {
            Die();
        }

        // Calcula la distancia entre el jefe y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador est� dentro del rango de ataque, el jefe ataca
        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
        else
        {
            StopAttack(); // Si est� fuera de rango, deja de atacar
        }
    }

    // Funci�n para iniciar la animaci�n de ataque
    void Attack()
    {
        animator.SetBool("isAttacking", true); // Activa la animaci�n de ataque
    }

    // Funci�n para detener la animaci�n de ataque
    void StopAttack()
    {
        animator.SetBool("isAttacking", false); // Desactiva la animaci�n de ataque
    }

    // Funci�n para manejar la muerte del jefe
    void Die()
    {
        Debug.Log("Die method called"); // Mensaje para depuraci�n
        animator.SetTrigger("Dead"); // Activa la animaci�n de muerte
        Destroy(gameObject, 2f); // Destruye al jefe despu�s de 2 segundos
    }

    // Dibuja un Gizmo en la escena para mostrar el rango de ataque del jefe
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Color del Gizmo (rojo)
        Gizmos.DrawWireSphere(transform.position, attackRange); // Dibuja una esfera representando el rango de ataque
    }
}




