using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifeTIme;
    public int damageToGive;

    public float explosionRadius;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTIme -= Time.deltaTime;

        if (lifeTIme <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Enemy>().HurtEnemy(damageToGive);
                GameObject obj = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(obj, 2f);
                Destroy(gameObject);
            }

            if (collider.tag == "Object")
            {
                GameObject obj = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(obj, 2f);
                Destroy(gameObject);
                Destroy(collider.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameObject.tag == "Bullet")
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().HurtEnemy(damageToGive);
                GameObject obj = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(obj, 2f);
                Destroy(gameObject);
            }

            if (other.gameObject.tag == "Object")
            {
                GameObject obj = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(obj, 2f);
                Destroy(gameObject);
            }

            if (other.gameObject.tag == "arm")
            {
                other.gameObject.transform.parent.gameObject.GetComponent<Enemy>().HurtEnemy(damageToGive);
                GameObject obj = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(obj, 2f);
                Destroy(gameObject);
            }
        } else if (gameObject.tag == "Missile")
        {
            explode();
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
