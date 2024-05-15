using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorPuntaje : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;

    private float puntaje;

    void Start()
    {
        // Recuperar puntaje guardado en PlayerPrefs
        puntaje = PlayerPrefs.GetFloat("Puntaje", 0f);

        // Actualizar texto con puntaje recuperado
        textoPuntaje.text = "Coins: " + puntaje.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntaje += puntosEntrada;
        PlayerPrefs.SetFloat("Puntaje", puntaje);
        textoPuntaje.text = "Coins: " + puntaje.ToString("0");
    }

    public float GetPuntaje()
    {
        return puntaje;
    }
    
}
