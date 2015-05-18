using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlMarcador : MonoBehaviour
{
	// Puntos ganados en la partida
	public int puntos = 0;

	// Vidas
	public int vidas = 5;

	// Referencia para el resto de objetos
	public GameObject marcador;

	// Actualizar el marcador
	void Update ()
	{
		// Localizamos el componente del UI
		Text t = marcador.GetComponent<Text> ();

		// Actualizamos el marcador
		t.text = "Puntos: "+puntos.ToString () + "\n";
		t.text += "Vidas: "+vidas.ToString () + "\n";

		// Si el número de vidas llega a 0, reiniciamos el juego
		if(vidas == 0)
			Application.LoadLevel(Application.loadedLevel);
	}
}
