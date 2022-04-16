using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class GameState : ScriptableObject
{
  private static GameState instance;
  public static GameState Instance
  {
    get
    {
      if (instance == null)
      {
        var op = Addressables.LoadAssetAsync<GameState>("GameState");
        var obj = op.WaitForCompletion();
        Addressables.Release(op);
        if (obj == null)
        {
          throw new System.Exception("Could not find any singleton scriptable object instances in the reurce");
        }
        instance = obj;
      }
      return instance;
    }
  }
  private Dictionary<string, State> states;
  [Header("States")]
  public List<State> configStates;
  public List<State> permanentStates;
  public List<State> gameStates;

  [Header("Config")]

  public SaveSystem saveSystem;

  public State GetState(string state_id)
  {
    if (states.ContainsKey(state_id))
    {
      return states[state_id];
    }
    return null;
  }
  public object Get(string state_id, object query)
  {
    if (states == null)
    {
      init();
    }
    State state = GetState(state_id);
    if (state)
    {
      return state.Get(query);
    }
    return null;
  }

  public void Set(string state_id, object data)
  {
    if (states == null)
    {
      init();
    }
    State state = GetState(state_id);
    if (state)
    {
      state.Set(data);
    }
  }

  private void SaveData(List<State> stateList, string path)
  {
    List<RawSaveData> rawSaveData = new List<RawSaveData>();
    int len = stateList.Count;
    for (int i = 0; i < len; i++)
    {
      State state = stateList[i];
      rawSaveData.Add(new RawSaveData(state.id, state.Save()));
    }
    saveSystem.Save(rawSaveData, path);

  }

  public void SaveAll()
  {
    Save("config");
    Save("special");
    Save("player");
  }
  public void Save(string type)
  {
    if (states == null)
    {
      init();
    }
    switch (type)

    {
      case "config":
        {
          SaveData(configStates, "config");
          break;
        }
      case "permanent":
        {
          SaveData(permanentStates, "special");
          break;
        }
      case "player":
        {
          SaveData(gameStates, "player");
          break;
        }
      default: return;
    }
  }

  public void LoadAll()
  {
    Load("config");
    Load("permanent");
    Load("player");
  }

  public void Load(string path = "player")
  {
    if (states == null)
    {
      init();
    }
    List<RawSaveData> rawSaveData = (List<RawSaveData>)saveSystem.Load(path);
    if (rawSaveData == null)
    {
      return;
    }
    int len = rawSaveData.Count;
    for (int i = 0; i < len; i++)
    {
      RawSaveData rawData = rawSaveData[i];
      State state = GetState(rawData.id);
      if (state)
      {
        state.Load(rawData.rawData);
      }
    }
  }

  public void init()
  {
    states = new Dictionary<string, State>();
    int len = configStates.Count;
    for (int i = 0; i < len; i++)
    {
      states.Add(configStates[i].id, configStates[i]);
    }

    len = permanentStates.Count;
    for (int i = 0; i < len; i++)
    {
      states.Add(permanentStates[i].id, permanentStates[i]);
    }

    len = gameStates.Count;
    for (int i = 0; i < len; i++)
    {
      states.Add(gameStates[i].id, gameStates[i]);
    }
  }

  public void test()
  {
  }

  [Serializable]
  private struct RawSaveData
  {
    public string id;

    public object rawData;

    public RawSaveData(string _id, object _rawData)
    {
      id = _id;
      rawData = _rawData;
    }
  }
}
