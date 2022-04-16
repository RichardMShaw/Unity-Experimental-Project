using System;
using System.Collections.Generic;
using UnityEngine;

public class State : ScriptableObject
{

  public string id;
  public virtual object Get(object query)
  {
    return null;
  }
  public virtual void Set(object data)
  {
  }

  public virtual object Save()
  {
    return null;
  }

  public virtual void Load(object data)
  {

  }
}
