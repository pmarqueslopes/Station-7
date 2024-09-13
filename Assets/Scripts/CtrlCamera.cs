using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlCamera : MonoBehaviour
{
    public float speed;
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    public  float zoommin;
    public float zoomax;

    public void ZoomCamera()

    {
         float Fov = GetComponent<Camera>().fieldOfView;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Fov--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Fov++;
        }
        if(Fov> zoomax)
        {
            Fov = zoomax;
        }
        if (Fov < zoommin)
        {
            Fov = zoommin;
        }

        GetComponent<Camera>().fieldOfView = Fov;
    }




    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * -speed;
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * -speed;
        transform.Translate(xMove, 0f, zMove, Space.World);


        Vector3 clampedPosition = transform.position;

        if (clampedPosition.x > xMax)
        {
            clampedPosition.x = xMax;
        }
        if (clampedPosition.x < xMin)
        {
            clampedPosition.x = xMin;
        }
        if (clampedPosition.z > zMax)
        {
            clampedPosition.z = zMax;
        }
        if (clampedPosition.z < zMin)
        {
            clampedPosition.z = zMin;
        }

        //clampedPosition.x = Mathf.Clamp(clampedPosition.x, -136f, -180f);

        transform.position = clampedPosition;
        ZoomCamera();
    }
}