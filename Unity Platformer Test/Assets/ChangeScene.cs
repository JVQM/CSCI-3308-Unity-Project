using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	
	/// <summary>
	/// Changes to scene.
	/// </summary>
	/// <param name="sceneToChange">Scene to change.</param>
	public void ChangeToScene (string sceneToChange) {
		Application.LoadLevel (sceneToChange);
	}

}
