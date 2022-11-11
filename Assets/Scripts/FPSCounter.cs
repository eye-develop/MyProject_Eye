using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private float _updateDelay;
    [SerializeField] private GameObject text;

    private float _elapsedTime;
    
    void Update()
    {
        _elapsedTime += Time.unscaledDeltaTime;

        if (_elapsedTime >= _updateDelay)
        {
            int currentFPS = (int) (1 / Time.unscaledDeltaTime);
            _fpsText.text = $"FPS: {currentFPS}";
            text.GetComponent<TextMesh>().text=$"FPS: {currentFPS}";
            _elapsedTime = 0;
        }
    }
}
