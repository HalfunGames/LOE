using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_mechanics : MonoBehaviour
{
    public float timeLimit = 5;
    public float time;

    public float speed = 2;

    public GameObject impact;
    public GameObject bigExplosion;
    public GameObject smoke;
    public GameObject fire;

    private void Start()
    {
        time = timeLimit;
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        //move bullet
        transform.position += (transform.forward) * speed;
        if (time <= 0)
        {
            Debug.Log("SelfDestruct");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //check collision
        //if enemy remove
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Destroy");
            Instantiate(bigExplosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Instantiate(smoke, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Instantiate(fire, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }
        //remove self
        Debug.Log("Hit");
        Instantiate(impact, transform.position, Quaternion.Inverse(transform.rotation));
        Destroy(gameObject);
    }
}
