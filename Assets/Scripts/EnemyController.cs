using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;
    private float defaultSpeed;

    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = moveSpeed;
        myRB = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
        float distanceX = Mathf.Abs(transform.position.x - thePlayer.transform.position.x);
        float distanceZ = Mathf.Abs(transform.position.z - thePlayer.transform.position.z);

        //float distanceY = Mathf.Abs(transform.position.y - thePlayer.transform.position.y);

        if (distanceX > 50f || distanceZ > 50f /*|| distanceY > 10f*/)
        {
            Destroy(gameObject);
        }

        moveSpeed =  defaultSpeed + Score.getScore() / 500;
    }
}
