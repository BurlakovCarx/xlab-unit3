using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StickInteraction : MonoBehaviour
{
    [HideInInspector] public UnityEvent onTrueColllisionRock = new UnityEvent();

    private bool _isDown;

    private void Update()
    {
        _isDown = Input.GetMouseButton(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            FindObjectOfType<ScoreManager>().AddPoint();

            if (_isDown)
                rb.AddForce(-15, 15, 0, ForceMode.Impulse);
            else
                rb.AddForce(15, 15, 0, ForceMode.Impulse);
        }

        onTrueColllisionRock.Invoke();
    }
}
