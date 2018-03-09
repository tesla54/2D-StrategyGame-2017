using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnBuldings : MonoBehaviour {

    //for pruduct Soldier
    public  GameObject spawnPoint;
    public  GameObject soldierPrefeb;


    [Header("Building")]
    [SerializeField]
    private Material selected;
    [SerializeField]
    private Material def;

    private MeshRenderer buildingRender;

    [Header("Buildings Images")]
    //Iamges  
    public Sprite _barrackImage;
    public Sprite _powerPlantImages;
    public Sprite _soldierImage;



    [Header("GameObject for Information")]
    //Information Menu
    public bool currentlySelected = false;
    public GameObject infoName;
    public GameObject infoImage;
    public GameObject product1;
    public GameObject product2;

    

    // Use this for initialization
    void Start () {

        buildingRender=GetComponent<MeshRenderer>();

        //IM setActive false on start      
        infoName.SetActive(false);
        infoImage.SetActive(false);
        product1.SetActive(false);
        product2.SetActive(false);

        clickOnBarrack();
    }

    void Update()
    {

    }



    //Product Soldier
    public  void productSoldier()
    { 
         Instantiate(soldierPrefeb, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
    }


    //prroduct barrack
    public void clickOnBarrack()
    {
        if (currentlySelected == true)
        {

            infoName.SetActive(true);
            infoName.GetComponent<Text>().text = "Barrack";

            infoImage.SetActive(true);
            infoImage.GetComponent<Image>().sprite = _barrackImage;

            product1.SetActive(true);
            product1.GetComponent<Image>().sprite = _soldierImage;


        }
        else
        {
            if(currentlySelected == false)
            {
                infoName.SetActive(false);
                infoImage.SetActive(false);
                product1.SetActive(false);
            }
        }

        //Metarial
        if (currentlySelected == false)
        {
            buildingRender.material = def;
        }
        else
        {
            buildingRender.material = selected;
        }
            


    }


    //Product PowerPlant
    public void  clickOnPowerPlant()
    {
        if (currentlySelected == true)
        {
            infoName.SetActive(true);
            infoName.GetComponent<Text>().text = "Power Plants";

            infoImage.SetActive(true);
            infoImage.GetComponent<Image>().sprite = _powerPlantImages;



        }
        else
        {
            if (currentlySelected == false)
            {
                infoName.SetActive(false);
                infoImage.SetActive(false);

            }
        }

        //Metarial
        if (currentlySelected == false)
        {
            buildingRender.material = def;
        }
        else
        {
            buildingRender.material = selected;
        }
    }

}
