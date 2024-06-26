using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public GameObject articuloPrefab; // Asigna el prefab del artículo en el Inspector
    public Transform spawnPoint; // Punto de aparición del artículo

    public int[,] shopItems = new int[5, 5];
    public float coins;
    public Text CoinsTXT;
    public GestorPuntaje gestorPuntaje;

    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 20;
        shopItems[2, 2] = 5;
        shopItems[2, 3] = 10;
        shopItems[2, 4] = 50;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            float precioArticulo = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            coins -= precioArticulo;
            gestorPuntaje.SumarPuntos(-precioArticulo); // Restar el precio del artículo al puntaje del jugador
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

            Instantiate(articuloPrefab, spawnPoint.position, Quaternion.identity);
        }
    }   
}
