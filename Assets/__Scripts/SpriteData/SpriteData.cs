using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Sprite Data")]
public class SpriteData : ScriptableObject
{
  public Sprite sprite;

  public SpriteTransform transfrom;
}

[Serializable]
public struct SpriteTransform
{
  public Vector3 position;
  public Quaternion rotation;
  public Vector3 scale;
}
