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

	public GameObject marcadorBomba1;
	public GameObject marcadorBomba2;
	public GameObject marcadorBomba3;

	private int bombas = 3;
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
	}

}
