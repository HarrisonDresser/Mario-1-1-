using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaController : MonoBehaviour
{
    private Animator animator;
    public MarioScript marioScript;
    private Rigidbody2D rd;

    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    private bool damagePlayer = true;
    private bool playerAlive = true;

    public GameObject pickupPrefab;

    public bool isHit = false;




    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator.SetBool("isDead", false);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        MarioScript player = collision.gameObject.GetComponent<MarioScript>();

        if (player != null && damagePlayer)
        {

            playerAlive = false;
            player.ChangeHealth(-1);
            Debug.Log("Player Hit by Koopa");
            //collision.gameObject.SetActive(false);

            // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }
        if (collision.transform.CompareTag("GoombaDamage"))
        {
            
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
            player.ForceJump();
            animator.SetBool("isDead", true);
            KoopaHit();
            //Debug.Log("Koopa Killed");
            //Destroy(this.gameObject);
            //player.SetScore(100);
            //player.ChangeHealth(-1);
            //Debug.Log("Goomba Damage");
            //collision.gameObject.SetActive(false);

            // NEEDS TO CALL CHANGE HEALTH gameObject.GetComponent<MarioScript>().ChangeHealth();
        }

    }

    public void KoopaHit()
    {
        Debug.Log("Player Contact with Koopa");
        if (isHit == false)
        {
            ShellDelay();
            //Invoke("ShellDelay", 0.3f);
            //animator.Play("Qblock_Bounce");
            Destroy(gameObject);
            isHit = true;
        }
    }


    public void ShellDelay()
    {
        Instantiate(pickupPrefab, transform.position, transform.rotation);
    }

 }


