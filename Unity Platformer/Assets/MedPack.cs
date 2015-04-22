using UnityEngine;
using System.Collections;

public class MedPack : MonoBehaviour {
	public float MedSpeed = 0.1f;
	public float HealAMT = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(-MedSpeed*Time.deltaTime,0.0f,0.0f);
		Destroy(this.gameObject, 15f);
	}
	void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				col.GetComponent<Health>().ReceiveDmg (-HealAMT);
				Destroy(this.gameObject);
			}
		}
	}
}
