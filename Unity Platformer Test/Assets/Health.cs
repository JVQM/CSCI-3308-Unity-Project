using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour

{
	/// <summary>
	/// The current health.
	/// </summary>
	public float currentHealth;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	/// <summary>
	/// Damage function, subtracts dmg from current health	/// </summary>
	/// <param name="dmg">Damage to take</param>
	public void ReceiveDmg(float dmg){
			currentHealth-=dmg;
	}
	/// <summary>
	/// Checks if the object is dead depending on current health	/// </summary>
	/// <returns><c>true</c>, if dead was dead, <c>false</c> target is still alive.</returns>
	public bool isDead()
		{
			if (currentHealth <=0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
}

