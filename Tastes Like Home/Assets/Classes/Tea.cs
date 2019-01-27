using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea
{
  public string teaName;
  public TeaType teaType;
  public string description;
  public int tiredValue;
  public int sadValue;
  public int madValue;
  public bool discovered;

  public Tea(string name, int sad, int tired, int mad, string type, string description)
  {
    this.teaName = name;
    this.sadValue = sad;
    this.tiredValue = tired;
    this.madValue = mad;
    this.teaType = TeaManager.getTeaType(type);
    this.description = description;
    this.discovered = false;
  }
}
