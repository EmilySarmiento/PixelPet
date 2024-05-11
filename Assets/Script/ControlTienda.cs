using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTienda : MonoBehaviour
{
    public GameObject canvasTienda; 

    
    public void MostrarTienda()
    {
        canvasTienda.SetActive(true); // Activa el Canvas de la tienda
    }

    public void SalirTienda()
    {
        canvasTienda.SetActive(false);
    }
}
