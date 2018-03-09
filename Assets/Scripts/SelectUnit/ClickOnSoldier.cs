using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnSoldier : MonoBehaviour {

    [Header("Soldier")]
    [SerializeField]
    private Material selected;
    [SerializeField]
    private Material def;

    private MeshRenderer myRend;

    
    public bool currentlySelected = false;

    public Transform soldierTransform;
    public Vector3 destination;
    public LayerMask ground;

    



    void Start () {

        myRend = GetComponent<MeshRenderer>();
        soldierTransform = GetComponent<Transform>();
        ClickMe();

      


    }
	

	void Update () {

        //Soldier Movement
        if (Input.GetMouseButtonDown(1) && currentlySelected==true)
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, ground))
            {
                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            PathRequestManager.RequestPath(soldierTransform.position, destination, gameObject.GetComponent<Unit>().OnPathFound);


        }     
    }

    //for soldier
    public void ClickMe()
    {


        //if (currentlySelected == false)
        //{
        //    myRend.material = def;
        //}
        //else
        //{
        //    myRend.material = selected;
        //}

        if (currentlySelected ==true)
        {
            myRend.material = selected;
        }
        if (currentlySelected == false)
        {
            myRend.material = def;
        }
    }







}
