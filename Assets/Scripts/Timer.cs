using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 400;
    public Text timeText;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        TimeDisplay(timeValue);

        Debug.Log(timeValue);
    }

    void TimeDisplay(float timeToDisplay)
    {
        if(timeToDisplay < 0 )
        {
            timeToDisplay = 0;
        }
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
