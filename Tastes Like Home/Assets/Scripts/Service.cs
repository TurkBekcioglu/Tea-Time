﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Service : MonoBehaviour
{
	public Button b;
	public Tea t;

    // Start is called before the first frame update
    void Start()
    {
		b.onClick.AddListener(Serve);
    }

	void Serve() {
		string path = "Art/Counter/tea_cup_base";
		Sprite sp = Resources.Load<Sprite>(path);
		GameObject mug = GameObject.FindGameObjectWithTag("Mug");
		//if (mug.GetComponent<SpriteRenderer>().sprite != sp) {
		Debug.Log("123r45");
		if (HerbPlacement.herbs == 4) {
			Debug.Log("123r55555555");
			mug.GetComponent<SpriteRenderer>().sprite = sp;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
