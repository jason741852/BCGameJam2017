using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorDoor : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public float doorLSpeed;
    public float doorRSpeed;

    public bool openDoorsBool;
    public bool closeDoorsBool;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Open()
    {
        float t = 0f;
        if (openDoorsBool)
        {
            Vector3 startPosL = doorL.transform.position;
            Vector3 startPosR = doorR.transform.position;
            Vector3 endposL = doorL.transform.position + new Vector3(0f, 0f, doorL.transform.position.z + 5);
            Vector3 endposR = doorL.transform.position + new Vector3(0f, 0f, doorL.transform.position.z - 5);
            Debug.Log(endposL);
            Debug.Log(endposR);
            while (t < 1f)
            {
                t += Time.deltaTime * 0.05f;
                doorL.transform.position = Vector3.Slerp(startPosL, endposL, t);
                doorR.transform.position = Vector3.Slerp(startPosR, endposR, t);
                openDoorsBool = false;
                closeDoorsBool = true;
            }
            openDoorsBool = false;
            closeDoorsBool = true;
            return;

        }

        else
        {

                doorL.transform.position = new Vector3(doorL.transform.position.x, doorL.transform.position.y, doorL.transform.position.z - (float)100 * Time.deltaTime);
                doorR.transform.position = new Vector3(doorR.transform.position.x, doorR.transform.position.y, doorR.transform.position.z + (float)100 * Time.deltaTime);
            openDoorsBool = true;
            closeDoorsBool = false;
        }

    }

    void FixedUpdate()
    {

    }

}