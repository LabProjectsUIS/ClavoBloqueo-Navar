using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estirarCam : MonoBehaviour {
    Camera cam;
   
    public float height = 1f;
    public float width = 1f;
    Matrix4x4 m;

    // Use this for initialization
    void Start () {
       
        //cam = gameObject.GetComponent<Camera>();
        //cam.transform.LookAt(GameObject.Find("Guia").GetComponent<Transform>().position);
    }
   

    // Update is called once per frame
    void Update () {

        // stretch view
        //cam.transform.LookAt(GameObject.Find("Guia").GetComponent<Transform>().position);
        cam.ResetProjectionMatrix();
        m = cam.projectionMatrix;

        m.m11 *= height;
        m.m00 *= width;
        cam.projectionMatrix = m;
    }
}
