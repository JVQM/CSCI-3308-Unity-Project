//Score manager using Unity tutorial
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	/// <summary>
	/// Variable to hold score
	/// </summary>
	public static int score;       
	
	/// <summary>
	/// Text holder to display score
	/// </summary>
	public Text text;                     
	
	/// <summary>
	/// Initiates score and grabs text component
	/// </summary>
	public void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		score = 0;
	}
	
	/// <summary>
	/// At every frame, update score
	/// </summary>
	public void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
	}
}