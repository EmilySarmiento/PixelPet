using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraComida : MonoBehaviour
{
    public int comidaMax;
    public float comidaActual;
    public Image ImagenBarraComida;

    public float ChargeRate;


    public bool comidaAlMaximo = false;


    void Start()
    {
        comidaActual = comidaMax;
    }


    void Update()
    {
        RevisarComida();

        if (comidaActual == comidaMax)
        {
            comidaAlMaximo = true;
        }
    }


    public void RevisarComida()
    {
        ImagenBarraComida.fillAmount = comidaActual / comidaMax;
    }

    private IEnumerator BajarBarra()
    {
       yield return new WaitForSeconds(1f);
       while(comidaActual < comidaMax)
       {
        comidaActual += ChargeRate / 10f;
        if(comidaActual > comidaMax) comidaActual = comidaMax;
       ImagenBarraComida.fillAmount = comidaActual / comidaMax;
        yield return new WaitForSeconds(.1f);
       }
}

}
