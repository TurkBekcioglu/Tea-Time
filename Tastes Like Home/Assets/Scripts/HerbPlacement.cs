using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HerbPlacement : MonoBehaviour
{

	public Sprite herb;
	public string ingredient;
	public Button jar;
	public static int herbs = 0;

    // Start is called before the first frame update
    void Start()
    {
		jar.onClick.AddListener(PlaceHerb);
    }

	void PlaceHerb() {
		
		GameObject mixSlot;
		if (herbs == 0) {
			Debug.Log("12");
			mixSlot = GameObject.FindGameObjectWithTag("Herb1");
		} else if (herbs == 1) {
			mixSlot = GameObject.FindGameObjectWithTag("Herb2");
			Debug.Log("13");
		} else {
			return;
		}

		SpriteRenderer spriteRenderer = mixSlot.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = herb;
		mixSlot.GetComponent<HerbContainer>().ingredient = ingredient;
		herbs++;

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}