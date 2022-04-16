using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

public class Attribute : ScriptableObject
{
  public string type;
  [TextArea(3, 20)]
  public string description;

  public int defaultValue = 100;

  public virtual int getDefaultBasicValue {
    get {
      return 0;
    }
  }

  private static Modifier _defaultModifierType;
  public Modifier defaultModifierType
  {
    get
    {
      if (_defaultModifierType == null)
      {
        var op = Addressables.LoadAssetAsync<Modifier>("BaseModifier");
        var obj = op.WaitForCompletion();
        Addressables.Release(op);
        if (obj == null)
        {
          throw new System.Exception("Could not find any singleton scriptable object instances in the reurce");
        }
        _defaultModifierType = obj;
      }
      return _defaultModifierType;
    }
  }

  public StatModifier DefaultModifier()
  {
    return new StatModifier(defaultModifierType, (float)getDefaultBasicValue);
  }
}
