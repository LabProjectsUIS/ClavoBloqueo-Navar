using UnityEngine;
using System.Collections;
using System.Xml;
using System;
//=============================================================================----
// Copyright © NaturalPoint, Inc. All Rights Reserved.
// 
// This software is provided by the copyright holders and contributors "as is" and
// any express or implied warranties, including, but not limited to, the implied
// warranties of merchantability and fitness for a particular purpose are disclaimed.
// In no event shall NaturalPoint, Inc. or contributors be liable for any direct,
// indirect, incidental, special, exemplary, or consequential damages
// (including, but not limited to, procurement of substitute goods or services;
// loss of use, data, or profits; or business interruption) however caused
// and on any theory of liability, whether in contract, strict liability,
// or tort (including negligence or otherwise) arising in any way out of
// the use of this software, even if advised of the possibility of such damage.
//=============================================================================----

// Attach Body.cs to an empty Game Object and it will parse and create visual
// game objects based on bone data.  Body.cs is meant to be a simple example 
// of how to parse and display skeletal data in Unity.

// In order to work properly, this class is expecting that you also have instantiated
// another game object and attached the Slip Stream script to it.  Alternatively
// they could be attached to the same object.

public class Body : MonoBehaviour
{

    public GameObject SlipStreamObject;
    FileLoader loaderScript;
    GameObject puntaPointer;
    GameObject GuiaRigid;
    GameObject brocaVisible;
    bool brocaPerdida;

    // Use this for initialization
    void Start()
    {
        loaderScript = GameObject.Find("loader").GetComponent<FileLoader>();
        SlipStreamObject.GetComponent<SlipStream>().PacketNotification += new PacketReceivedHandler(OnPacketReceived);
        //puntaPointer = GameObject.Find("puntaPointer");
        //GuiaRigid = GameObject.Find("Guia");
        brocaVisible = GameObject.Find("brocaVisible");
    }

    // packet received
    void OnPacketReceived(object sender, string Packet)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Packet);
        
        //== skeletons ==--
/*
        XmlNodeList boneList = xmlDoc.GetElementsByTagName("Bone");
        
        for (int index = 0; index < boneList.Count; index++)
        {
           
            int id = System.Convert.ToInt32(boneList[index].Attributes["ID"].InnerText);

            float x = (float)System.Convert.ToDouble(boneList[index].Attributes["x"].InnerText);
            float y = (float)System.Convert.ToDouble(boneList[index].Attributes["y"].InnerText);
            float z = (float)System.Convert.ToDouble(boneList[index].Attributes["z"].InnerText);

            float qx = (float)System.Convert.ToDouble(boneList[index].Attributes["qx"].InnerText);
            float qy = (float)System.Convert.ToDouble(boneList[index].Attributes["qy"].InnerText);
            float qz = (float)System.Convert.ToDouble(boneList[index].Attributes["qz"].InnerText);
            float qw = (float)System.Convert.ToDouble(boneList[index].Attributes["qw"].InnerText);

            //== coordinate system conversion (right to left handed) ==--

            z = -z;
            qz = -qz;
            qw = -qw;

            //== bone pose ==--

            Vector3 position = new Vector3(x, y, z);
            Quaternion orientation = new Quaternion(qx, qy, qz, qw);

            //== locate or create bone object ==--

            string objectName = "Bone" + id.ToString();

            GameObject bone;

            bone = GameObject.Find(objectName);

            if (bone == null)
            {
                bone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Vector3 scale = new Vector3(0.1f, 0.1f, 0.1f);
                bone.transform.localScale = scale;
                bone.name = objectName;
            }

            //== set bone's pose ==--

            bone.transform.position = position;
            bone.transform.rotation = orientation;
        }
        */
        //== rigid bodies ==--

        XmlNodeList rbList = xmlDoc.GetElementsByTagName("RigidBody");
        
        for (int index = 0; index < rbList.Count; index++)
        {
            int id = System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText);

            float x = (float)System.Convert.ToDouble(rbList[index].Attributes["x"].InnerText);
            float y = (float)System.Convert.ToDouble(rbList[index].Attributes["y"].InnerText);
            float z = (float)System.Convert.ToDouble(rbList[index].Attributes["z"].InnerText);

            float qx = (float)System.Convert.ToDouble(rbList[index].Attributes["qx"].InnerText);
            float qy = (float)System.Convert.ToDouble(rbList[index].Attributes["qy"].InnerText);
            float qz = (float)System.Convert.ToDouble(rbList[index].Attributes["qz"].InnerText);
            float qw = (float)System.Convert.ToDouble(rbList[index].Attributes["qw"].InnerText);
			//Debug.Log(rbList[index].Attributes["qx"].Value);
			//== coordinate system conversion (right to left handed) ==--

			// original
			//z = -z;

            Vector3 position = new Vector3(x, y, z);
            Quaternion orientation = new Quaternion(qx, qy, qz, qw);

            //Vector3 positionPunta = new Vector3(qx, qy, qz);

            //== locate or create bone object ==--

            string objectName = "RigidBody" + id.ToString();
            //string objectName = "RigidBody";
            //si el id la posicion del elemento en script es igual al id del xml de llegada
            if (Convert.ToInt32(loaderScript.rigids[0][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[0][1].Trim('"');
            }
            if (Convert.ToInt32(loaderScript.rigids[1][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[1][1].Trim('"');
            }
            if (Convert.ToInt32(loaderScript.rigids[2][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[2][1].Trim('"');
            }
            if (Convert.ToInt32(loaderScript.rigids[3][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[3][1].Trim('"');
            }
            if (Convert.ToInt32(loaderScript.rigids[4][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[4][1].Trim('"');
            }
            if (Convert.ToInt32(loaderScript.rigids[5][0]) == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = loaderScript.rigids[5][1].Trim('"');
                
            }
            if (5 == System.Convert.ToInt32(rbList[index].Attributes["ID"].InnerText))
            {
                objectName = "sc";
            }


            GameObject bone;

            bone = GameObject.Find(objectName);

            if (bone == null)
            {
                bone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Vector3 scale = new Vector3(0.1f, 0.1f, 0.1f);
                bone.transform.localScale = scale; // escala nuevo bone
                bone.name = objectName;
            }
            if (objectName == "Guia")
            {
                //bone.transform.position = new Vector3(qx / 1000, qy / 1000, qz / 1000);
                //puntaPointer.transform.position = position;
				 //bone.transform.LookAt(puntaPointer.transform);
                brocaPerdida = false;
                bone.transform.position = position;
                bone.transform.rotation = orientation;
			}

			else
            {
                bone.transform.position = position;
                bone.transform.rotation = orientation;

            }
			// Debug.Log(bone.name + ": rotX: " + bone.transform.eulerAngles.x + "rotY:" + bone.transform.eulerAngles.y + "rotZ:" + bone.transform.eulerAngles.z);
			//== set bone's pose ==--

			double xr = bone.transform.rotation.x;
			double yr = bone.transform.rotation.y;
			double zr = bone.transform.rotation.z;
			int mm = 0;

		}
        if (brocaPerdida)
        {
            brocaVisible.SetActive(true);
        }
        else
        {
            brocaVisible.SetActive(false);
        }
        brocaPerdida = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
