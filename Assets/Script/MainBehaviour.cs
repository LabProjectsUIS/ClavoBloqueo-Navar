using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class MainBehaviour : MonoBehaviour {


    GameObject Frame;
    GameObject GafasRigid;
    GameObject GafasFrame;
    GameObject Femur;
    GameObject FemurRigid;
    GameObject Guia;
    GameObject GuiaRigid;
    GameObject Punto1A;
    GameObject Punto1B;
    GameObject Punto2A;
    GameObject Punto2B;
    GameObject Punto3A;
    GameObject Punto3B;
    GameObject Punto4A;
    GameObject Punto4B;
    GameObject Punto1AS;
    GameObject Punto1BS;
    GameObject Punto2AS;
    GameObject Punto2BS;
    GameObject Punto3AS;
    GameObject Punto3BS;
    GameObject Punto4AS;
    GameObject Punto4BS;
    GameObject punto1AMirror;
    GameObject punto1BMirror;
    GameObject punto2AMirror;
    GameObject punto2BMirror;
    GameObject punto3AMirror;
    GameObject punto3BMirror;
    GameObject punto4AMirror;
    GameObject punto4BMirror;
    GameObject puntos1;
    GameObject puntos2;
    GameObject puntos3;
    GameObject puntos4;
    GameObject puntos1Mirror;
    GameObject puntos2Mirror;
    GameObject puntos3Mirror;
    GameObject puntos4Mirror;
    GameObject punto1Target;
    GameObject punto2Target;
    GameObject punto3Target;
    GameObject punto4Target;
    float distanciaPunto1;
    float distanciaPunto2;
    float distanciaPunto3;
    float distanciaPunto4;

    //GameObject menu;

    Vector3 rotador;
    Vector3 traslador;
    Vector3 posicionPunto1A;
    Vector3 posicionPunto1B;
    Vector3 posicionPunto2A;
    Vector3 posicionPunto2B;
    Vector3 posicionPunto3A;
    Vector3 posicionPunto3B;
    Vector3 posicionPunto4A;
    Vector3 posicionPunto4B;
    float orix, oriy, oriz;
    float posx, posy, posz;
    LineRenderer punto1Line;
    LineRenderer punto2Line;
    LineRenderer punto3Line;
    LineRenderer punto4Line;

    LineRenderer punto1LineMirror;
    LineRenderer punto2LineMirror;
    LineRenderer punto3LineMirror;
    LineRenderer punto4LineMirror;
    int pantalla=0;
    public Color rojo;
    Renderer testigo1;
    ColliderBehaviour collidScript;
    GameObject target;
    int modelo;
    GameObject tunelPunto1;
    GameObject tunelPunto2;
    GameObject tunelPunto3;
    GameObject tunelPunto4;

    FileLoader loaderScript;
    string[][] rigids = new string[4][];
    string[][] matriz = new string[4][];
    GameObject puntaPointer;
    RaycastHit hit;
    GameObject laserSphere;
    GameObject CameraGuia;

    GameObject proyector1;
    GameObject proyector2;
    GameObject proyector3;
    GameObject proyector4;

    GameObject Indicador1;
    GameObject Indicador2;
    GameObject Indicador3;
    GameObject Indicador4;

	GameObject O1L1;
	GameObject O1L2;
	GameObject O2L1;
	GameObject O2L2;
	GameObject O3L1;
	GameObject O3L2;
	GameObject O4L1;
	GameObject O4L2;
	public GameObject spriteAP;

    Camera CameraPiel22;
    Camera CameraPiel2;
    Camera CameraHueso22;
    Camera CamC;
    Camera camH;
    Camera camH2;
    Camera camP1;
    GameObject flag;
    bool m;

    //Ray ray1A;
    //Ray ray1B;
    //Ray ray2A;
    //Ray ray2B;
    //Ray ray3A;
    //Ray ray3B;
    //Ray ray4A;
    //Ray ray4B;




    
    

    void Awake()
    {
        camH = GameObject.Find("CameraHueso").GetComponent<Camera>();
        camH2 = GameObject.Find("CameraHueso2").GetComponent<Camera>();
        camP1 = GameObject.Find("CameraPiel1").GetComponent<Camera>();
        CameraPiel2 = GameObject.Find("CameraPiel2").GetComponent<Camera>();
        CameraPiel22 = GameObject.Find("CameraPiel22").GetComponent<Camera>();
        CameraHueso22 = GameObject.Find("CameraHueso22").GetComponent<Camera>();
        CamC = GameObject.Find("CameraCorona").GetComponent<Camera>();
        flag = GameObject.Find("Flag");
        

        Indicador1 = GameObject.Find("Indicador1");
        Indicador2 = GameObject.Find("Indicador2");
        Indicador3 = GameObject.Find("Indicador3");
        Indicador4 = GameObject.Find("Indicador4");


        loaderScript = GameObject.Find("loader").GetComponent<FileLoader>();
        collidScript = GameObject.Find("guiaCollider").GetComponent<ColliderBehaviour>();
        //Frame = GameObject.Find("MetaFrame");
        GafasRigid = GameObject.Find("Gafas");
        //GafasFrame = GameObject.Find("GafasFrame");
        //Femur = GameObject.Find("femurclean");
        //FemurRigid = GameObject.Find("Femur");
        //Guia = GameObject.Find("guia_model");
        GuiaRigid = GameObject.Find("Guia");

		O1L1 = GameObject.Find("O1L1");
		O1L2 = GameObject.Find("O1L2");
		O2L1 = GameObject.Find("O2L1");
		O2L2 = GameObject.Find("O2L2");
		O3L1 = GameObject.Find("O3L1");
		O3L2 = GameObject.Find("O3L2");
		O4L1 = GameObject.Find("O4L1");
		O4L2 = GameObject.Find("O4L2");
		Punto1A = GameObject.Find("punto1A");
        Punto1B = GameObject.Find("punto1B");
        Punto1AS = GameObject.Find("punto1AS");
        Punto1BS = GameObject.Find("punto1BS");
        Punto2A = GameObject.Find("punto2A");
        Punto2B = GameObject.Find("punto2B");
        Punto2AS = GameObject.Find("punto2AS");
        Punto2BS = GameObject.Find("punto2BS");
        Punto3A = GameObject.Find("punto3A");
        Punto3B = GameObject.Find("punto3B");
        Punto3AS = GameObject.Find("punto3AS");
        Punto3BS = GameObject.Find("punto3BS");
        Punto4A = GameObject.Find("punto4A");
        Punto4B = GameObject.Find("punto4B");
        Punto4AS = GameObject.Find("punto4AS");
        Punto4BS = GameObject.Find("punto4BS");

        punto1AMirror = GameObject.Find("punto1AMirror");
        punto1BMirror = GameObject.Find("punto1BMirror");
        punto2AMirror = GameObject.Find("punto2AMirror");
        punto2BMirror = GameObject.Find("punto2BMirror");
        punto3AMirror = GameObject.Find("punto3AMirror");
        punto3BMirror = GameObject.Find("punto3BMirror");
        punto4AMirror = GameObject.Find("punto4AMirror");
        punto4BMirror = GameObject.Find("punto4BMirror");

        punto1LineMirror = GameObject.Find("punto1LineMirror").GetComponent<LineRenderer>();
        punto2LineMirror = GameObject.Find("punto2LineMirror").GetComponent<LineRenderer>();
        punto3LineMirror = GameObject.Find("punto3LineMirror").GetComponent<LineRenderer>();
        punto4LineMirror = GameObject.Find("punto4LineMirror").GetComponent<LineRenderer>();

        puntos1 = GameObject.Find("puntos1");
        puntos2 = GameObject.Find("puntos2");
        puntos3 = GameObject.Find("puntos3");
        puntos4 = GameObject.Find("puntos4");
        puntos1Mirror = GameObject.Find("puntos1Mirror");
        puntos2Mirror = GameObject.Find("puntos2Mirror");
        puntos3Mirror = GameObject.Find("puntos3Mirror");
        puntos4Mirror = GameObject.Find("puntos4Mirror");
        punto1Target = GameObject.Find("punto1Target");
        punto2Target = GameObject.Find("punto2Target");
        punto3Target = GameObject.Find("punto3Target");
        punto4Target = GameObject.Find("punto4Target");
        punto1Line = GameObject.Find("punto1Line").GetComponent<LineRenderer>();
        punto2Line = GameObject.Find("punto2Line").GetComponent<LineRenderer>();
        punto3Line = GameObject.Find("punto3Line").GetComponent<LineRenderer>();
        punto4Line = GameObject.Find("punto4Line").GetComponent<LineRenderer>();

        tunelPunto1 = GameObject.Find("TunelPunto1");
        tunelPunto2 = GameObject.Find("TunelPunto2");
        tunelPunto3 = GameObject.Find("TunelPunto3");
        tunelPunto4 = GameObject.Find("TunelPunto4");
        rojo = new Color(255, 0, 0);
        target = GameObject.Find("targetCamera");
        modelo = 1;
        
        puntaPointer = GameObject.Find("puntaPointer");
        laserSphere = GameObject.Find("laserSphere");
        CameraGuia = GameObject.Find("target");

        proyector1 = GameObject.Find("proyector1");
        proyector2 = GameObject.Find("proyector2");
        proyector3 = GameObject.Find("proyector3");
        proyector4 = GameObject.Find("proyector4");

        
    

    }
    void Start()
    {
        punto1Select();
		//4 points coordinates: tibiaA, tibiaB, femurA, femurB
		posicionPunto1A = loaderScript.punto1A;
		posicionPunto1B = loaderScript.punto1B;
		posicionPunto2A = loaderScript.punto2A;
		posicionPunto2B = loaderScript.punto2B;
		posicionPunto3A = loaderScript.punto3A;
		posicionPunto3B = loaderScript.punto3B;
		posicionPunto4A = loaderScript.punto4A;
		posicionPunto4B = loaderScript.punto4B;

		//Punto1A.transform. = O1L1.transform;
		Debug.Log(Punto1A.transform.position);

        //setting coordinates to spheres mm to m

        Punto1A.transform.localPosition = posicionPunto1A / 1000;
		Punto1B.transform.localPosition = posicionPunto1B / 1000;
		Punto1AS.transform.localPosition = posicionPunto1A / 1000;
        Punto1BS.transform.localPosition = posicionPunto1B / 1000;
        Punto2A.transform.localPosition = posicionPunto2A / 1000;
        Punto2B.transform.localPosition = posicionPunto2B / 1000;
        Punto2AS.transform.localPosition = posicionPunto2A / 1000;
        Punto2BS.transform.localPosition = posicionPunto2B / 1000;
        Punto3A.transform.localPosition = posicionPunto3A / 1000;
        Punto3B.transform.localPosition = posicionPunto3B / 1000;
        Punto3AS.transform.localPosition = posicionPunto3A / 1000;
        Punto3BS.transform.localPosition = posicionPunto3B / 1000;
        Punto4A.transform.localPosition = posicionPunto4A / 1000;
        Punto4B.transform.localPosition = posicionPunto4B / 1000;
        Punto4AS.transform.localPosition = posicionPunto4A / 1000;
        Punto4BS.transform.localPosition = posicionPunto4B / 1000;
        punto1AMirror.transform.position = Punto1A.transform.position;
        punto1BMirror.transform.position = Punto1B.transform.position;
        punto2AMirror.transform.position = Punto2A.transform.position;
        punto2BMirror.transform.position = Punto2B.transform.position;
        punto3AMirror.transform.position = Punto3A.transform.position;
        punto3BMirror.transform.position = Punto3B.transform.position;
        punto4AMirror.transform.position = Punto4A.transform.position;
        punto4BMirror.transform.position = Punto4B.transform.position;
		



		punto1Line.SetPosition(0, Punto1A.transform.localPosition);
        punto1Line.SetPosition(1, Punto1B.transform.localPosition);
        punto1Line.SetWidth(0.0035f, 0.0035f);
        punto2Line.SetPosition(0, Punto2A.transform.localPosition);
        punto2Line.SetPosition(1, Punto2B.transform.localPosition);
        punto2Line.SetWidth(0.0035f, 0.0035f);
        punto3Line.SetPosition(0, Punto3A.transform.localPosition);
        punto3Line.SetPosition(1, Punto3B.transform.localPosition);
        punto3Line.SetWidth(0.0035f, 0.0035f);
        punto4Line.SetPosition(0, Punto4A.transform.localPosition);
        punto4Line.SetPosition(1, Punto4B.transform.localPosition);
        punto4Line.SetWidth(0.0035f, 0.0035f);

        punto1LineMirror.SetPosition(0, punto1AMirror.transform.position);
        punto1LineMirror.SetPosition(1, punto1BMirror.transform.position);
        punto1LineMirror.SetWidth(0.0035f, 0.0035f);
        punto2LineMirror.SetPosition(0, punto2AMirror.transform.position);
        punto2LineMirror.SetPosition(1, punto2BMirror.transform.position);
        punto2LineMirror.SetWidth(0.0035f, 0.0035f);
        punto3LineMirror.SetPosition(0, punto3AMirror.transform.position);
        punto3LineMirror.SetPosition(1, punto3BMirror.transform.position);
        punto3LineMirror.SetWidth(0.0035f, 0.0035f);
        punto4LineMirror.SetPosition(0, punto4AMirror.transform.position);
        punto4LineMirror.SetPosition(1, punto4BMirror.transform.position);
        punto4LineMirror.SetWidth(0.0035f, 0.0035f);

        distanciaPunto1 = Vector3.Distance(Punto1A.transform.position, Punto1B.transform.position);
        distanciaPunto2 = Vector3.Distance(Punto2A.transform.position, Punto2B.transform.position);
        distanciaPunto3 = Vector3.Distance(Punto3A.transform.position, Punto3B.transform.position);
        distanciaPunto4 = Vector3.Distance(Punto4A.transform.position, Punto4B.transform.position);


        //setting depth cylinder
        tunelPunto1.transform.localPosition = (posicionPunto1A + posicionPunto1B) / 2000;
        tunelPunto2.transform.localPosition = (posicionPunto2A + posicionPunto2B) / 2000;
        tunelPunto3.transform.localPosition = (posicionPunto3A + posicionPunto3B) / 2000;
        tunelPunto4.transform.localPosition = (posicionPunto4A + posicionPunto4B) / 2000;
        tunelPunto1.transform.localScale = new Vector3(0.01f, 0.01f, ((float) distanciaPunto1 / 2f));
        tunelPunto2.transform.localScale = new Vector3(0.01f, 0.01f, ((float)distanciaPunto2 / 2f));
        tunelPunto3.transform.localScale = new Vector3(0.01f, 0.01f, ((float)distanciaPunto3 / 2f));
        tunelPunto4.transform.localScale = new Vector3(0.01f, 0.01f, ((float)distanciaPunto4 / 2f));
        tunelPunto1.transform.LookAt(Punto1B.transform.position);
        tunelPunto2.transform.LookAt(Punto2B.transform.position);
        tunelPunto3.transform.LookAt(Punto3B.transform.position);
        tunelPunto4.transform.LookAt(Punto4B.transform.position);






    }
    void LateUpdate() {
        //GuiaRigid.transform.eulerAngles = new Vector3(GuiaRigid.transform.eulerAngles.x, GuiaRigid.transform.eulerAngles.y, 0);
        //femurTarget.transform.eulerAngles = new Vector3(femurTarget.transform.eulerAngles.x, femurTarget.transform.eulerAngles.y, 0);
        //tibiaTarget.transform.eulerAngles = new Vector3(tibiaTarget.transform.eulerAngles.x, tibiaTarget.transform.eulerAngles.y, 0);
       
    }

    

    // Update is called once per frame
    void Update () {
        CamC.gameObject.SetActive(false);
        CamC.gameObject.SetActive(true);
       
        Ray ray = new Ray(proyector1.transform.position, proyector1.transform.up * -1);
        RaycastHit hit;
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto1A.transform.position = hit.point;
            punto1AMirror.transform.position = hit.point;
            Punto1AS.transform.position = hit.point;
        }
        ray = new Ray(proyector1.transform.position, proyector1.transform.up);
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto1B.transform.position = hit.point;
            punto1BMirror.transform.position = hit.point;
            Punto1BS.transform.position = hit.point;
        }

        ray = new Ray(proyector2.transform.position, proyector2.transform.up * -1);
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto2A.transform.position = hit.point;
            punto2AMirror.transform.position = hit.point;
            Punto2AS.transform.position = hit.point;
        }
        ray = new Ray(proyector2.transform.position, proyector2.transform.up);
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto2B.transform.position = hit.point;
            punto2BMirror.transform.position = hit.point;
            Punto2BS.transform.position = hit.point;
        }

        ray = new Ray(proyector3.transform.position, proyector3.transform.up * -1);
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto3A.transform.position = hit.point;
            punto3AMirror.transform.position = hit.point;
            Punto3AS.transform.position = hit.point;
        }
        ray = new Ray(proyector3.transform.position, proyector3.transform.up );
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto3B.transform.position = hit.point;
            punto3BMirror.transform.position = hit.point;
            Punto3BS.transform.position = hit.point;
        }

        ray = new Ray(proyector4.transform.position, proyector4.transform.up * -1);
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto4A.transform.position = hit.point;
            punto4AMirror.transform.position = hit.point;
            Punto4AS.transform.position = hit.point;
        }
        ray = new Ray(proyector4.transform.position, proyector4.transform.up );
        ray.origin = ray.GetPoint(0.1f);
        ray.direction = -ray.direction;
        if (Physics.Raycast(ray, out hit))
        {
            Punto4B.transform.position = hit.point;
            punto4BMirror.transform.position = hit.point;
            Punto4BS.transform.position = hit.point;
        }

        punto1Line.SetPosition(0, Punto1A.transform.localPosition);
        punto1Line.SetPosition(1, Punto1B.transform.localPosition);
        punto1Line.SetWidth(0.0035f, 0.0035f);
        punto2Line.SetPosition(0, Punto2A.transform.localPosition);
        punto2Line.SetPosition(1, Punto2B.transform.localPosition);
        punto2Line.SetWidth(0.0035f, 0.0035f);
        punto3Line.SetPosition(0, Punto3A.transform.localPosition);
        punto3Line.SetPosition(1, Punto3B.transform.localPosition);
        punto3Line.SetWidth(0.0035f, 0.0035f);
        punto4Line.SetPosition(0, Punto4A.transform.localPosition);
        punto4Line.SetPosition(1, Punto4B.transform.localPosition);
        punto4Line.SetWidth(0.0035f, 0.0035f);

        punto1LineMirror.SetPosition(0, punto1AMirror.transform.position);
        punto1LineMirror.SetPosition(1, punto1BMirror.transform.position);
        punto1LineMirror.SetWidth(0.0035f, 0.0035f);
        punto2LineMirror.SetPosition(0, punto2AMirror.transform.position);
        punto2LineMirror.SetPosition(1, punto2BMirror.transform.position);
        punto2LineMirror.SetWidth(0.0035f, 0.0035f);
        punto3LineMirror.SetPosition(0, punto3AMirror.transform.position);
        punto3LineMirror.SetPosition(1, punto3BMirror.transform.position);
        punto3LineMirror.SetWidth(0.0035f, 0.0035f);
        punto4LineMirror.SetPosition(0, punto4AMirror.transform.position);
        punto4LineMirror.SetPosition(1, punto4BMirror.transform.position);
        punto4LineMirror.SetWidth(0.0035f, 0.0035f);

        distanciaPunto1 = Vector3.Distance(Punto1A.transform.position, Punto1B.transform.position);
        distanciaPunto2 = Vector3.Distance(Punto2A.transform.position, Punto2B.transform.position);
        distanciaPunto3 = Vector3.Distance(Punto3A.transform.position, Punto3B.transform.position);
        distanciaPunto4 = Vector3.Distance(Punto4A.transform.position, Punto4B.transform.position);

        tunelPunto1.transform.localPosition = (Punto1A.transform.localPosition + Punto1B.transform.localPosition) / 2;
        tunelPunto2.transform.localPosition = (Punto2A.transform.localPosition + Punto2B.transform.localPosition) / 2;
        tunelPunto3.transform.localPosition = (Punto3A.transform.localPosition + Punto3B.transform.localPosition) / 2;
        tunelPunto4.transform.localPosition = (Punto4A.transform.localPosition + Punto4B.transform.localPosition) / 2;
        tunelPunto1.transform.localScale = new Vector3(0.008f, 0.008f, ((float)distanciaPunto1 / 2f));
        tunelPunto2.transform.localScale = new Vector3(0.008f, 0.008f, ((float)distanciaPunto2 / 2f));
        tunelPunto3.transform.localScale = new Vector3(0.008f, 0.008f, ((float)distanciaPunto3 / 2f));
        tunelPunto4.transform.localScale = new Vector3(0.008f, 0.008f, ((float)distanciaPunto4 / 2f));
        tunelPunto1.transform.LookAt(Punto1B.transform.position);
        tunelPunto2.transform.LookAt(Punto2B.transform.position);
        tunelPunto3.transform.LookAt(Punto3B.transform.position);
        tunelPunto4.transform.LookAt(Punto4B.transform.position);

        atras();







        if (Physics.Raycast(puntaPointer.transform.position, GuiaRigid.transform.forward, out hit))
        {
            laserSphere.SetActive(true);
            laserSphere.transform.position = hit.point;

        }
        else
        {

            laserSphere.SetActive(false);
        }


        punto1Target.transform.LookAt(CameraGuia.transform.position, CameraGuia.transform.up);
        punto2Target.transform.LookAt(CameraGuia.transform.position, CameraGuia.transform.up);
        punto3Target.transform.LookAt(CameraGuia.transform.position, CameraGuia.transform.up);
        punto4Target.transform.LookAt(CameraGuia.transform.position, CameraGuia.transform.up);

        //menu.transform.position = Frame.transform.position + new Vector3(0, 0.2f, 0.3f);

    }

    /* public void adjustCamera()
     {
         Vector3 tibiaVector = tibiaPuntoB.transform.position-tibiaPuntoA.transform.position;
         target.transform.position = tibiaVector*;
     }*/
    

    public void Rotater() {
        
        GafasRigid.transform.Rotate(rotador);

    }

    public void Translater()
    {

        GafasRigid.transform.Translate(Vector3.forward * 0.05f);
               

    }

    public void punto1Select()
    {
        puntos1.SetActive(true);
        puntos2.SetActive(false);
        puntos3.SetActive(false);
        puntos4.SetActive(false);
        puntos1Mirror.SetActive(false);
        puntos2Mirror.SetActive(true);
        puntos3Mirror.SetActive(true);
        puntos4Mirror.SetActive(true);
        Indicador1.SetActive(true);
        Indicador2.SetActive(false);
        Indicador3.SetActive(false);
        Indicador4.SetActive(false);
        camP1.nearClipPlane = 0.7f;
        camH.nearClipPlane = 0.53f;

      
        m = true;

    }
    public void punto2Select()
    {
        puntos1.SetActive(false);
        puntos2.SetActive(true);
        puntos3.SetActive(false);
        puntos4.SetActive(false);
        puntos1Mirror.SetActive(true);
        puntos2Mirror.SetActive(false);
        puntos3Mirror.SetActive(true);
        puntos4Mirror.SetActive(true);
        Indicador1.SetActive(false);
        Indicador2.SetActive(true);
        Indicador3.SetActive(false);
        Indicador4.SetActive(false);
        camP1.nearClipPlane = 0.58f;
        camH.nearClipPlane = 0.41f;
        //TransformExtensions.SetYPos(spriteAP.transform, -0.000000000000001f);
        m = true;
    }
    public void punto3Select()
    {
        puntos1.SetActive(false);
        puntos2.SetActive(false);
        puntos3.SetActive(true);
        puntos4.SetActive(false);
        puntos1Mirror.SetActive(true);
        puntos2Mirror.SetActive(true);
        puntos3Mirror.SetActive(false);
        puntos4Mirror.SetActive(true);
        Indicador1.SetActive(false);
        Indicador2.SetActive(false);
        Indicador3.SetActive(true);
        Indicador4.SetActive(false);
        camP1.nearClipPlane = 0.45f;
        camH.nearClipPlane = 0.393f;
        m = false;
    }
    public void punto4Select()
    {
        puntos1.SetActive(false);
        puntos2.SetActive(false);
        puntos3.SetActive(false);
        puntos4.SetActive(true);
        puntos1Mirror.SetActive(true);
        puntos2Mirror.SetActive(true);
        puntos3Mirror.SetActive(true);
        puntos4Mirror.SetActive(false);
        Indicador1.SetActive(false);
        Indicador2.SetActive(false);
        Indicador3.SetActive(false);
        Indicador4.SetActive(true);
        camP1.nearClipPlane = 0.4599999999f;
        camH.nearClipPlane = 0.29f;
        m = false;
    }

    public void femurSelect()
    {
        //imageTibia.GetComponent<Image>().sprite = tibiaUnselected;
        //imageFemur.GetComponent<Image>().sprite = femurSelected;
        //Femur.SetActive(true);
        //Tibia.SetActive(false);
        //femurDescripcion.SetActive(true);
        //tibiaDescripcion.SetActive(false);
        //puntosTibia.SetActive(false);
        //puntosFemur.SetActive(true);
        


    }

    public void tibiaSelect()
    {
        //imageTibia.GetComponent<Image>().sprite = tibiaSelected;
        //imageFemur.GetComponent<Image>().sprite = femurUnselected;
        //Femur.SetActive(false);
        //Tibia.SetActive(true);
        //femurDescripcion.SetActive(false);
        //tibiaDescripcion.SetActive(true);
        //puntosTibia.SetActive(true);
        //puntosFemur.SetActive(false);
        //menu.transform.position = TibiaRigid.transform.position + new Vector3(0, 0.5f, 0);
    }

    public void loadInitial(int modelo)
    {
        if (modelo == 0)
        {

        }
    }

    public void atras()
    {
        pantalla--;
        collidScript.countV = 0;
        collidScript.countR = 2;
        collidScript.countA = 0;
        if (flag.activeInHierarchy)
        {
            punto1Target.gameObject.SetActive(false);
            punto2Target.gameObject.SetActive(false);
            punto3Target.gameObject.SetActive(false);
            punto4Target.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                punto1Select();
                CameraPiel22.gameObject.SetActive(false);
                CameraPiel2.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                punto2Select();
                CameraPiel22.gameObject.SetActive(true);
                CameraPiel2.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                punto3Select();

                CameraPiel2.gameObject.SetActive(false);
                CameraPiel22.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                punto4Select();

                CameraPiel2.gameObject.SetActive(false);
                CameraPiel22.gameObject.SetActive(true);
            }

        }
        else
        {
           punto1Target.gameObject.SetActive(true);
            punto2Target.gameObject.SetActive(true);
            punto3Target.gameObject.SetActive(true);
            punto4Target.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                punto1Select();
                CameraHueso22.gameObject.SetActive(false);
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                punto2Select();
                CameraHueso22.gameObject.SetActive(true);
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                punto3Select();
                
                CameraHueso22.gameObject.SetActive(true);
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                punto4Select(); 
                CameraHueso22.gameObject.SetActive(true);
            }
        }



        /*switch (pantalla)
        {
            case -1:
                pantalla++;
                break;
            case 0:
                punto1Select();
                break;
            case 1:
                punto2Select();
                break;
            case 2:
                punto3Select();
                break;
        }*/
    }
    public void adelante()
    {
        pantalla++;
        testigo1.material.color = rojo;
        collidScript.countV = 0;
        collidScript.countR = 2;
        collidScript.countA = 0;

        switch (pantalla)
        {
            
            case 1:
                punto2Select();
                break;
            case 2:
                punto3Select();
                break;
            case 3:
                punto4Select();
                break;
            case 4:
                pantalla--;
                break;


        }
    }
}
public static class TransformExtensions
{
    public static void SetYPos(this Transform t,float newZPos)
    {
        var posZ = t.position;
        posZ.z = newZPos;
        t.position = posZ;
/*
        var posY = t.position;
        posY.y= newYPos;
        t.position = posY;

        var posZ = t.position;
        posZ.z = newZPos;
        t.position = posZ;*/

    }
}
