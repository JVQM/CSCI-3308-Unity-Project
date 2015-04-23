//Player Physics from Sebastion Lague Tutorials on Platformers

using UnityEngine;
using System.Collections;


[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {
	/// <summary>
	/// Set the layer for collisionmask, player will collide with this layer
	/// </summary>
	public LayerMask collisionMask;

	/// <summary>
	/// Get the player's box collider
	/// </summary>
	private BoxCollider collider;

	/// <summary>
	/// Collider Scaled vector
	/// </summary>
	private Vector3 s;
	/// <summary>
	/// Center of the collider
	/// </summary>
	private Vector3 c;

	/// <summary>
	/// The size of the original vector
	/// </summary>
	private Vector3 originalSize;
	/// <summary>
	/// The original center of collider
	/// </summary>
	private Vector3 originalCentre;
	/// <summary>
	/// The collider scaled value
	/// </summary>
	private float colliderScale;

	/// <summary>
	/// Amount of divisions in collider to detect in X direction
	/// </summary>
	private int collisionDivisionsX = 3;
	/// <summary>
	/// Amount of divisions in collider to detect in Y direction	
	/// </summary>
	private int collisionDivisionsY =10;
	
	private float skin = .005f;
	
	[HideInInspector]
	/// <summary>
	/// Boolean to check if object is in contact with object from bottom
	/// </summary>
	public bool grounded;
	[HideInInspector]
	/// <summary>
	/// Boolean to check player is no longer moving
	/// </summary>
	public bool movementStopped;
	
	Ray ray;
	RaycastHit hit;

	/// <summary>
	/// Initialization, gets collider of player and its values(size and center)
	/// </summary>
	public void Start() {
		collider = GetComponent<BoxCollider>();
		colliderScale = transform.localScale.x;
		
		originalSize = collider.size;
		originalCentre = collider.center;
		SetCollider(originalSize,originalCentre);
	}

	/// <summary>
	/// Move the specified moveAmount.
	/// </summary>
	/// <param name="moveAmount">Move amount.</param>
	public void Move(Vector2 moveAmount) {
		
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position;
		
		// Check collisions above and below
		grounded = false;
		
		for (int i = 0; i<collisionDivisionsX; i ++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/(collisionDivisionsX-1) * i; // Left, centre and then rightmost point of collider
			float y = p.y + c.y + s.y/2 * dir; // Bottom of collider
			
			ray = new Ray(new Vector2(x,y), new Vector2(0,dir));
			Debug.DrawRay(ray.origin,ray.direction);
			
			if (Physics.Raycast(ray,out hit,Mathf.Abs(deltaY) + skin,collisionMask)) {
				// Get Distance between player and ground
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				// Stop player's downwards movement after coming within skin width of a collider
				if (dst > skin) {
					deltaY = dst * dir - skin * dir;
				}
				else {
					deltaY = 0;
				}
				
				grounded = true;
				
				break;
				
			}
		}
		
		
		// Check collisions left and right
		movementStopped = false;
		for (int i = 0; i<collisionDivisionsY; i ++) {
			float dir = Mathf.Sign(deltaX);
			float x = p.x + c.x + s.x/2 * dir;
			float y = p.y + c.y - s.y/2 + s.y/3 * i;
			
			ray = new Ray(new Vector2(x,y), new Vector2(dir,0));
			Debug.DrawRay(ray.origin,ray.direction);
			
			if (Physics.Raycast(ray,out hit,Mathf.Abs(deltaX) + skin,collisionMask)) {
				// Get Distance between player and ground
				float dst = Vector3.Distance (ray.origin, hit.point);
				
				// Stop player's downwards movement after coming within skin width of a collider
				if (dst > skin) {
					deltaX = dst * dir - skin * dir;
				}
				else {
					deltaX = 0;
				}
				
				movementStopped = true;
				break;
				
			}
		}
		
		if (!grounded && !movementStopped) {
			Vector3 playerDir = new Vector3(deltaX,deltaY);
			Vector3 o = new Vector3(p.x + c.x + s.x/2 * Mathf.Sign(deltaX),p.y + c.y + s.y/2 * Mathf.Sign(deltaY));
			ray = new Ray(o,playerDir.normalized);
			
			if (Physics.Raycast(ray,Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY),collisionMask)) {
				grounded = true;
				deltaY = 0;
			}
		}
		
		
		Vector2 finalTransform = new Vector2(deltaX,deltaY);
		
		transform.Translate(finalTransform,Space.World);
	}
	
	// Set collider
	public void SetCollider(Vector3 size, Vector3 centre) {
		collider.size = size;
		collider.center = centre;
		
		s = size * colliderScale;
		c = centre * colliderScale;
	}
	
	public void ResetCollider() {
		SetCollider(originalSize,originalCentre);	
	}
	
}
