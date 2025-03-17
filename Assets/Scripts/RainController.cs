using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField] private Transform _rainTransform;
    [SerializeField] private ParticleSystem _rainParticle;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private KeyCode _key;
    [SerializeField] private float _transitionDuration = 3f; 

    private bool _isMove;
    private int _targetCounter;
    private Transform _currentTarget;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_key))
        {
            MoveNextTarget();
        }
    }

    public void MoveNextTarget()
    {
        if (_isMove)
            return;

        if (_targetCounter == _targets.Count - 1)
            _targetCounter = 0;
        else 
            _targetCounter++;

            _currentTarget = _targets[_targetCounter];

        _isMove = true;

        _rainParticle.Stop();

        StartCoroutine(nameof(MoveCor));
    }

    private IEnumerator MoveCor()
    {
        float timer = 0;

        Vector3 startPosition = transform.position;

        while (true)
        {
            if (timer > _transitionDuration)
                break;

            Vector3 tempPosition = Vector3.Lerp(startPosition, _currentTarget.position, timer / _transitionDuration);
            Vector3 newPosition = new(tempPosition.x, _rainTransform.position.y, tempPosition.z);

            _rainTransform.position = newPosition;

            timer += Time.deltaTime;

            yield return null; 
        }

        _isMove = false;

        _rainParticle.Play();
    }
}
