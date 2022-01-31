using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaShell : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float Thrust;
    public MarioScript marioScript;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void FixedUpdate()
    {
        //rd2d.AddForce(new Vector3(1f, 0f, 0f));
        //rd2d.AddForce(transform.right * Thrust);
        //rd2d.AddForce(-(transform.right) * Thrust);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        MarioScript player = collision.gameObject.GetComponent<MarioScript>();

        if (player != null)
        {
            //Debug.Log("Koopa Kick");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            KoopaKick();
            Debug.Log("Koopa Shell Hits Goomba");
            //collision.gameObject.SetActive(false);
            //player.SetScore(400);
        }


        // Debug.Log("Object that entered the trigger : " + collider);
    }



    public void KoopaKick()
    {
        Debug.Log("Koopa Kick");
        Destroy(gameObject, 4);
    }





}
