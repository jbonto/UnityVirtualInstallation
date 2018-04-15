using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
	public float Movementspeed;
	public float turnspeed;
	private float verticalAxis, horizontalAxis;
	private float currentRotation;
	private Rigidbody RB;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		currentRotation = this.transform.position.y;
	}
	
	/**Void Update is called once per frame, and FixedUpdate is called at a unit of time set in Unity.
	 * Update can be called at a different rate on different computers, because they are playing the game at different frame rates.
	 * Because of this, anything to do with Unity physis should go in FixedUpdate, so it is consistant between computers.
	 * This also means FixedUpdate cannot call if Unity's time(time.timeScale) is set to 0, but Update will call(many functions within Update won't though, but code such as anything resetting the timeScale to 1f will)
	 * */
	void Update () {

		horizontalAxis = Input.GetAxis("Horizontal");
		verticalAxis = Input.GetAxis ("Vertical");
		}

	void FixedUpdate(){
		/**
		 * Turn and move were created for and explained in Unity's official tank game tutorial
		 * 
		 * */
		Turn ();
		Move ();


	}
	void Turn(){
		float turn = horizontalAxis * turnspeed * horizontalAxis * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn* horizontalAxis, 0f);
		RB.MoveRotation (RB.rotation * turnRotation);
	}
	void Move(){
		Vector3 movement = transform.forward * verticalAxis * Movementspeed * Time.deltaTime;
		RB.MovePosition (RB.position + movement);
	}
}
