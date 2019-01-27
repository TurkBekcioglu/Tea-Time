using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterActivator : MonoBehaviour
{

	public Button trigger;
	public bool isClicked;
	public GameObject counter;

    // Start is called before the first frame update
    void Start()
    {
		Button btn = trigger.GetComponent<Button>();
		btn.onClick.AddListener(OpenCounter);
		isClicked = false;
        
    }

	void OpenCounter() {
		isClicked = true;
	}

	private void OnGUI() {
		if (isClicked) {
			counter.SetActive(true);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
