using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

//Attributes such as Health
[CreateAssetMenu(menuName = "Project/Attributes/Basic Attribute")]
public class BasicAttribute : Attribute
{
  private static BasicAttribute health;
  public static BasicAttribute Health
  {
    get
    {
      if (energy == null)
      {
        var op = Addressables.LoadAssetAsync<BasicAttribute>("HealthAttribute");
        var obj = op.WaitForCompletion();
        Addressables.Release(op);
        if (obj == null)
        {
          throw new System.Exception("Could not find any singleton scriptable object instances in the reurce");
        }
        energy = obj;
      }
      return health;
    }
  }
  private static BasicAttribute energy;
  public static BasicAttribute Energy
  {
    get
    {
      if (energy == null)
      {
        var op = Addressables.LoadAssetAsync<BasicAttribute>("EnergyAttribute");
        var obj = op.WaitForCompletion();
        Addressables.Release(op);
        if (obj == null)
        {
          throw new System.Exception("Could not find any singleton scriptable object instances in the reurce");
        }
        energy = obj;
      }
      return energy;
    }
  }
  public int defaultBasicValue;
  public override int getDefaultBasicValue {
    get {
      return defaultBasicValue;
    }
  }
}
