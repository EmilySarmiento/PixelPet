using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
	private float puntos;

	private TextMeshProUGUI textMesh;


	private void Start()
	{
		textMesh = GetComponent<TextMeshProUGUI>();
		puntos = PlayerPrefs.GetFloat("Puntaje", 0f);
		ActualizarTextoPuntaje();

	}
 
	private void Update()
	{
        puntos += Time.deltaTime;
        textMesh.text = puntos.ToString("0");
    }

	 private void ActualizarTextoPuntaje()
    {
        // Actualizar el texto con los puntos
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        PlayerPrefs.SetFloat("Puntaje", puntos);
		PlayerPrefs.Save();
    }

	 /*public void ModificarPuntos(float puntosModificados)
    {
        // Modificar los puntos según el valor proporcionado
        puntos += puntosModificados;
        // Guardar puntos
        PlayerPrefs.SetFloat("Puntaje", puntos);
        // Asegurarse de guardar los cambios en PlayerPrefs
        PlayerPrefs.Save();
        // Actualizar el texto con los puntos
        ActualizarTextoPuntaje();
    }*/

}
