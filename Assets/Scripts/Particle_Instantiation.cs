using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Instantiation : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    
    public Vector3 playerVelocity;
    Rigidbody _rigidbody;
    private float timeElapsed;
    Vector3 particlePos;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        var randX = Random.Range(transform.position.x-0.5f, transform.position.x + 0.5f);
        var randY = Random.Range(transform.position.y - 0.5f, transform.position.y + 0.5f);
        var randZ = Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f);
        particlePos = new Vector3(randX, randY, randZ);

        timeElapsed += Time.deltaTime;
        playerVelocity = _rigidbody.velocity;
        var isPlayerMoving = playerVelocity.magnitude > 0.1;

        if (isPlayerMoving && timeElapsed>=0.03)
        {
            var particleInst = Instantiate(particle, particlePos, transform.rotation);
            particleInst.GetComponent<particle_movement>().playerRigidBody = _rigidbody;
            timeElapsed = 0;
        }
    }
}
