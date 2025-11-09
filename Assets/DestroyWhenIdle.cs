using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//If Idle condition is true for a certain period of time, Destroy the object
public class DestroyWhenIdle : MonoBehaviour
{
    [SerializeField]
    private float delay = 5f;
    private bool hasLiveEffector;

    private Coroutine subroutine_ref = null;

    private void Update()
    {
        if (!hasLiveEffector && subroutine_ref == null)
        {
            subroutine_ref = StartCoroutine(DestroyAfterTimeDelay(delay));
        }
        else if (hasLiveEffector && subroutine_ref != null)
        {
            StopCoroutine(subroutine_ref);
            subroutine_ref = null;
        }
    }

    private IEnumerator DestroyAfterTimeDelay (float d)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Effector") && !hasLiveEffector)
        {
            hasLiveEffector = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Effector") && hasLiveEffector)
        {
            hasLiveEffector = false;
        }
    }
}
