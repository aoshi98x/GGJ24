using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesObserver : MonoBehaviour
{
    [SerializeField] CollisionSubject[] subjectToObserve;
    [SerializeField] int score, life;

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
        if(life<100)
        {
            life += 5;
        }
        else if(life >100)
        {
            life = 100;
        }

        score += 500;
        GameManager.Instance.Score = 25;
    }
    private void NoCoincidence()
    {
        life -= 5;
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
