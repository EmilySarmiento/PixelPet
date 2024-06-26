using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public GameObject ball;

    private Rigidbody2D rb;
    public float speed = 10f;


    //texto
    public string textValue;
    public Text textElement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        CancelInvoke();
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }


    //Cuando la pelota choca contra en suelo
  
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            //Debug.Log("Perdiste sorry");
            //Time.timeScale = 0.1f;
            //textElement.gameObject.SetActive(true);
            //textElement.text = textValue;
            ball.SetActive(false);
            SceneManager.LoadScene(2);
        }
     }
}
