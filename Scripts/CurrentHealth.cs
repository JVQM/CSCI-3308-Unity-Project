using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentHealth : MonoBehaviour
{
	/// <summary>
	/// Variable to hold current Health
	/// </summary>
	public static float cHealth;       
	
	/// <summary>
	/// Text holder to display score
	/// </summary>
	Text text;                     
	
	/// <summary>
	/// Initiates current health and grabs text component
	/// </summary>
	public void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		cHealth = 0;
	}
	
	/// <summary>
	/// At every frame, update current Health
	/// </summary>
	public void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Current Health: " + cHealth;
	}
}
