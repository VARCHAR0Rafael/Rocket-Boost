using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //getting a rigidbody component added to a variable
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
    //process for rotation of the rocket to left and rigth
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("PRESSED Left");
        }else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("PRESSED Rigth");
        }
    }
}
