using System;
using System.Collections;
using System.Collections.Generic;
using EmeraldAI;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnerBot : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [Tooltip("Точки появления бота")]
    [SerializeField] private List<GameObject> spawners;
    [SerializeField] private GameObject parent;
    [Header("Настройки ботов")]
    [Tooltip("Префабы ботов")]
    [SerializeField] private List<GameObject> prefabsBot;
    //[Tooltip("Радиус обнаружения игрока ботом")]
    //[SerializeField] private int[] detectionRadius;
    [Tooltip("Скорость бега")]
    [SerializeField] private int[] runSpeed;
    [Header("Настройки уровня")]
    [Tooltip("Шанс появления сильного бота(Element 1 в префабах бота)")]
    [SerializeField] private int chanseHardBot = 30;
    [Tooltip("Отображение уровня")]
    [SerializeField] private int lvl = 1;
    [Tooltip("Колличество ботов на первом уровне")]
    [SerializeField] private int countBot1Lvl = 10;
    [Tooltip("Сколько ботов добавится при переходе на следующий уровень")]
    [SerializeField] private int plusBotLvl = 2;
    [Tooltip("Сколько добавить скорости боту на следующем уровне")]
    [SerializeField] private int plusSpeed = 1;
    [Header("Настройки босса")]
    [Tooltip("Префаб босса")]
    [SerializeField] private GameObject prefabBotBoss;
    [Tooltip("Через сколько уровней появится босс")]
    [SerializeField] private int everyLevels = 5;
    [Tooltip("Радиус обнаружения")]
    [SerializeField] private int detectionRadiusBoss = 18;
    [Tooltip("Скорость бега")]
    [SerializeField] private int runSpeedBoss = 5;

    private void Awake()
    {
        prefabBotBoss.GetComponent<EmeraldAISystem>().DetectionRadius = detectionRadiusBoss;
        prefabBotBoss.GetComponent<EmeraldAISystem>().RunSpeed = runSpeedBoss;
        
        for (int i = 0; i < prefabsBot.Count - 1; i++)
        {
            //prefabsBot[i].GetComponent<EmeraldAISystem>().DetectionRadius = detectionRadius[i];
            prefabsBot[i].GetComponent<EmeraldAISystem>().RunSpeed = runSpeed[i];
        }
        
    }

    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(AllBot());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var testObj = PhotonNetwork.Instantiate("TestNetObj", new Vector3(-1, 1, -10), quaternion.identity);
            Debug.Log(testObj.name );
        }
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < countBot1Lvl; i++)
        {
            int randomSpawn = Random.Range(0, spawners.Count);
            int randomBot = Random.Range(0, 101);

            switch (randomBot)
            {
                case { } n when (n > chanseHardBot && n <= 100):
                    //Instantiate(prefabsBot[0],spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
                    var bot =PhotonNetwork.Instantiate("TestBotNet",transform.position,Quaternion.identity);
                    bot.transform.parent = gameObject.transform;
                    break;
                case { } n when (n <= chanseHardBot):
                    Instantiate(prefabsBot[1],spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
    
    private void Level()
    {
        text.GetComponent<TextMesh>().text=$"Level: {lvl+1}";
        lvl += 1;
        Debug.Log("update " + lvl);
        countBot1Lvl += plusBotLvl;
        chanseHardBot += 5;
        
        for (int i = 0; i < prefabsBot.Count - 1; i++)
        {
            prefabsBot[i].GetComponent<EmeraldAISystem>().RunSpeed += plusSpeed;
        }
        
        StartCoroutine(Spawn());
        
        if (lvl % everyLevels == 0)
            SpawnBoss();
    }
    
    
    private void SpawnBoss()
    {
        if (prefabBotBoss != null)
        {
            int randomSpawn = Random.Range(0, spawners.Count-1);
            Instantiate(prefabBotBoss,spawners[randomSpawn].transform.position,Quaternion.identity,parent.transform);
        }
        
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
