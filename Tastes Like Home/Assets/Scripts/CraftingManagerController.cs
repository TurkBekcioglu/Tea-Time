using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManagerController : MonoBehaviour
{
	const int NAME = 0;
	const int SAD = 1;
	const int TIRED = 2;
	const int MAD = 3;
	const int DESC = 4;
	const string statsPath = "Data/TLHTeaData_Stats.tsv";
	const string recipePath = "Data/TLHTeaData_Recipes.tsv";

	string ingredient1;
	string ingredient2;
	string result;

	// Start is called before the first frame update
    void Start()
    {
		ingredient1 = "";
		ingredient2 = "";
		result = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Get data from TSV
	string[,] GetTSVData(string path, int itemsPerLine)
	{
		string[] lines = File.ReadAllLines(path);
		int l = lines.Length;
		string[,] data = new string[itemsPerLine, l];
		for(int i = 0; i < l; i++) 
		{
			string[] line = lines[i].Split('\t');
			for(int j = 0; j < line.Length; j++) 
			{
				data[i, j] = line[j];
			}
		}
		return data;
	}

	string teaLookup(string name, int item)
	{
		string[,] data = GetTSVData(statsPath, 5);
		for(int i = 0; i < data.Length / 5; i++) 
		{
			if (data[i, NAME] == name) 
			{
				return data[i, item];
			}
		}
		Debug.LogError("Name not found in database.");
		return "";
	}

	void setIngredient1(string name)
	{
		ingredient1 = name;
	}

	void setIngredient2(string name)
	{
		ingredient2 = name;
	}

	void brew()
	{
		if (ingredient1 == ingredient2) 
		{
			result = ingredient1;
			ingredient1 = "";
			ingredient2 = "";
		}
		else 
		{
			string[,] recipes = GetTSVData(recipePath, 3);
			for(int i = 0; i < recipes.Length / 3; i++) 
			{
				if ((recipes[i, 0] == ingredient1 && recipes[i, 1] == ingredient2)
					|| (recipes[i, 0] == ingredient2 && recipes[i, 1] == ingredient1)) 
				{
					result = recipes[i, 2];
					ingredient1 = "";
					ingredient2 = "";
					return;
				}
			}
		}
	}
}
