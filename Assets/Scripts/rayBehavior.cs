using UnityEngine;

public class rayBehavior : MonoBehaviour
{

    public GameObject ball;
    private Transform parent;
    private float targetTime = 3.0f;
    private bool timerEnabled = false;
    public AudioClip death;

    public bool mute;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        volume = GameObject.Find("MenuController").GetComponent<MenuController>().volume;
        mute = GameObject.Find("MenuController").GetComponent<MenuController>().mute;

        if (GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().work)
        {
            if (timerEnabled)
            {
                targetTime -= Time.deltaTime;
                if (targetTime <= 0.0f)
                {
                    timerEnabled = false;
                    targetTime = 3.0f;
                    GameObject newBall = Instantiate(ball, parent);
                    newBall.name = "Sphere";
                }
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
                GameObject.Find("MenuController").GetComponent<MenuController>().LoseHeart();
            }
            if (!mute)
            {
                GetComponent<AudioSource>().clip = death;
                GetComponent<AudioSource>().volume = volume;
                GetComponent<AudioSource>().Play();
            }
            Destroy(other.gameObject);


        }

    }
}
