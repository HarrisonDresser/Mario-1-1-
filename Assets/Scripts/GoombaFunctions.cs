using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaFunctions : MonoBehaviour
{
    public MarioScript marioScript;
    public GoombaController goombaController;
    // Start is called before the first frame update
    void Start()
    {

        goombaController = GetComponent<GoombaController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        /*
       if (collider.transform.CompareTag("Player"))
        {
            //collider.gameObject.SetActive(false);
            //collider.GetComponent<GoombaController>().GoombaDeath();
            Debug.Log("DESTROY GOM");
            Destroy(this.gameObject);
            //Debug.Log("GoombaStomped");
            //collision.GetComponent<MarioScript>().ChangeHealth();
            //ChangeLives();
            //lives.text = "lives " + livesValue.ToString();
        //}
        }
        */
    }
    
}