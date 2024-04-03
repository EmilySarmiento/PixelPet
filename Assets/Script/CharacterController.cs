using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed; //Velocidad
    public float jumpStreng; //Fuerza del salto
    public int maxJumps; //M�ximo de saltos
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;
    public float maxBounceAngle = 75f;

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
        //L�gica de movimiento//
        //Revisa la tecla que est� presinando el jugador
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
        //Si se cumple la condici�n
        if ((mirandoDerecha == true && inputMovimiento < 0)||(mirandoDerecha == false && inputMovimiento > 0))
        {
            //Voltear al personaje
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    //collision

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) {
            return;
        }

        Rigidbody2D ball = collision.rigidbody;
        Collider2D paddle = collision.otherCollider;

        // Gather information about the collision
        Vector2 ballDirection = ball.velocity.normalized;
        Vector2 contactDistance = paddle.bounds.center - ball.transform.position;

        // Rotate the direction of the ball based on the contact distance
        // to make the gameplay more dynamic and interesting
        float bounceAngle = (contactDistance.x / paddle.bounds.size.x) * maxBounceAngle;
        ballDirection = Quaternion.AngleAxis(bounceAngle, Vector3.forward) * ballDirection;

        // Re-apply the new direction to the ball
        ball.velocity = ballDirection * ball.velocity.magnitude;
    }
    
}
