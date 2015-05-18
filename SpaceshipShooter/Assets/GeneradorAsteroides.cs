using UnityEngine;
using System.Collections;

public class GeneradorAsteroides : MonoBehaviour
{
	public Rigidbody2D asteroideG1;
	public Rigidbody2D asteroideG2;
	public Rigidbody2D asteroideG3;
	public Rigidbody2D asteroideM;

	// Para controlar el tiempo entre cada asteroide generado
	private float intervalo;

	void GenerarAsteroide ()
	{
		// Calculamos una posición inicial para el asteroide de forma aleatoria
		Vector2 posicionInicial = new Vector2 (transform.position.x + ((Random.value * 50f) - 25f), transform.position.y);

		// Clonamos el objeto de uno de los cuatro tipos
		int tipoAsteroide = Random.Range (0, 4);

		Rigidbody2D asteroide = null;

		switch (tipoAsteroide) {
		case 0:
			asteroide = (Rigidbody2D)Instantiate (asteroideG1, posicionInicial, transform.rotation);
			break;
		case 1:
			asteroide = (Rigidbody2D)Instantiate (asteroideG2, posicionInicial, transform.rotation);
			break;
		case 2:
			asteroide = (Rigidbody2D)Instantiate (asteroideG3, posicionInicial, transform.rotation);
			break;
		case 3:
			asteroide = (Rigidbody2D)Instantiate (asteroideM, posicionInicial, transform.rotation);
			asteroide.GetComponent<ControlAsteroide>().puntos = 500;
			break;
		}

		// Le damos rotación y lo escalamos un poco para que parezcan diferentes 
		asteroide.AddTorque (Random.value * 100f);
		float escala = Random.Range (.5f, 1f);
		asteroide.transform.localScale = new Vector3 (escala, escala, escala);
	}

	void Update ()
	{
		// Cada cierto tiempo, fabricamos un asteroide
		if (Time.time > intervalo) {
			GenerarAsteroide ();
			intervalo += Random.Range (.25f, 3);
		}
	}

}
