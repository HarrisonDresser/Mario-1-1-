using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaControllerPong : MonoBehaviour
{
    public float speed;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            timer = changeTime;
        }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    // Follows the target position like with a spring
    void FixedUpdate()
        {
            Vector2 position = rigidbody2D.position;
            position.x = position.x + Time.deltaTime * speed * direction;

            rigidbody2D.MovePosition(position);
        }
}
