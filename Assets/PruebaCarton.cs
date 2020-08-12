using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PruebaCarton : MonoBehaviour {

	GameObject Carton;
	GameObject Guia;
	GameObject Centro;
	GameObject Lateral1;
	GameObject Lateral2;
	GameObject LateralCentro;
	GameObject PuntaPointer;
	GameObject CartonModel;
	GameObject u1, u2, u3, fl1;
	GameObject guiaModel;
	GameObject sphereLarga;
	GameObject CameraA;
	Vector3 niceRot;
	float i = 0;
	float tempDis;

	private void Awake()
	{
		CameraA = GameObject.Find("Main Camera");
		Carton = GameObject.Find("Carton");
		Guia = GameObject.Find("Guia");
		Centro = GameObject.Find("Centro");
		Lateral1 = GameObject.Find("Lateral1");
		Lateral2 = GameObject.Find("Lateral2");
		LateralCentro = GameObject.Find("LateralCentro");
		PuntaPointer = GameObject.Find("puntaPointer");
		CartonModel = GameObject.Find("CartonModel");
		u1 = GameObject.Find("u1");
		u2 = GameObject.Find("u2");
		u3 = GameObject.Find("u3");
		fl1 = GameObject.Find("fl1");
		guiaModel = GameObject.Find("guia_model");
		sphereLarga = GameObject.Find("s1");
		Lateral1.GetComponent<MeshRenderer>().enabled = true;
	}
	// Use this for initialization
	void Start () {

		//Lateral1.transform.parent = null;
		tempDis = Vector3.Distance(Lateral1.transform.position,Lateral2.transform.position);
		Debug.Log("La distancia inicial laterales es: "+tempDis);
	}
	
	// Update is called once per frame
	void Update () {
		CameraA.transform.LookAt(Carton.transform);
		if (Input.GetKeyDown(KeyCode.Keypad7)) { RegistrarCarton1(); }
		if (Input.GetKeyDown(KeyCode.Keypad8)) { RegistrarCarton2(); }
		if (Input.GetKeyDown(KeyCode.Keypad9)) { RegistrarCarton3(); }
		if (Input.GetKeyDown(KeyCode.B)) { calibrarBroca(); }
	}

	void RegistrarCarton1() {
		Debug.Log("Presionó KeyPad7 - Registra primer punto del Cartón");
		u1.transform.position = PuntaPointer.transform.position;
		Lateral1.transform.parent = null;
		Lateral1.transform.parent = Carton.transform;
		CartonModel.transform.parent = Lateral1.transform;
		Lateral1.transform.position = u1.transform.position;
		//CartonModel.transform.localPosition = new Vector3(0,0,0);

		Lateral2.GetComponent<MeshRenderer>().enabled = false;
		LateralCentro.GetComponent<MeshRenderer>().enabled = false;
		
	}
	void RegistrarCarton2() {

		u2.transform.position = PuntaPointer.transform.position;
		tempDis = Vector3.Distance(u1.transform.position, Lateral2.transform.position);


		Lateral2.transform.parent = null;
		Lateral2.transform.parent = Carton.transform;
		Lateral1.transform.parent = Lateral2.transform;
		//Lateral1.transform.RotateAround(Lateral1.transform.rotation,20*Time.deltaTime);
		//Lateral1.transform.LookAt(u2.transform);
		
		/*while (i<450) {
			Debug.Log(i);
			if (Mathf.Abs(Vector3.Distance(u2.transform.position, Lateral2.transform.position) - tempDis) > 0.001)
			{
				Debug.Log("Dist diff"+Mathf.Abs(Vector3.Distance(u2.transform.position, Lateral2.transform.position) - tempDis));
				//Lateral1.transform.Rotate(Vector3.up, i);
				Lateral1.transform.RotateAround(Lateral1.transform.position, Vector3.forward, i);
				//tempDis = Vector3.Distance(u2.transform.position, Lateral2.transform.position);
			}
			i = i + 90;
		}*/
		Lateral2.GetComponent<MeshRenderer>().enabled = true;
		Lateral1.GetComponent<MeshRenderer>().enabled = false;
		LateralCentro.GetComponent<MeshRenderer>().enabled = false;

	}
	void RegistrarCarton3() {

		u3.transform.position = PuntaPointer.transform.position;
		LateralCentro.transform.parent = null;
		LateralCentro.transform.parent = Carton.transform;
		Lateral2.transform.parent = LateralCentro.transform;
		LateralCentro.transform.position = u3.transform.position;

		LateralCentro.GetComponent<MeshRenderer>().enabled = true;
		Lateral2.GetComponent<MeshRenderer>().enabled = false;
		Lateral1.GetComponent<MeshRenderer>().enabled = false;
	}

	public void calibrarBroca() //Método de registro
	{
		Debug.Log("Broca en el punto");
		guiaModel.transform.LookAt(sphereLarga.transform);
		guiaModel.transform.Rotate(+90, 0, 0);
	}
}
