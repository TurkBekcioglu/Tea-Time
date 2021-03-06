﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mix : MonoBehaviour
{
	public Button b;

    // Start is called before the first frame update
    void Start()
    {
		b.onClick.AddListener(Mixer);
    }

	void Mixer() {
		GameObject mixSlot1, mixSlot2;
		SpriteRenderer spriteRenderer;

		int herbs = HerbPlacement.herbs;
		if (herbs == 2) {
			mixSlot1 = GameObject.FindGameObjectWithTag("Herb1");
			mixSlot2 = GameObject.FindGameObjectWithTag("Herb2");

			spriteRenderer = mixSlot1.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = null;
			spriteRenderer = mixSlot2.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = null;

			string ing1 = mixSlot1.GetComponent<HerbContainer>().ingredient;
			string ing2 = mixSlot2.GetComponent<HerbContainer>().ingredient;

			HerbPlacement.herbs++;

			Tea t = RecipeManager.brew(ing1, ing2);
			Debug.Log("654" + t.teaName);
			string path = "Art/Teas/TeaLeaves/" + t.teaName;

			Sprite sp = Resources.Load<Sprite>(path);

			GameObject mixHerb = GameObject.FindGameObjectWithTag("MixHerb");
			mixHerb.GetComponent<SpriteRenderer>().sprite = sp;
			mixHerb.GetComponent<MixButton>().setTea(t);
		}
	}
		
}
