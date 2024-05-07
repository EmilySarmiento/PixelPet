using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTienda : MonoBehaviour
{
    public GameObject canvasTienda; // Referencia al Canvas de la tienda que quieres mostrar

    // Método para mostrar el Canvas de la tienda
    public void MostrarTienda()
    {
        canvasTienda.SetActive(true); // Activa el Canvas de la tienda
    }
}
