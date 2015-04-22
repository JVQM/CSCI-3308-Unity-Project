using UnityEngine;
using System.Collections;

public class TestColliderandHealth : MonoBehaviour {
	float PreviousHealth = 0;
	float NewHealth = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(-5*Time.deltaTime,0.0f,0.0f);
	}
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
