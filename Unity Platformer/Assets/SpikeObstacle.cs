using UnityEngine;
using System.Collections;

public class SpikeObstacle : MonoBehaviour
{
	public float dmg = 3;
	// Update is called once per frame
	void Update ()
	{
	
	}
void OnTriggerEnter(Collider hit){
		Debug.Log("ishurt");
		if(hit.tag == "Player"){
			hit.GetComponent<Health>().ReceiveDmg(3);
		}
	}
}
