using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixButton : MonoBehaviour
{
	public Button b;
	public Tea t;
	
    // Start is called before the first frame update
    void Start()
    {
		b.onClick.AddListener(Brew);
    }

	public void setTea(Tea other) {
		this.t = other;
	}

	void Brew() {
		//if (this.GetComponent<SpriteRenderer>().sprite != null) {
		if (HerbPlacement.herbs == 3) {
			GameObject mug = GameObject.FindGameObjectWithTag("Mug");
			Debug.Log("12" + t.teaName);
			string path = "Art/Counter/" + t.teaName;
			mug.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
			this.GetComponent<SpriteRenderer>().sprite = null;
			GameObject serv = GameObject.FindGameObjectWithTag("Serv");
			serv.GetComponent<Service>().t = t;
			HerbPlacement.herbs++;
		}
	}
		
}
