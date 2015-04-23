using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {
	/// <summary>
	/// The crate object animation.
	/// </summary>
	private Animator CrateObject;
	/// <summary>
	/// The explosion sound effect.
	/// </summary>
	private AudioSource ExplosionSD;
	/// <summary>
	/// Speed of GameObject.
	/// </summary>
	public float EnemySpeed = 0.1f;
	// Use this for initialization
	/// <summary>
	/// Sets attached animations and audio sources.
	/// </summary>
	void Start () {
		CrateObject = GetComponent<Animator>();
		AudioSource Explosion = GetComponent<AudioSource>();
		ExplosionSD = Explosion;
	}
	
	// Update is called once per frame
	/// <summary>
	/// Updates every frame. Moves object, checks isDead. If true, destroys object, plays animation and sound.
	/// </summary>
	void Update () {
		this.transform.position += new Vector3(-EnemySpeed*Time.deltaTime,0.0f,0.0f);
		if(this.GetComponent <Health>().isDead ()){
			CrateObject.SetTrigger ("Explode");
			ExplosionSD.Play ();
			Destroy (this.gameObject,0.5f);}
		Destroy (this.gameObject,10f);		
		
	}
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col collision parameter to detect collisions.</param>
	/// <param name="return">  Tag "Player" collision causes Health call, Dmg received & object destruct</param>
	void OnTriggerEnter(Collider col){
		if(col != null){
			if(col.gameObject.tag == "Player"){
				CrateObject.SetTrigger ("Explode");
				Destroy(this.gameObject,1);
				ExplosionSD.Play ();
				col.GetComponent<Health>().ReceiveDmg (5);
			}
		}
	}
}
