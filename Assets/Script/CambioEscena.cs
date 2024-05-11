using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public GameObject funciones;

    public void cambiar(string nombre)
    {
        SceneManager.LoadScene(nombre);
        funciones.GetComponent<GuardarPersonaje>().Guardar();   
    }
    

    public void BotonSalir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }

}
