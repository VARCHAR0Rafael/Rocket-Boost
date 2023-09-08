using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reLoadDelay = 2f;
    [SerializeField] AudioClip crashAudioClip;
    [SerializeField] AudioClip SuccessAudioClip;

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  //variable to cath the audiosoruce
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FirstPoint":
                Debug.Log("This is the Starting point");
                break;
            case "Finish":
                LoadLevelDelay();
                break;
            default:
                StartCrash();
                break;
        }
    }

    void StartCrash()
    {
        //This is to enable player controls when it crash
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashAudioClip);

        Invoke("ReloadLevel", reLoadDelay);     //use invoke to delay the reload
    }
    void ReloadLevel()
    {
        //Reload scene code
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadLevelDelay()
    {
        //This is to enable player controls when reach the end of the level
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(SuccessAudioClip);
        //GetComponent<AudioSource>().enabled = false;
        Invoke("LoadNextLevel", reLoadDelay);   //use invoke to delay the load
    }
    void LoadNextLevel()
    {
        //load Next Level scene code
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneLevel = currentSceneIndex + 1;
        if (nextSceneLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneLevel = 0;
        }
        SceneManager.LoadScene(nextSceneLevel);
    }
}
