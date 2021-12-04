using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public bool work = false;
    public float respawnTime;
    public float liveTime = 10.0f;
    private bool spawnedBonus = false;
    public bool bonusCaught = false;
    public GameObject[] randomBonus;
    public Transform parent;
    GameObject actualBonus;
    private int bonusId;

    void Start()
    {
        respawnTime = Random.Range(10.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(work)
        {
            if (!spawnedBonus)
            {
                respawnTime -= Time.deltaTime;

                if (respawnTime <= 0.0f)
                {
                    bonusId = 3;
                    insertBonus();
                    actualBonus.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 2, Random.Range(0.0f, 30.0f));
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

    }

    private void bonusFunction(int bonusId)
    {
        switch (bonusId)
        {
            case 0:
                print("+1 vida al jugador");
                break;
            case 1:
                GameObject.Find("Sphere(Clone)").GetComponent<ball>().speed *= 2;
                break;
            case 2:
                print("aumenta los puntos del jugador");
                break;
            case 3:
                print("smooth move rayo y margen para arriba");
                break;
            case 4:
                print("algo super random (rota el mapa? aparecen cubos? más de una pelota?"); //podemos sacar mas ideas de aqui o cambiarlos xd.
                break;
            case 5:
                GameObject.Find("Sphere(Clone)").GetComponent<ball>().speed /= 2;
                break;
        }

    }

    private void insertBonus()
    {
        actualBonus = Instantiate(randomBonus[bonusId], parent) as GameObject;
        liveTime = 5.0f;
        spawnedBonus = true;
    }

    public void ChangeWork(string estado)
    {
        if (estado == "run") work = true;
        else if (estado == "stop") work = false;
    }
}
