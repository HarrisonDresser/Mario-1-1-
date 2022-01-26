using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MarioScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    //public Text score;
    //private int scoreValue = 0;
    public Animator animator;
    //public float hozMovement;
    //public float verMovement;

    //UI COIN DISPLAY AND LIVES
    //scoreText.text = scoreValue.ToString()

    // public TextMeshProGUI scoreText;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //score.text = scoreValue.ToString();
    }
    void update()
    {
        Animation();
        //direction = new Vector2(hozMovment,verMovement).normalized;
        //Debug.Log(Input.GetAxis("Horizontal"));
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
        //rd2d.velocity = new Vector2(direction.x * speed, direction.y * movespeed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        //Debug.Log(GameState);

    }

    void PlayerMovement()
    {
        //PLAYER MOVEMENT CONTROLS
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2( hozMovement * speed, verMovement * speed));
        animator.SetFloat("MoveX", hozMovement);
        animator.SetFloat("MoveY", verMovement);

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
        if (collision.collider.tag == "Goomba")
        {
            rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            
        }
        //if (collision.collider.tag == "GoombaDie")
       // {

        //}
    }

    void Animation()
    {
       // animator.SetFloat("MoveX", hozMovement);
        //animator.SetFloat("MoveY", verMovement);
    }

}
