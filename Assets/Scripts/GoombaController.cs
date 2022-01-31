using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Rigidbody2D rd;

    public SpriteRenderer spriteRenderer;
    public Sprite deathSprite;

    private bool damagePlayer = true;
    private bool playerAlive = true;

    private Animator animator;

    //METHODS CALLED 
    public MarioScript marioScript;

    //RUNS BEFORE START
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Start()
    {

        //spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
        //marioScript.ChangeLives();
        rd = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
     {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));
     }



    public void OnCollisionStay2D(Collider2D collision)
    {
        MarioScript player = collision.gameObject.GetComponent<MarioScript>();

        if (player != null && damagePlayer)
        {
            
            playerAlive = false;
            player.ChangeHealth(-1);
            Debug.Log("Player Hit by Goomba");
           //collision.gameObject.SetActive(false);
           
           // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }
        //if (collision.transform.CompareTag("KoopaShell"))
        //{

            //Debug.Log("Turn Shell off");
            //collision.gameObject.SetActive(false);
        //}


        //if (collision.transform.CompareTag("Player"))
        //{
        // collision.gameObject.SetActive(false);
        //collision.GetComponent<MarioScript>().ChangeHealth();
        //ChangeLives();
        //lives.text = "lives " + livesValue.ToString();
        // }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        MarioScript player = collider.gameObject.GetComponent<MarioScript>();

        if (player != null && playerAlive)
        {
            damagePlayer = false;
           // player.ForceJump();
            GoombaDeath();
            player.SetScore(100);
            //player.ChangeHealth(-1);
            //Debug.Log("Goomba Damage");
            //collision.gameObject.SetActive(false);
            //collision.transform.CompareTag("GoombaDamage")

            // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }

        if (collider.transform.CompareTag("KoopaShell"))
        {
            GoombaDeath();
            Debug.Log("Goomba hit by KoopaShell");
            player.SetScore(40);
        }


        /*
         * 
         * 
        if (collider.transform.CompareTag("KoopaShell"))
        {
            GoombaDeath();
            Debug.Log("Goomba hit by KoopaShell");
            player.SetScore(400);
            // this.transform.position = new Vector3(0, -1000, 0);
        }
        */


    }



    public void GoombaDeath()
    {

        Debug.Log("GoombDied");
        //spriteRenderer.sprite = deathSprite;
        //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        animator.SetBool("Alive", false);
        Destroy(gameObject, 0.2f);
        //Debug.Log("method called");

        //Destroy(GetComponent<Rigidbody2D)();
        //Destroy(gameObject, 1);
    }
}

