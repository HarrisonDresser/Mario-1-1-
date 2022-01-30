using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockController : MonoBehaviour
{

    public GameObject pickupPrefab;
    public SpriteRenderer spriteRenderer;
    public Sprite BlockHit;

    void start()
    {
        //spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
    }        


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            //ISSUE WITH BLOCK HIT CALLING METHOD
            //BlockHit();
            //USE FOR CALLING OTHER SCRIPTS TO THIS TRIGGER - ITEMS, ETC
            //collider.GetComponent<ScriptName>().Method();
            Debug.Log("Player Contact with QBlock");
        }
    }


    public void Blockhit()
    {
        Instantiate(pickupPrefab, transform.position + Vector3.up, transform.rotation);
        //transform.parent.GetComponent<SpriteRenderer>.Sprite = BlockHit;
        //GetComponent<BoxCollider>().enabled = false;
    }



    
}
