using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    enum State { onWall ,onGround, onAir }
    [SerializeField] int power;
    Rigidbody _rigidbody;
    [SerializeField] int speed;
    int jumpCount;
    State playerState;
    RaycastHit rayhit;

    // Start is called before the first frame update
    void Start()
    {
        // float MaxHeight;
        jumpCount = 2;
        
        _rigidbody =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out rayhit))
        {
            rayhit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log(rayhit.collider.name);
            Debug.Log("HIIIIIIIT!!!!");
        }
        PlayerMovement();
       //MaxHeight =  _rigidbody.transform.position.
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("enter collision");
        if (collision.collider.tag == "ground")
        {
            playerState = State.onGround;
            jumpCount = 2;
        }
        else if (collision.collider.tag == "wall")
        {
            
            playerState = State.onWall;
            jumpCount = 1;
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit collision");
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        Debug.Log(_rigidbody.velocity.y);
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x,-_rigidbody.velocity.y,_rigidbody.velocity.z);
        
    }
 
   
    private void PlayerMovement()
    {
        
        Vector3 force = new Vector3(0,0,0);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount>0)
        {
            jumpCount--;
            force += Vector3.up * power;
            if (playerState == State.onWall && _rigidbody.velocity.x > 0)
            {
                force += Vector3.left * power;
            }
            if (playerState == State.onWall && _rigidbody.velocity.x < 0)
            {
                force += Vector3.right * power;
            }

            
            //_rigidbody.AddForce(Vector3.up * power);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            force += new Vector3 (0, 0, speed* Time.deltaTime);

            //_rigidbody.AddForce();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            force += new Vector3(0, 0, -speed * Time.deltaTime);
            //_rigidbody.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force += new Vector3(-speed * Time.deltaTime, 0, 0);
            //_rigidbody.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force += new Vector3(speed * Time.deltaTime, 0, 0);
            //_rigidbody.AddForce(speed * Time.deltaTime, 0, 0);
        }
        _rigidbody.AddForce(force);
    }
}
