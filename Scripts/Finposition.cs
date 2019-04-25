using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Finposition : MonoBehaviour {

    public Slider Finlocation;
    public GameObject Fins;
    public GameObject Main_Rocket;

    float BodyLength;
    float finloc;
    float newfin;
    float a;
    float b;
    float dos;
    float c;
    float d;
    Vector3 Cp;
    float Cp_Y; //percentage of distance from midpoint of body


    void Start()
    {
        
    }

    void Update()
    {
        Cp = Fins.transform.localPosition; // gives location in relation to main body
        Cp_Y = Cp.y; // value will be between -1 and 1
        dos = Finlocation.value; // value of the slider for fin position expressed as %

        finloc = dos / 100; //gets value from finlocation slider
        BodyLength = FinLocation.BodyLength;
        newfin = BodyLength * finloc; //this gives the distance from top of rocket 

        

        // convert the distance to a value between -1 and 1 representing distance from midpoint of body
        if (newfin < BodyLength / 2) 
        {
            a = BodyLength / 2 - newfin; // gives distance from midpoint
            b = a / (BodyLength / 2); // gives the new local position from the parent main body's midpoint expressed as a value between 0 and 1
        }



        if ((Cp_Y > 0) && (newfin<BodyLength/2)) //means fin is currently in top half of body and wants to move to new position in top of body
        {
            Fins.transform.localPosition = new Vector3(0, -Cp_Y, 0); // puts the fin back to middle of body
            Fins.transform.localPosition = new Vector3(0, b, 0); // puts fin to intended location
        }



        
        

        else
        {
            c = newfin - BodyLength / 2;
            d = c / (BodyLength / 2);
        }

        if ((Cp_Y>0) && (newfin>BodyLength/2)) // fins currently in top half and want to move to bottom half
        {
            Fins.transform.localPosition = new Vector3(0, -Cp_Y, 0);
            Fins.transform.localPosition = new Vector3(0, -d, 0);

        }


        if ((Cp_Y < 0) &&(newfin<BodyLength/2)) //fin is in bottom half of body and want to move to top half
        {
            Fins.transform.localPosition = new Vector3(0, (Cp_Y * -1), 0);
            Fins.transform.localPosition = new Vector3(0, b, 0);

        }

        if ((Cp_Y<0) && (newfin>BodyLength/2)) //fin in bottom half and want to change position while still in bottom half
        {
            Fins.transform.localPosition = new Vector3(0, (Cp_Y * -1), 0);
            Fins.transform.localPosition = new Vector3(0, -d, 0);
        }

    }
}




  
    
           
    



    

    
    

    

    

