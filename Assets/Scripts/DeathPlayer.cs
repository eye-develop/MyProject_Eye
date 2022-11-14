using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        Debug.Log("start");
        Debug.Log(gameObject.transform.position);
    }

    public void Respawn()
    {
        player.gameObject.transform.position = gameObject.transform.position;
        Debug.Log("player " + player.gameObject.transform.position);
        Debug.Log("spawner " + gameObject.transform.position);
    }
}
