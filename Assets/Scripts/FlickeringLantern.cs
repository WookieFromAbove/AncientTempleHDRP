using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLantern : MonoBehaviour
{
    private Renderer _emissionRenderer;

    private Color _baseColor;
    private Color _newColor;

    [SerializeField]
    private float _minIntensity = -0.2f;
    [SerializeField]
    private float _maxIntensity = 0.2f;

    private float _randomIntensity;

    private float _rate = 0.1f;

    private bool _isFlickering = true;

    private void Start()
    {
        _emissionRenderer = GetComponent<Renderer>();
        if (_emissionRenderer == null)
        {
            Debug.Log("Renderer is NULL.");
        }
        
        _baseColor = _emissionRenderer.material.color;

        StartCoroutine(FlickerRoutine());
    }

    private IEnumerator FlickerRoutine()
    {
        _isFlickering = true;

        while (_isFlickering == true)
        {
            _randomIntensity = Random.Range(_minIntensity, _maxIntensity);

            _newColor = _baseColor * _randomIntensity;

            DynamicGI.SetEmissive(_emissionRenderer, _newColor);

            yield return new WaitForSeconds(_rate);
        }
    }
}
