using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    TeaManager.initTeas("Data/TLHTeaData_Stats.csv");
    Debug.Log("Teas loaded");
    RecipeManager.initRecipes("Data/TLHTeaData_Recipes.csv");
    Debug.Log("Recipes loaded");
  }

  // Update is called once per frame
  void Update()
  {

  }
}
