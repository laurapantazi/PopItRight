﻿using UnityEngine;
using System.Collections;

public class BalloonPop : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			anim.Play ("PopAnimation",-1,0f);
		}
	}
}