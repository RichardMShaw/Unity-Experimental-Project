using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/State/Character")]
public class CharacterState : State
{
  public Flags values;

  public override object Get(object query)
  {
    return values.Get((string)query);
  }
  public override void Set(object data)
  {
    values.Set((Flag)data);
  }
  public override object Save()
  {
    return values.Save();
  }

  public override void Load(object data)
  {
    values.Load(data);
  }
}
