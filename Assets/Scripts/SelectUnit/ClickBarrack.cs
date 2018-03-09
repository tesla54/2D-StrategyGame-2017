using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBarrack : MonoBehaviour {

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
                // For Barrack Select
                if (rayHit.collider.gameObject.tag == "Barrack")
                {
                    ClickOnBuldings clicOnScript = rayHit.collider.GetComponent<ClickOnBuldings>();

                    if (selectedObjects.Count == 0)
                    {
                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.clickOnBarrack();
                    }
                    else
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnBuldings>().currentlySelected = false;
                                obj.GetComponent<ClickOnBuldings>().clickOnBarrack();
                            }

                            selectedObjects.Clear();
                        }

                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.clickOnBarrack();
                    }
                }
                else
                {
                    //DeSelect on click barrack,Ground,......
                    if (rayHit.collider.gameObject.tag == "Soldier" || rayHit.collider.gameObject.tag == "Ground" || rayHit.collider.gameObject.tag == "PowerPlant")
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnBuldings>().currentlySelected = false;
                                obj.GetComponent<ClickOnBuldings>().clickOnBarrack();
                            }

                            selectedObjects.Clear();
                        }
                    }
                }
            }



        }

    }
}
