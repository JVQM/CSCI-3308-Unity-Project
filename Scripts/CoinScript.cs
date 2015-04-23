using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	/// <summary>
	/// The coin sound effect. Plays on pickup.
	/// </summary>
	private AudioSource coinSFX;
	// Use this for initialization
	/// <summary>
	/// Gets attached audiosource.
	/// </summary>
	void Start () {
		AudioSource coin_sound = GetComponent<AudioSource>();
		coinSFX = coin_sound;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates per frame. Destroys object after 10 seconds
	/// </summary>
	void Update () {
		Destroy (this.gameObject,10f);
		
	}
	/// <summary>
	/// Triggers object destruction on collision
	/// </summary>
	/// <param name="col">Col collision parameter to detect collisions</param>
	void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				coinSFX.Play ();
				Destroy(this.gameObject);
			}
		}
	}
}
