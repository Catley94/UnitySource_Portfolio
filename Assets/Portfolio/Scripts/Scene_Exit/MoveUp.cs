using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("ENTERED");
    }
    
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("EXITED");
    }
}
