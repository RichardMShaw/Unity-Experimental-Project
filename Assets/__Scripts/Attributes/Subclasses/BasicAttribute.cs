using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attributes such as Health
[CreateAssetMenu(menuName = "Project/Attributes/Basic Attribute")]
public class BasicAttribute : Attribute
{
  public int defaultBasicValue;
  public override int getDefaultBasicValue {
    get {
      return defaultBasicValue;
    }
  }
}
