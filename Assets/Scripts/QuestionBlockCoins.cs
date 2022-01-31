using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockCoins : MonoBehaviour
{

   // public GameObject pickupPrefab;
    public CoinCounter coinCounter;


    // public SpriteRenderer spriteRenderer;
    //public Sprite blockHit;
    public MarioScript marioScript;
    public Animator animator;
    //public bool isHit = false;
    public bool isHit = false;

    void start()
    {
        marioScript = FindObjectOfType<MarioScript>();
        animator = GetComponent<Animator>();
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
        
        Debug.Log("Player Contact with Coin Block");
        if (isHit == false)
        {
            //Invoke("Delay", 1);
            coinCounter.AddCoin();
            marioScript.SetScore(200);
            animator.Play("Question-Coins-Hit");
            isHit = true;
            
        }
        Debug.Log(isHit);
        //Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        //ChangeSprite();
        //transform.parent.GetComponent<SpriteRenderer>.Sprite = BlockHit;
        //GetComponent<BoxCollider>().enabled = false;
        //animator.SetBool("isHit", true);
        // animator.Play("Qblock_Bounce");
        //animator.SetBool("isHit", true);
        //animator.SetBool("isOpen", true);
    }
}