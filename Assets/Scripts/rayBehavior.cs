using UnityEngine;

public class rayBehavior : MonoBehaviour
{

    public GameObject ball;
    private Transform parent;
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
                GameObject newBall = Instantiate(ball, parent);
                newBall.name = "Sphere";
            }
    }
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            if (other.name == "Sphere")
            {
                timerEnabled = true;
                parent = transform.parent;
            }
                Destroy(other.gameObject);
            

        }

    }
}
