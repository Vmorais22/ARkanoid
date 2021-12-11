using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBehavior3 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool work = false;
    public float respawnTime;
    public float liveTime = 10.0f;
    private bool spawnedBonus = false;
    public bool bonusCaught = false;
    public GameObject[] randomBonus;
    public Transform parent;
    private GameObject actualBonus;
    public GameObject player;
    private int bonusId;
    private bool music = false;
    private bool musicRunning = false;

    void Start()
    {
        respawnTime = Random.Range(10.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (work)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            if (!spawnedBonus)
            {
                respawnTime -= Time.deltaTime;

                if (respawnTime <= 0.0f)
                {
                    bonusId = Random.Range(0, 7);
                    insertBonus();
                    actualBonus.transform.position = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), transform.position.y + 2.0f, transform.position.z + Random.Range(0.0f, 30.0f));
                }
            }
            else
            {
                liveTime -= Time.deltaTime;

                if (bonusCaught)
                {
                    Destroy(actualBonus);
                    bonusFunction(bonusId);
                    respawnTime = Random.Range(10.0f, 30.0f); ;
                    spawnedBonus = false;
                    bonusCaught = false;


                }
                else if (liveTime <= 0)
                {
                    Destroy(actualBonus);
                    spawnedBonus = false;
                    respawnTime = Random.Range(10.0f, 30.0f); ;
                }


            }
        }
        else
        {
            if (GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Pause();
            }
        }

    }

    private void bonusFunction(int bonusId)
    {
        switch (bonusId)
        {
            case 0:
                print("+1 vida al jugador");
                break;
            case 1:
                //acelera la pelota
                GameObject.Find("Sphere3").GetComponent<ball>().speed *= 2;
                break;
            case 2:
                print("aumenta los puntos del jugador");
                break;
            case 3:
                print("smooth move rayo y margen para arriba");
                break;
            case 4:
                //triplica el player
                GameObject copy1 = Instantiate(player, parent) as GameObject;
                copy1.name = "copy1";
                copy1.transform.tag = "Ball";
                GameObject copy2 = Instantiate(player, parent) as GameObject;
                copy2.name = "copy2";
                copy2.transform.tag = "Ball";
                break;
            case 5:
                //ralentiza la pelota
                GameObject.Find("Sphere3").GetComponent<ball>().speed /= 2;
                break;
            case 6:
                print("animación reducir longitud pala player");
                break;
            case 7:
                print("animación aumentar long pala player");
                break;
        }

    }

    private void insertBonus()
    {
        actualBonus = Instantiate(randomBonus[bonusId]) as GameObject;
        liveTime = 5.0f;
        spawnedBonus = true;
    }

    public void ChangeWork(string estado)
    {
        if (estado == "run") work = true;
        else if (estado == "stop") work = false;
    }
}
