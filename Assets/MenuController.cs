using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject canvasnormal, canvaspause, canvasoptions;

    public void OpenMenu()
    {
        GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().ChangeWork("stop");
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
        GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().ChangeWork("run");
        canvaspause.SetActive(false);
        canvasnormal.SetActive(true);
    }

    public void ChangeSphereVel(float value)
    {
        if (value == 1f) GameObject.Find("Sphere").GetComponent<ball>().speed = 15;
        else if (value == 2f) GameObject.Find("Sphere").GetComponent<ball>().speed = 25;
        else if (value == 3f) GameObject.Find("Sphere").GetComponent<ball>().speed = 35;
        else if (value == 4f) GameObject.Find("Sphere").GetComponent<ball>().speed = 45;
        else GameObject.Find("Sphere").GetComponent<ball>().speed = 55;
    }

    public void ChangeVolume(float value)
    {
        GameObject.Find("ARCamera").GetComponent<AudioSource>().volume = (value * value);
        GameObject.Find("ARCamera").GetComponent<AudioSource>().Pause();
    }

    public void SilenceVolume(bool value)
    {
        GameObject.Find("ARCamera").GetComponent<AudioSource>().mute = value;
    }

    public void ChangeVolumeEfects(float value)
    {
        GetComponent<AudioSource>().clip = GameObject.Find("Sphere").GetComponent<ball>().wall;
        GetComponent<AudioSource>().volume = (value * value);
        GetComponent<AudioSource>().Pause();
        GetComponent<AudioSource>().clip = GameObject.Find("Sphere").GetComponent<ball>().brick;
        GetComponent<AudioSource>().volume = (value * value);
        GetComponent<AudioSource>().Pause();
    }

    public void SilenceEffects(bool value)
    {
        GameObject.Find("Sphere").GetComponent<ball>().mute = value;
    }

    public void SpawnBonus()
    {
        GameObject.Find("MapImageTarget").GetComponent<mapBehavior>().respawnTime = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
