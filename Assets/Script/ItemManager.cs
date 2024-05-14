using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Lista de items en la tienda

    public List<Item> items = new List<Item>()
    {
        new Item("MonoRosa", 20f),
        new Item("Fresa", 5f),
        new Item("Jabon", 10f),
        new Item("Oso", 50f)
    };

    private GestorPuntaje gestorPuntaje;
    private float puntaje;

    void Start()
    {

        gestorPuntaje = GameObject.FindObjectOfType<GestorPuntaje>();
        puntaje = gestorPuntaje.GetPuntaje();
    }

    public void ComprarItem(string nombreItem)
    {
        // Buscar el item en la lista
        Item item = items.Find(x => x.nombre == nombreItem);

        // Validar si el item existe
        if (item != null)
        {
            // Verificar si el jugador tiene suficiente puntaje
            if (puntaje >= item.valor)
            {
                // Restar el valor del item del puntaje
                puntaje -= item.valor;

                // Actualizar el texto del puntaje
                gestorPuntaje.textoPuntaje.text = "Coins: " + puntaje.ToString("0");

                // Mostrar mensaje de compra exitosa
                Debug.Log("¡" + nombreItem + " comprado!");
            }
            else
            {
                // Mostrar mensaje de puntaje insuficiente
                Debug.Log("No tienes suficiente puntaje para comprar " + nombreItem);
            }
        }
        else
        {
            // Mostrar mensaje de item no encontrado
            Debug.Log("Item no encontrado: " + nombreItem);
        }
    }
}
