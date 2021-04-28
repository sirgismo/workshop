using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategicMove : MonoBehaviour
{
    [SerializeField] private int MovementSpeed;
    public new Camera  camera;
    private Ray ray;
    private RaycastHit hit;
    private GameObject selectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 1000;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            Debug.Log(hit.collider.name);
            // SelectPlayer();
            if (selectedPlayer)
            {
                Debug.Log(selectedPlayer.name);
                if (hit.collider.gameObject == selectedPlayer)
                {
                    Debug.Log(selectedPlayer.name);
                    selectedPlayer = null;
                }
                else
                {
                    Vector3 toPos = new Vector3(hit.point.x,0,hit.point.z);
                    Debug.Log(selectedPlayer.name);
                    Debug.Log(toPos);
                    StopAllCoroutines();
                    StartCoroutine(MoveTo(toPos));
                }
                
            }
            else if (hit.collider.gameObject.tag == "Player")
            {
                selectedPlayer = hit.collider.gameObject;
            }
        }

    }

   private IEnumerator MoveTo(Vector3 dest)
    {
        Debug.Log("enter Moveto");
        Vector3 playerPos = selectedPlayer.transform.position;

        //Vector3 distance;
        //MoveDir.Normalize();

        while ((dest-playerPos).magnitude>1)
        {
            playerPos = selectedPlayer.transform.position;
            Vector3 MoveDir = dest - playerPos;
            MoveDir = new Vector3(MoveDir.x, 0, MoveDir.z);
            Debug.Log(MovementSpeed * Time.deltaTime * MoveDir);
            Debug.Log("enterWhile");
            selectedPlayer.GetComponent<Rigidbody>().AddForce(MovementSpeed * Time.deltaTime * MoveDir);
            yield return null;

        }
    }
}
