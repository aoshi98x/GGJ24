using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    List<GameObject> poses = new List<GameObject>();
    [SerializeField] MaterialManager matManager;
    MeshRenderer wallRender;
    int indexPose;
    // Start is called before the first frame update
    void Start()
    {
        matManager = FindAnyObjectByType<MaterialManager>();
        wallRender = GetComponent<MeshRenderer>();
        for (int i = 0; i < transform.childCount; i++)
        {
            poses.Add(transform.GetChild(i).gameObject);
        }
        foreach (GameObject son in poses)
        {
            son.SetActive(false);
        }
        indexPose = Random.Range(0, poses.Count);
        poses[indexPose].SetActive(true);
        matManager.ReplaceMaterial(wallRender, matManager.wallsTextures, indexPose);
    }
}
