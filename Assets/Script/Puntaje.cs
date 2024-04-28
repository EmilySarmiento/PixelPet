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
	}
 
	private void UpDate()
	{
		puntos += Time.deltaTime;
		textMesh.text = puntos.ToString("0");

	}


}
