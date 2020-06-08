using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class FileLoader : MonoBehaviour
{

    //string rutaExe = Application.dataPath + "../casos/1/";
    public string rutaExe = "";
    string[] rutasSplit;

    public string[][] rigids = new string[7][];
    public string[][] matriz = new string[6][];
    public string[][] puntos = new string[8][];
    public string[] diaDis = new string[3];
    public Vector3 posTibia;
    public Quaternion rotRigidTibia;
    public Quaternion rotModelTibia;
    public Vector3 posFemur;
    public Quaternion rotRigidFemur;
    public Quaternion rotModelFemur;
    public Vector3 punto1A;
    public Vector3 punto1B;
    public Vector3 punto2A;
    public Vector3 punto2B;
    public Vector3 punto3A;
    public Vector3 punto3B;
    public Vector3 punto4A;
    public Vector3 punto4B;
    int contador;
    OBJ ObjScript1;
    OBJ ObjScript2;
    GameObject tibiaModel;
    GameObject femurModel;
    //bool tibiaColliderAdded = false;
    bool femurColliderAdded = false;




    // Use this for initialization
    void Awake()
    {
        tibiaModel = GameObject.Find("tibiamodel");
        femurModel = GameObject.Find("femurmodel");
        //ObjScript1 = GameObject.Find("tibiamodel").GetComponent<OBJ>();
        ObjScript2 = GameObject.Find("femurmodel").GetComponent<OBJ>();
        rutaExe = Application.persistentDataPath + "/Casos/1/";
        Debug.Log(rutaExe);
        //Debug.Log("file:///" + rutaExe + "tibiaClean.obj");

        //StartCoroutine(ObjScript1.Load("file:///" + rutaExe + "tibiaFinal.obj"));
        StartCoroutine(ObjScript2.Load("file:///" + rutaExe + "tubo2.obj"));
        rigids = readRigids(rutaExe + "rigids.txt");
        matriz = readMatriz(rutaExe + "matriz.csv"); // femur pos, femur rigid rot,femur model rot,  tibia pos, tibia rigid rot, tibia model rot 
        posFemur = new Vector3((float)Convert.ToDouble(matriz[0][0]), (float)Convert.ToDouble(matriz[0][1]), (float)Convert.ToDouble(matriz[0][2]));
        rotRigidFemur = new Quaternion((float)Convert.ToDouble(matriz[1][0]), (float)Convert.ToDouble(matriz[1][1]), (float)Convert.ToDouble(matriz[1][2]), (float)Convert.ToDouble(matriz[1][3]));
        rotModelFemur = new Quaternion((float)Convert.ToDouble(matriz[2][0]), (float)Convert.ToDouble(matriz[2][1]), (float)Convert.ToDouble(matriz[2][2]), (float)Convert.ToDouble(matriz[2][3]));
        posTibia = new Vector3((float)Convert.ToDouble(matriz[3][0]), (float)Convert.ToDouble(matriz[3][1]), (float)Convert.ToDouble(matriz[3][2]));
        rotRigidTibia = new Quaternion((float)Convert.ToDouble(matriz[4][0]), (float)Convert.ToDouble(matriz[4][1]), (float)Convert.ToDouble(matriz[4][2]), (float)Convert.ToDouble(matriz[4][3]));
        rotModelTibia = new Quaternion((float)Convert.ToDouble(matriz[5][0]), (float)Convert.ToDouble(matriz[5][1]), (float)Convert.ToDouble(matriz[5][2]), (float)Convert.ToDouble(matriz[5][3]));
        puntos = readPuntos(rutaExe + "puntos.csv"); //punto1a, punto1b, punto2a, punto2b ,punto3a, punto3b,punto4a, punto4b
        punto1A = new Vector3((float)Convert.ToDouble(puntos[0][0]), (float)Convert.ToDouble(puntos[0][1]), (float)Convert.ToDouble(puntos[0][2]));
        punto1B = new Vector3((float)Convert.ToDouble(puntos[1][0]), (float)Convert.ToDouble(puntos[1][1]), (float)Convert.ToDouble(puntos[1][2]));
        punto2A = new Vector3((float)Convert.ToDouble(puntos[2][0]), (float)Convert.ToDouble(puntos[2][1]), (float)Convert.ToDouble(puntos[2][2]));
        punto2B = new Vector3((float)Convert.ToDouble(puntos[3][0]), (float)Convert.ToDouble(puntos[3][1]), (float)Convert.ToDouble(puntos[3][2]));
        punto3A = new Vector3((float)Convert.ToDouble(puntos[4][0]), (float)Convert.ToDouble(puntos[4][1]), (float)Convert.ToDouble(puntos[4][2]));
        punto3B = new Vector3((float)Convert.ToDouble(puntos[5][0]), (float)Convert.ToDouble(puntos[5][1]), (float)Convert.ToDouble(puntos[5][2]));
        punto4A = new Vector3((float)Convert.ToDouble(puntos[6][0]), (float)Convert.ToDouble(puntos[6][1]), (float)Convert.ToDouble(puntos[6][2]));
        punto4B = new Vector3((float)Convert.ToDouble(puntos[7][0]), (float)Convert.ToDouble(puntos[7][1]), (float)Convert.ToDouble(puntos[7][2]));
        diaDis = readDiaDis(rutaExe + "diadis.txt");
        //StartCoroutine("loadBundle");


    }

    // Update is called once per frame
    void Update()
    {
        if (femurModel.GetComponent<MeshFilter>() && femurColliderAdded == false)
        {
            Mesh femurMesh = femurModel.GetComponent<MeshFilter>().mesh;
            femurModel.AddComponent<MeshCollider>().sharedMesh = femurMesh;
            femurColliderAdded = true;
        }
    }



    public string[][] readRigids(string ruta)
    {
        contador = 0;
        StreamReader stm = new StreamReader(ruta);
        while (!stm.EndOfStream)
        {

            rigids[contador] = stm.ReadLine().Split(',');
            contador++;
        }

        stm.Close();
        return rigids;
    }

    public string[][] readMatriz(string ruta)
    {
        contador = 0;
        StreamReader stm = new StreamReader(ruta);
        while (!stm.EndOfStream)
        {

            matriz[contador] = stm.ReadLine().Split(',');
            contador++;
        }

        stm.Close();
        return matriz;

    }

    public string[][] readPuntos(string ruta)
    {
        contador = 0;
        StreamReader stm = new StreamReader(ruta);
        while (!stm.EndOfStream)
        {

            puntos[contador] = stm.ReadLine().Split(',');
            contador++;
        }

        stm.Close();
        return puntos;

    }
    public string[] readDiaDis(string ruta)
    {
        StreamReader stm = new StreamReader(ruta);
        while (!stm.EndOfStream)
        {

            diaDis = stm.ReadLine().Split(',');
            contador++;
        }

        stm.Close();
        return diaDis;

    }

    string obtenerRuta()
    {
        rutaExe = Application.persistentDataPath;
        rutasSplit = rutaExe.Split('/');
        rutaExe = "";
        for (int i = 0; i + 3 <= rutasSplit.Length; i++)
        {
            rutaExe = rutaExe + rutasSplit[i] + "/";
        }
        return rutaExe;


    }




}

