using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public GameObject barrack;
    public GameObject powerPlant;

    GameObject _barrack;
    GameObject _powerPlant;
   

	void Start () {
		
	}
	
	
	void Update () {
		
	}



    public void buildBarrack()
    {

        _barrack = Instantiate(barrack, new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z), Quaternion.identity);

        _barrack.AddComponent<DragTest>();
        _barrack.GetComponent<ClickOnBuldings>().infoName = GameObject.Find("/Canvas/InformationMenu/TextInfoName");
        _barrack.GetComponent<ClickOnBuldings>().infoImage = GameObject.Find("/Canvas/InformationMenu/ImageInfo");
        _barrack.GetComponent<ClickOnBuldings>().product1 = GameObject.Find("/Canvas/InformationMenu/Product1");
        _barrack.GetComponent<ClickOnBuldings>().product2 = GameObject.Find("/Canvas/InformationMenu/Product2");

    }

    public void buildPowerPlant()
    {
        _powerPlant = Instantiate(powerPlant, new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z), Quaternion.identity);

        _powerPlant.AddComponent<DragTest>();
        _powerPlant.GetComponent<ClickOnBuldings>().infoName = GameObject.Find("/Canvas/InformationMenu/TextInfoName");
        _powerPlant.GetComponent<ClickOnBuldings>().infoImage = GameObject.Find("/Canvas/InformationMenu/ImageInfo");

    }
}
