using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nombre;
    public float valor;

    public Item(string nombre, float valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    void Start()
    {
        // Create some item objects
        Item monoRosa = new Item("MonoRosa", 20f);
        Item fresa = new Item("Fresa", 5f);
        Item jabon = new Item("Jabon", 10f);
        Item oso = new Item("Oso", 50f);

        // Add items to a list
        List<Item> items = new List<Item>() { monoRosa, fresa, jabon, oso };

        // Display item information
        foreach (Item item in items)
        {
            Debug.Log("Nombre: " + item.nombre);
            Debug.Log("Valor: " + item.valor);
        }
    }
}
