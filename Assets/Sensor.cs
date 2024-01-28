using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] string bodyPart;
    public bool wasCorrect;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(bodyPart))
        {
            wasCorrect = true;
        }
    }
}
