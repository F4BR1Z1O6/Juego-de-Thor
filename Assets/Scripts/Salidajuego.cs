using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salidajuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // No se necesita hacer nada en este caso, ya que no hay inicializaci�n necesaria.
    }

    // Update is called once per frame
    void Update()
    {
        // Tampoco se necesita algo en Update para esta funcionalidad espec�fica.
    }

    // Esta funci�n se llama para cerrar el juego.
    public void FuncionCerrarJuego()
    {
        Application.Quit(); // Cierra el juego.
    }
}
