using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaanger : MonoBehaviour {

    GameObject wanted;
    public List<GameObject> barracks;

    // Use this for initialization
    void Start () {
        barracks = new List<GameObject>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  onClickCreateSoldier()
    {
        barracks.AddRange(GameObject.FindGameObjectsWithTag("Barrack"));

        //for find selected Barrack
        for(int i = 0; i < barracks.Count; i++)
        {
            if (barracks[i].GetComponent<ClickOnBuldings>().currentlySelected == true)
            {
                wanted = barracks[i];
                barracks.Clear();
                break;
            }
   
        }

        //print(wanted);
        wanted.GetComponent<ClickOnBuldings>().productSoldier();

    }
}
