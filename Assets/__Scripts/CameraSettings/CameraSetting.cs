using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Camera Setting")]
public class CameraSetting : ScriptableObject
{
  public CameraPosition transform;
}

[Serializable]
public struct CameraPosition
{
  public Vector3 position;
  public Vector3 rotation;
}