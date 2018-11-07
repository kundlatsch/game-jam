using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float ScrollSpeed = 15;
    public double ScrollEdge = 0.01;
     
    private int HorizontalScroll = 1;
    private int VerticalScroll = 1;
    private int DiagonalScroll = 1;
     
    public float PanSpeed = 10;
     
    private Vector2 Zoomrand_range = new Vector2(-5,5);
    private float CurrentZoom = 0;
    public float ZoomZpeed = 1;
    public float ZoomRotation = 1;
     
    private Vector3 InitPos;
    private Vector3 InitRotation;


    void Start()
    {
        //Instantiate(Arrow, Vector3.zero, Quaternion.identity);
      
       
    }
     
    void Update ()
    {
        
        if ( Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
            }
        else if ( Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * Time.deltaTime * ScrollSpeed, Space.World);
            }
           
        if ( Input.GetKey("w"))
            {
                transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed, Space.World);
            }
        else if ( Input.GetKey("s"))
            {
                transform.Translate(Vector3.down * Time.deltaTime * ScrollSpeed, Space.World);
            }


        // float fov = Camera.main.fieldOfView;
        // fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        // fov = Mathf.Clamp(fov, minFov, maxFov);
        // Camera.main.fieldOfView = fov;
    //ZOOM IN/OUT
       
        // CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;
       
        // CurrentZoom = Mathf.Clamp(CurrentZoom,Zoomrand_range.x,Zoomrand_range.y);
       
        // transform.position.y -= (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1;
        // transform.eulerAngles.x -= (transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1;
                 // Attaches the float y to scrollwheel up or down
         // float y = Input.mouseScrollDelta.y;
 
         // // If the wheel goes up it, decrement 5 from "zoomTo
         // if (y >= 1)
         // {
         //     zoomTo -= 5f;
         //     Debug.Log ("Zoomed In");
         // }
 
         // // If the wheel goes down, increment 5 to "zoomTo"
         // else if (y <= -1) {
         //     zoomTo += 5f;
         //     Debug.Log ("Zoomed Out");
         // }
 
         // // creates a value to raise and lower the camera's field of view
         // curZoomPos =  zoomFrom + zoomTo;
 
         // curZoomPos = Mathf.Clamp (curZoomPos, 5f, 35f);
 
         // // Stops "zoomTo" value at the nearest and farthest zoom value you desire
         // zoomTo = Mathf.Clamp (zoomTo, -15f, 30f);

         // Debug.Log(curZoomPos);
 
         // // Makes the actual change to Field Of View
         // Camera.main.fieldOfView = curZoomPos;
    }
}
// 