using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _golfStick;
    [SerializeField] private float _range = 30, _speed = 500;

    private bool _isDown;

    private void Start()
    {
        
    }

    private void Update()
    {
        _isDown = Input.GetMouseButton(0);

        Quaternion rot = _golfStick.localRotation;

        Quaternion toRot = Quaternion.Euler(_isDown ? _range : -_range, 0, 0);

        rot = Quaternion.RotateTowards(rot, toRot, _speed * Time.deltaTime);

        _golfStick.localRotation = rot; 
    }

    public void OnLoseRock()
    {
        Debug.Log("GameOver");
    }

}
