using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClavo2 : MonoBehaviour {

	GameObject Guia;
	GameObject guiaModel;
	GameObject PuntaPointer;
	GameObject Punto1C;
	GameObject GuiaPivot;
	// Use this for initialization
	private void Awake()
	{
		Guia = GameObject.Find("Guia2");
		guiaModel = GameObject.Find("guia_model2");
		PuntaPointer = GameObject.Find("puntaPointer2");
		Punto1C = GameObject.Find("Punto1C");
		GuiaPivot = GameObject.Find("GuiaPivot");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Keypad4)) { calibrarBroca(); }
	}

	void calibrarBroca()
	{
		Debug.Log("Posicionando broca");
		GuiaPivot.transform.position = Punto1C.transform.position;
		//GuiaPivot.transform.rotation = Punto1C.transform.rotation;
		//guiaModel.transform.rotation = Punto1C.transform.rotation;
	}
}
