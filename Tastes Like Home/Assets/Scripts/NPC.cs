using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public int race;
  public int color;

  public Character()
  {
    race = Random.Range(0, 4);
    color = Random.Range(0, 4);
  }
}
