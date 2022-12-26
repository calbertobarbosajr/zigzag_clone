using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BolaControlador : MonoBehaviour {


	//public static BolaControlador instance;


	[SerializeField]
	private float vel = 1f, limiteVel = 1.5f;
	[SerializeField]
	private Rigidbody rb;
	public static bool gameOver = false;
	[SerializeField]
	private int moedasNum = 0;
	[SerializeField]
	private Text txtMoedas;
	[SerializeField]
	private GameObject Particulas;

	//Variaveis GO

	[SerializeField]
	private Text txtBtn, txtGO;
	[SerializeField]
	private Image imgBtn,imgFundo;
	[SerializeField]
	private bool controle;
	[SerializeField]
	private GameObject efeito;
	//



	void Awake()
	{
		SceneManager.sceneLoaded += Carrega;
	}



	void Carrega(Scene cena, LoadSceneMode modo)
	{		
		gameOver = false;
	}

	// Use this for initialization
	void Start () {
		
		moedasNum = PlayerPrefs.GetInt ("MoedasGame");
		txtMoedas.text = moedasNum.ToString ();


		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (vel, 0, 0);


		txtGO = GameObject.FindWithTag ("txtgo").GetComponent<Text>();
		txtBtn = GameObject.FindWithTag ("txtbtn").GetComponent<Text>();
		imgBtn = GameObject.FindWithTag ("imgbtn").GetComponent<Image>();
		imgFundo = GameObject.FindWithTag ("imgfundo").GetComponent<Image>();


		controle = true;

		txtBtn.enabled = false;
		txtGO.enabled = false;
		imgBtn.enabled = false;
		imgFundo.enabled = false;

		StartCoroutine ("AjustaVel");
	}



	// Update is called once per frame
	void Update () {



		if(Input.GetKeyDown(KeyCode.Space) && !gameOver)
		{			
			BolaMov ();
		}

		if(!Physics.Raycast(transform.position,Vector3.down,1))
		{
			gameOver = true;
			rb.useGravity = true;
		}

		if(gameOver && controle)
		{
			
			PlayerPrefs.SetInt ("MoedasGame",moedasNum);
			txtBtn.enabled = true;
			txtGO.enabled = true;
			imgBtn.enabled = true;
			imgFundo.enabled = true;
			controle = false;


		}


	}




	void BolaMov()
	{
		if(rb.velocity.x > 0)
		{
			rb.velocity = new Vector3 (0, 0, vel);
		}
		else if(rb.velocity.z > 0)
		{
			rb.velocity = new Vector3 (vel, 0, 0);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("moeda"))
		{
			Destroy (col.gameObject);
			moedasNum++;
			txtMoedas.text = moedasNum.ToString ();
			Instantiate (Particulas, transform.position, Quaternion.identity);
			Instantiate (efeito, transform.position, Quaternion.identity);
		}
	}


	IEnumerator AjustaVel()
	{
		
			while (!gameOver) {
				yield return new WaitForSeconds (2);
				if (vel < limiteVel) {				
					vel += 0.2f;
				} 

			}


	}




	public void Novamente()
	{		
		SceneManager.LoadScene (0);

	}

}
