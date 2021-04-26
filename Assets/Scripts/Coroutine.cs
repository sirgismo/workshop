using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private float speed;
    IEnumerator MoveCo;
    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
        MoveCo = coroutine_test(speed);
        StartCoroutine(MoveCo);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) StopCoroutine(MoveCo);
    }
    private IEnumerator coroutine_test(float speed)
    {

        while (true)
        {
            Debug.Log(speed * Time.deltaTime);
            transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
            yield return null;
        }
        
    }


}
