using System.Collections;
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
		if (HerbPlacement.herbs == 4) {
			mug.GetComponent<SpriteRenderer>().sprite = sp;
			HerbPlacement.herbs = 0;
			GameController.customersServed++;
			//GameController.happinessToday++;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}