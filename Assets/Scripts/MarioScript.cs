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
    public SpriteRenderer spriteRenderer;
    public Sprite marioDeathSprite;




    //public Text score;
    //private int scoreValue = 0;
    public Animator animator;
    //public float hozMovement;
    //public float verMovement;
    //private bool goombaAlive;
    //public int liveCount = 3;
    //public text lives;

    //LIVES COMPONETS 
    private int maxLives = 3;
    public int livesCount;
    // private bool marioAlive;

    //bool jump = false;

    //SUPER MARIO VARIABLES
    public bool marioSmall;


    //UI COIN DISPLAY AND LIVES
    //scoreText.text = scoreValue.ToString()

    // public TextMeshProGUI scoreText;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //CALLED METHODS
        //goombaController.GoombaDeath();
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //lives.text = "Lives "+ livesValue.ToString();
        livesCount = maxLives;
        marioSmall = true;

        //score.text = scoreValue.ToString();
    }
    void Update()
    {
        Animation();
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
        //Debug.Log(marioAlive);
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


        //if (rd2d.velocity.y > 0)
        //{
            //animator.SetBool("Jump", true)
        //}
        //if (rd2d.velocity.y = 0)
        //{
            //animator.SetBool("Jump", false)
        //}


        //MOVEMENT ANIMATORS
        //animator.SetFloat("MoveX", hozMovement);
        //animator.SetFloat("MoveY", verMovement);
    }

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
        

        if (collision.collider.tag == "Goomba")
        {
            rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            //goombaController.GoombaDeath()
        }
        if(collision.collider.tag == "GoombaDie")
        {
            //goombaController.GoombaDeath()
            //if (marioSmall = true)
            //{
            //MarioDeath();
            //}
            livesCount.ToString();
            LivesChange();
            //Debug.Log(livesCount);
        }
       
        //if (collision.collider.tag == "GoombaDie")
        //{
           // animator.SetTrigger("Death"); 
        //}
    }

    public void LivesChange()
    {

        if (livesCount >= 0) 
        {
            livesCount -= 1;
        }
        else 
        {
            //HardRestart();
        }

        //if (livesValue <= 0)
        //{
            //Destroy(player);
        //}

         Debug.Log(livesCount);
    }


    public void HardRestart()
    {
        //if (livesCount <= 0)
        //livesCount = maxLives;
    }

    public void SoftReset()
    {

    }

    //public void MarioDeath()
    //}
        //freeze gamestate
       // Debug.Log("maxLives");
        //call SoftRestart()
    //}

    void Animation()
    {
       // animator.SetFloat("MoveX", hozMovement);
        //animator.SetFloat("MoveY", verMovement);
    }
  
}
