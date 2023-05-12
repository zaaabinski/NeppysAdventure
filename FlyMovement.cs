using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float radius = 5f; // promieñ okrêgu
    public float speed = 2f; // prêdkoœæ ruchu
    private float angle = 0f; // k¹t w radianach
    private bool goingRight = true; // zmienna przechowuj¹ca kierunek ruchu
    float rot;
    private void Start()
    {
        speed = Random.Range(1, 4);
        radius = Random.Range(1, 6);
        rot = Random.Range(1f, 180f);
        gameObject.transform.Rotate(0, rot, 0);
        StartCoroutine(ChangeSpeed());
    }
    void Update()
    {
        // Oblicz wektor ruchu na podstawie aktualnego k¹ta i promienia
        Vector3 movementVector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f).normalized * speed;

        // Przemieszczaj obiekt po okrêgu
        transform.position += movementVector * Time.deltaTime;

        if (transform.position.magnitude >= radius)
        {
            goingRight = !goingRight;
        }

        // Zwiêksz k¹t o prêdkoœæ ruchu, pomno¿on¹ przez deltaTime
        angle += speed * Time.deltaTime;
    }
    IEnumerator ChangeSpeed()
    {
        yield return new WaitForSeconds(10);
        speed = Random.Range(1, 4);
        radius = Random.Range(1, 6);
    }
}

