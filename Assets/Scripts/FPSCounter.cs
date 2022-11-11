using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private float _updateDelay = 0.5f;
    [SerializeField] private GameObject text;

    private float _elapsedTime;
    
    void Update()
    {
        _elapsedTime += Time.unscaledDeltaTime;

        if (_elapsedTime >= _updateDelay)
        {
            int currentFPS = (int) (1 / Time.unscaledDeltaTime);
            text.GetComponent<TextMesh>().text=$"FPS: {currentFPS}";
            
            _elapsedTime = 0;
        }
    }
}
