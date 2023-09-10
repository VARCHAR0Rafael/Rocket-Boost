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

    [SerializeField] ParticleSystem crashParcticles;
    [SerializeField] ParticleSystem SuccessParcticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool isCollosionOff = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();  //variable to cath the audiosoruce
    }

    void Update()
    {
        CheatCode();
    }

    void OnCollisionEnter(Collision collision)
    {
        //if statement to avoid double audios
        if (isTransitioning || isCollosionOff)
        {
            return;
        }

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
        isTransitioning = true;
        audioSource.Stop();
        //This is to enable player controls when it crash
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashAudioClip);
        crashParcticles.Play();

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
        isTransitioning = true;
        audioSource.Stop();
        //This is to enable player controls when reach the end of the level
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(SuccessAudioClip);
        SuccessParcticles.Play();
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

    void CheatCode()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();

        }else if (Input.GetKey(KeyCode.C))
        {
            isCollosionOff  = !isCollosionOff;
            //GetComponent<BoxCollider>().enabled = false;
        }
    }

}
