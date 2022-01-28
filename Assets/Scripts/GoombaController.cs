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
        if (collision.collider.tag == "Player")
        {
        //ChangeLives();
        //lives.text = "lives " + livesValue.ToString();
        }

    }


    public void GoombaDamage()
    {
        //Destroy(GetComponent<Rigidbody2D)();
        //Debug.Log("method called");
    }


    public void GoombaDeath()
    {
        spriteRenderer.sprite = deathSprite;
        Debug.Log("method called");

        //Destroy(GetComponent<Rigidbody2D)();
        //Destroy(gameObject, 1);
    }
}

