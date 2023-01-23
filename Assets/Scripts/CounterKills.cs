using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterKills : MonoBehaviour
{
    [SerializeField] private GameObject killsText;
    private int kills;

    private void Start()
    {
        kills = 0;
        killsText.GetComponent<TextMesh>().text=$"Kills: {kills}";
        
        Debug.Log($"kill + {kills}");
    }

    public void Kill()
    {
        Debug.Log($"kill + {kills}");
        kills += 1;
        killsText.GetComponent<TextMesh>().text=$"Kills: {kills}";
    }
}
