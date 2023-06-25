using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfCreditsTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("UI_Credits"))
        {
            other.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}
