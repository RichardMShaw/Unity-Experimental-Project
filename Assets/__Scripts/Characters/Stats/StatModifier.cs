using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatModifier
{
  public Modifier type;

  public float value;

  public StatModifier(Modifier _type, float _value)
  {
    type = _type;
    value = _value;
  }

}
