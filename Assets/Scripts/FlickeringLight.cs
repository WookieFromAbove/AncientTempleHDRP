using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField]
    private float _maxIncrease = 0.2f;
    [SerializeField]
    private float _maxDecrease = 0.2f;
    [SerializeField]
    private float _rateDamping = 0.1f;
    [SerializeField]
    private float _strength = 300f;

    private bool _stopFlickering = false;

    private Light _lightSource;

    private float _baseIntensity;

    private bool _isFlickering = false;

    // Start is called before the first frame update
    void Start()
    {
        _lightSource = GetComponent<Light>();
        if (_lightSource == null)
        {
            Debug.Log("LightSource is NULL.");
        }

        _baseIntensity = _lightSource.intensity;
        
        StartCoroutine(FlickerRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!_stopFlickering && !_isFlickering)
        {
            StartCoroutine(FlickerRoutine());
        }
    }

    private IEnumerator FlickerRoutine()
    {
        _isFlickering = true;

        while (!_stopFlickering)
        {
            _lightSource.intensity = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - _maxDecrease, _baseIntensity + _maxIncrease), _strength * Time.deltaTime);
            
            yield return new WaitForSeconds(_rateDamping);
        }

        _isFlickering = false;
    }
}
