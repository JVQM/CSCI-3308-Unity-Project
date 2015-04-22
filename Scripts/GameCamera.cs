using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	/// <summary>
	/// vector target to aim for 
	/// </summary>
	public Transform target;
	/// <summary>
	/// The track speed.
	/// </summary>
	public float trackSpeed = 10;
	
	
	// Set target
	/// <summary>
	/// Sets the target to aim for
	/// </summary>
	/// <param name="t">vector to aim for</param>
	public void SetTarget(Transform t) {
		target = t;
	}
	
	// Track target
	/// <summary>
	/// Update per  frame, transforms object to target vector
	/// </summary>
	public void Update() {
		if (target) {
			float x = IncrementTowards(transform.position.x, target.position.x+20, trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
			transform.position = new Vector3(x,y, transform.position.z);
		}
	}
	
	// Increase n towards target by speed
	/// <summary>
	/// Increments param n towards target by speed
	/// </summary>
	/// <returns>The towards.</returns>
	/// <param name="n">First vector, current position vector of cam</param>
	/// <param name="target">Second vector, target vector for cam</param>
	/// <param name="a">The alpha component.</param>
	public float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}
