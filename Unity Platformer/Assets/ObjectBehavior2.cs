using UnityEngine;
using System.Collections;

public class ObjectBehavior2 : MonoBehaviour {
	public float speed = -20f;
	public float timeStamp;
	// Use this for initialization
	void Start () {
	
		timeStamp = 1.0f;

	}
	
	// Update is called once per frame
	void Update () {
		// Add a horizontal speed to the object
		this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		
		// Destroy the enemy in 3 seconds,
		// when it is no longer visible on the screen
		Destroy(gameObject, 10f);
	}
}
