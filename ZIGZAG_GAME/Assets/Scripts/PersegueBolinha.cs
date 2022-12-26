using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersegueBolinha : MonoBehaviour {

	[SerializeField]
	private Transform bolinha;
	[SerializeField]
	private Vector3 dist;
	[SerializeField]
	private float lerpVal;
	[SerializeField]
	private Vector3 pos, alvoPos;

	// Use this for initialization
	void Start () {

		dist = bolinha.position - transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate()
	{
		if(!BolaControlador.gameOver)
		{
			PersegueFunc ();
		}

	}

	void PersegueFunc()
	{
		pos = transform.position;
		alvoPos = bolinha.position - dist;
		pos = Vector3.Lerp (pos, alvoPos, lerpVal);
		transform.position = pos;
	}
}
