using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StickInteraction : MonoBehaviour
{
    [HideInInspector] public UnityEvent onColllisionRock = new UnityEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(-10, 10, 0, ForceMode.Impulse);
        }

        onColllisionRock.Invoke();
    }
}
