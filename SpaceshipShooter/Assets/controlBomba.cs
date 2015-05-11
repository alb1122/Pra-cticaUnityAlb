using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlBomba : MonoBehaviour {

	// Use this for initialization
	public int numBombas = 3;
	public GameObject MarcadorBombas;
	public Sprite bomSprite;
	public Sprite[] sprites;


	void Start () {
		    

			
			
				for (int i = 0; i < numBombas; i++)
				{
					//GameObject MarcadorBombas = new GameObject("UI Element " + i.ToString());

					// Image imagen = MarcadorBombas.AddComponent(typeof(Image));
					
					//imagen.sprite = sprites[Random.Range(0, sprites.Length)];
					//MarcadorBombas.transform.SetParent(gameObject, false);
				}



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
