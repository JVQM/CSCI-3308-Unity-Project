using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
	public float Bulletspeed = 5;
	public float Dmg = 5;
	public float timeStamp;
	// Use this for initialization
	void Start () {
		timeStamp = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(1.0f+Bulletspeed*Time.deltaTime,0.0f,0.0f);
		Destroy(this.gameObject,1);
	}
void OnTriggerEnter(Collider Hit){
		if(Hit != null){
			if(Hit.gameObject.tag == "Obstacle"){
				Destroy(Hit.gameObject);
				Destroy(this.gameObject);}
			if(Hit.gameObject.tag == "Enemy"){
					Hit.GetComponent<Health>().ReceiveDmg (Dmg);
					Destroy(this.gameObject);
					Hit = null;
				}
		}
	}
}
