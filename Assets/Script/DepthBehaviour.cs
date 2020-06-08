using UnityEngine;
using System.Collections;

public class DepthBehaviour : MonoBehaviour {

    ColliderBehaviour colliderScript;



	// Use this for initialization
	void Start () {
        colliderScript = GameObject.Find("guiaCollider").GetComponent<ColliderBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hueso")
        {
            colliderScript.isDrillingBone = true;
           // Debug.Log("isdrillingBONE");
        }

        if (other.gameObject.name == "CylinderPunto1" || other.gameObject.name == "CylinderPunto2" || other.gameObject.name == "CylinderPunto3" || other.gameObject.name == "CylinderPunto4")
        {
            colliderScript.isDrilling = true;
            //Debug.Log("chock");
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CylinderPunto1" || other.gameObject.name == "CylinderPunto2" || other.gameObject.name == "CylinderPunto3" || other.gameObject.name == "CylinderPunto4")
        {
            colliderScript.isDrilling = false;
        }
        if (other.gameObject.name == "Hueso")
        {
            colliderScript.isDrillingBone = false;
        }
    }

}
