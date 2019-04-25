using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Calculations : MonoBehaviour {

    float normalforce;
    float axialforce;
    float Cp;
    float Cg;
    float C_m;
    float PTorque;
    float staticmargin;
    string test;
    string title;
    float Cn;
    float M_alpha;
    float density = 1.225f;
    float Inertia;
    float NatFreq;
    float BodyLength;
    float BodyMass;
    float FinMass;
    float BodyWidth;
    float area;
    float C1;
    float Aoa;
    float C2;
    float C2a;
    float C2r;
    float DR;
    float DampedFreq;
    float DampR;
    float DynamicPressure;
    float PitchAngle;
    float M_ac;
    float Cm_ac;
    float MM;
    float Icg;
    float Fin_y;
    float Fin_x;
    float Ifin;






    //values that need referencing 
    float velocity = 7f;
   





    // Use this for initialization
    void Start () {
        Cp = FinLocation.CpPosition; //retrieve from other script
        Cg = FinLocation.Cg;
        staticmargin = Cp - Cg;

        BodyWidth = FinLocation.BodyWidth;
        area = 3.14f * Mathf.Pow(BodyWidth, 2) / 4; // pi dsquared /4

        

    }
	
	// Update is called once per frame
	void Update () {

        
        BodyLength = FinLocation.BodyLength; 
        BodyMass = FinLocation.BodyMass;
        FinMass = FinLocation.FinMass;


        //Calculating inertia
        // I for cylinder = 1/2 *mr^2

        // Icg
        Icg = BodyMass * Mathf.Pow(BodyLength, 2) / 12 + BodyMass * Mathf.Pow((Cg - BodyLength / 2), 2); //calculates longitudinal inertia about the c.o.g for the main body
        Fin_y = FinLocation.FinSize_Y;
        Fin_x = FinLocation.FinSize_X;

        Ifin = (Fin_x * Mathf.Pow(Fin_y, 3) / 12) + FinMass * Mathf.Pow(staticmargin, 2); //calculates longitudinal inertia about the c.o.g for the fins

        Inertia = Icg + Ifin;


       


       


        PTorque = plateMesh.PTorque; //these are from the aeroblocks script 
        Aoa = plateMesh.Aoa;


        Cn = plateMesh.CN; //normal force coefficient
        M_alpha = ((staticmargin * Cn * density * area * Mathf.Pow(velocity, 2) / 2) / Aoa); //corrective moment coefficient 

        //Calculating damping ratio
        NatFreq = Mathf.Sqrt(Mathf.Abs((M_alpha / Inertia)));
       // DampedFreq = (2 * 3.14f / Time.deltaTime); // the delta time is the time between peaks, needs changing
        // DampR = Mathf.Sqrt(Mathf.Abs(((1 - Mathf.Pow(DampedFreq, 2)) / NatFreq)));



        //calculating damping ratio by another method
        C1 = Mathf.Abs(M_alpha);

        //C2r is propulsive damping moment coefficient 
        //C2r = m_dot * Mathf.Sqrt((BodyLength-Cg), 2)

        C2a = (velocity * area * density * .5f) * (Cn * Mathf.Pow(staticmargin, 2)); //aerodynamic damping moment coefficient
        C2 = C2a + C2r;

        DR = (C2 / (2 * Mathf.Sqrt((C1 * Inertia)))); // damping ratio 


        DynamicPressure = 0.5f * 1.3f * Mathf.Pow(velocity, 2);








        //pitching moment for restoring
        axialforce = plateMesh.AForce;
        normalforce = plateMesh.NForce;

        MM = normalforce * (Cg - Cp);

        C_m = PTorque / (area * DynamicPressure * BodyLength); // pitching moment coefficient
        PitchAngle = Displacement.PitchAngle; // calls pitch attitude angle from displacement script

        //experimenting with moment about c/4 e.g. aero centre for constant moment coefficient
        M_ac = normalforce   * (Cp - (BodyLength / 4)) - (BodyMass * (Cg - (BodyLength / 4)));
        Cm_ac = M_ac / (area * DynamicPressure * BodyLength);



        SaveToFile();


    }

    

    public void SaveToFile()
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\PitchingMoment Output.txt", true))
        {

            test = Cn.ToString() + "," + C_m.ToString() + "," + NatFreq.ToString() + "," + MM.ToString();

            
            writer.WriteLine(test);
            writer.Close();

        }

    }
}
