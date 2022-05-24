using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Characters/Parties/Heroes")]
public class HeroParty : ScriptableObject
{
  public List<HeroPartySlot> heroes;

}

[Serializable]
public struct HeroPartySlot
{
  public HeroTemplate template;

  public List<HeroPartySlotBasicStat> stats;
  public List<SkillSlot> skillSlots;
}

[Serializable]
public struct HeroPartySlotBasicStat
{
  public BasicAttribute attribute;
  public int basicValue;
}
