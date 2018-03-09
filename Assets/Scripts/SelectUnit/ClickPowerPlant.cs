using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPowerPlant : MonoBehaviour {


    [SerializeField]
    private LayerMask clickablesLayer;
    [SerializeField]
    private LayerMask notClickableLayer;

    public List<GameObject> selectedObjects;



    void Start () {
        selectedObjects = new List<GameObject>();
    }
	

	void Update () {
        RaycastHit rayHit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickablesLayer))
            {
                // For PowerPlant Select
                if (rayHit.collider.gameObject.tag == "PowerPlant")
                {
                    ClickOnBuldings clicOnScript = rayHit.collider.GetComponent<ClickOnBuldings>();

                    if (selectedObjects.Count == 0)
                    {
                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.clickOnPowerPlant();
                    }
                    else
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnBuldings>().currentlySelected = false;
                                obj.GetComponent<ClickOnBuldings>().clickOnPowerPlant();
                            }

                            selectedObjects.Clear();
                        }

                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.clickOnPowerPlant();
                    }
                }
                else
                {
                    //DeSelect on click 
                    if (rayHit.collider.gameObject.tag == "Soldier" || rayHit.collider.gameObject.tag == "Ground"|| rayHit.collider.gameObject.tag == "Barrack")
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnBuldings>().currentlySelected = false;
                                obj.GetComponent<ClickOnBuldings>().clickOnPowerPlant();
                            }

                            selectedObjects.Clear();
                        }
                    }
                }
            }



        }
    }
}
