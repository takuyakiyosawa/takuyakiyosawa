﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    // ここから
    public float speed = 4.5f;
    public float slideSpeed = 2.0f;

	public static float sutamina = 1;

	Animator animator;
	UIScript uiscript;


	void Start () {
		animator = GetComponent <Animator> ();
		uiscript = GameObject.Find ("Canvas").GetComponent<UIScript> ();
	}


	void Update () {
        //ここから
        transform.position += Vector3.forward * speed * Time.deltaTime;
        float pos_x = transform.position.x;
        /*if (Input.GetKey (KeyCode.LeftArrow)){
            if (pos_x > -1.9f) {
				transform.position += Vector3.left * slideSpeed * Time.deltaTime;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
            if (pos_x < 1.9f) {
				transform.position += Vector3.right * slideSpeed * Time.deltaTime;
			}
		}*/


		//アニメーションについて(いじらない)
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool ("STOP", true);
			speed = 0;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			animator.SetBool ("STOP", false);
			speed = 5.0f;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetBool ("JUMP", true);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			animator.SetBool ("JUMP", false);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			animator.SetBool ("SLIDE", true);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			animator.SetBool ("SLIDE", false);
		}
		Debug.Log (sutamina);
	}
		
	// Triggerである障害物にぶつかったとき
	void OnTriggerEnter (Collider colider){
		
		var stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");
//		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");
		bool isBarrier = colider.CompareTag ("barrier");
		bool isGoal = colider.CompareTag ("goal");

		// 障害物に当たったとき
		if( (isHigh == true && isSlide == false) ||
			(isLow == true && isJump == false) ||
		    (isBarrier == true)){
			//この下に書こう
			speed = 0;

			animator.SetBool ("DEAD", true);
			// UI
			uiscript.Gameover();

		}
		//ゴールした時
		if(isGoal == true){
			//この下に書こう
			speed = 0;
			animator.SetBool ("WIN", true);
			// UI
			uiscript.Goal();
		}
}
}
