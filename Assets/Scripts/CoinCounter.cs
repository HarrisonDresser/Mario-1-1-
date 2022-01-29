using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;

    void update() 
    {
        Debug.Log("Count: " + coinCount);
    }
    public void AddCoin()
    {
        coinCount += 1;
        if (coinCount > 99)
        {
            coinCount -= 100;
        }
    }
}