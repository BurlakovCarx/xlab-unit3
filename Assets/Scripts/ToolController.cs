using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tools;
    [SerializeField] private KeyCode _key;

    private int _currentIndex;

    void Start()
    {
        SetRandomTool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
            SetRandomTool();
    }

    public void SetRandomTool()
    {
        _tools.ForEach(x => x.SetActive(false));

        _currentIndex = Random.Range(0, _tools.Count);

        _tools[_currentIndex].SetActive(true);
    }
}
