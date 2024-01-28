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
            Transform checker = GameObject.Find("HUDChecker").GetComponent<Transform>();
            switch (bodyPart)
            {
                case "HeadControl":
                    checker.GetChild(0).gameObject.SetActive(true);
                    break;

                case "LeftControl":
                    checker.GetChild(1).gameObject.SetActive(true);
                    break;

                case "RightControl":
                    checker.GetChild(2).gameObject.SetActive(true);
                    break;
            }
            wasCorrect = true;
        }
    }
}
