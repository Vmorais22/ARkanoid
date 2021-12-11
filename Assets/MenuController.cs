using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject canvasnormal, canvaspause, canvasoptions, canvasdead;

    public float speed = 25.0f;

    public float volume = 1f;

    public bool mute = false;

    private bool heart = true;
    private bool heart1 = true;
    private bool heart2 = true;
    private bool heart3 = true;
    private bool heart4 = true;

    private float points = 0f;

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        canvasnormal.SetActive(false);
        canvaspause.SetActive(true);
    }

    public void OpenOptions()
    {
        canvaspause.SetActive(false);
        canvasoptions.SetActive(true);
    }

    public void CloseOptions()
    {
        canvasoptions.SetActive(false);
        canvaspause.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        canvaspause.SetActive(false);
        canvasnormal.SetActive(true);
    }

    public void ChangeSphereVel(float value)
    {
        if (value == 1f) speed = 15;
        else if (value == 2f) speed = 25;
        else if (value == 3f) speed = 35;
        else if (value == 4f) speed = 45;
        else speed = 55;
    }

    public void ChangeVolume(float value)
    {
        GameObject.Find("MapImageTarget").GetComponent<AudioSource>().volume = value * value;
        GameObject.Find("MapImageTarget2").GetComponent<AudioSource>().volume = value * value;
        GameObject.Find("MapImageTarget3").GetComponent<AudioSource>().volume = value * value;
    }

    public void SilenceVolume(bool value)
    {
        GameObject.Find("MapImageTarget").GetComponent<AudioSource>().mute = value;
        GameObject.Find("MapImageTarget2").GetComponent<AudioSource>().mute = value;
        GameObject.Find("MapImageTarget3").GetComponent<AudioSource>().mute = value;
    }

    public void ChangeVolumeEfects(float value)
    {
        volume = value * value;
    }

    public void SilenceEffects(bool value)
    {
        mute = value;
    }

    public void SpawnBonus()
    {
        GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().respawnTime = 0f;
        GameObject.Find("MapImageTarget2").GetComponent<mapBehaviour2>().respawnTime = 0f;
        GameObject.Find("MapImageTarget3").GetComponent<mapBehavior3>().respawnTime = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//prueba
    }

    //Funciones del juego

    public void UpdatePointsBrick()
    {
        points += 10f;
        GameObject.Find("Points").GetComponent<Text>().text = points.ToString();
    }

    public void UpdatePointsBonus()
    {
        points += 100f;
        GameObject.Find("Points").GetComponent<Text>().text = points.ToString();
    }

    public void LoseHeart()
    {
        if (heart4)
        {
            heart4 = false;
            GameObject.Find("Heart4").SetActive(false);
        }
        else if (heart3)
        {
            heart3 = false;
            GameObject.Find("Heart3").SetActive(false);
        }
        else if (heart2)
        {
            heart2 = false;
            GameObject.Find("Heart2").SetActive(false);
        }
        else if (heart1)
        {
            heart1 = false;
            GameObject.Find("Heart1").SetActive(false);
        }
        else if (heart)
        {
            heart = false;
            GameObject.Find("Heart").SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            canvasdead.SetActive(true);
        }
    }

    public void GainHeart()
    {
        if (!heart)
        {
            heart4 = true;
            GameObject.Find("Heart").SetActive(true);
        }
        else if (!heart1)
        {
            heart1 = true;
            GameObject.Find("Heart1").SetActive(true);
        }
        else if (!heart2)
        {
            heart2 = true;
            GameObject.Find("Heart2").SetActive(true);
        }
        else if (!heart3)
        {
            heart3 = true;
            GameObject.Find("Heart3").SetActive(true);
        }
        else if (!heart4)
        {
            heart4 = true;
            GameObject.Find("Heart4").SetActive(true);
        }
    }

}
