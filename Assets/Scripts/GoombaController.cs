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



    public void OnCollisionStay2D(Collision2D collision)
    {
        MarioScript player = collision.gameObject.GetComponent<MarioScript>();

        if (player != null && damagePlayer)
        {
            player.ForceJump();
            playerAlive = false;
            player.ChangeHealth(-1);
            Debug.Log("Player Hit by Goomba");
           //collision.gameObject.SetActive(false);
           
           // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }

        //if (collision.transform.CompareTag("Player"))
        //{
           // collision.gameObject.SetActive(false);
            //collision.GetComponent<MarioScript>().ChangeHealth();
            //ChangeLives();
            //lives.text = "lives " + livesValue.ToString();
       // }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        MarioScript player = collision.gameObject.GetComponent<MarioScript>();

        if (player != null && playerAlive)
        {
            damagePlayer = false;
      
            GoombaDeath();
            player.SetScore(100);
            //player.ChangeHealth(-1);
            //Debug.Log("Goomba Damage");
            //collision.gameObject.SetActive(false);

            // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }
    }

    public void GoombaDamage()
    {
        //Debug.Log("method called");
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

