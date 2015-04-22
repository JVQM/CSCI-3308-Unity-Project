using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
	/// <summary>
	/// The bulletspeed.
	/// </summary>
	public float Bulletspeed = 5;
	/// <summary>
	/// The dmg.
	/// </summary>
	public float Dmg = 5;
	/// <summary>
	/// Time stamp initiation
	/// </summary>
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	/// <summary>
	/// Update called once per frame, moves object right, destroys object after certain time
	/// </summary>
	public void Update () {
		this.transform.position += new Vector3(1.0f+Bulletspeed*Time.deltaTime,0.0f,0.0f);
		Destroy(this.gameObject,1);
	}
	/// <summary>
	/// Collider trigger, on hit do something
	/// </summary>
	/// <param name="Hit">Hit collision detect</param>
	/// <param name="Return">> If hit is obstacle, destroy object and this, if hit is enemy, enemy is damaged</param>
public void OnTriggerEnter(Collider Hit){
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
