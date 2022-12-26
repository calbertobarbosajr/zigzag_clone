using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotMoeda : MonoBehaviour {

	[SerializeField]
	private float vel = 80;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (0,0,vel * Time.deltaTime));
	}
}
