using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private KeyCode _key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(_key))
            Spawn();
    }

    private void Spawn()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
