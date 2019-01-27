using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
  public Tea result;
  public Ingredient ingredient1;
  public Ingredient ingredient2;
  public bool discovered;

  public Recipe(string result, string ingredient1, string ingredient2)
  {
    this.result = getResult(result);
    this.ingredient1 = RecipeManager.getIngredient(ingredient1);
    this.ingredient2 = RecipeManager.getIngredient(ingredient2);
    this.discovered = false;
  }

  private Tea getResult(string result)
  {
    return TeaManager.getTea(result);
  }
}
