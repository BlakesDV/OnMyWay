using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public DrawLine drawLineScript; // Referencia al script DrawLine
    public float speed = 5f; // Velocidad del personaje

    private int currentWaypointIndex = 0; // �ndice del punto de la l�nea al que se dirige el personaje

    void Start()
    {
        transform.position = drawLineScript.linePos[currentWaypointIndex];
    }

    void Update()
    {
        // Si el personaje ha llegado al �ltimo punto de la l�nea, detenemos su movimiento
        if (currentWaypointIndex >= drawLineScript.linePos.Count - 1)
            return;

        // Calculamos la direcci�n hacia el siguiente punto de la l�nea
        Vector2 direction = (drawLineScript.linePos[currentWaypointIndex + 1] - (Vector2)transform.position).normalized;

        // Movemos al personaje hacia el siguiente punto de la l�nea
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el personaje est� lo suficientemente cerca del siguiente punto de la l�nea, pasamos al siguiente punto
        if (Vector2.Distance(transform.position, drawLineScript.linePos[currentWaypointIndex + 1]) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
