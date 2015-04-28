using UnityEngine;
using System.Collections;

public class TestColliderandHealth : MonoBehaviour {
	/// <summary>
	/// Holder float to check previous health.
	/// </summary>
	public float PreviousHealth = 0;
	/// <summary>
	/// Holder to check new health.
	/// </summary>
	public float NewHealth = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/// <summary>
	/// Update per frame to move object left to collide with player
	/// </summary>
	public void Update () {
		this.transform.position += new Vector3(-5*Time.deltaTime,0.0f,0.0f);
	}
	/// <summary>
	/// Collider trigger to collide with player	/// </summary>
	/// <param name="col">Collider, if is player, run tests </param>
	void OnTriggerEnter(Collider col){
		if(col != null){
			{if(col.gameObject.tag == "Player")
			{Debug.Log ("Collided with Player");}
				else{Debug.Log ("Failure:Object did not collide with player");}}
			PreviousHealth += col.GetComponent <Health> ().currentHealth;
			col.GetComponent<Health>().ReceiveDmg(5);
			NewHealth += col.GetComponent <Health> ().currentHealth;
			{if(NewHealth < PreviousHealth){
				Debug.Log ("Block did damage to player");}
				else{Debug.Log ("Failure:Object did not damage the player");}}
			col.GetComponent<Health>().ReceiveDmg (-5);
		//now previousHealth is actually the next health...=]
		PreviousHealth = 0;
		PreviousHealth += col.GetComponent <Health> ().currentHealth;
			{if(PreviousHealth > NewHealth){
			Debug.Log ("Object healed the player");}
				else{Debug.Log ("Failure:Object did not heal the player");}}
		col.GetComponent<Health>().ReceiveDmg (20000);
			{if(col.GetComponent<Health>().isDead ()){
			Debug.Log ("Object killed the player");}
				else{Debug.Log ("Failure:Object did not kill the player after receiving TONS of damage");}}

		}
	}
}
