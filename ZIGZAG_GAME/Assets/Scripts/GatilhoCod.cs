using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoCod : MonoBehaviour {

	[SerializeField]
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			rb.useGravity = true;
			Destroy (gameObject, 0.3f);
			CriaChao.chaoNumCena--;
		}
	}
}
