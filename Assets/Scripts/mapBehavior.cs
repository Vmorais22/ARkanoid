using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public bool work = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(work);

    }


    public void ChangeWork(string estado)
    {
        if (estado == "run") work = true;
        else if (estado == "stop") work = false;
    }
}
