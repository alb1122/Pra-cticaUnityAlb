using UnityEngine;
using System.Collections;

public class ControlAsteroide : MonoBehaviour
{
	public GameObject marcador;
	public GameObject nave;
	// Por defecto, 100 puntos
	public int puntos = 100;
	public GameObject exp;
	public GameObject navExp;
	public GameObject expBomba;

	// Localizar y conectar el marcador para poder actualizarlo
	void Start ()
	{
		marcador = GameObject.Find ("Marcador");
		nave = GameObject.Find ("nave");


	}

	// Detectar la colisión entre el asteroide y el disparo
	void OnCollisionEnter2D (Collision2D coll)
	{
		GetComponent<AudioSource> ().Play ();

		if (coll.gameObject.tag == "disparo") {
			// Sumar la puntuación de este asteroide
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;
			Instantiate (exp, transform.position, transform.rotation);

			// El disparo desaparece
			//coll.gameObject.GetComponent<ParticleAnimator>()
			coll.gameObject.GetComponent<Renderer>().enabled = false;
			coll.gameObject.GetComponent<Collider2D>().enabled = false;

		}
		else if (coll.gameObject.tag == "bomba"){
			Instantiate(expBomba,transform.position,transform.rotation);
			coll.gameObject.GetComponent<Renderer>().enabled = false;
			coll.gameObject.GetComponent<Collider2D>().enabled = false;

		}
		else {
			if (coll.gameObject.tag == "nave") {
				// Hemos chocado con la nave, restamos una vida
				Instantiate (exp, transform.position, transform.rotation);
				Destroy(nave);
				if (marcador.GetComponent<ControlMarcador> ().vidas > 0) {
					marcador.GetComponent<ControlMarcador> ().vidas -= 1;
				}
			}
		}

		// El asteroide se destruye
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
	}

}
