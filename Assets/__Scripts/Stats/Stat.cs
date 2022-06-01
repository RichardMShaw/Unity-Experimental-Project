using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Where modifier calculations for StatAttributes are done.
[Serializable]
public class Stat
{
  public int value
  {
    get
    {
      return cachedValue;
    }
  }

  public int basicValue;

  [SerializeField]
  private StatModifier baseStat;

  [SerializeField]
  private int cachedValue;
  private Dictionary<Modifier, float> cachedTypeValues;

  private Dictionary<StatModifier, StatModifier> modifiers;

  public Stat(Attribute attribute)
  {
    basicValue = attribute.getDefaultBasicValue;
    cachedTypeValues = new Dictionary<Modifier, float>();

    modifiers = new Dictionary<StatModifier, StatModifier>();
    var modifier = attribute.DefaultModifier();

    baseStat = modifier;
    modifiers.Add(modifier, modifier);

    var type = modifier.type;
    cachedTypeValues.Add(type, modifier.value);
    cachedValue = (int)modifier.value;
  }

  public Stat(Attribute attribute, int value)
  {
    basicValue = attribute.getDefaultBasicValue;
    cachedTypeValues = new Dictionary<Modifier, float>();

    modifiers = new Dictionary<StatModifier, StatModifier>();
    var modifier = attribute.DefaultModifier();
    modifier.value = value;

    baseStat = modifier;
    modifiers.Add(modifier, modifier);

    var type = modifier.type;
    cachedTypeValues.Add(type, modifier.value);
    cachedValue = (int)modifier.value;
  }
  public Stat(Attribute attribute, int value, int _basicValue)
  {
    basicValue = _basicValue;
    cachedTypeValues = new Dictionary<Modifier, float>();

    modifiers = new Dictionary<StatModifier, StatModifier>();
    var modifier = attribute.DefaultModifier();
    modifier.value = value;

    baseStat = modifier;
    modifiers.Add(modifier, modifier);

    var type = modifier.type;
    cachedTypeValues.Add(type, modifier.value);
    cachedValue = (int)modifier.value;
  }

  private void CalculateModifiers()
  {
    cachedValue = 1;
    foreach (var value in cachedTypeValues)
    {
      cachedValue *= (int)value.Value;
    }
  }

  public void AddModifier(StatModifier modifier)
  {
    if (modifiers.ContainsKey(modifier))
    {
      return;
    }
    modifiers.Add(modifier, modifier);

    var type = modifier.type;
    if (!modifiers.ContainsKey(modifier))
    {
      cachedTypeValues.Add(type, 0);
    }
    cachedTypeValues[type] = cachedTypeValues[type] + modifier.value;

    CalculateModifiers();
  }

  public void RemoveModifier(StatModifier modifier)
  {
    if (!modifiers.ContainsKey(modifier))
    {
      return;
    }
    modifiers.Remove(modifier);

    var type = modifier.type;
    cachedTypeValues[type] = cachedTypeValues[type] - modifier.value;
    if (cachedTypeValues[type] <= 0)
    {
      cachedTypeValues.Remove(type);
    }

    CalculateModifiers();
  }

}

