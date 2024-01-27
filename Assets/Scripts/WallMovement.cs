using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField]Transform wallPos;
    public float velocity;

    void Start()
    {
      
        wallPos = GetComponent<Transform>();
        
    }
        


    void FixedUpdate()
    {
        FwdMovement((int)velocity);
    }

    void FwdMovement (int movementVel)
    {
        wallPos.Translate(Vector3.forward * movementVel * Time.deltaTime);
    }
}
