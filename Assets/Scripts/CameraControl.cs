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
     
    private Vector2 ZoomRange = new Vector2(-5,5);
    private float CurrentZoom = 0;
    public float ZoomZpeed = 1;
    public float ZoomRotation = 1;
     
    private Vector3 InitPos;
    private Vector3 InitRotation;
     
     
     
    void Start()
    {
        //Instantiate(Arrow, Vector3.zero, Quaternion.identity);
       
        InitPos = transform.position;
        InitRotation = transform.eulerAngles;
       
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
       
    //ZOOM IN/OUT
       
        // CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;
       
        // CurrentZoom = Mathf.Clamp(CurrentZoom,ZoomRange.x,ZoomRange.y);
       
        // transform.position.y -= (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1;
        // transform.eulerAngles.x -= (transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1;
       
    }
}
