using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    
    Material material;
    Color dangerColor;
    Color safeColor;
    // Start is called before the first frame update
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        dangerColor = new Color(50,50,50,1);
        safeColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DangerColor()
    {
        material.color = dangerColor;
    }
    public void SafeColor()
    {
        material.color = safeColor;
    }
}
