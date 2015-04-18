using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	private AudioSource coinSFX;
	// Use this for initialization
	void Start () {
		AudioSource coin_sound = GetComponent<AudioSource>();
		coinSFX = coin_sound;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject,10f);
		
	}
	void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				coinSFX.Play ();
				Destroy(this.gameObject);
			}
		}
	}
}
