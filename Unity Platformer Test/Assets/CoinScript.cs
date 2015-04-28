using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	/// <summary>
	/// The coin sound effect. Plays on pickup.
	/// </summary>
	public AudioSource coinSFX;

	///<summary>
	/// Variable holding coin value for increasing score. 
	/// </summary>
	public int CoinValue = 10;

	/// <summary>
	/// Start this instance. Grabs audio source and adds to component. 
	/// </summary>
	public void Start () {
		AudioSource coin_sound = GetComponent<AudioSource>();
		coinSFX = coin_sound;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates per frame. Destroys object after 10 seconds
	/// </summary>
	public void Update () {
		Destroy (this.gameObject,10f);
		
	}
	/// <summary>
	/// Triggers object destruction on collision
	/// </summary>
	/// <param name="col">Col collision parameter to detect collisions</param>
	public void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				ScoreManager.score += CoinValue;
				coinSFX.Play ();
				Destroy(this.gameObject,0.2f);
			}
		}
	}
}
