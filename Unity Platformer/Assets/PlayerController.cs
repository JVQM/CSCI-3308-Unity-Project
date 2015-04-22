using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : Health {
	
	// Player Handling
	public float gravity = 20;
	public float speed = 0;
	public float acceleration = 0;
	public float jumpHeight = 12;
	
	public float currentSpeed;
	public float targetSpeed;
	private Vector2 amountToMove;

	private AudioSource ShotSD;
	private AudioSource RollSD;
	private AudioSource JumpSD;
	private AudioSource DeathSD;
	
	private PlayerPhysics playerPhysics;
	private Animator Player;



	GameObject Shot;
	

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		Player = GetComponent<Animator>();
		AudioSource[] audios = GetComponents<AudioSource>();
		ShotSD = audios[0];
		RollSD = audios[1];
		JumpSD = audios[2];
	}
	
	void Update () {
		if(this.GetComponent <Health>().isDead ()){
			Player.SetTrigger ("Death");
			Destroy (this.gameObject,2);}
		// Reset acceleration upon collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		//If player is firing weapon
		if (Input.GetMouseButtonDown (1)){
			GameObject bullet = Instantiate (Resources.Load ("Shot")) as GameObject;
			Player.SetTrigger ("Shoot");
			ShotSD.Play ();
			bullet.transform.position = (this.transform.position + new Vector3(1.0f,1.3f,0.0f));
		}

		if (Input.GetMouseButtonDown (2)){
			Player.SetTrigger ("Roll");
			RollSD.Play ();
		}

		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			
			// Jump
			if (Input.GetMouseButtonDown(0)) {
				amountToMove.y = jumpHeight;
				Player.SetTrigger ("Jump");
				JumpSD.Play ();
			}
		}
		
		// Input
		targetSpeed =  speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed,acceleration);
		
		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}


	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
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
