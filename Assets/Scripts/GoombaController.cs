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

    //METHODS CALLED 
    public MarioScript marioScript;

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

        if (player != null)
        {
           //Debug.Log("Player Hit by Goomba");
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



    public void GoombaDamage()
    {
        //Debug.Log("method called");
    }


    public void GoombaDeath()
    {
        Debug.Log("GoombDied");
        //spriteRenderer.sprite = deathSprite;
        //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        Destroy(gameObject, 1);
        //Debug.Log("method called");

        //Destroy(GetComponent<Rigidbody2D)();
        //Destroy(gameObject, 1);
    }
}

