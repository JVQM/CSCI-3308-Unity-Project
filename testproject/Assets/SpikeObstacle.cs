using UnityEngine;
using System.Collections;

public class SpikeObstacle : MonoBehaviour
{
	public float ObstacleSpeed = 10;
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += new Vector3(-ObstacleSpeed*Time.deltaTime,0.0f,0.0f);
	}
}
