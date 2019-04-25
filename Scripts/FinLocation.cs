using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class FinLocation : MonoBehaviour {

    public GameObject Main_Rocket;
    public GameObject StandardFins;

    
    Vector3 Cp;
      
    Vector3 BodySize;
    public static float BodyLength;
    public static float BodyWidth;
    public static float CpPosition;
    public  Vector3 Finsize;
    public static float FinSize_Y;
    public static float FinSize_X;
   public static float Cg;
   public static float BodyMass;
    public static float FinMass;
    public static float Cp_Y;
    string test;




    //constants

    float MassperLength = .05f; // gives a mass per unit length
    float standardfins = .002f;



    // Use this for initialization
    void Start () {

        // need to find the size of rocket

        BodySize = GetComponent<Collider>().bounds.size;
        BodyLength = BodySize.y;
        BodyWidth = BodySize.x;

        // cp is just the location of the fins with respect to the main body as not considering the effect from body
        Cp = StandardFins.transform.localPosition; // gives location in relation to main body
        Cp_Y = Cp.y; // value will be between -1 and 1

        CpPosition = BodyLength / 2 * Cp_Y; // gives distance from midpoint of body

        //convert the cp position relative to the midpoint of body to a distance from top of rocket i.e. Leading Edge
        if (Cp_Y < 0) //means fin is in the bottom half of body
            {
            CpPosition = CpPosition * -1 + BodyLength / 2;
            }
        else
            {
            CpPosition = BodyLength / 2 - CpPosition; // means fin is in top half of body
            }

        //calculating cg
        Finsize = GetComponent<Collider>().bounds.size;
        FinSize_Y = Finsize.y;
        FinSize_X = Finsize.x;
        BodyMass = BodyLength * MassperLength;
        FinMass = FinSize_Y * standardfins;


        Cg = ((BodyMass * BodyLength / 2) + (4*FinMass * CpPosition)) / ((BodyLength * MassperLength) + (FinSize_Y * standardfins));

        SaveToFile();

	}

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\Cg_Cp Output.txt", true))
        {

            test = CpPosition.ToString() + "," + Cg.ToString();


            writer.WriteLine(test);
            writer.Close();

        }

    }
}
