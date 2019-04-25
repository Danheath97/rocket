using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BodyChange : MonoBehaviour {

public GameObject Main_Rocket;
public Dropdown myBodySize;



	
		
	
	
	// Update is called once per frame
	void Update () {
		switch(myBodySize.value)
    {
        case 1:
            Main_Rocket.transform.localScale = new Vector3(1.5f, 2f, 1.5f);
                

                break;
        case 2:
                
                Main_Rocket.transform.localScale = new Vector3(1.7f, 3.11f, 1.7f);
                
                break;
        case 3:
                Main_Rocket.transform.localScale = new Vector3(2f, 4.5f, 2f);
               
                break;


    }
	}
}
