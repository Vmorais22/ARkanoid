using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    private Rigidbody rb;
    public bool work = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, rb.velocity.y, speed * z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.angularVelocity);
        if(!work)
        {
            transform.position = transform.position;
        }
        else
        {
            
        }

    }

    public void ChangeWork()
    {
        work = !work;
    }
}
