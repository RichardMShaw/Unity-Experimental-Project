using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveTemplate : ScriptableObject
{
  public PassiveType type;

  public PassiveStatAttributes stats;

  public List<PassiveEvents> events;
}

public struct PassiveEvents {
  public SkillEvent skillEvent;

  public List<Skill> skills;
}

