using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AGameState : MonoBehaviour
{
    public UnityEvent OnEnter = new(), OnExit = new();

    [SerializeField] List<GameObject> _activeGameobjects;

    public void Enter()
    {
        ActiveGameObjects(true);
        OnEnter.Invoke();
    }

    public void Exit()
    {
        ActiveGameObjects(false);
        OnExit.Invoke();
    }

    protected void ActiveGameObjects(bool active)
    {
        _activeGameobjects.ForEach(x => x.SetActive(active));
    }
}
