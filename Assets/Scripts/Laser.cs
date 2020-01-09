using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float targetTime = 5f;
    public GameObject impactEffect;

    public bool isFire;
    private LineRenderer lr;

    private AudioSource mAduioSrc;


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        mAduioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (isFire)
        {
            mAduioSrc.Play();
            targetTime -= Time.deltaTime;
            lr.SetPosition(1, new Vector3(0f, 0f, 5000f));

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider)
                {
                    lr.SetPosition(1, new Vector3(0f, 0f, hit.distance));

                    GameObject obj = (GameObject)Instantiate(impactEffect, hit.point, transform.rotation);
                    Destroy(obj, 2f);

                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<Enemy>().HurtEnemy(.2f);
                    }

                    if (hit.collider.gameObject.tag == "arm")
                    {
                        hit.collider.transform.parent.gameObject.GetComponent<Enemy>().HurtEnemy(.2f);
                    }
                }
                else
                {
                    lr.SetPosition(1, new Vector3(0f, 0f, 5000f));
                }
            }
        } else
        {
            lr.SetPosition(1, new Vector3(0f, 0f, .7f));
        }
    }
}
