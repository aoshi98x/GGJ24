using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform initialPoint, destinyPoint;
    [SerializeField] GameObject wall;
    public float time;
    [SerializeField] float velocityFactor;
    // Start is called before the first frame update
    void Start()
    {
        initialPoint = GameObject.Find("InitialPoint").GetComponent<Transform>();
        destinyPoint = GameObject.Find("DestinyPoint").GetComponent<Transform>();
    }

    private void Update() {

        

        if (time >= GameManager.Instance.timeToSpawn)
        {
            Instantiate(wall, initialPoint.position, Quaternion.Euler(0,180,0));
            time = 0;
        }
    }

    void FixedUpdate()
    {
        time+= Time.fixedDeltaTime;
    }

}
