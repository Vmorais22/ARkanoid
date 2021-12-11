using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.parent.localPosition = new Vector3(transform.parent.localPosition.x, 2.0f, transform.parent.localPosition.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Sphere") GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().bonusCaught = true;
        if(other.transform.name == "Sphere2") GameObject.Find("MapImageTarget2").GetComponent<mapBehaviour2>().bonusCaught = true;
    }
}
