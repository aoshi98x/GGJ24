using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Destructor : MonoBehaviour
{
    public event Action None, Strong, Medium, Light;
    [SerializeField]int coincidenceLevel;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Wall"))
        {
            coincidenceLevel = 0;
            for (int i = 0; i < other.transform.childCount; i++)
            {
                if(other.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    Transform shilouette = other.transform.GetChild(i);
                    for (int j = 0; j < shilouette.childCount; j++)
                    {
                        if (shilouette.GetChild(j).gameObject.GetComponent<Sensor>().wasCorrect)
                        {
                            coincidenceLevel++;
                        }
                    }
                }
            }
            switch (coincidenceLevel)
            {
                case 1:
                    Light?.Invoke();
                    break;

                case 2:
                    Medium?.Invoke();
                    break;

                case 3:
                    Strong?.Invoke();
                    break;

                default:
                    None?.Invoke();
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
