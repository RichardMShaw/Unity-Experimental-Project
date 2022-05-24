using System;

[Serializable]
public struct SkillSlot
{
  public Skill skill;

  public string Name
  {
    get { return skill.name; }
  }

  public SkillSlot(Skill _skill)
  {
    skill = _skill;
  }
  public SkillSlot(SkillSlot skillSlot)
  {
    skill = skillSlot.skill;
  }
}