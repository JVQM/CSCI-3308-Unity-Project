using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour

{
	public float currentHealth;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	public void ReceiveDmg(float dmg){
			currentHealth-=dmg;
	}
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

