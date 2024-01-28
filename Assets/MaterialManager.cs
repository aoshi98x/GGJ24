using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public List<Material> wallsTextures = new List<Material>();

    public void ReplaceMaterial(MeshRenderer actual, List<Material> newMat, int index)
    {
        actual.material = newMat[index];
    }
    
   
}
