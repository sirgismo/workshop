using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_movement : MonoBehaviour
{
    [SerializeField] private Vector3 playerSpeed;
    [SerializeField] private int shootSpeed;
    private float timeElapsed;
    public Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
       shootSpeed = 1;
       playerSpeed = playerRigidBody.velocity;


    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.position += -playerSpeed*Time.deltaTime*shootSpeed;
        if(timeElapsed>=2)
        {
            Destroy(gameObject);
        }
    }
}
