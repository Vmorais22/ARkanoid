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
        GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().bonusCaught = true;
    }
}
