using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlNave : MonoBehaviour
{
	public float velocidadNave = 20f;
	public float velocidadDisparo = 10f;
	public float velocidadDisparoBomba = 1f;
	public float limiteD;
	public float limiteI=20f;
	public float posicionXi=-13.5f;
	public float posicionXd=13.5f;
	public float horzExtent;
	// Acceso al prefab Disparo
	public Rigidbody2D disparo;
	public Rigidbody2D bomba;

	private float intervalo;
	private bool muerto=false;

	//pal respawn
	float tmuerto=0;
	float tresp=1;
	float secondsToCount=1;
	int number=0;
	float xo;
	float yo;
	float zo;
	Vector3 posO;
	public GameObject marcadorBomba1;
	public GameObject marcadorBomba2;
	public GameObject marcadorBomba3;

	private int bombas = 3;

	public GameObject exp;
	public GameObject asteroideM;

	void Start ()
	{
		// posO = new Vector3();
	//	posO = transform.position;
		asteroideM = GameObject.Find ("AsteroideM");
		muerto = false;
		
	}
	// Hacemos copias del prefab del disparo y las lanzamos

	void Disparar ()
	{
		// Clonar el objeto
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 3f);

		// Lanzarlo
		d.AddForce (Vector2.up * velocidadDisparo);	
	}
	void DispararBomba ()
	{
		// Clonar el objeto


		Rigidbody2D d = (Rigidbody2D)Instantiate (bomba, transform.position, transform.rotation);
		
		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;
		
		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 3f);
		
		// Lanzarlo
		d.AddForce (Vector2.up * velocidadDisparo);	
		switch (bombas) {
		case 1:
			Image i3 = marcadorBomba1.GetComponent<Image> ();
			i3.canvasRenderer.Clear ();
			break;
		case 2:
			Image i2 = marcadorBomba2.GetComponent<Image> ();
			i2.canvasRenderer.Clear ();
			break;
		case 3:
			Image i1 = marcadorBomba3.GetComponent<Image> ();
			i1.canvasRenderer.Clear ();
			break;


		default:
			break;
		}

		bombas = bombas - 1;







	}

	void Update ()
	{
		horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
		// Izquierda
		posicionXi = (horzExtent  * -1)+1;
		posicionXd = (horzExtent  )-1;
		if (muerto) {


		
	
		
		
		} else {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//posicionXi=transform.position.x;
				if (transform.position.x >= posicionXi) {
					transform.Translate (Vector3.left * velocidadNave * Time.deltaTime);
				} else {
					transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);
				}

				

			}

			// Derecha
			if (Input.GetKey (KeyCode.RightArrow)) {
				if (transform.position.x <= posicionXd) {
					transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);
				} else {

					transform.Translate (Vector3.right * velocidadNave * Time.deltaTime * 0);
				}
			}

			// Disparo
			if (Input.GetKeyDown (KeyCode.Space)) {
				Disparar ();
			}
			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				// Cada cierto tiempo, fabricamos un asteroide
				if (bombas > 0) {

					DispararBomba ();
				}
			}
		}
//		if (muerto) {
//			secondsCounter += Time.deltaTime;
//			if (secondsCounter >= secondsToCount)
//			{
//				secondsCounter=0;
//				number++;
//				transform.position = transform.position;
//
//
//				//cube.transform.position = new Vector3(x, y, 0);
//
//			}
//
//
//		}
//		if (Time.time < tmuerto) {
//			GetComponent<CircleCollider2D>().enabled = false;
//			GetComponent<Renderer>().enabled = true;
//			for(double i = 0; i < 2; i=i+0.2)
//			{
//				if (Time.time<0.2){
//					GetComponent<Renderer>().enabled = true;
//				}
//				GetComponent<Renderer>().enabled = false;
//			}
//		}

	if (Time.time > tmuerto-1) {
		//transform.position=new Vector3(0,0,0);
		
		GetComponent<Renderer> ().enabled = false;
	}
	if (Time.time > tmuerto - 3) {
			//transform.position=new Vector3(0,0,0);
		
			GetComponent<Renderer> ().enabled = true;
		} else {
			GetComponent<Renderer> ().enabled = false;
		}

	if (Time.time > tmuerto) {
				//transform.position=new Vector3(0,0,0);

				GetComponent<Renderer> ().enabled = true;
				GetComponent<CircleCollider2D> ().enabled = true;
				disparo.GetComponent<Renderer> ().enabled = true;
				disparo.GetComponent<Collider2D> ().enabled = true;
				muerto = false;
			}
		
	}

	void OnCollisionEnter2D (Collision2D coll)
	{

		

			if (coll.gameObject.tag == "asteroide") {
				// Hemos chocado con la nave, restamos una vida
				Instantiate (exp, transform.position, transform.rotation);
				GetComponent<Renderer>().enabled = false;
				GetComponent<Collider2D>().enabled = false;
				respawnNave();

			}
		

	}
	void respawnNave(){
		//GetComponent<Renderer>().enabled = false;
		//GetComponent<Collider2D>().enabled = false;
		//

		muerto = true;

		if (muerto) {
			disparo.GetComponent<Renderer>().enabled=false;
			disparo.GetComponent<Collider2D>().enabled = false;
			transform.position=new Vector3(0,0,0);
			tmuerto=Time.time+4;
		}
		 
			
		
//		 float t=Time.time+1;
//		new WaitForSeconds(5);
//
//		if (Time.time>t) {
//		
//			GetComponent<Renderer> ().enabled = true;
//			GetComponent<Collider2D> ().enabled = true;
//
//		}
		 


	}


}
