using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerBot : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject prefabBot;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int countBot1lvl = 10;

    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(AllBot());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < countBot1lvl; i++)
        {
            Instantiate(prefabBot,spawner.transform.position,quaternion.identity,spawner.transform);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Level()
    {
        lvl += 1;
        countBot1lvl *= lvl;
        StartCoroutine(Spawn());
    }

    public IEnumerator AllBot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (spawner.transform.childCount == 0)
            {
                Debug.Log("level");
                Level();
            }
        }
    }
}
