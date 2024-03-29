using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{

    public GameObject gatoPersonaje;
    public GameObject perroPersonaje;
    public GameObject conejoPersonaje;

    public bool Gato;
    public bool Perro;
    public bool Conejo;

    private void Update()
    {
        
        Gato= PlayerPrefs.GetInt("seleccionGato") == 1;
        Perro= PlayerPrefs.GetInt("seleccionPerro") == 1;
        Conejo= PlayerPrefs.GetInt("seleccionConejo") == 1;

        if( Gato == true)
        {
            gatoPersonaje.SetActive(true);
            Destroy(perroPersonaje);
            Destroy(conejoPersonaje);
        }

        if( Perro == true)
        {
            perroPersonaje.SetActive(true);
            Destroy(gatoPersonaje);
            Destroy(conejoPersonaje);
        }

        if( Conejo == true)
        {
            conejoPersonaje.SetActive(true);
            Destroy(perroPersonaje);
            Destroy(gatoPersonaje);
        }
    }
}
