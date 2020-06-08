using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
    GameObject frame;
    Vector3 offset;
    // Use this for initialization
    void Start () {
        
        //frame = GameObject.Find("GafasFrame");
    } 
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back,
        //                  Camera.main.transform.rotation * Vector3.back);

        //offset= transform.position - frame.transform.position;
        /*transform.LookAt(frame.transform.position, Vector3.up);
        transform.Rotate(0, 180, 0);*/

    }
}
