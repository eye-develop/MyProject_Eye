using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerBot : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> spawners;
    [SerializeField] private GameObject parent;
    [SerializeField] private List<GameObject> prefabsBot;
    [SerializeField] private int chanseHardBot = 30;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int countBot1Lvl = 10;
    [SerializeField] private GameObject prefabBotBoss;
    [SerializeField] private int everyLevels = 5;
    
    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(AllBot());
    }
    
    private IEnumerator Spawn()
    {
        for (int i = 0; i < countBot1Lvl; i++)
        {
            int randomSpawn = Random.Range(0, spawners.Count-1);
            int randomBot = Random.Range(0, 101);

            switch (randomBot)
            {
                case { } n when (n > chanseHardBot && n <= 100):
                    Instantiate(prefabsBot[0],spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
                    break;
                case { } n when (n <= chanseHardBot):
                    Instantiate(prefabsBot[1],spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
                    break;
                default:
                    break;
            }

            if (lvl % everyLevels == 0)
            {
                Debug.Log("boss");
                //Instantiate(prefabBotBoss,spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
            }
                 
            yield return new WaitForSeconds(2f);
        }
    }
    
    private void Level()
    {
        lvl += 1;
        countBot1Lvl += 2;
        chanseHardBot += 5;
        StartCoroutine(Spawn());
    }
    
    public IEnumerator AllBot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (parent.transform.childCount == 0)
            {
                Level();
            }
        }
    }
}
