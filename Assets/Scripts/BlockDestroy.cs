using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{

    /*
    public float xPos;
    public float yPos;
    public float zPos;
    */
 
    // Start is called before the first frame update
     public Animator animator;
    private MarioScript player;




     //public bool blockHit;
    


void Start()
{
    animator = GetComponent<Animator>();
    player = FindObjectOfType<MarioScript>();
    //blockHit = false;
    //animation["Brickk-Bounce"].wrapMode = WrapMode.Once;
}


 public void OnTriggerEnter2D (Collider2D collider)
 {
    // If the collider is entered by player tage the


    if (collider.transform.CompareTag("Player"))
        {
            //blockHit = true;
            // GetComponent<Animation>().Play("Brick-Bounce"); 
            Debug.Log("block hit");
            if (player.currentHealth == 1)
            {
                animator.Play("Hit");
            }
            else if (player.currentHealth == 2)
            {
                Destroy(gameObject);
            }
            
        }
   
 }




 /*
     if (collision.collider.tag == "Ground")
        {
           isGrounded = true;
           animator.SetBool("Jump", false);
        }
        else
        {
            isGrounded = false;
        }

*/
 






    /*
    IEnumerator OnTriggerEnter (Collider col)
    {
        transform.GetComponent<Collider>().isTrigger = false;
        if (col.gameObject.tag == "Player")
        {
            this.transform.position = new Vector3(xPos, yPos + 0.2F, zPos);
            yield return new WaitForSeconds(0.08F);
            this.transform.position = new Vector3(xPos, yPos, zPos);
            yield return new WaitForSeconds(0.25F);
            transform.GetComponent<Collider>().isTrigger = true;
            Debug.Log("hit");
        }
        Debug.Log("hit");
    }

    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    */
}
