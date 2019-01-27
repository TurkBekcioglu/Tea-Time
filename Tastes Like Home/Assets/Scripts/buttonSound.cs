using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSound : MonoBehaviour
{

	AudioSource audio;
	public Button b;

	// Start is called before the first frame update
    void Start()
    {
		audio = GetComponent<AudioSource>();
		b.onClick.AddListener(MakeSound);
    }

	void MakeSound() 
	{
		audio.Play(0);
	}
}
