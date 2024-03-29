using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPersonaje : MonoBehaviour

{
    public bool Gato;
    public bool Perro;
    public bool Conejo;

    private void Update()
    {
        if (Gato == false && Perro == false && Conejo == false)
        {
            Gato = true;
        }
        Gato = PlayerPrefs.GetInt("seleccionGato") == 1;
        Perro = PlayerPrefs.GetInt("seleccionPerro") == 1;
        Conejo = PlayerPrefs.GetInt("seleccionConejo") == 1;
    }

    public void PersonajeGato()
    {
        Gato = true;
        Perro = false;
        Conejo = false;
        Guardar();

    }

    public void PersonajePerro()
    {
        Gato = false;
        Perro = true;
        Conejo = false;
        Guardar();

    }

     public void PersonajeConejo()
    {
        Gato = false;
        Perro = false;
        Conejo = true;
        Guardar();

    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("seleccionGato", Gato ? 1: 0);
        PlayerPrefs.SetInt("seleccionPerro", Perro ? 1: 0);
        PlayerPrefs.SetInt("seleccionConejo", Conejo ? 1: 0);
    }
}