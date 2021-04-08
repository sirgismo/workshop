using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    Transform mainCam;
    
    [SerializeField] float camDistance;
    [SerializeField] Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        camDistance = 10f;
        camPos = mainCam.localPosition - transform.localPosition;
        camPos.z = -camDistance;
       
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        mainCam.localPosition = transform.localPosition + camPos;
        
        
    }
}
