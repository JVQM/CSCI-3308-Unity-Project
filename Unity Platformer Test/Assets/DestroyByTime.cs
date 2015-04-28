using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	/// <summary>
	/// The lifetime of an object before being destroyed
	/// </summary>
	public float lifetime;
	/// <summary>
	/// Inititation, destroy object at lifetime
	/// </summary>
	public void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}