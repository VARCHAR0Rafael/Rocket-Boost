using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateValue = 100f;
    [SerializeField] AudioClip audioClip;

    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //getting a rigidbody component added to a variable
        rb = GetComponent<Rigidbody>(); //variable to cath the rigidbody
        audioSource = GetComponent<AudioSource>();  //variable to cath the audiosoruce
    }

    // Update is called once per frame
    void Update()
    {
        //Main gameplay processes
        ProcessThrust();
        ProcessRotation();
    }
    //process for boost the rocket and makeing go up
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //use relative force to add force relative to tha face ot tip of the rocket
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!audioSource.isPlaying) //we use an if state to prevend double audio bugs
            {
                //play rocket boost audio
                audioSource.PlayOneShot(audioClip);
            }
        }
        else
        {
            //stop rocket boost audio
            audioSource.Stop();
        }
    }
    //process for rotation of the rocket to left and rigth
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateMethod(rotateValue);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateMethod(-rotateValue);
        }
    }

    private void RotateMethod(float rotationThisFrame)
    {
        rb.freezeRotation = true; //Freeze rotation when player is controllig to avoid bugs
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); //Actually rotating the rocket
        rb.freezeRotation = false; //Back to unfreeze rotation
    }
}
