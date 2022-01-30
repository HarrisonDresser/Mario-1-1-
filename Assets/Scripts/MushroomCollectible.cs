using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    private MarioScript marioScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
    MarioScript player = collider.gameObject.GetComponent<MarioScript>();

    if (player != null)
    {
        //TRIGGER NEW MARIO ANIMATION CONTROLLER OR SET BOOL TO TRUE FOR MARIO SIZE = Super
        player.ChangeHealth(1);
        Destroy(gameObject);
    }

        Debug.Log("Object that entered the trigger : " + collider);
    }


}
