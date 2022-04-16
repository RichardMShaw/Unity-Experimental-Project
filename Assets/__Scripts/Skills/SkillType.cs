using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Project/Skill Type")]
public class SkillType : ScriptableObject
{
  public new string name;
  [TextArea(3, 20)]
  public string description;

  public List<Attribute> restrictions;
}