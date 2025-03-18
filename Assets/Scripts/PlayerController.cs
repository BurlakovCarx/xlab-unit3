using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent onAttemptsChange = new();
    public int attempts { get; private set; }
    public int maxAttempts { get => _maxAttempts; }

    [SerializeField] private int _maxAttempts = 3;
    [SerializeField] private Transform _golfStick;
    [SerializeField] private float _range = 30, _speed = 500;
    [SerializeField] private AGameState _gameoverState;

    private bool _isDown;

    private void OnEnable()
    {
        attempts = maxAttempts;
    }

    private void OnDisable()
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
        attempts--;
        onAttemptsChange.Invoke();

        if(attempts <= 0)
            FindObjectOfType<GameStateSwitch>().SwitchState(_gameoverState);
    }

}
