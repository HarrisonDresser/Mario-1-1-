using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MarioScript : MonoBehaviour
{
    //CALLED METHODS
    public GoombaController goombaController;


    //COMPONENTS 
    private Rigidbody2D rd2d;
    public float speed;
    public float jumpForce;
    private float moveInput; 
    private float verInput;
    
    private bool walk, walk_left, walk_right, jump;
    public Vector2 velocity; 

    //PLAYER MASKS
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public LayerMask wallMask;

    public Transform headPos;
    public LayerMask WhatIsCeiling;

    //JUMP
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //FALLING PHYSICS 
    public float fallMultiplier;
    public float lowJumpMultipler;

    //SPRITES
    //public SpriteRenderer spriteRenderer;
    //public Sprite marioDeathSprite;




    //public Text score;
    private int scoreValue = 0;
    public Animator animator;
    //public float hozMovement;
    //public float verMovement;
    //private bool goombaAlive;
    //public int liveCount = 3;
    //public text lives;

    //LIVES COMPONETS 
    private int maxLives = 3;
    public int livesCount;
    public bool marioAlive;

   
    //SCORE COMPONETS
    

    //HEALTH / SUPER MARIO VARIABLES    
    public int maxHealth = 2; 
    public int health;               //{ get {return currentHealth;} }
    //int currentHealth; //Dead = 0, smallMario = 1, SuperMario = 2 


    //UI COIN DISPLAY AND LIVES
    //scoreText.text = scoreValue.ToString()

    // public TextMeshProGUI scoreText;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //CALLED METHODS
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //SET COUNTER AT START - LIVES, HEALTH, SCORE,TIME
        //SetcountText();


        //void SetCount()
       // {
           //countText.text = "Count: count.ToString();
           //if (count >= 20)
           //{
                //winTextObject.SetActive(true);
           //}
       // }





        animator.SetBool("MarioDeath", false);
        //GAMESTART STATS
        health = 1; 
        scoreValue = 0;
        livesCount = maxLives;



        //lives.text = "Lives "+ livesValue.ToString();
        //Debug.Log();
        Debug.Log(health);
        //if(livesCount > 0 )
        //{

        //}
        //score.text = scoreValue.ToString();
    }
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        /////TURN TOWARDS GO
        if (moveInput > 0)
        {
           transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        ////COOL JUMP FALL
        if (rd2d.velocity.y < 0)
        {
            rd2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
        }
        else if (rd2d.velocity.y > 0 && Input.GetKey(KeyCode.X))
        {
            rd2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
        }

        //fix double jump bug 
        if (Input.GetKeyUp(KeyCode.X))
        {
            isJumping = false;
            animator.SetBool("Jump", false);
        }

        //PLAYER JUMP 
        if (isGrounded == true && Input.GetKeyDown("x") && isJumping == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rd2d.velocity = Vector2.up * jumpForce;
        }

        //JUMP HIGHER WHEN HOLD X
        if (Input.GetKey(KeyCode.X) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rd2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else 
            {
                isJumping = false;
            }
        }
        if (isGrounded == false)
        {
            animator.SetBool("Jump", true);
        }

    }

    void FixedUpdate()
    {
        PlayerMovement();
        //Debug.Log(jumpTimeCounter);
        //Debug.Log(isGrounded);
       // Debug.Log(isGrounded); //True & False
        //Debug.Log(isJumping);  //false
        //Debug.Log(verInput);
        //Debug.Log(rd2d.velocity.y);
        //Debug.Log(Vector2.up); (0.0,1.0)
        //Debug.Log(moveInput);

        //CLOSE GAME COMMAND
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    void PlayerMovement()
    {
        //PLAYER MOVEMENT CONTROLS
        moveInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
        rd2d.velocity = new Vector2(moveInput * speed, rd2d.velocity.y);

        //RUNNING ANIMATION    
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
    }

    //RAY CASTING SETUPPPPPPPPP
   // Vector3 CheckWallRays (Vector3 pos, float direction)
    //{  //        pos.x = center of player - direction is either 1 or -1 - 
       // Vector2 originTop = new Vector2 (pos.x + direction * .4f, pos.y + 1f -0.2f);
        //Vector2 originMiddle = new Vector2(pos.x + direction * .4f, pos.y);
       // Vector2 originBottom = new Vector2 (pos.x + direction * .4f, pos.y - 1f + 0.2f);

        //RaycastHit2D wallTop = Physics2D. Raycast (originTop, new Vector2 (direction, 0), velocity.x * Time.deltaTime, wallMask);
    //}



    // Player -> Tag Collision Detection
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.collider.tag == "Ground")
        {
           isGrounded = true;
           animator.SetBool("Jump", false);
        }
        else
        {
            isGrounded = false;
        }
        
        //GOOMB STOMPP - calls goomba death animation and score count
        if (collision.gameObject.CompareTag("Goomba"))
        {
            rd2d.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            collision.gameObject.SetActive(false);
            goombaController.GoombaDeath();

            SetScore();
            //goombaController.GoombaDeath()
        }

        //Goomba Killing Mario 
        if(collision.collider.tag == "GoombaDie")
        {
            if (health == 1)
            {
            ChangeHealth();
            }
            //else (marioSize == 2)
           // {
               // marioAlive = true;
           // }
            //goombaController.GoombaDeath()
            //if (marioSmall = true)
            //{
            //}
            //livesCount.ToString();
            //Debug.Log(livesCount);
        }
       
        //if (collision.collider.tag == "GoombaDie")
        //{
           // animator.SetTrigger("Death"); 
        //}
    }

   



    public void ChangeHealth()
    {
        if (health > 0) 
        {
            health = health - 1;
        }
        if (health == 0)
        {
            MarioDeath();
        }
        //if (livesValue <= 0)
        //{
            //Destroy(player);
        //}
         Debug.Log(health);
    }

    public void ChangeLives() //Called when mario takes damage
    {
        //if (lives < 0)
        //{
       // MarioDeath();
       // }
       
    }

    public void MarioDeath()
    {
        //animator.SetBool("Dead", true);
        animator.SetBool("MarioDeath", true);
        //rd2d.constraints = Rigidbody2DConstraints.FreezePostion;
        //Destroy(player);

    }

    public void SetScore()
    {
        scoreValue = scoreValue + 100; 
        Debug.Log(scoreValue);
    }

    public void HardRestart()
    {
        //if (livesCount <= 0)
        //livesCount = maxLives;
    }

    public void SoftReset()
    {
        health = 1;
    }

}
