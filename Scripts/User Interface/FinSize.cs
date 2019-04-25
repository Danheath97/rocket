using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinSize : MonoBehaviour {

    public GameObject Fins;
    public Dropdown Finsize;

	// Update is called once per frame
	void Update () {
	

        switch(Finsize.value)
        {
            

            case 1:
                Fins.transform.localScale = new Vector3(.6666f, 0.035f, .5f);

                break;

            case 2:
                Fins.transform.localScale = new Vector3(.6666f, 0.083333f, .5f);

                break;

            case 3:
                Fins.transform.localScale = new Vector3(.6666f, 0.13f, .5f);

                break;

        }
        



	}
}
