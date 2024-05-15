using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraComida : MonoBehaviour
{
    public int comidaMax;
    public float comidaActual;
    public Image ImagenBarraComida;
    public Button Buttoncomida;

    public float ChargeRate;

    
    void Start()
    {
        comidaActual = comidaMax / 2;
        ActualizarBarraComida();
        StartCoroutine(BajarBarra());
    }

    public void SubirComida()
    {
        float aumento = comidaMax * 0.1f; // Calcular un aumento del 10%
        comidaActual += aumento; // Aumentar la comida actual
        if (comidaActual > comidaMax) // Asegurar que la comida actual no exceda el máximo
        {
            comidaActual = comidaMax;
        }
        ActualizarBarraComida(); 
    }

    void ActualizarBarraComida()
    {
        ImagenBarraComida.fillAmount = comidaActual / comidaMax; 
    }


    private IEnumerator BajarBarra()
    {
        yield return new WaitForSeconds(5f);
        while (comidaActual > 0)
        {
            comidaActual -= ChargeRate / 10f;
            if (comidaActual < 0) comidaActual = 0;
            ImagenBarraComida.fillAmount = comidaActual / comidaMax;
            yield return new WaitForSeconds(10f);
        }
    }
}