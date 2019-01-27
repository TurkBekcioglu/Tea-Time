using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public Button start;
	public bool isClicked;
	public Button credits;
	public Button quit;
	public GameObject C;

    // Start is called before the first frame update
    void Start()
    {
		start.onClick.AddListener(ChangeScene);
		credits.onClick.AddListener(OpenCreds);
		quit.onClick.AddListener(ExitCreds);
		isClicked = false;

    }

	void ExitCreds() {
		isClicked = false;
	}

	void OpenCreds() {
		isClicked = true;
	}

	private void OnGUI() {
		if (isClicked) {
			C.SetActive(true);
		} else {
			C.SetActive(false);
		}
	}

	void ChangeScene() {
		SceneManager.LoadScene(1);
	}

}