using UnityEngine;
using MyoUnity;
using System.Collections;




public class MyoScript : MonoBehaviour {
    Main mainScript;
    MyoManager myoScript;
    register registerScript;
    // Use this for initialization
    MyoPose lastPose;
    bool locked = true;
    private MyoPose myoPose = MyoPose.UNKNOWN;
    public bool holded;

    void Start () {
        holded = false;
        myoScript = GameObject.Find("MyoManager").GetComponent<MyoManager>();
        MyoManager.Initialize();
        StartCoroutine("attach");
        MyoManager.PoseEvent += OnPoseEvent;
        mainScript = GameObject.Find("MainScript").GetComponent<Main>();
        registerScript = GameObject.Find("main").GetComponent<register>();

    }
    IEnumerator attach()
    {
        //if (!MyoManager.GetIsAttached())
        //{
        //    MyoManager.AttachToAdjacent();
        //    yield return new WaitForSeconds(2);
        //    if (!MyoManager.GetIsAttached())
        //    {
        //        MyoManager.AttachToAdjacent();
        //        yield return new WaitForSeconds(2);
        //        if (!MyoManager.GetIsAttached())
        //        {
        //            MyoManager.AttachToAdjacent();
        //            yield return new WaitForSeconds(2);
        //            if (!MyoManager.GetIsAttached())
        //            {
        //                MyoManager.AttachToAdjacent();

        //            }

        //        }

        //    }
        //}
        yield return new WaitForSeconds(5);
        MyoManager.AttachToAdjacent();

    }

    // Update is called once per frame
    void Update () {

        if (!MyoManager.GetIsAttached())
        {
            
        }
        else
        {
            if (myoPose != lastPose)
            {

                if (myoPose == MyoPose.DOUBLE_TAP)
                {
                    mainScript.TapControl();
                    locked = !locked;
                    lastPose = myoPose;


                }
                if (myoPose == MyoPose.REST)
                {
                    lastPose = myoPose;

                }
                if (!locked)
                {
                    if (myoPose == MyoPose.FIST)
                    {
                        StartCoroutine("isFistHold");
                        lastPose = myoPose;


                    }
                    if (myoPose == MyoPose.FINGERS_SPREAD)
                    {
                        lastPose = myoPose;
                        mainScript.AbrirMenu();

                    }
                    if (myoPose == MyoPose.WAVE_OUT)
                    {
                        StartCoroutine("isWOHold");
                        lastPose = myoPose;

                    }
                    if (myoPose == MyoPose.WAVE_IN)
                    {
                        StartCoroutine("isWIHold");
                        lastPose = myoPose;
                        

                    }
                    
                }

            }
        }


    }

    IEnumerator isFistHold()
    {
        if(myoPose == MyoPose.FIST)
        {
            yield return new WaitForSeconds(0.5f);
            if (myoPose == MyoPose.FIST)
            {
                yield return new WaitForSeconds(0.5f);
                if (myoPose == MyoPose.FIST)
                {
                    yield return new WaitForSeconds(0.5f);
                    if (myoPose == MyoPose.FIST)
                    {
                        yield return new WaitForSeconds(0.5f);
                        if (myoPose == MyoPose.FIST)
                        {
                            yield return new WaitForSeconds(0.5f);
                            if (myoPose == MyoPose.FIST)
                            {
                                
                                MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
                                mainScript.TapControl();
                                locked = !locked;
                                StartCoroutine("registerFemur");

                            }
                            else
                            {
                                mainScript.SelectMyo();
                            }

                        }
                        else
                        {
                            mainScript.SelectMyo();
                        }

                    }
                    else
                    {
                        mainScript.SelectMyo();
                    }

                }
                else
                {
                    mainScript.SelectMyo();
                }

            }
            else
            {
                mainScript.SelectMyo();
            }

        }
        else
        {
            mainScript.SelectMyo();
        }
    }

    IEnumerator isWIHold()
    {
        if (myoPose == MyoPose.WAVE_IN)
        {
            yield return new WaitForSeconds(0.5f);
            if (myoPose == MyoPose.WAVE_IN)
            {
                yield return new WaitForSeconds(0.5f);
                if (myoPose == MyoPose.WAVE_IN)
                {
                    yield return new WaitForSeconds(0.5f);
                    if (myoPose == MyoPose.WAVE_IN)
                    {
                        yield return new WaitForSeconds(0.5f);
                        if (myoPose == MyoPose.WAVE_IN)
                        {
                            yield return new WaitForSeconds(0.5f);
                            if (myoPose == MyoPose.WAVE_IN)
                            {

                                MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
                                mainScript.TapControl();
                                locked = !locked;
                                registerScript.calibrarBroca();

                            }
                            else
                            {
                                mainScript.Atras();
                            }

                        }
                        else
                        {
                            mainScript.Atras();
                        }

                    }
                    else
                    {
                        mainScript.Atras();
                    }

                }
                else
                {
                    mainScript.Atras();
                }

            }
            else
            {
                mainScript.Atras();
            }

        }
        else
        {
            mainScript.Atras();
        }
    }
    IEnumerator isWOHold()
    {
        if (myoPose == MyoPose.WAVE_OUT)
        {
            yield return new WaitForSeconds(0.5f);
            if (myoPose == MyoPose.WAVE_OUT)
            {
                yield return new WaitForSeconds(0.5f);
                if (myoPose == MyoPose.WAVE_OUT)
                {
                    yield return new WaitForSeconds(0.5f);
                    if (myoPose == MyoPose.WAVE_OUT)
                    {
                        yield return new WaitForSeconds(0.5f);
                        if (myoPose == MyoPose.WAVE_OUT)
                        {
                            yield return new WaitForSeconds(0.5f);
                            if (myoPose == MyoPose.WAVE_OUT)
                            {

                                MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
                                mainScript.TapControl();
                                locked = !locked;
                                StartCoroutine("registerClavo");

                            }
                            else
                            {
                                mainScript.Adelante();
                            }

                        }
                        else
                        {
                            mainScript.Adelante();
                        }

                    }
                    else
                    {
                        mainScript.Adelante();
                    }

                }
                else
                {
                    mainScript.Adelante();
                }

            }
            else
            {
                mainScript.Adelante();
            }

        }
        else
        {
            mainScript.Adelante();
        }
    }
    void OnPoseEvent(MyoPose pose)
    {
        myoPose = pose;
    }
    IEnumerator registerFemur()
    {
        registerScript.registrarFemur0();
        yield return new WaitForSeconds(5);
        registerScript.registrarFemur1();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
        yield return new WaitForSeconds(5);
        registerScript.registrarFemur2();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
        yield return new WaitForSeconds(5);
        registerScript.registrarFemur3();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);

    }
    IEnumerator registerClavo()
    {
        registerScript.registrarClavo0();
        yield return new WaitForSeconds(5);
        registerScript.registrarClavo1();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
        yield return new WaitForSeconds(5);
        registerScript.registrarClavo2();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);
        yield return new WaitForSeconds(5);
        registerScript.registrarClavo3();
        MyoManager.VibrateForLength(MyoVibrateLength.SHORT);

    }
}
