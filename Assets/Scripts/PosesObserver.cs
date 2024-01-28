using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosesObserver : MonoBehaviour
{
    [SerializeField] Destructor subjectToObserve;

    [SerializeField] AudioClip[] soundClips;

    private void Awake()
    {
        if (subjectToObserve != null)
        {
          
          subjectToObserve.Strong += TotalCoincidence;
          subjectToObserve.Medium += MediumCoincidence;
          subjectToObserve.Light += LightCoincidence;
          subjectToObserve.None += NoCoincidence;
          
        }
    }

    private void TotalCoincidence()
    {
        GameManager.Instance.PlaySfx(soundClips[0]);
        if(GameManager.Instance.Health < 100)
        {
            GameManager.Instance.Health = 15;
        }
        else if(GameManager.Instance.Health >= 100)
        {
            GameManager.Instance.Health = 0;
        }

        GameManager.Instance.Score = 25;
    }
    private void MediumCoincidence()
    {
        if (GameManager.Instance.Health < 100)
        {
            GameManager.Instance.Health = 5;
        }
        GameManager.Instance.Score = 10;
    }
    private void LightCoincidence()
    {
        GameManager.Instance.TakeDamage(5);
        GameManager.Instance.Score = 5;
    }
    private void NoCoincidence()
    {
        GameManager.Instance.PlaySfx(soundClips[1]);
        GameManager.Instance.TakeDamage(15);
    }

    private void OnDestroy()
    {
        // unsubscribe/deregister from the event if we destroy the object
        if (subjectToObserve != null)
        {
             subjectToObserve.Strong -= TotalCoincidence;
             subjectToObserve.Medium -= MediumCoincidence;
             subjectToObserve.Light -= LightCoincidence;
             subjectToObserve.None -= NoCoincidence;


        }
    }
}
