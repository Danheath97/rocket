using UnityEngine;

public class RocketCam : MonoBehaviour {

    public GameObject Main_Rocket;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - Main_Rocket.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = offset + Main_Rocket.transform.position;

		
	}
}
