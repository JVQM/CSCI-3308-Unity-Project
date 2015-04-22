using UnityEngine;
using System.Collections;

public class MedPack : MonoBehaviour {
	/// <summary>
	/// The medpack speed.
	/// </summary>
	public float MedSpeed = 0.1f;
	/// <summary>
	/// The total heal amount	/// </summary>
	public float HealAMT = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates per frame, moves object left
	/// </summary>
	public void Update () {
		this.transform.position += new Vector3(-MedSpeed*Time.deltaTime,0.0f,0.0f);
	}
	/// <summary>
	/// Object trigger on collision
	/// </summary>
	/// <param name="col">Collider col </param>
	/// <param name="Return">If col == player, player gets health and this is destroyed</param>
	public void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				col.GetComponent<Health>().ReceiveDmg (-HealAMT);
				Destroy(this.gameObject);
			}
		}
	}
}
