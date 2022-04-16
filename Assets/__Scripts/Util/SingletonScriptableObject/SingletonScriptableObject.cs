using UnityEngine;

public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
{
  private static T instance;
  public virtual string path
  {
    get
    {
      return null;
    }
  }
  public static T Instance
  {
    get
    {
      if (instance == null)
      {
        T[] assets = Resources.LoadAll<T>("");
        if (assets == null || assets.Length < 1)
        {
          throw new System.Exception("Could not find any singleton scriptable object instances in the resource");
        }
        instance = assets[0];
      }
      return instance;
    }
  }
}