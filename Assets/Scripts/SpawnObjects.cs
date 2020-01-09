using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject enemyObject;
    public Vector3 center;
    public Vector3 size;

    float targetTime = 5f;   //how long it will count down



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime; //reduce target time by 1 every second
        center = transform.position;

        if (targetTime <= 0.0f)       //timer ended
        {
            targetTime = 5.0f;
            SpawnEnemies();
            SpawnEnemies();
            SpawnEnemies();
        }        
    }

    public void SpawnEnemies()
    {
        Vector3 tempPos = transform.position;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0f, Random.Range(-size.z / 2, size.z / 2));
        while(Mathf.Abs(tempPos.x - pos.x) < 7.0f && Mathf.Abs(tempPos.z - pos.z) < 7.0f)
        {
            pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0f, Random.Range(-size.z / 2, size.z / 2));
        }

        GameObject t = Instantiate(enemyObject, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        Gizmos.DrawCube(center, size);
    }
}
