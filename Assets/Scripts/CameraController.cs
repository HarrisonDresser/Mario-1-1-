using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Transform targetTransform;
    public Transform end;
    public Vector3 tempVec3 = new Vector3();

    void Start()
    {
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //GOOD CAMERA CODE - NO STOPING POINTS 
        tempVec3.x = targetTransform.position.x;
        tempVec3.y = this.transform.position.y;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;

        if(target.transform.position.x > -3f)
        {
          transform.position = new Vector3(target.transform.position.x, 3f, -10f);
        }
        if (target.transform.position.x > 193f)
        {
            Debug.Log("End");
            transform.position = new Vector3(end.transform.position.x, 3f, -10);
        }
         //if(target.transform.position.x > -3f && target.transform.position.x < 200f)
        //{
         // transform.position = new Vector3(target.transform.position.x, 3f, -10f);
        //}
        //else
        //{
            //transform.position = new Vector3(target.transform.position.x, 195f, -10f);
        //}



        //transform.position = new Vector3(target.transform.position.x, 0f, -10f);

       //this.transform.position = new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z);
       //this.transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "CameraMove")
        {
            Debug.Log("Collison");
        }
    }
    
}
