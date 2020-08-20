using UnityEngine;
using System.Collections;

/*Este script realiza el registro de los objetos en escena para establecer una posicion dentro
 del espacio mediante la selección de puntos establecidos en el objeto fisico y virtual.
 
  Cualquier método/función que inicie como "registrar" da acción al registro al objeto nombrado
  dentro de dicho método/función.

   Tambien se establecen los metodos de cambio de Fase.

 */
public class register : MonoBehaviour {

    Camera camH;
    Camera camH2;
    Camera camC;
    Camera camP1;
    Camera camP2;
    Camera CameraPiel22;
    Camera CameraHueso22;
    Camera targetCamera;
    Camera CameraContador2;

	GameObject Punto1C;
	GameObject Punto2C;
	GameObject Punto3C;
	GameObject Clavo2;
	GameObject flag;
    public bool man;
    GameObject Piel;
	GameObject Fase1, Fase2;
    GameObject e1;
    GameObject e2;
    GameObject e3;
    GameObject t1;
    GameObject t2;
    GameObject t3;
    GameObject el1;
    GameObject tl1;
    GameObject f1;
    GameObject f2;
    GameObject f3;
    GameObject fl1;
    GameObject puntaPointer;
    GameObject femur;
    GameObject femurM;
    GameObject femurR;
    GameObject tibia;
    GameObject tibiaM;
    GameObject tibiaR;
    GameObject guiaModel;
    GameObject sphereLarga;
    GameObject Hueso;
	GameObject SphereCanula;
	GameObject Cilindro;
	GameObject clavoCurvo;
	GameObject punto1;
	GameObject punto2;
	GameObject O1;
	GameObject O2;
	GameObject Punto1Centro, Punto2Centro;
	GameObject Ind, Can, Canula, CanModel, Indicador2, Indicador1;
	MeshRenderer RenderPierna;
	private Vector3 offset;
    bool m;
    float tempDis;
    Vector3 niceRot;
    float i = 0;
	// Use this for initialization
	void Awake()
	{
		Indicador2 = GameObject.Find("Indicador2");
		Indicador1 = GameObject.Find("Indicador1");
		Punto1Centro = GameObject.Find("Punto1Centro");
		Punto2Centro = GameObject.Find("Punto2Centro");
		Fase1 = GameObject.Find("Fase1");
		Fase2 = GameObject.Find("Fase2");
		O1 = GameObject.Find("O1");
		O2 = GameObject.Find("O2");
		Clavo2 = GameObject.Find("Clavo2");
		Punto1C = GameObject.Find("Punto1C");
		Punto2C = GameObject.Find("Punto2C");
		Punto3C = GameObject.Find("Punto3C");
		SphereCanula = GameObject.Find("SphereCanula");
		Canula = GameObject.Find("Canula");
		Hueso = GameObject.Find("Hueso");
        Piel = GameObject.Find("CONOHueco");
        flag = GameObject.Find("Flag");
        camH = GameObject.Find("CameraHueso").GetComponent<Camera>();
        camH2 = GameObject.Find("CameraHueso2").GetComponent<Camera>();
        camC = GameObject.Find("CameraCorona").GetComponent<Camera>();
        camP1 = GameObject.Find("CameraPiel1").GetComponent<Camera>();
        camP2 = GameObject.Find("CameraPiel2").GetComponent<Camera>();
        CameraPiel22 = GameObject.Find("CameraPiel22").GetComponent<Camera>();
        CameraHueso22 = GameObject.Find("CameraHueso22").GetComponent<Camera>();
        targetCamera = GameObject.Find("CameraTarget").GetComponent<Camera>();
        //CameraContador2 = GameObject.Find("CameraContador2").GetComponent<Camera>();

        e1 = GameObject.Find("e1");
        e2 = GameObject.Find("e2");
        e3 = GameObject.Find("e3");
        el1 = GameObject.Find("el1");
        tl1 = GameObject.Find("tl1");
        t1 = GameObject.Find("t1");
        t2 = GameObject.Find("t2");
        t3 = GameObject.Find("t3");
        fl1 = GameObject.Find("fl1");
        f1 = GameObject.Find("f1");
        f2 = GameObject.Find("f2");
        f3 = GameObject.Find("f3");
        puntaPointer = GameObject.Find("puntaPointer");
        guiaModel = GameObject.Find("guia_model");
        sphereLarga = GameObject.Find("s1");
        femur = GameObject.Find("femurclean");
        femurM = GameObject.Find("femurmodel");
        femurR = GameObject.Find("Femur");
        tibia = GameObject.Find("clavoclean");
        tibiaM = GameObject.Find("clavomodel");
        tibiaR = GameObject.Find("Tibia");

		clavoCurvo = GameObject.Find("ClavoCurvo");
		punto1 = GameObject.Find("Punto1");
		punto2 = GameObject.Find("Punto2");

		Ind = GameObject.Find("Ind");
		Can = GameObject.Find("Can");
		CanModel = GameObject.Find("CanModel");
		RenderPierna = GameObject.Find("object_1").GetComponent<MeshRenderer>();

	}
    private void Start()
    {
       // offset = camP1.transform.position - GameObject.Find("proyector1").GetComponent<Transform>().position;
        camH.gameObject.SetActive(false);
        camH2.gameObject.SetActive(false);
        camP1.gameObject.SetActive(true);
        camP2.gameObject.SetActive(true);
        CameraPiel22.gameObject.SetActive(false);
        targetCamera.gameObject.SetActive(false);
        camC.gameObject.SetActive(true);
        CameraHueso22.gameObject.SetActive(false);
		
        //CameraContador2.gameObject.SetActive(false);
        // camP2.gameObject.SetActive(true);
        //camD.transform.position = new Vector3(0.033f, 0.1861f, 0.98542f);
        /* camP1.gameObject.SetActive(true);
         camP2.gameObject.SetActive(true);
         camP3.gameObject.SetActive(true);
         camD1.gameObject.SetActive(false);
         camD2.gameObject.SetActive(false);
         camD3.gameObject.SetActive(false);*/
        //camP1.transform.LookAt(GameObject.Find("proyector1").GetComponent<Transform>().position);

    }
    private void LateUpdate()
    {
        //camP1.transform.position = GameObject.Find("proyector1").GetComponent<Transform>().position + offset;
    }

