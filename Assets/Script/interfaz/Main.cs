using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    // Use this for initialization
    public GameObject menuView;
    public GameObject GreenFrame;
    public GameObject DescripcionView;
    Vector3 BarPosIzq;
    Vector3 BarPosDer;    
    int scrollEstado;
    int scrollMax;
    float valueRazon;

    bool femurotibia = true; //true=tibia

    Sprites sprites;
    public MainBehaviour MainBehav;


    void Start () {
        sprites = GameObject.Find("SpriteObject").GetComponent<Sprites>();
        MainBehav = GameObject.Find("main").GetComponent<MainBehaviour>();
        menuView = GameObject.Find("CategoriasView");
        DescripcionView = GameObject.Find("DescripcionView");

        GreenFrame = GameObject.Find("GreenFrame");


        scrollEstado = 1;
        scrollMax = 4;
        CerrarMenu();

    }
	
	// Update is called once per frame
	void Update () {
        
    }
    

    public void TapControl()
    {
        if (menuView.activeSelf || DescripcionView.activeSelf)
        {
            CerrarMenu();
        }
        else
        {
            AbrirMenu2();
        }

    }

    public void AbrirMenu()
    {
        if(DescripcionView.activeSelf || menuView.activeSelf)
        {
            menuView.SetActive(true);
            GreenFrame.SetActive(true);
            DescripcionView.SetActive(false);
        }
        

    }
    public void AbrirMenu2()
    {
            menuView.SetActive(true);
            GreenFrame.SetActive(true);
            DescripcionView.SetActive(false);
        


    }
    public void CerrarMenu()
    {
        
        menuView.SetActive(false);
        DescripcionView.SetActive(false);
        GreenFrame.SetActive(false);
        GreenFrame.transform.localPosition = new Vector3(-240, GreenFrame.transform.localPosition.y, GreenFrame.transform.localPosition.z);
        scrollEstado = 1;
        

    }
    public void Adelante()
    {
        if (DescripcionView.activeSelf && DescripcionView.GetComponent<Image>().sprite.name.Contains("abordaje"))
        {
            femurotibia = !femurotibia;
            getAbordaje();
            
        }
        else
        {
            if (scrollEstado < scrollMax)
            {

                GreenFrame.transform.localPosition = new Vector3(GreenFrame.transform.localPosition.x + 160, GreenFrame.transform.localPosition.y, GreenFrame.transform.localPosition.z);


                scrollEstado++;
            }
            else
            {
                scrollEstado = 1;
                GreenFrame.transform.localPosition = new Vector3(-240, GreenFrame.transform.localPosition.y, GreenFrame.transform.localPosition.z);

            }
        }
        

    }

    public void Atras()
    {
        if (DescripcionView.activeSelf && DescripcionView.GetComponent<Image>().sprite.name.Contains("abordaje"))
        {
            femurotibia = !femurotibia;
            getAbordaje();
            
        }
        else
        {
            if (scrollEstado > 1)
            {

                GreenFrame.transform.localPosition = new Vector3(GreenFrame.transform.localPosition.x - 160, GreenFrame.transform.localPosition.y, GreenFrame.transform.localPosition.z);

                scrollEstado--;
            }
            else
            {
                scrollEstado = scrollMax;
                GreenFrame.transform.localPosition = new Vector3(240, GreenFrame.transform.localPosition.y, GreenFrame.transform.localPosition.z);


            }
        }
     }

    void getAbordaje()
    {
        if (femurotibia)
        {
            DescripcionView.GetComponent<Image>().sprite = sprites.abordajeTSprite;

        }
        else
        {
            DescripcionView.GetComponent<Image>().sprite = sprites.abordajeFSprite;

        }
    }

    public void SelectMyo()
    {
        if (menuView.activeInHierarchy)
        {

            switch (scrollEstado) {
                case 1:
                    menuView.SetActive(false);
                    DescripcionView.SetActive(true);
                    DescripcionView.GetComponent<Image>().sprite = sprites.activarTSprite;
                    MainBehav.punto1Select();
                    GreenFrame.SetActive(false);
                    break;
                case 2:
                    menuView.SetActive(false);
                    DescripcionView.SetActive(true);
                    DescripcionView.GetComponent<Image>().sprite = sprites.activarFSprite;
                    MainBehav.punto2Select();
                    GreenFrame.SetActive(false);
                    break;
                case 3:
                    //menuView.SetActive(false);
                    //DescripcionView.SetActive(true);
                    //getAbordaje();
                    //GreenFrame.SetActive(false);
                    menuView.SetActive(false);
                    DescripcionView.SetActive(true);
                    DescripcionView.GetComponent<Image>().sprite = sprites.activarFSprite;
                    MainBehav.punto3Select();
                    GreenFrame.SetActive(false);
                    break;
                case 4:
                    //menuView.SetActive(false);
                    //DescripcionView.SetActive(true);
                    //DescripcionView.GetComponent<Image>().sprite = sprites.casoSprite;
                    //GreenFrame.SetActive(false);
                    menuView.SetActive(false);
                    DescripcionView.SetActive(true);
                    DescripcionView.GetComponent<Image>().sprite = sprites.activarFSprite;
                    MainBehav.punto4Select();
                    GreenFrame.SetActive(false);
                    break;
            }  
        }
        
        
    }

}
