using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    private Rigidbody rb;
    public bool work = false;
    private  Vector3 oldVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, rb.velocity.y, speed * z);
        oldVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ChangeWork();
        }
        //Game paused when QR not visible
        if (!work && rb.velocity != new Vector3(0.0f, 0.0f, 0.0f))
        {
            oldVelocity = rb.velocity;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        //else works normal
        else if (work) 
        {
            if (rb.velocity == new Vector3(0.0f, 0.0f, 0.0f)) {
                rb.velocity = oldVelocity;
            }

            //si la pelota está distruida
            
        }
    }
   
    public void ChangeWork()
    {
        work = !work;
    }
}
