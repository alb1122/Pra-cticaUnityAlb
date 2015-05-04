using UnityEngine;
using System.Collections;

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
	private float tiempoInicial=Time.time;
	
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
			if (Time.time > intervalo+tiempoInicial) {

				intervalo += 5;
				DispararBomba ();
			}
			tiempoInicial=0;
		}
	}

}
