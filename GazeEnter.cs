using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject man;
    public float speed = 1f;
    public Vector3 rotAmount = new Vector3(0, 0, 0);
     
	// Use this for initialization
	void Start () {
        man = GameObject.Find("man");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GazeEnterEvent()
    {
        //stop walking 
        VRAutoscript.moveforward = false;
        VRAutoscript.speed = 0;
        //start GameObject Rotations 
        StartCoroutine(Rotations());
    }

    IEnumerator Rotations()
    {
        float endTime = Time.time + speed; // When to end the coroutine
        float step = 1f / speed; // How much to step by per sec
        var fromAngle = transform.eulerAngles; // start rotation
        var targetRot = transform.eulerAngles + rotAmount; // where we want to be at the end
        float t = 0; // how far we are. 0-1
        while (Time.time <= 180)
        {
            t += step * Time.deltaTime;
            //transform.eulerAngles = Vector3.Lerp(targetRot, transform.eulerAngles, t);
            man.transform.Rotate((0), (1f), (0) * t);
            yield return 0;
        }


        yield return 180;
    }
    public void GazeEnterExit()
    {
        //Walking again  
        VRAutoscript.moveforward = true;
        VRAutoscript.speed = 3f;
    }
}
