using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillQueue : ScriptableObject
{
  private bool running;

  public VoidEventChannel skillQueueCompleteChannel;
  private Queue<SkillQueueSlot> queue;

  private void CheckQueue(){
    if(queue == null){
      queue = new Queue<SkillQueueSlot>();
    }
  }

  public void Clear()
  {
    CheckQueue();
    queue.Clear();
  }
  public void Enqueue(SkillQueueSlot slot)
  {
    CheckQueue();
    queue.Enqueue(slot);
  }

  // public void Enqueue(BattleCharacter caster, BattleCharacter target, Skill skill){
  //   queue.Enqueue(new SkillQueueSlot(caster, target, skill));
  // }

  // public void Enqueue(BattleCharacter caster, BattleCharacter target, SkillSlot skillSlot){
  //   queue.Enqueue(new SkillQueueSlot(caster, target, skillSlot));
  // }

  public void Pause()
  {
    running = false;
  }

  public void Process()
  {
    CheckQueue();
    running = true;
    while (running && queue.Count > 0)
    {
      var slot = queue.Dequeue();
      slot.Cast();
    }
    skillQueueCompleteChannel.RaiseEvent();
  }

}

[Serializable]
public struct SkillQueueSlot
{
  public BattleCharacter caster;
  public BattleCharacter target;
#nullable enable
  public Skill? skill;
  public SkillSlot? skillSlot;
#nullable disable
  public SkillQueueSlot(BattleCharacter _caster, BattleCharacter _target, Skill _skill)
  {
    caster = _caster;
    target = _target;
    skill = _skill;
    skillSlot = null;
  }

  public SkillQueueSlot(BattleCharacter _caster, BattleCharacter _target, SkillSlot _skillSlot)
  {
    caster = _caster;
    target = _target;
    skill = null;
    skillSlot = _skillSlot;
  }

  public void Cast()
  {
    if (skillSlot != null)
    {
      skillSlot.Cast(caster, target);
    }
    else if (skill != null)
    {
      skill.Cast(caster, target);
    }
  }
}