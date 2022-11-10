using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private float _updateDelay;

    private float _elapsedTime;
    
    void Update()
    {
        _elapsedTime += Time.unscaledDeltaTime;

        if (_elapsedTime >= _updateDelay)
        {
            int currentFPS = (int) (1 / Time.unscaledDeltaTime);
            _fpsText.text = $"FPS: {currentFPS}";
            _elapsedTime = 0;
        }
    }
}
