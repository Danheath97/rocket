using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class Displacement : MonoBehaviour {

    public GameObject Displacement_Rocket;
    public Vector3 displacement;
    public Vector3 InitialPosition;
    
    string output;
    public static float PitchAngle;
    public float alpha;
    public static float Aoa;

    float FlightPathAngle;


    public Vector3 wind;







    // Use this for initialization
    void Start () {
        InitialPosition = Displacement_Rocket.transform.position;
        wind = plateMesh.wind;

        FlightPathAngle = Mathf.Rad2Deg *-1* Mathf.Atan(wind.y / wind.x);
        


    }
	
	// Update is called once per frame
	void Update () {
        displacement = Displacement_Rocket.transform.position - InitialPosition;

        


        PitchAngle =  Mathf.Rad2Deg * Mathf.Atan(displacement.y / displacement.x);
        
        Aoa = FlightPathAngle - PitchAngle ;

        

        SaveToFile();

           
	}

    

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\PitchAttitude Output.txt", true))
        {

            output =   PitchAngle.ToString() + ","   +  Time.time.ToString();

            writer.WriteLine(output);
            writer.Close();

        }

    }

}
