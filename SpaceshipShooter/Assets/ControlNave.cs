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
	float secondsCounter=0;
	float secondsToCount=1;
	int number=0;

	public GameObject marcadorBomba1;
	public GameObject marcadorBomba2;
	public GameObject marcadorBomba3;

	private int bombas = 3;

	public GameObject exp;
	public GameObject asteroideM;

	void Start ()
	{

		asteroideM = GameObject.Find ("AsteroideM");
		
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
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//posicionXi=transform.position.x;
			if (transform.position.x>=posicionXi){
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime );
			}else {
				transform.Translate (Vector3.left * velocidadNave * Time.deltaTime * 0);
				}

				

		}

		// Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.position.x<=posicionXd) {
				transform.Translate (Vector3.right * velocidadNave * Time.deltaTime);
			}else {

			transform.Translate (Vector3.right * velocidadNave * Time.deltaTime*0);
			}
		}

		// Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			Disparar ();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			// Cada cierto tiempo, fabricamos un asteroide
				if (bombas>0) {

				DispararBomba ();
			}
		}
		if (muerto) {
			secondsCounter += Time.deltaTime;
			if (secondsCounter >= secondsToCount)
			{
				secondsCounter=0;
				number++;
				transform.position = transform.position;


				//cube.transform.position = new Vector3(x, y, 0);

			}


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
		Destroy (gameObject);
		muerto = true;
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
