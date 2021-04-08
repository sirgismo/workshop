using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int power;
    Rigidbody _rigidbody;
    [SerializeField] int speed;
     
    
    
    // Start is called before the first frame update
    void Start()
    {

        power = 200;
        speed = 200;
        _rigidbody =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 force = new Vector3(0,0,0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            force += Vector3.up * power;
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
