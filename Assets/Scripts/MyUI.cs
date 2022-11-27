using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyUI : MonoBehaviour
{
    [SerializeField] private Text deathText;
    private int deathBot;

    private void Start()
    {
        deathBot = 0;
        deathText.text = $"Bot :{deathBot}";
    }

    public void Test()
    {
        deathBot += 1;
        
        Debug.Log("Death");
        up();
    }

    private void up()
    {
        deathText.text = $"Bot :{deathBot}";
        Debug.Log("Bot "+deathBot);
    }
}
