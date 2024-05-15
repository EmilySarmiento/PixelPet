using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAmor : MonoBehaviour
{
   public int amorMax;
   public float amorActual;
   public Image ImagenBarraAmor;
   public Button ButtonAmor;

   public float ChargeRate;

   void Start()
   {
        amorActual = amorMax / 2;
        ActualizarBarraAmor();
        StartCoroutine(BajarBarra());
   }

   public void SubirAmor()
   {
        float aumento = amorMax * 0.1f; // Calcular un aumento del 10%
        amorActual += aumento; // Aumentar el amor actual
        if (amorActual > amorMax) // Asegurar que el amor actual no exceda el máximo
        {
            amorActual = amorMax;
        }
        ActualizarBarraAmor(); // Actualizar la barra de amor visualmente
   }

   void ActualizarBarraAmor()
   {
        ImagenBarraAmor.fillAmount = amorActual / amorMax; // Actualizar la barra de amor visualmente
   }

   private IEnumerator BajarBarra()
   {
        yield return new WaitForSeconds(10f);
        while (amorActual > 0)
        {
            amorActual -= ChargeRate / 10f;
            if (amorActual < 0) amorActual = 0;
            ImagenBarraAmor.fillAmount = amorActual / amorMax; // Actualizar la barra de amor visualmente
            yield return new WaitForSeconds(10f);
        }
   }
}
