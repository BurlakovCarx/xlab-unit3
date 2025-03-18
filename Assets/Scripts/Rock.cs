using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool collided;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Rock>(out Rock rock))
        {
            if (rock.collided)
                return;

            collided = true;
            rock.collided = true;

            var controller = FindObjectOfType<PlayerController>();
            controller.OnLoseRock();
        }
    }
}
