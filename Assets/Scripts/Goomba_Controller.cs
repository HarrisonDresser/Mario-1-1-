using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba_Controller : MonoBehaviour
{     
    
    public float speed;
    public bool moveLeft = true;
    private Rigidbody2D rigidbody2D;
    private int direction = -1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2D.position;
        if (moveLeft == true)
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            rigidbody2D.MovePosition(position);
        }
    }
}
