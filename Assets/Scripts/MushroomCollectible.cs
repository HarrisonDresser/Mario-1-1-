using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    private MarioScript marioScript;
    public GameObject gameObject;


    float LeftPoint = -10f;
    float RightPoint = 16.5f;
    bool Direction = true;  //  true = right false = left






    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Direction == true)
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime, Space.World);
            Direction = true;
        }

        if (this.transform.position.x > RightPoint)
        {
            Direction = false;
        }

        if (Direction == false)
        {
            transform.Translate(Vector3.right * -2 * Time.deltaTime, Space.World);
            Direction = false;
        }

        if (this.transform.position.x < LeftPoint)
        {
            Direction = true;
        }
    

    }




    void OnTriggerEnter2D(Collider2D collider)
        {

            MarioScript player = collider.gameObject.GetComponent<MarioScript>();

            if (player != null)
            {
                this.transform.position = new Vector3(0, -1000, 0);
                //TRIGGER NEW MARIO ANIMATION CONTROLLER OR SET BOOL TO TRUE FOR MARIO SIZE = Super
                player.ChangeHealth(1);
                player.SetScore(1000);
                gameObject.SetActive(false);
            }

           // Debug.Log("Object that entered the trigger : " + collider);
        }

}
