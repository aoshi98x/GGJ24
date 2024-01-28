using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesObserver : MonoBehaviour
{
    [SerializeField] CollisionSubject[] subjectToObserve;


    private void Awake()
    {
        if (subjectToObserve != null)
        {
            for (int i = 0; i < subjectToObserve.Length; i++)
            {
                subjectToObserve[i].Collide += Coincidence;
                subjectToObserve[i].Wrong += NoCoincidence;
            }
        }
    }

    private void Coincidence()
    {
        if(GameManager.Instance.Health < 100)
        {
            GameManager.Instance.Health = 5;
        }
        else if(GameManager.Instance.Health > 100)
        {
            GameManager.Instance.Health = 100;
        }

        GameManager.Instance.Score = 25;
    }
    private void NoCoincidence()
    {
        GameManager.Instance.TakeDamage();
    }

    private void OnDestroy()
    {
        // unsubscribe/deregister from the event if we destroy the object
        if (subjectToObserve != null)
        {
            for (int i = 0; i < subjectToObserve.Length; i++)
            {
                subjectToObserve[i].Collide -= Coincidence;
                subjectToObserve[i].Wrong -= NoCoincidence;
            }
            
        }
    }
}
