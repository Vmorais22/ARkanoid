using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontMove : MonoBehaviour
{

    Vector3 initPosition;
    void Start()
    {
        initPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag != "Ball") transform.localPosition = initPosition;
        else transform.localPosition = new Vector3(transform.localPosition.x, 2, transform.localPosition.z);

    }
}
