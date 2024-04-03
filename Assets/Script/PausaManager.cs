using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    public GameObject cuadroPausa;
    public bool enPausa;
    // Start is called before the first frame update
    

   public void PausarBoton()
    {
        enPausa = true;
        cuadroPausa.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void ContinuarBoton()
    {
        enPausa = false;
        cuadroPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void InicioBoton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    
}
