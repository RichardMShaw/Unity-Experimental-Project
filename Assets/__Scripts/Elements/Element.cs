using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Element")]
public class Element : ScriptableObject
{
  public new string name;

  [TextArea(3, 20)]
  public string description;

  public ElementAttribute powerAttribute;

  public ElementAttribute weaknessAttribute;
}