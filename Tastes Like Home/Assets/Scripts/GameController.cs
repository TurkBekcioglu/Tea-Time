using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static int dayPhase = 0;
	public static int customersServed = 0;
	public int dayCount = 0;
	float timer = 0;
	public static int happinessToday = 0;
	public int happinessOverall = 0;
	public int unlockLevel = 0;
	public int[] goals;



  // Start is called before the first frame update
  void Start()
  {
    TeaManager.initTeas("Data/TLHTeaData_Stats.csv");
    Debug.Log("Teas loaded");
    RecipeManager.initRecipes("Data/TLHTeaData_Recipes.csv");
    Debug.Log("Recipes loaded");
		goals = new int[4];
		goals[0] = 150;
		goals[1] = 300;
		goals[2] = 500;
		goals[3] = 750;
  }

  // Update is called once per frame
  void Update()
  {
		if(dayPhase == 1) {
			//other manager triggers popups for yesterdays earnings
			DisplayDayCard(true);
			if (timer > 5) {
				dayPhase++;
				DisplayDayCard(false);
				timer = 0;
			} else {
				timer += Time.deltaTime;
			}
		} else if (dayPhase == 2) {
			//run customer loop
		} else {
			//night stuff
			if (happinessToday > 0) {
				happinessToday--;
				happinessOverall++;
				DisplayNightCard(true);
				UpdateFillMeter();
				if (happinessOverall == goals[unlockLevel]) {
					unlockLevel++;
					Unlock();
					happinessOverall = 0;
				}
			} else {
				dayCount++;
				DisplayNightCard(false);
			}
		}
		if (customersServed == 10) {
			dayPhase = 3;
			customersServed = 0;
		} 
			

  }

	void Unlock() {
		string path = "";
		if (unlockLevel == 1) {
			GameObject s3 = GameObject.Find("Slot3");
			GameObject s4 = GameObject.Find("Slot4");
			GameObject s5 = GameObject.Find("Slot5");

			s3.transform.GetChild(0).GetComponent<Button>().interactable = true;
			s4.transform.GetChild(0).GetComponent<Button>().interactable = true;
			s5.transform.GetChild(0).GetComponent<Button>().interactable = true;

			path = "Art/Teas/Ingredients/"+ s3.GetComponent<HerbPlacement>().ingredient;
			s3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

			path = "Art/Teas/Ingredients/"+ s4.GetComponent<HerbPlacement>().ingredient;
			s4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

			path = "Art/Teas/Ingredients/"+ s5.GetComponent<HerbPlacement>().ingredient;
			s5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

		} else if (unlockLevel == 2) {
			GameObject s6 = GameObject.Find("Slot6");
			GameObject s7 = GameObject.Find("Slot7");

			s6.transform.GetChild(0).GetComponent<Button>().interactable = true;
			s7.transform.GetChild(0).GetComponent<Button>().interactable = true;

			path = "Art/Teas/Ingredients/"+ s6.GetComponent<HerbPlacement>().ingredient;
			s6.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

			path = "Art/Teas/Ingredients/"+ s7.GetComponent<HerbPlacement>().ingredient;
			s7.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);

		} else if (unlockLevel == 3) {
			GameObject s8 = GameObject.Find("Slot8");
			s8.transform.GetChild(0).GetComponent<Button>().interactable = true;

			path = "Art/Teas/Ingredients/"+ s8.GetComponent<HerbPlacement>().ingredient;
			s8.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
		}

	}

	void UpdateFillMeter() {
		GameObject nc = GameObject.FindGameObjectWithTag("NightCard");
		//GameObject bg = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
		//GameObject mf = this.gameObject.transform.GetChild(1).GetChild(1).gameObject;
		//mf.GetComponent<RectTransform>().width = (happinessOverall/750) * 150;
		GameObject gc = this.gameObject.transform.GetChild(1).gameObject;
		gc.GetComponent<Text>().text = happinessOverall + "/750";
	}

	void DisplayNightCard(bool state) {
		GameObject nc = GameObject.FindGameObjectWithTag("NightCard");
		nc.SetActive(state);
	}

	void DisplayDayCard(bool state) {
		GameObject dc = GameObject.FindGameObjectWithTag("DayCard");
		dc.SetActive(state);
		GameObject gc = this.gameObject.transform.GetChild(1).gameObject;
		gc.GetComponent<Text>().text = "Day " + dayCount;

	}
}