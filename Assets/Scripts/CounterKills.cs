using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts;

namespace Assets.Scripts
{
    public class CounterKills : MonoBehaviour
    {
        public static event Action PointKillsAction;
    
        [SerializeField] private GameObject text;
        private float kill;
    
        public void TestKIll()
        {
            PointKillsAction?.Invoke();
        }

        public void OnDestroy()
        {
            Debug.LogWarning("destroy");
            StartCoroutine(DestroyTime());
        }

        IEnumerator DestroyTime()
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("fffff");
            SpawnerBot.Dest(gameObject);
            //Destroy(gameObject);
        }
    }
}