    // Update is called once per frame
    void Update () {
        
        registrar();
        Render();
        Cameras();
		camC.gameObject.SetActive(true);
	
		float dist = Vector3.Distance(Punto1Centro.transform.position, Punto2Centro.transform.position);
		//Debug.Log("Verificacion distancia de puntos: " + dist);
		int nnn = 0;
        //camP1.transform.position = GameObject.Find("proyector1").GetComponent<Transform>().position;
        //camD.transform.LookAt(GameObject.Find("proyector1").GetComponent<Transform>().position);

        // camD.transform.position = GameObject.Find("proyector1").GetComponent<Transform>().position;
    }

    //Método de interacción y cambio entre fases.
    void Cameras()
    {
        
        //phase 1
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Hueso.gameObject.SetActive(false);
			//Piel.SetActive(true);
			Fase1.SetActive(true);
			Fase2.SetActive(false);
          flag.SetActive(true);
			//Proximales on
			RenderPierna.enabled = true;
			camH.gameObject.SetActive(false);
            camH2.gameObject.SetActive(false);
           
            camP1.gameObject.SetActive(true);
            camP2.gameObject.SetActive(true);
            targetCamera.gameObject.SetActive(false);
            camC.gameObject.SetActive(false);
            //CameraContador2.gameObject.SetActive(false);
        }
        //phase 2
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Distales on
            Hueso.gameObject.SetActive(true);
			
