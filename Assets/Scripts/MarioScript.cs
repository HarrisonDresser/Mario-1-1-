using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    //private int scoreValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        //score.text = scoreValue.ToString();
    }

    void FixedUpdate()
    {
  
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2( hozMovement * speed, verMovement * speed));


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        //Debug.Log(GameState);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.X))
            {
                rd2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            }
            
        }
    }
    
}
