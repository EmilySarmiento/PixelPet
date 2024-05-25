using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRoom : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D Rigidbody;
    public bool running = false;
    public Image ComidaBarra;
    public float Comida, MaxComida;
    public float AttackCost;
    public float RunCost;
    public float ChargeRate;
    private Coroutine recharge;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = false;
        }
        if (running && (direction.x != 0 || direction.y != 0))
        {
            Rigidbody.velocity = direction * MoveSpeed * 1.5f;
            Comida -= RunCost * Time.deltaTime;
            if (Comida < 0) Comida = 0;
            ComidaBarra.fillAmount = Comida / MaxComida;
        }
        else
        {
            Rigidbody.velocity = direction * MoveSpeed;
        }
    }
}
