using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerBot : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> spawners;
    [SerializeField] private GameObject parent;
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
            int rnd = Random.Range(0, spawners.Count-1);
            Instantiate(prefabBot,spawners[rnd].transform.position,Quaternion.identity,parent.transform);
            yield return new WaitForSeconds(2f);
        }
    }
    
    private void Level()
    {
        lvl += 1;
        countBot1lvl += 2;
        StartCoroutine(Spawn());
    }
    
    public IEnumerator AllBot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (parent.transform.childCount == 0)
            {
                Debug.Log("level");
                Level();
            }
        }
    }
}
