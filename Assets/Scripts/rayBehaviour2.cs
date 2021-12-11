using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayBehaviour2 : MonoBehaviour
{
    public GameObject ball;
    private Transform parent;
    private float targetTime = 3.0f;
    private bool timerEnabled = false;
    public AudioClip death;
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
                targetTime = 3.0f;
                GameObject newBall = Instantiate(ball, parent);
                newBall.name = "Sphere2";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            if (other.name == "Sphere2")
            {
                timerEnabled = true;
                parent = transform.parent;
            }
            GetComponent<AudioSource>().clip = death;
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);


        }

    }
}
