using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragTest : MonoBehaviour {

    private MeshRenderer buildingRender;
    bool canBuild=false;

    [SerializeField]
    private Material errorMaterial;
    [SerializeField]
    private Material defMaterial;

    GameObject textCantBuiild;




    void Start()
    {
        buildingRender = this.GetComponent<MeshRenderer>();
        textCantBuiild = GameObject.Find("/Canvas/TextCantBuild");
        
    }

    void Update()
    {
        followCurser();

        if (canBuild == true)
        {
            if (Input.GetMouseButton(0))
            {
                // gameObject.GetComponent<DragTest>().enabled = false;
                Destroy(GetComponent<DragTest>());
            }
        }


        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerPlant" || other.gameObject.tag == "Barrack" || other.gameObject.tag=="OutMap")
        {
            canBuild = false;
            buildingRender.material.color = Color.red;
            textCantBuiild.GetComponent<Text>().text = "It can not be built here";
            //Debug.Log("Triggired");
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PowerPlant" || other.gameObject.tag == "Barrack" || other.gameObject.tag == "OutMap")
        {
            canBuild = true;
            buildingRender.material.color = Color.green;
            textCantBuiild.GetComponent<Text>().text = "";
            //Debug.Log("NOtTriggered");
            
        }
    }


    void followCurser()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 29.5f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
