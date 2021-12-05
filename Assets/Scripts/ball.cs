using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 25.0f;
    private Rigidbody rb;
    private  Vector3 oldVelocity;
    public AudioClip wall;
    public AudioClip brick;

    void Start()
    {
        transform.localPosition = new Vector3(0, 2, 15);
        rb = GetComponent<Rigidbody>();
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = -1;
        rb.velocity = new Vector3(speed * x, 0.0f, speed * z);
        oldVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Game paused when QR not visible
        if (!GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().work && rb.velocity != new Vector3(0.0f, 0.0f, 0.0f))
        {
            oldVelocity = rb.velocity;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        //else works normal
        else if (GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().work) 
        {

            if (rb.velocity == new Vector3(0.0f, 0.0f, 0.0f))
            {
                rb.velocity = oldVelocity;
            }
            else rb.velocity = rb.velocity.normalized * speed;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.tag == "wall")
        {
            GetComponent<AudioSource>().clip = wall;
            GetComponent<AudioSource>().Play();
        }
        if (collision.collider.transform.tag == "brick")
        {
            GetComponent<AudioSource>().clip = brick;
            GetComponent<AudioSource>().Play();
        }
    }          
}
