using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float[] _layerSpeeds; 
    [SerializeField] private Layer[] _layerObjects;

    private Transform _cameraTransform; 
    private float[] _startPositions; 
    private float _boundSizeX; 
    private float _sizeX; 

    private void Start()
    {
        _cameraTransform = Camera.main.transform; 
        _sizeX = _layerObjects[0].transform.localScale.x; 
        _boundSizeX = _layerObjects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; 
        _startPositions = new float[_layerObjects.Length]; 

        for (int i = 0; i < _layerObjects.Length; i++)
        {
            _startPositions[i] = _cameraTransform.position.x;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _layerObjects.Length; i++)
        {
            float reverseLayerSpeed = 1 - _layerSpeeds[i];
            float temp = (_cameraTransform.position.x * reverseLayerSpeed);
            float distance = _cameraTransform.position.x * _layerSpeeds[i];
            _layerObjects[i].transform.position = new Vector2(_startPositions[i] + distance, _cameraTransform.position.y);

            if (temp > _startPositions[i] + _boundSizeX * _sizeX)
            {
                _startPositions[i] += _boundSizeX * _sizeX;
            }
            else if (temp < _startPositions[i] - _boundSizeX * _sizeX)
            {
                _startPositions[i] -= _boundSizeX * _sizeX;
            }
        }
    }
}
