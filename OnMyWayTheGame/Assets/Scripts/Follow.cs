using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public DrawLine drawLineScript; // Referencia al script DrawLine
    public float speed = 5f; // Velocidad del personaje

    private int currentWaypointIndex = 0; // Índice del punto de la línea al que se dirige el personaje

    void Start()
    {
        transform.position = drawLineScript.linePos[currentWaypointIndex];
    }

    void Update()
    {
        // Si el personaje ha llegado al último punto de la línea, detenemos su movimiento
        if (currentWaypointIndex >= drawLineScript.linePos.Count - 1)
            return;

        // Calculamos la dirección hacia el siguiente punto de la línea
        Vector2 direction = (drawLineScript.linePos[currentWaypointIndex + 1] - (Vector2)transform.position).normalized;

        // Movemos al personaje hacia el siguiente punto de la línea
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el personaje está lo suficientemente cerca del siguiente punto de la línea, pasamos al siguiente punto
        if (Vector2.Distance(transform.position, drawLineScript.linePos[currentWaypointIndex + 1]) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
