using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColliderBehaviour : MonoBehaviour {

    public bool isDrilling =false;
    public bool isDrillingBone = false;
    LineRenderer punto1Line;
    LineRenderer punto2Line;
    LineRenderer punto3Line;
    LineRenderer punto4Line;
    LineRenderer guiaLine;
    public Color verde;
    public Color azul;
    public Color blancoT;
    public Color rojo;
    public Color amarillo;
    public Color amarilloT;
    Renderer testigo1;
    Scrollbar testigoPor;
    Image testigoCir;
    Image testigoTrapecio;
    GameObject trapecioEmpty;
    GameObject puntaBrocaPegada;
    GameObject CylinderStop;
    //Text porcentaje;
    double distanciaHueso;
    double distanciaPunto1;
    double distanciaPunto2;
    double distanciaPunto3;
    double distanciaPunto4;
    double distanciaBroca;
    double distanciaBrocaEnt;
    double distanciabrocahueso;
    double distanciaBroca2Hueso;
    GameObject punto1A;
    GameObject punto1B;
    GameObject punto2A;
    GameObject punto2B;
    GameObject punto3A;
    GameObject punto3B;
    GameObject punto4A;
    GameObject punto4B;
    GameObject punto1AS;
    GameObject punto1BS;
    GameObject punto2AS;
    GameObject punto2BS;
    GameObject punto3AS;
    GameObject punto3BS;
    GameObject punto4AS;
    GameObject punto4BS;
    GameObject Hueso;


    GameObject Guia;
    GameObject Femur;
    GameObject Puntos1;
    GameObject Puntos2;
    GameObject Puntos3;
    GameObject Puntos4;
    GameObject targetPng;
    public int countR = 2;
    public int countA = 0;
    public int countV = 0;
    public Sprite trianRojo;
    public Sprite trianAmarillo;
    public Sprite trianVerde;
    GameObject perforando;
    GameObject puntaPunto1;
    GameObject puntaPunto2;
    GameObject puntaPunto3;
    GameObject puntaPunto4;
    GameObject targetCanvas;
    GameObject HuesoPunta;

    Text profundidad;
    Text HuesoCol;
    void Awake()
    {
        
        targetPng = GameObject.Find("targetPNG");
        HuesoPunta = GameObject.Find("HuesoPunta");
        puntaPunto1 = GameObject.Find("puntaBrocaPunto1");
        puntaPunto2 = GameObject.Find("puntaBrocaPunto2");
        puntaPunto3 = GameObject.Find("puntaBrocaPunto3");
        puntaPunto4 = GameObject.Find("puntaBrocaPunto4");
        puntaBrocaPegada = GameObject.Find("puntaBrocaPeg");
        trapecioEmpty = GameObject.Find("TrapecioEmpty");
        punto1Line = GameObject.Find("punto1Line").GetComponent<LineRenderer>();
        punto2Line = GameObject.Find("punto2Line").GetComponent<LineRenderer>();
        punto3Line = GameObject.Find("punto3Line").GetComponent<LineRenderer>();
        punto4Line = GameObject.Find("punto4Line").GetComponent<LineRenderer>();
        guiaLine = GameObject.Find("guiaLine").GetComponent<LineRenderer>();
        testigoCir = GameObject.Find("circleProgress").GetComponent<Image>();
        testigoTrapecio = GameObject.Find("TrapecioFull").GetComponent<Image>();
        perforando = GameObject.Find("perforando");
        CylinderStop = GameObject.Find("CylinderStop");
        
        testigoCir.fillAmount = 0;
        testigoTrapecio.fillAmount = 0;
        //porcentaje = GameObject.Find("porcentaje").GetComponent<Text>();
        Guia = GameObject.Find("guia_model");
        punto1A = GameObject.Find("punto1A");
        Hueso = GameObject.Find("Hueso");
        punto1B = GameObject.Find("punto1B");
        punto2A = GameObject.Find("punto2A");
        punto2B = GameObject.Find("punto2B");
        punto3A = GameObject.Find("punto3A");
        punto3B = GameObject.Find("punto3B");
        punto4A = GameObject.Find("punto4A");
        punto4B = GameObject.Find("punto4B");
        punto1AS = GameObject.Find("punto1AS");
        punto1BS = GameObject.Find("punto1BS");
        punto2AS = GameObject.Find("punto2AS");
        punto2BS = GameObject.Find("punto2BS");
        punto3AS = GameObject.Find("punto3AS");
        punto3BS = GameObject.Find("punto3BS");
        punto4AS = GameObject.Find("punto4AS");
        punto4BS = GameObject.Find("punto4BS");
        //targetCanvas = GameObject.Find("targetCanvas");
        //Femur = GameObject.Find("femurclean");
        Puntos1= GameObject.Find("puntos1");
        Puntos2 = GameObject.Find("puntos2");
        Puntos3 = GameObject.Find("puntos3");
        Puntos4 = GameObject.Find("puntos4");
        profundidad = GameObject.Find("profundidad").GetComponent<Text>();
        HuesoCol = GameObject.Find("HuesoCol").GetComponent<Text>();
        azul = new Color(0, 0, 255);
        verde = new Color(0, 255, 0);
        rojo = new Color(255, 0, 0);
        amarillo = new Color(255, 255, 0);
        amarillo = new Color(255, 255, 0,0.5f);
        blancoT = new Color(255, 255, 255,0.5f);


        countR = 2;
        countA = 0;
        countV = 0;
    }


    // Use this for initialization
    void Start () {



        HuesoCol.gameObject.SetActive(false);
        punto1Line.material.SetColor("_EmissionColor", rojo);
        punto2Line.material.SetColor("_EmissionColor", rojo);
        punto3Line.material.SetColor("_EmissionColor", rojo);
        punto4Line.material.SetColor("_EmissionColor", rojo);

        guiaLine.material.color = azul;
        punto1A.GetComponent<Renderer>().material.color = rojo;
        punto1B.GetComponent<Renderer>().material.color = rojo;
        punto2A.GetComponent<Renderer>().material.color = rojo;
        punto2B.GetComponent<Renderer>().material.color = rojo;
        punto3A.GetComponent<Renderer>().material.color = rojo;
        punto3B.GetComponent<Renderer>().material.color = rojo;
        punto4A.GetComponent<Renderer>().material.color = rojo;
        punto4B.GetComponent<Renderer>().material.color = rojo;

        punto1AS.GetComponent<Renderer>().material.color = blancoT;
        punto1BS.GetComponent<Renderer>().material.color = blancoT;
        punto2AS.GetComponent<Renderer>().material.color = blancoT;
        punto2BS.GetComponent<Renderer>().material.color = blancoT;
        punto3AS.GetComponent<Renderer>().material.color = blancoT;
        punto3BS.GetComponent<Renderer>().material.color = blancoT;
        punto4AS.GetComponent<Renderer>().material.color = blancoT;
        punto4BS.GetComponent<Renderer>().material.color = blancoT; 

        distanciaPunto1 = Vector3.Distance(punto1A.transform.position, punto1B.transform.position);
        distanciaPunto2 = Vector3.Distance(punto2A.transform.position, punto2B.transform.position);
        distanciaPunto3 = Vector3.Distance(punto3A.transform.position, punto3B.transform.position);
        distanciaPunto4 = Vector3.Distance(punto4A.transform.position, punto4B.transform.position);
        perforando.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        distanciaHueso = 2.5f;
        distanciaPunto1 = Vector3.Distance(punto1A.transform.position, punto1B.transform.position);
        
        distanciaPunto2 = Vector3.Distance(punto2A.transform.position, punto2B.transform.position);
        distanciaPunto3 = Vector3.Distance(punto3A.transform.position, punto3B.transform.position);
        distanciaPunto4 = Vector3.Distance(punto4A.transform.position, punto4B.transform.position);
      
        //targetCanvas.transform.position = puntaBrocaPegada.transform.position + new Vector3(0.09f, 0.05f, 0.02f);
        //Debug.Log(targetCanvas.transform.position+"position");

        // color testigos
        if (countV == 2)
        {
            punto1Line.material.SetColor("_EmissionColor", verde);
            punto2Line.material.SetColor("_EmissionColor", verde);
            punto3Line.material.SetColor("_EmissionColor", verde);
            punto4Line.material.SetColor("_EmissionColor", verde);
            //targetPng.GetComponent<SpriteRenderer>().sprite = trianVerde;
        }
        else if (countA==2)
        {
            punto1Line.material.SetColor("_EmissionColor", amarillo);
            punto2Line.material.SetColor("_EmissionColor", amarillo);
            punto3Line.material.SetColor("_EmissionColor", amarillo);
            punto4Line.material.SetColor("_EmissionColor", amarillo);
            //targetPng.GetComponent<SpriteRenderer>().sprite = trianAmarillo;
        }
        else
        {
            punto1Line.material.SetColor("_EmissionColor", rojo);
            punto2Line.material.SetColor("_EmissionColor", rojo);
            punto3Line.material.SetColor("_EmissionColor", rojo);
            punto4Line.material.SetColor("_EmissionColor", rojo);
            //targetPng.GetComponent<SpriteRenderer>().sprite = trianRojo;
        }


        //taladrado
        distanciabrocahueso = (Vector3.Distance(puntaBrocaPegada.transform.position, Hueso.transform.position));
       // Debug.Log(distanciabrocahueso+"dis broca hueso");
        if (isDrillingBone == true)
        {
           
                //Debug.Log(isDrillingBone);
                //Debug.Log(distanciabrocahueso);
                HuesoPunta.transform.position = puntaBrocaPegada.transform.position;
                distanciaBroca2Hueso = (HuesoPunta.transform.localPosition.y +1);
              // Debug.Log(distanciaBroca2Hueso + "distancia broca de hueso");
                HuesoCol.gameObject.SetActive(true);

                HuesoCol.text = (((int)(distanciaBroca2Hueso*distanciabrocahueso*1000)).ToString() + "mm");
           
            //Debug.Log(HuesoCol.text);
        }
        else
        {
            HuesoCol.text = ("");
        }

        if (Puntos1.activeSelf == true)
        {
            //distanciaBroca = ((Vector3.Distance(Guia.transform.position, tibiaPuntoB.transform.position)) - 0.15);
            distanciaBrocaEnt = (Vector3.Distance(puntaBrocaPegada.transform.position, punto1A.transform.position));
            //Debug.Log(distanciaBrocaEnt);
            //if (distanciaBroca < distanciaTibia && countA == 2) //ya está perforando
            if (isDrilling) //ya está perforando
            {
                puntaPunto1.transform.position = puntaBrocaPegada.transform.position;
                distanciaBroca = puntaPunto1.transform.localPosition.z + 1;
              
                perforando.SetActive(true);
                trapecioEmpty.SetActive(false);
                testigoTrapecio.enabled = false;
                if (distanciaBroca < 0.0001)
                    {

                        //porcentaje.text = "0%";
                        testigoCir.fillAmount = 0;

                    }
                    else if (distanciaBroca >= 1)
                    {
                        //porcentaje.text = "100%";
                        testigoCir.fillAmount = 1;
                    }
                    else
                    {
                        //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                        //testigoCir.fillAmount = (float)(1 - (distanciaBroca) / distanciaFemur);
                        testigoCir.fillAmount = (float) distanciaBroca;
                        //
                    }
                profundidad.text = (((int)((distanciaPunto1*distanciaBroca) * 1000)).ToString()+"mm");

            }
            else //está buscando el punto de entrada
            {
                perforando.SetActive(false);
                trapecioEmpty.SetActive(true);
                testigoTrapecio.enabled = true;
                if (distanciaBrocaEnt < 0.0001)
                {

                    //porcentaje.text = "100%";
                    testigoTrapecio.fillAmount = 1;

                }
                else if (distanciaBrocaEnt >= 0.07)
                {
                    //porcentaje.text = "0%";
                    testigoTrapecio.fillAmount = 0;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaTibia) * 100)).ToString() + "%";
                    testigoTrapecio.fillAmount = (float)(1 - (distanciaBrocaEnt) / 0.07);
                }

                profundidad.text = (((int)(distanciaBrocaEnt * 1000)).ToString() + "mm");
            }
        }
        else if (Puntos2.activeSelf == true)
        {
            //distanciaBroca = ((Vector3.Distance(Guia.transform.position, femurPuntoB.transform.position)) - 0.15);
            
            distanciaBrocaEnt = (Vector3.Distance(puntaBrocaPegada.transform.position, punto2A.transform.position));

            //if (distanciaBroca<distanciaFemur && countA==2)*/ //ya está perforando
            if (isDrilling) //ya está perforando
            {
                puntaPunto2.transform.position = puntaBrocaPegada.transform.position;
                distanciaBroca = (puntaPunto2.transform.localPosition.z+1)/2;
                perforando.SetActive(true);
                trapecioEmpty.SetActive(false);
                testigoTrapecio.enabled = false;

                    if (distanciaBroca < 0.0001)
                    {

                        //porcentaje.text = "0%";
                        testigoCir.fillAmount = 0;

                    }
                    else if (distanciaBroca >= 1)
                    {
                        //porcentaje.text = "100%";
                        testigoCir.fillAmount = 1;
                    }
                    else
                    {
                        //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                        //testigoCir.fillAmount = (float)(1 - (distanciaBroca) / distanciaFemur);
                        testigoCir.fillAmount = (float) distanciaBroca;
                        //
                    }
                profundidad.text = (((int)((distanciaPunto2*distanciaBroca) * 1000)).ToString()+"mm");

            }
            else //está buscando el punto de entrada
            {
                perforando.SetActive(false);
                trapecioEmpty.SetActive(true);
                testigoTrapecio.enabled = true;
                if (distanciaBrocaEnt < 0.0001)
                {

                    //porcentaje.text = "100%";
                    testigoTrapecio.fillAmount = 1;

                }
                else if (distanciaBrocaEnt >= 0.07)
                {
                    //porcentaje.text = "0%";
                    testigoTrapecio.fillAmount = 0;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                    testigoTrapecio.fillAmount = (float)(1 - (distanciaBrocaEnt) / 0.07);
                }

                profundidad.text = (((int)(distanciaBrocaEnt*1000)).ToString()+"mm");
            }
            
            
        }

        else if (Puntos3.activeSelf == true)
        {
            //distanciaBroca = ((Vector3.Distance(Guia.transform.position, femurPuntoB.transform.position)) - 0.15);

            distanciaBrocaEnt = (Vector3.Distance(puntaBrocaPegada.transform.position, punto3A.transform.position));

            //if (distanciaBroca<distanciaFemur && countA==2)*/ //ya está perforando
            if (isDrilling) //ya está perforando
            {
                puntaPunto3.transform.position = puntaBrocaPegada.transform.position;
                distanciaBroca = (puntaPunto3.transform.localPosition.z + 1) / 2;
                perforando.SetActive(true);
                trapecioEmpty.SetActive(false);
                testigoTrapecio.enabled = false;

                if (distanciaBroca < 0.0001)
                {

                    //porcentaje.text = "0%";
                    testigoCir.fillAmount = 0;

                }
                else if (distanciaBroca >= 1)
                {
                    //porcentaje.text = "100%";
                    testigoCir.fillAmount = 1;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                    //testigoCir.fillAmount = (float)(1 - (distanciaBroca) / distanciaFemur);
                    testigoCir.fillAmount = (float)distanciaBroca;
                    //
                }
                profundidad.text = (((int)((distanciaPunto3 * distanciaBroca) * 1000)).ToString() + "mm");

            }
            else //está buscando el punto de entrada
            {
                perforando.SetActive(false);
                trapecioEmpty.SetActive(true);
                testigoTrapecio.enabled = true;
                if (distanciaBrocaEnt < 0.0001)
                {

                    //porcentaje.text = "100%";
                    testigoTrapecio.fillAmount = 1;

                }
                else if (distanciaBrocaEnt >= 0.07)
                {
                    //porcentaje.text = "0%";
                    testigoTrapecio.fillAmount = 0;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                    testigoTrapecio.fillAmount = (float)(1 - (distanciaBrocaEnt) / 0.07);
                }

                profundidad.text = (((int)(distanciaBrocaEnt * 1000)).ToString() + "mm");
            }


        }
        else if (Puntos4.activeSelf == true)
        {
            //distanciaBroca = ((Vector3.Distance(Guia.transform.position, femurPuntoB.transform.position)) - 0.15);

            distanciaBrocaEnt = (Vector3.Distance(puntaBrocaPegada.transform.position, punto4A.transform.position));

            //if (distanciaBroca<distanciaFemur && countA==2)*/ //ya está perforando
            if (isDrilling) //ya está perforando
            {
                puntaPunto4.transform.position = puntaBrocaPegada.transform.position;
                distanciaBroca = (puntaPunto4.transform.localPosition.z + 1) / 2;
                perforando.SetActive(true);
                trapecioEmpty.SetActive(false);
                testigoTrapecio.enabled = false;
                if (distanciaBroca < 0.0001)
                {

                    //porcentaje.text = "0%";
                    testigoCir.fillAmount = 0;

                }
                else if (distanciaBroca >= 1)
                {
                    //porcentaje.text = "100%";
                    testigoCir.fillAmount = 1;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                    //testigoCir.fillAmount = (float)(1 - (distanciaBroca) / distanciaFemur);
                    testigoCir.fillAmount = (float)distanciaBroca;
                    //
                }
                profundidad.text = (((int)((distanciaPunto4 * distanciaBroca) * 1000)).ToString() + "mm");

            }
            else //está buscando el punto de entrada
            {
                perforando.SetActive(false);
                trapecioEmpty.SetActive(true);
                testigoTrapecio.enabled = true;
                if (distanciaBrocaEnt < 0.0001)
                {

                    //porcentaje.text = "100%";
                    testigoTrapecio.fillAmount = 1;

                }
                else if (distanciaBrocaEnt >= 0.07)
                {
                    //porcentaje.text = "0%";
                    testigoTrapecio.fillAmount = 0;
                }
                else
                {
                    //porcentaje.text = ((int)((1 - (distanciaBroca) / distanciaFemur) * 100)).ToString() + "%";
                    testigoTrapecio.fillAmount = (float)(1 - (distanciaBrocaEnt) / 0.07);
                }

                profundidad.text = (((int)(distanciaBrocaEnt * 1000)).ToString() + "mm");
               
            }


        }
        


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Hueso")
        {
            // distanciabrocahueso = 0;
            //HuesoCol.text = distanciabrocahueso.ToString();
           
            
        }

        if (other.gameObject.name=="punto1AS" || other.gameObject.name == "punto2AS" || other.gameObject.name == "punto3AS" || other.gameObject.name == "punto4AS")
        {
            punto1AS.GetComponent<Renderer>().material.color = amarillo;
            punto2AS.GetComponent<Renderer>().material.color = amarillo;
            punto3AS.GetComponent<Renderer>().material.color = amarillo;
            punto4AS.GetComponent<Renderer>().material.color = amarillo;
            countA++;
            countR--;
        }
        else if (other.gameObject.name == "punto1A" || other.gameObject.name == "punto2A" || other.gameObject.name == "punto3A" || other.gameObject.name == "punto4A")
        {
            countV++;
            punto1A.GetComponent<Renderer>().material.color = verde;
            punto2A.GetComponent<Renderer>().material.color = verde;
            punto3A.GetComponent<Renderer>().material.color = verde;
            punto4A.GetComponent<Renderer>().material.color = verde;
        }

        if (other.gameObject.name == "punto1BS" || other.gameObject.name == "punto2BS" || other.gameObject.name == "punto3BS" || other.gameObject.name == "punto4BS")
        {
            punto1BS.GetComponent<Renderer>().material.color = amarillo;
            punto2BS.GetComponent<Renderer>().material.color = amarillo;
            punto3BS.GetComponent<Renderer>().material.color = amarillo;
            punto4BS.GetComponent<Renderer>().material.color = amarillo;
            countA++;
            countR--;
        }
        else if (other.gameObject.name == "punto1B" || other.gameObject.name == "punto2B" || other.gameObject.name == "punto3B" || other.gameObject.name == "punto4B")
        {
            countV++;
            punto1B.GetComponent<Renderer>().material.color = verde;
            punto2B.GetComponent<Renderer>().material.color = verde;
            punto3B.GetComponent<Renderer>().material.color = verde;
            punto4B.GetComponent<Renderer>().material.color = verde;
        }

    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Hueso")
        {

            //HuesoCol.gameObject.SetActive(false);

        }
        if (other.gameObject.name == "punto1AS" || other.gameObject.name == "punto2AS" || other.gameObject.name == "punto3AS" || other.gameObject.name == "punto4AS")
        {
            punto1AS.GetComponent<Renderer>().material.color = blancoT;
            punto2AS.GetComponent<Renderer>().material.color = blancoT;
            punto3AS.GetComponent<Renderer>().material.color = blancoT;
            punto4AS.GetComponent<Renderer>().material.color = blancoT;
            countA--;
            countR++;
        }
        else if (other.gameObject.name == "punto1A" || other.gameObject.name == "punto2A" || other.gameObject.name == "punto3A" || other.gameObject.name == "punto4A")
        {
            countV--;
            punto1A.GetComponent<Renderer>().material.color = rojo;
            punto2A.GetComponent<Renderer>().material.color = rojo;
            punto3A.GetComponent<Renderer>().material.color = rojo;
            punto4A.GetComponent<Renderer>().material.color = rojo;
        }
        

        if (other.gameObject.name == "punto1BS" || other.gameObject.name == "punto2BS" || other.gameObject.name == "punto3BS" || other.gameObject.name == "punto4BS")
        {
            punto1BS.GetComponent<Renderer>().material.color = blancoT;
            punto2BS.GetComponent<Renderer>().material.color = blancoT;
            punto3BS.GetComponent<Renderer>().material.color = blancoT;
            punto4BS.GetComponent<Renderer>().material.color = blancoT;
            countA--;
            countR++;
        }
        else if (other.gameObject.name == "punto1B" || other.gameObject.name == "punto2B" || other.gameObject.name == "punto3B" || other.gameObject.name == "punto4B")
        {
            countV--;
            punto1B.GetComponent<Renderer>().material.color = rojo;
            punto2B.GetComponent<Renderer>().material.color = rojo;
            punto3B.GetComponent<Renderer>().material.color = rojo;
            punto4B.GetComponent<Renderer>().material.color = rojo;
        }

   }
}
