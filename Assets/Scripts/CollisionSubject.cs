using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionSubject : MonoBehaviour
{
    public event Action Collide, Neutral;
    private CapsuleCollider bodyCollider;
    public string tag0, tag1, tag2;
    

    private void Start()
    {
        bodyCollider = GetComponent<CapsuleCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tag0))
        {
            Collide?.Invoke();
        }
        else if(other.gameObject.CompareTag(tag1))
        {
            Neutral?.Invoke();
        }
        else if(other.gameObject.CompareTag(tag2))
        {
            Neutral?.Invoke();
        }
    }
}
