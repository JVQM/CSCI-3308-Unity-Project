using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	/// <summary>
	/// Exits the game on click.
	/// </summary>
	public void ExitGameOnClick () {
		Application.Quit ();
	}
}
