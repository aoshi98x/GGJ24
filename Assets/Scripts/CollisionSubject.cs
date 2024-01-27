using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSubject : MonoBehaviour
{
    public event Action Collide, Wrong;
    private CapsuleCollider bodyCollider;
    public string tag;

    private void Start()
    {
        bodyCollider = GetComponent<CapsuleCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tag))
        {
            Collide?.Invoke();
        }
        else 
        {
            Wrong?.Invoke();
        }
    }
}
