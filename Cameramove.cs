using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public GameObject Camera;
    public Rigidbody rd;
    public float Sportspeed2 = 5;
    public float Rotatespeed=2;
    
    Camera camera=new Camera();
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float X = Input.GetAxis("Mouse X") * Rotatespeed;
        float Y = Input.GetAxis("Mouse Y") * Rotatespeed;
        Vector3 speed = new Vector3(h,0,v);
        rd.velocity = speed * Sportspeed2;
        //camera.transform.localRotation=camera.transform.localRotation*Quaternion.Euler(-Y,0,0);
        //transform.localRotation = transform.localRotation * Quaternion.Euler(0,X,0);
        if(Input.GetKey(KeyCode.P))
        {
            camera.transform.position = camera.transform.position - 
                camera.transform.right * Input.GetAxisRaw("Mouse X") * Rotatespeed * Time.timeScale;
        }
    }
}
