using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    //private Vector3 cameraTarget;
    public Vector3 offset;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            transform.position = new Vector3(0f, 100f, 0f);
        }
        else
        {

            //cameraTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
            //transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
            Vector3 newPosition = new Vector3(target.position.x, 0, target.position.z);
            transform.position = newPosition + offset;
        }
    }
}
