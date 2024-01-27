using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform initialPoint, destinyPoint, wallTrans;
    [SerializeField] float timeToSpawn;
    public float difficultyTime;
    [SerializeField] float velocityFactor;
    // Start is called before the first frame update
    void Start()
    {
        initialPoint = GameObject.Find("InitialPoint").GetComponent<Transform>();
        destinyPoint = GameObject.Find("DestinyPoint").GetComponent<Transform>();
        wallTrans = GameObject.Find("Wall").GetComponent<Transform>();
        wallTrans.gameObject.SetActive(false);
        velocityFactor = 5;
    }

    private void Update() {

        if (timeToSpawn >= difficultyTime)
        {
            switch (difficultyTime)
            {
                case >=4:

                    wallTrans.GetComponent<WallMovement>().velocity = velocityFactor * (difficultyTime/5);

                    break;
                case <= 3:

                    wallTrans.GetComponent<WallMovement>().velocity = (velocityFactor / difficultyTime) * 3;
                    
                    break;
            }
            wallTrans.gameObject.SetActive(true);
            wallTrans.position = initialPoint.position;
            timeToSpawn = 0;
        }
        if (wallTrans.position.z <= destinyPoint.position.z)
        {
            wallTrans.position = initialPoint.position;
            wallTrans.gameObject.SetActive(false);
            timeToSpawn = 0;
        }
    }

    void FixedUpdate()
    {
        timeToSpawn += Time.fixedDeltaTime;
    }

}
