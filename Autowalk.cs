using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Autowalk : MonoBehaviour
{


    public static float speed ;
    public static bool moveforward;
    private CharacterController controller;

    private Transform vrHead;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            moveforward = !moveforward;

        }
        if (moveforward)
        {


            speed = 1.0f;
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }


      
    }
}