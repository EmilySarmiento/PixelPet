using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick2 : MonoBehaviour
{

    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntaje puntaje;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
        
            Destroy(gameObject);
        }
    }
}
