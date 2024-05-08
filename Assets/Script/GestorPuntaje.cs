using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorPuntaje : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;

    void Start()
    {
        // Recuperar el puntaje guardado en PlayerPrefs
        float puntaje = PlayerPrefs.GetFloat("Puntaje", 0f);

        // Actualizar el texto con el puntaje recuperado
        textoPuntaje.text = "Coins: " + puntaje.ToString("0");
    }
}
