using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<LineRenderer>().startColor = Color.blue;
        GetComponent<LineRenderer>().endColor = Color.blue;
    }
}
