using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockController : MonoBehaviour
{

    public GameObject pickupPrefab;
   // public SpriteRenderer spriteRenderer;
    //public Sprite blockHit;
    private MarioScript player;
    public Animator animator;
    public bool isHit = false;


    void start()
    {
        player = FindObjectOfType<MarioScript>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //animator.SetBool("isOpen", false);
        //animator.SetBool("isHit", false);

    }        


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {

            //ISSUE WITH BLOCK HIT CALLING METHOD
            BlockHit();
            //USE FOR CALLING OTHER SCRIPTS TO THIS TRIGGER - ITEMS, ETC
            //collider.GetComponent<ScriptName>().Method();
        }
    }


    public void BlockHit()
    {
        Debug.Log("Player Contact with QBlock");
        if (isHit == false)
        {
            Invoke("Delay", 1);
            animator.Play("Qblock_Bounce");
            isHit = true;
        }

        //Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        //ChangeSprite();
        //transform.parent.GetComponent<SpriteRenderer>.Sprite = BlockHit;
        //GetComponent<BoxCollider>().enabled = false;
        //animator.SetBool("isHit", true);
       // animator.Play("Qblock_Bounce");
        //animator.SetBool("isHit", true);
        //animator.SetBool("isOpen", true);
    }

        
   public void Delay()
    {
        Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        //Debug.Log("Sprite Called");
        //spriteRenderer.sprite = blockHit;
    }
    
}
