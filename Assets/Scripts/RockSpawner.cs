using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private float _maxInterval = 2.5f, _minInterval = 0.5f, _progressionTime = 60;
    [SerializeField] private GameObject _prefab;

    private float _timer;
    private float _interval;
    private void Start()
    {
        StartCoroutine(nameof(SpawnCor));   
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private IEnumerator SpawnCor()
    {
        while(true)
        {
            _interval = Mathf.Lerp(_maxInterval, _minInterval, _timer / _progressionTime);

            yield return new WaitForSeconds(_interval);

            Instantiate(_prefab, transform.position, Quaternion.identity);
        }
    }
}
