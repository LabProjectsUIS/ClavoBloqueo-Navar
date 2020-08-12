//======================================================================================================
// Copyright 2016, NaturalPoint Inc.
//======================================================================================================

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class OptitrackRigidBody : MonoBehaviour
{
    public OptitrackStreamingClient StreamingClient;
    public Int32 RigidBodyId;
	private List<Quaternion> listAcum = new List<Quaternion>();
	private int counter;

	private int counterLimit = 5;

	void Start()
    {
        // If the user didn't explicitly associate a client, find a suitable default.
        if ( this.StreamingClient == null )
        {
            this.StreamingClient = OptitrackStreamingClient.FindDefaultClient();

            // If we still couldn't find one, disable this component.
            if ( this.StreamingClient == null )
            {
                Debug.LogError( GetType().FullName + ": Streaming client not set, and no " + typeof( OptitrackStreamingClient ).FullName + " components found in scene; disabling this component.", this );
                this.enabled = false;
                return;
            }
        }
    }


#if UNITY_2017_1_OR_NEWER
    void OnEnable()
    {
        Application.onBeforeRender += OnBeforeRender;
    }


    void OnDisable()
    {
        Application.onBeforeRender -= OnBeforeRender;
    }


    void OnBeforeRender()
    {
        UpdatePose();
    }
#endif


    void Update()
    {
        UpdatePose();
    }


    void UpdatePose()
    {
        OptitrackRigidBodyState rbState = StreamingClient.GetLatestRigidBodyState( RigidBodyId );
        if ( rbState != null )
        {
			//this.transform.localPosition = rbState.Pose.Position;
			//this.transform.localRotation = rbState.Pose.Orientation;
			//Debug.Log("pos" + rbState.Pose.Position.x + "," + rbState.Pose.Position.y + "," + rbState.Pose.Position.z );
			//Debug.Log("quat" + counter + ":" + rbState.Pose.Orientation.x + "," + rbState.Pose.Orientation.y + "," + rbState.Pose.Orientation.z + "," + rbState.Pose.Orientation.w);
			
		if (this.RigidBodyId ==2) //promediar broca
			{
				
				if (counter<counterLimit)
				{
					//acum = rbState.Pose.Position;
					//Debug.Log(listAcum.Count);
					var NewOrientation = new Quaternion(rbState.Pose.Orientation.x, rbState.Pose.Orientation.y, rbState.Pose.Orientation.z, rbState.Pose.Orientation.w);
					listAcum.Add(NewOrientation);
					//Debug.Log("quat" + counter + ":" + NewOrientation.x+ "," + NewOrientation.y + "," + NewOrientation.z + "," + NewOrientation.w);
					counter++;
				}
				else {
					var newQuat = new Quaternion(
						listAcum.Average(x =>x.x),
						listAcum.Average(x =>x.y),
						listAcum.Average(x =>x.z),
						listAcum.Average(x => x.w));
					//var vectorPosGuia = new Vector3(-rbState.Pose.Position.x, rbState.Pose.Position.y, -rbState.Pose.Position.z);
					this.transform.localPosition = rbState.Pose.Position;
					this.transform.localRotation = newQuat;
					//Debug.Log("pos" + rbState.Pose.Position.x + "," + rbState.Pose.Position.y + "," + rbState.Pose.Position.z);
					//Debug.Log("quat" + counter + ":" + newQuat.x + "," + newQuat.y + "," + newQuat.z + "," + newQuat.w);
					counter = 0;
					listAcum.Clear();
				}//funcion promedie y asigne
			}
			else
			{
				/*var vectorPos = new Vector3(-rbState.Pose.Position.x, rbState.Pose.Position.y, -rbState.Pose.Position.z);
				var NewOrientation = new Quaternion(rbState.Pose.Orientation.x,rbState.Pose.Orientation.y,rbState.Pose.Orientation.z, rbState.Pose.Orientation.w);
				//this.transform.localPosition = vectorPos;
				//this.transform.localRotation = NewOrientation;
				NewOrientation.z = -NewOrientation.z;
				NewOrientation.x = -NewOrientation.x;*/
				this.transform.localPosition = rbState.Pose.Position;
				this.transform.localRotation = rbState.Pose.Orientation;

			}
		}
    }
}
