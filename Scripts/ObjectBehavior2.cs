using UnityEngine;
using System.Collections;

public class ObjectBehavior2 : MonoBehaviour {
	/// <summary>
	/// The speed of GameObject.
	/// </summary>
	public float speed = -20f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates per frame. Changes position of object based on speed. Destroys object after 10 seconds.
	/// </summary>
	void Update () {
		// Add a horizontal speed to the object
		this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		
		// Destroy the enemy in 3 seconds,
		// when it is no longer visible on the screen
		Destroy(gameObject, 10f);
	}
}
