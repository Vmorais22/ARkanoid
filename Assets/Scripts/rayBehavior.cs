using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayBehavior : MonoBehaviour
{

    public GameObject ball;
    public Transform parent;
    private float targetTime = 5.0f;
    private bool timerEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerEnabled)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                timerEnabled = false;
                targetTime = 5.0f;
                Instantiate(ball, parent);
            }
    }
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            timerEnabled = true;

        }

    }
}
