using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
  static Recipe[] recipes;
  // Start is called before the first frame update
  void Start()
  {
    recipes = initRecipes("Data/TLHTeaData_Recipes.csv");
  }

  private Recipe[] initRecipes(string path)
  {
    string[] lines = File.ReadAllLines(path);
    Recipe[] recipes = new Recipe[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
      string[] r = lines[i].Split(',');
      Recipe recipe = new Recipe(r[0], r[1], r[2]);
      recipes[i] = recipe;
    }

    return recipes;
  }

  public static Tea brew(string i1, string i2)
  {
    Ingredient ingredient1 = getIngredient(i1);
    Ingredient ingredient2 = getIngredient(i2);

    for (int i = 0; i < recipes.Length; i++)
    {
      Recipe recipe = recipes[i];
      if (
        (recipe.ingredient1 == ingredient1 && recipe.ingredient2 == ingredient2) ||
        (recipe.ingredient2 == ingredient1 && recipe.ingredient1 == ingredient2)
      )
      {
        return recipe.result;
      }
    }

    throw new System.ArgumentException("Recipe does not exist");
  }


  public static Ingredient getIngredient(string ingredient)
  {
    switch (ingredient)
    {
      case "green":
        return Ingredient.GREEN;
      case "black":
        return Ingredient.BLACK;
      case "oolong":
        return Ingredient.OOLONG;
      case "jasmine":
        return Ingredient.JASMINE;
      case "strawberry":
        return Ingredient.STRAWBERRY;
      case "peach":
        return Ingredient.PEACH;
      case "honey":
        return Ingredient.HONEY;
      case "ginger":
        return Ingredient.GINGER;
      case "mint":
        return Ingredient.MINT;
      default:
        throw new System.ArgumentException("Ingredient is invalid");
    }
  }
}
