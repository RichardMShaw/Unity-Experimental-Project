using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Modifier")]
public class Modifier : ScriptableObject
{
  public string type;
  [TextArea(3, 20)]
  public string comment;
  [TextArea(3, 20)]
  public string description;
}
