using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public GameObject funciones;

    public void cambiar()
    {
        SceneManager.LoadScene("MiniJuego");
        funciones.GetComponent<GuardarPersonaje>().Guardar();
    }
}
