using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoldier : MonoBehaviour
{


    public Vector3 destination;

    [SerializeField]
    private LayerMask clickablesLayer;
    [SerializeField]
    private LayerMask notClickableLayer;

    public  List<GameObject> selectedObjects;



    void Start()
    {
        selectedObjects = new List<GameObject>();
    }


    void Update()
    {
        

        if ((Input.GetMouseButtonDown(1)))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // PathRequestManager.RequestPath(deneme.transform.position, destination, newScript.OnPathFound);       
        }

    
        RaycastHit rayHit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickablesLayer))
            {
                // For Soldier Select
                if (rayHit.collider.gameObject.tag == "Soldier")
                {
                    ClickOnSoldier clicOnScript = rayHit.collider.GetComponent<ClickOnSoldier>();

                    if (selectedObjects.Count == 0)
                    {
                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.ClickMe();
                    }
                    else
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnSoldier>().currentlySelected = false;
                                obj.GetComponent<ClickOnSoldier>().ClickMe();
                            }

                            selectedObjects.Clear();
                        }

                        selectedObjects.Add(rayHit.collider.gameObject);
                        clicOnScript.currentlySelected = true;
                        clicOnScript.ClickMe();
                    }
                }
                else
                {
                    //DeSelect on click barrack,Ground,......
                    if(rayHit.collider.gameObject.tag == "Barrack"|| rayHit.collider.gameObject.tag == "Ground"|| rayHit.collider.gameObject.tag == "PowerPlant")
                    {
                        if (selectedObjects.Count > 0)
                        {
                            foreach (GameObject obj in selectedObjects)
                            {
                                obj.GetComponent<ClickOnSoldier>().currentlySelected = false;
                                obj.GetComponent<ClickOnSoldier>().ClickMe();
                            }

                            selectedObjects.Clear();
                        }
                    }
                }
            }



        }

    }
}



