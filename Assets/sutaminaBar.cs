﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sutaminaBar : MonoBehaviour {
	public float speed = 5.0f;
	public Slider slider;
	Animator animator;
	UIScript uiscript;

	// Use this for initialization
	void Start () {
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		animator = GetComponent <Animator> ();
		uiscript = GameObject.Find ("Canvas").GetComponent<UIScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			PlayerScript.sutamina = PlayerScript.sutamina + (Time.deltaTime / 2);
		}
		//スタミナが０以上の時
		if (PlayerScript.sutamina > 0) {
			//スタミナが徐々に減る
			PlayerScript.sutamina = PlayerScript.sutamina - (Time.deltaTime / 15);
		}
		if (PlayerScript.sutamina < 0) {
			speed = 0;
			animator.SetBool ("DEAD", true);
			uiscript.Gameover ();
			Debug.Log ("taoreta");
		}
		if (PlayerScript.sutamina > 1) {
			PlayerScript.sutamina = 1;
		}
		Debug.Log (PlayerScript.sutamina);

		//スタミナとvalueをつなげる
		//スタミナをスライダーに反映させる処理
		slider.value = PlayerScript.sutamina;
	}
}
