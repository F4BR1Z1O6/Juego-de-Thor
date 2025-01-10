using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public float jumpForce = 10f; // Fuerza del salto del jugador
    public float maxHealth = 100f; // Salud m�xima del jugador
    private float currentHealth; // Salud actual del jugador
    private bool isGrounded; // Indica si el jugador est� en el suelo

    private Rigidbody2D rb; // Componente Rigidbody2D para controlar el movimiento f�sico
    private Animator animator; // Componente Animator para controlar las animaciones
    private bool facingRight = true; // Indica si el jugador est� mirando hacia la derecha

    // M�todo que se ejecuta al iniciar el juego
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
        animator = GetComponent<Animator>(); // Obtiene el componente Animator
        currentHealth = maxHealth; // Inicializa la salud actual

        // Verifica si el componente Animator est� presente
        if (animator == null)
        {
            Debug.LogError("No Animator component found on " + gameObject.name);
        }

        // Establece la posici�n de inicio del jugador en el punto de spawn, si existe
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    // Este m�todo se ejecuta en cada frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal"); // Obtiene la entrada horizontal del jugador
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y); // Mueve al jugador horizontalmente

        // Actualiza las animaciones seg�n el movimiento
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(move)); // Establece la velocidad de la animaci�n
        }

        // Control de la direcci�n en la que el jugador est� mirando
        if (move > 0 && !facingRight)
        {
            Flip(); // Voltea al jugador si est� mirando a la izquierda
        }
        else if (move < 0 && facingRight)
        {
            Flip(); // Voltea al jugador si est� mirando a la derecha
        }

        // Permite al jugador saltar si est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Aplica una fuerza de salto
        }

        // Actualiza las animaciones de salto y ca�da seg�n la velocidad vertical
        if (animator != null)
        {
            if (isGrounded)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    animator.SetBool("isJumping", true);
                    animator.SetBool("isFalling", false);
                }
                else if (rb.velocity.y < 0)
                {
                    animator.SetBool("isJumping", false);
                    animator.SetBool("isFalling", true);
                }
            }
        }
    }

    // Este m�todo se ejecuta cuando el jugador colisiona con otros objetos
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el jugador colisiona con el suelo
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        // Verifica si el jugador colisiona con un objeto "Triangle" (posiblemente un checkpoint)
        if (collision.collider.tag == "Triangle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la siguiente escena
        }

        // Verifica si el jugador colisiona con un objeto final (game over)
        if (collision.collider.tag == "FinalObject")
        {
            EndGame(); // Termina el juego
        }

        // Verifica si el jugador colisiona con un enemigo o un obst�culo
        if (collision.collider.tag == "Enemigo" || collision.collider.tag == "Hazard")
        {
            TakeDamage(20); // Llama a la funci�n para recibir da�o
        }

        // Verifica si el jugador colisiona con una bala enemiga u otro obst�culo
        if (collision.collider.tag == "BalaEnemigo" || collision.collider.tag == "Hazard")
        {
            TakeDamage(20); // Llama a la funci�n para recibir da�o
        }
    }

    // Este m�todo se ejecuta cuando el jugador deja de estar en contacto con el suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica si el jugador deja el suelo
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    // M�todo para finalizar el juego
    void EndGame()
    {
        Debug.Log("Game Over!");
        Application.Quit(); // Sale del juego

        // En el editor de Unity, detiene la simulaci�n del juego
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // M�todo para voltear la direcci�n en la que el jugador est� mirando
    void Flip()
    {
        facingRight = !facingRight; // Cambia la direcci�n del jugador
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Invierte el valor de la escala horizontal
        transform.localScale = theScale; // Aplica la nueva escala
    }

    // M�todo para que el jugador reciba da�o
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce la salud actual
        if (currentHealth <= 0)
        {
            EndGame(); // Si la salud llega a 0 o menos, termina el juego
        }
        else
        {
            if (animator != null)
            {
                animator.SetTrigger("isHurt"); // Activa la animaci�n de da�o
                StartCoroutine(ResetHurt()); // Reinicia el trigger de da�o despu�s de un tiempo
            }
        }
    }

    // Coroutine para reiniciar el trigger de la animaci�n de da�o
    IEnumerator ResetHurt()
    {
        yield return new WaitForSeconds(0.5f); // Espera 0.5 segundos
        if (animator != null)
        {
            animator.ResetTrigger("isHurt"); // Reinicia el trigger de animaci�n
        }
    }
}








