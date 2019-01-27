using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaManager : MonoBehaviour
{
  public static Dictionary<string, Tea> teas;
  // Start is called before the first frame update
  void Start()
  {
    teas = initTeas("Data/TLHTeaData_Stats.csv");
  }

  public static Tea getTea(string name)
  {
    return teas[name];
  }

  private Dictionary<string, Tea> initTeas(string path)
  {
    string[] lines = File.ReadAllLines(path);
    Dictionary<string, Tea> teas = new Dictionary<string, Tea>();

    for (int i = 0; i < lines.Length; i++)
    {
      string[] t = lines[i].Split(',');
      Tea tea = new Tea(t[0], int.Parse(t[1]), int.Parse(t[2]), int.Parse(t[3]), t[4], t[5]);
      teas.Add(t[0], tea);
    }

    return teas;
  }


  public static TeaType getTeaType(string type)
  {
    switch (type)
    {
      case "green":
        return TeaType.GREEN;
      case "fruit":
        return TeaType.FRUIT;
      case "black":
        return TeaType.BLACK;
      case "oolong":
        return TeaType.OOLONG;
      case "jasmine":
        return TeaType.JASMINE;
      case "spiced":
        return TeaType.SPICED;
      case "special":
        return TeaType.SPECIAL;
      default:
        throw new System.ArgumentException("TeaType is invalid");
    }
  }
}
