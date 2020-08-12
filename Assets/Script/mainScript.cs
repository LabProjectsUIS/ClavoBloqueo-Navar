using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{

    private GameObject /*obj1,*/ obj2, obj3,obj4, obj5, obj6, obj7, obj8, obj9, obj10;
    //private bool rotatingObj1 = false;
    private Vector3 rotationAxis1;
    //private System.Random rnd = new System.Random();

    [Range(0.0f, 2.0f)]
    public float weightGuia = 0.5f;

	Vector3 old_forward3, old_right3; //Guia
	Vector3 old_forward4, old_right4; //Clavo
	bool firstFrame = true;

    void Start()
    {
        /*obj1 = GameObject.Find("original");*/
        obj2 = GameObject.Find("Guia"); obj3 = GameObject.Find("Guia");
	}

    void Update()
    {
        float currentTime = Time.deltaTime;
        if (firstFrame)
        {
            // initialization
            old_forward3 = obj2.transform.forward;
            old_right3 = obj2.transform.right;
			firstFrame = false;
            
        }
        else
        {
            // obj3's orientation is a weighted average of obj2's current orientation and obj3's old orientation
            Vector3 new_forward3 = ((weightGuia) * obj2.transform.forward + (1 - weightGuia) * old_forward3).normalized;
            Vector3 new_right3 = ((weightGuia) * obj2.transform.right + (1 - weightGuia) * old_right3).normalized;
            // Use a cross-product to makes sure new_up3 is perpendicular to new_forward3.
            Vector3 new_up3 = Vector3.Cross(new_forward3, new_right3).normalized;
            obj3.transform.rotation = Quaternion.LookRotation(new_forward3, new_up3);
            old_forward3 = obj3.transform.forward;
            old_right3 = obj3.transform.right;

		}
		float count=0.05f;


		if (Input.GetKeyDown(KeyCode.Keypad5)) //eje y
		{
			Vector3 positiony = obj4.transform.position;
			positiony.y+=count;
			obj4.transform.position = positiony;
		}
		if (Input.GetKeyDown(KeyCode.Keypad2)) //eje -y
		{
			Vector3 positiony = obj4.transform.position;
			positiony.y -= count;
			obj4.transform.position = positiony;
		}
		if (Input.GetKeyDown(KeyCode.Keypad1)) //eje x
		{
			Vector3 positiony = obj4.transform.position;
			positiony.x += count;
			obj4.transform.position = positiony;
		}
		if (Input.GetKeyDown(KeyCode.Keypad3)) //eje -x
		{
			Vector3 positiony = obj4.transform.position;
			positiony.x -= count;
			obj4.transform.position = positiony;
		}

	}
}
