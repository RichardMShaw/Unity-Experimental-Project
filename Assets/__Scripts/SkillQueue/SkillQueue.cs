using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillQueue : ScriptableObject
{
  public Queue<SkillQueueSlot> queue;

  public void Enqueue(BattleCharacter caster, BattleCharacter target, Skill skill){
    queue.Enqueue(new SkillQueueSlot(caster, target, skill));
  }

  public void Enqueue(BattleCharacter caster, BattleCharacter target, SkillSlot skillSlot){
    queue.Enqueue(new SkillQueueSlot(caster, target, skillSlot));
  }

  
}

[Serializable]
public struct SkillQueueSlot {
  public BattleCharacter caster;
  public BattleCharacter target;
  public Skill? skill;
  public SkillSlot? skillSlot;
  public SkillQueueSlot(BattleCharacter _caster, BattleCharacter _target, Skill _skill){
    caster = _caster;
    target = _target;
    skill = _skill;
    skillSlot = null;
  }

  public SkillQueueSlot(BattleCharacter _caster, BattleCharacter _target, SkillSlot _skillSlot){
    caster = _caster;
    target = _target;
    skill = null;
    skillSlot = _skillSlot;
  }
}