			//Piel.SetActive(false);
			Fase1.SetActive(false);
			Fase2.SetActive(true);
            flag.SetActive(false);
            m = false;
            camH.gameObject.SetActive(true);
            camH2.gameObject.SetActive(true);
			RenderPierna.enabled=false;
            //camP1.gameObject.SetActive(false);
            //camP2.gameObject.SetActive(false);
            targetCamera.gameObject.SetActive(false);
            //camC.gameObject.SetActive(false);
            //CameraContador2.gameObject.SetActive(true);

        }
        if (!flag.gameObject.activeInHierarchy)
        { targetCamera.gameObject.SetActive(false);
            targetCamera.gameObject.SetActive(true);
            targetCamera.nearClipPlane = 0.06f;
            //CameraContador2.gameObject.SetActive(false);
            //CameraContador2.gameObject.SetActive(true);

        }
    }
    void regresarFemur()
    {
        femurM.transform.parent = femur.transform;
        f1.transform.parent = femurM.transform;
        fl1.transform.parent = femurM.transform;
        e1.transform.parent = null;

    }
    void regresarTibia()
    {
        tibiaM.transform.parent = tibia.transform;
        t1.transform.parent = tibiaM.transform;
        tl1.transform.parent = tibiaM.transform;
        e1.transform.parent = null;

    }
    void registrar()//Método de registro
    {
            if (Input.GetKeyDown(KeyCode.A))
            {
            Debug.Log("oprime A");
                if (femur.activeSelf)
                {
                Debug.Log("FEMUR ACTIVO");
                    e1.transform.position = puntaPointer.transform.position;
                    f1.transform.LookAt(f2.transform);
                    fl1.transform.position = (f1.transform.position + f2.transform.position) / 2;
                    fl1.transform.LookAt(f2.transform);
                    f1.transform.parent = femur.transform;
                    femurM.transform.parent = f1.transform;
                    e1.transform.parent = femur.transform;
                    f1.transform.parent = e1.transform;
                    f1.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (tibia.activeSelf)
                {
                Debug.Log("TIBIA ACTIVO");
                    e1.transform.position = puntaPointer.transform.position;
                    t1.transform.LookAt(t2.transform);
                    tl1.transform.position = (t1.transform.position + t2.transform.position) / 2;
                    tl1.transform.LookAt(t2.transform);
                    t1.transform.parent = tibia.transform;
                    tibiaM.transform.parent = t1.transform;
                    e1.transform.parent = tibia.transform;
                    t1.transform.parent = e1.transform;
                    t1.transform.localPosition = new Vector3(0, 0, 0);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
           
            if (femur.activeSelf)
            {
                Debug.Log("oprime S,femur");
                e2.transform.position = puntaPointer.transform.position;
                    el1.transform.position = (e1.transform.position + e2.transform.position) / 2;
                    f1.transform.LookAt(e2.transform);
                    fl1.transform.parent = femur.transform;
                    f1.transform.parent = fl1.transform;
                }
                else if (tibia.activeSelf)
                {
                Debug.Log("oprime S,tibia");
                e2.transform.position = puntaPointer.transform.position;
                    el1.transform.position = (e1.transform.position + e2.transform.position) / 2;
                    t1.transform.LookAt(e2.transform);
                    tl1.transform.parent = tibia.transform;
                    t1.transform.parent = tl1.transform;
                }
            
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
            if (femur.activeSelf)
                {
                Debug.Log("oprime d,femur");
                e3.transform.position = puntaPointer.transform.position;
                    tempDis = Vector3.Distance(e3.transform.position, f3.transform.position);
                    i = 0;
                    while (i < 360)
                    {
                        fl1.transform.localEulerAngles = new Vector3(fl1.transform.localEulerAngles.x, fl1.transform.localEulerAngles.y, i);
                        if (Vector3.Distance(e3.transform.position, f3.transform.position) < tempDis)
                        {
                            niceRot = fl1.transform.localEulerAngles;
                            tempDis = Vector3.Distance(e3.transform.position, f3.transform.position);
                        }
                        i = i + 0.1f;

                    }
                    fl1.transform.localEulerAngles = niceRot;
                    femur.transform.parent = femurR.transform;
                regresarFemur(); 
                }
                else if (tibia.activeSelf)
                {
                Debug.Log("oprime d,tibia");
                e3.transform.position = puntaPointer.transform.position;
                    tempDis = Vector3.Distance(e3.transform.position, t3.transform.position);
                    i = 0;
                    while (i < 360)
                    {
                        tl1.transform.localEulerAngles = new Vector3(tl1.transform.localEulerAngles.x, tl1.transform.localEulerAngles.y, i);
                        if (Vector3.Distance(e3.transform.position, t3.transform.position) < tempDis)
                        {
                            niceRot = tl1.transform.localEulerAngles;
                            tempDis = Vector3.Distance(e3.transform.position, t3.transform.position);
                        }
                        i = i + 0.1f;

                    }
                    tl1.transform.localEulerAngles = niceRot;
                    tibia.transform.parent = tibiaR.transform;
                }  
            }
    }
	
	public void Render()
    {
		if (Input.GetKeyDown(KeyCode.Keypad0)) //Registrar Canula con mango de madera
		{
			Ind.transform.position = puntaPointer.transform.position;
			Ind.transform.rotation = guiaModel.transform.rotation;
			Can.transform.parent = Canula.transform;
			CanModel.transform.parent = Can.transform;
			Ind.transform.parent = Canula.transform;
			Can.transform.parent = Ind.transform;
			CanModel.transform.position = Ind.transform.position;
			CanModel.transform.rotation = guiaModel.transform.rotation;
		}
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			Ind.transform.position = Punto1Centro.transform.Find("Punto1L1").gameObject.transform.position;
			Ind.transform.rotation = Punto1Centro.transform.Find("Punto1L1").gameObject.transform.rotation;
			Can.transform.parent = Canula.transform;
			CanModel.transform.parent = Can.transform;
			Ind.transform.parent = Canula.transform;
			Can.transform.parent = Ind.transform;
			CanModel.transform.position = Ind.transform.position;
			CanModel.transform.rotation = Indicador1.transform.rotation;
			//CanModel.transform.rotation = Punto2Centro.transform.Find("Punto2L1").gameObject.transform.rotation;
		}
		if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("calibra broca");
            calibrarBroca();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            registrarClavo0();
            Debug.Log("registra 1");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            registrarClavo1();
            Debug.Log("registra2");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            registrarClavo2();
            Debug.Log("registra3");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            registrarClavo3();
            Debug.Log("registra4");
        }
        //REGISTRAR TUBO
        if (Input.GetKeyDown(KeyCode.H))
        {
            registrarFemur0();
            Debug.Log("REGISTRA FEMUR0");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            registrarFemur1();
            Debug.Log("REGISTRA FEMUR1");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            registrarFemur2();
            Debug.Log("REGISTRA FEMUR2");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            registrarFemur3();
            Debug.Log("REGISTRA FEMUR3");
        }
    }
    public void calibrarBroca() //Método de registro
    {
        guiaModel.transform.LookAt(sphereLarga.transform);
        guiaModel.transform.Rotate(+90, 0, 0);
    }
    public void registrarFemur0() {

        femur.transform.parent = null;
        f1.GetComponent<MeshRenderer>().enabled = true;
        f2.GetComponent<MeshRenderer>().enabled = false;
        f3.GetComponent<MeshRenderer>().enabled = false;
    }

    public void registrarClavo0() //Método de registro
    {
        tibia.transform.parent = null;
        t1.GetComponent<MeshRenderer>().enabled = true;
        t2.GetComponent<MeshRenderer>().enabled = false;
        t3.GetComponent<MeshRenderer>().enabled = false;



    }
    public void registrarFemur1() //Método de registro
    {
        e1.transform.position = puntaPointer.transform.position;
        f1.transform.LookAt(f2.transform);
        fl1.transform.position = (f1.transform.position + f2.transform.position) / 2;
        fl1.transform.LookAt(f2.transform);
        f1.transform.parent = femur.transform;
        femurM.transform.parent = f1.transform;
        e1.transform.parent = femur.transform;
        f1.transform.parent = e1.transform;
        f1.transform.localPosition = new Vector3(0, 0, 0);

        f1.GetComponent<MeshRenderer>().enabled = false;
        f2.GetComponent<MeshRenderer>().enabled = true;
        f3.GetComponent<MeshRenderer>().enabled = false;
    }
	public void registrarClavo1() //Método de registro punto t1
    {

        e1.transform.position = puntaPointer.transform.position;
        t1.transform.LookAt(t2.transform);
        tl1.transform.position = (t1.transform.position + t2.transform.position) / 2;
        tl1.transform.LookAt(t2.transform);
        t1.transform.parent = tibia.transform;
        tibiaM.transform.parent = t1.transform;
        e1.transform.parent = tibia.transform;
        t1.transform.parent = e1.transform;
        t1.transform.localPosition = new Vector3(0, 0, 0);

        t1.GetComponent<MeshRenderer>().enabled = false;
        t2.GetComponent<MeshRenderer>().enabled = true;
        t3.GetComponent<MeshRenderer>().enabled = false;
    
    }
    public void registrarFemur2() //Método de registro
    {
        e2.transform.position = puntaPointer.transform.position;
        el1.transform.position = (e1.transform.position + e2.transform.position) / 2;
        f1.transform.LookAt(e2.transform);
        fl1.transform.parent = femur.transform;
        f1.transform.parent = fl1.transform;

        f1.GetComponent<MeshRenderer>().enabled = false;
        f2.GetComponent<MeshRenderer>().enabled = false;
        f3.GetComponent<MeshRenderer>().enabled = true;

    }
    public void registrarClavo2() //Método de registro punto t2
    {
        e2.transform.position = puntaPointer.transform.position;
        el1.transform.position = (e1.transform.position + e2.transform.position) / 2;
        t1.transform.LookAt(e2.transform);
        tl1.transform.parent = tibia.transform;
        t1.transform.parent = tl1.transform;

        t1.GetComponent<MeshRenderer>().enabled = false;
        t2.GetComponent<MeshRenderer>().enabled = false;
        t3.GetComponent<MeshRenderer>().enabled = true;
    }
    public void registrarFemur3() //Método de registro
    {
        e3.transform.position = puntaPointer.transform.position;
        tempDis = Vector3.Distance(e3.transform.position, f3.transform.position);
        i = 0;
        while (i < 360)
        {
            fl1.transform.localEulerAngles = new Vector3(fl1.transform.localEulerAngles.x, fl1.transform.localEulerAngles.y, i);
            if (Vector3.Distance(e3.transform.position, f3.transform.position) < tempDis)
            {
                niceRot = fl1.transform.localEulerAngles;
                tempDis = Vector3.Distance(e3.transform.position, f3.transform.position);
            }
            i = i + 0.1f;

        }
        fl1.transform.localEulerAngles = niceRot;
        femur.transform.parent = femurR.transform;


        regresarFemur();
        f1.GetComponent<MeshRenderer>().enabled = true;
        f2.GetComponent<MeshRenderer>().enabled = true;
        f3.GetComponent<MeshRenderer>().enabled = true;


    }

    public void registrarClavo3() //Método de registro punto t3
    {
        e3.transform.position = puntaPointer.transform.position;
        tempDis = Vector3.Distance(e3.transform.position, t3.transform.position);
        i = 0;
        while (i < 360)
        {
            tl1.transform.localEulerAngles = new Vector3(tl1.transform.localEulerAngles.x, tl1.transform.localEulerAngles.y, i);
            if (Vector3.Distance(e3.transform.position, t3.transform.position) < tempDis)
            {
                niceRot = tl1.transform.localEulerAngles;
                tempDis = Vector3.Distance(e3.transform.position, t3.transform.position);
            }
            i = i + 0.1f;

        }
        tl1.transform.localEulerAngles = niceRot;
        tibia.transform.parent = tibiaR.transform;


        regresarTibia();
        t1.GetComponent<MeshRenderer>().enabled = true;
        t2.GetComponent<MeshRenderer>().enabled = true;
        t3.GetComponent<MeshRenderer>().enabled = true;

    }
    
}
