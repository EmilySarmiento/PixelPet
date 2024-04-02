using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed; //Velocidad
    public float jumpStreng; //Fuerza del salto
    public int maxJumps; //Máximo de saltos
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxcollider;
    private bool mirandoDerecha = true;
    private int lessJumps; //Saltos restantes
    //private Animator animator;
    //public PausaManager pausaManager;
    // Update is called once per frame
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        //if (pausaManager.enPausa == true)
        //{
        //    return;
        //}
        procesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider.bounds.center, new Vector2(boxcollider.bounds.size.x, boxcollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycasthit.collider != null;
    }
    void ProcesarSalto()
    {
        if (EstaEnSuelo())
        {
            lessJumps = maxJumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && lessJumps > 0)
        {
            lessJumps = lessJumps - 1;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * jumpStreng, ForceMode2D.Impulse);
        }
    }

    void procesarMovimiento()
    {
        //Lógica de movimiento//
        //Revisa la tecla que esté presinando el jugador
        float inputMovimiento = Input.GetAxis("Horizontal");

        //if (inputMovimiento != 0)
        //{
        //    animator.SetBool("isRunning", true);
        //}
        //else
        //{
        //    animator.SetBool("isRunning", false);
        //}

        rigidBody.velocity = new Vector2(inputMovimiento * speed, rigidBody.velocity.y);
        gestionarOrientacion(inputMovimiento);
    }

    void gestionarOrientacion(float inputMovimiento)
    {
        //Si se cumple la condición
        if ((mirandoDerecha == true && inputMovimiento < 0)||(mirandoDerecha == false && inputMovimiento > 0))
        {
            //Voltear al personaje
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
    
}
