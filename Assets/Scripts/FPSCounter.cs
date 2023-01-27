using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private float _updateDelay = 0.5f;
        [SerializeField] private GameObject textFps;
    
        [SerializeField] private GameObject textKill;
        private float _elapsedTime;
        private int kill;

        private void Start()
        {
            CounterKills.PointKillsAction += PlusKill;
        }

        void Update()
        {
            _elapsedTime += Time.unscaledDeltaTime;

            if (_elapsedTime >= _updateDelay)
            {
                int currentFPS = (int) (1 / Time.unscaledDeltaTime);
                textFps.GetComponent<TextMesh>().text=$"FPS: {currentFPS}";
                textKill.GetComponent<TextMesh>().text=$"Kill: {kill}";
            
                _elapsedTime = 0;
            }
        }

        public void PlusKill()
        {
            kill += 1;
        }
    
    }
}