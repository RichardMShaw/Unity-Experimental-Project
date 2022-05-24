using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharacterTemplate : ScriptableObject
{
  public new string name;

  public SpriteData spriteData;

  [TextArea(3, 20)]
  public string description;

  public List<CharacterTemplateBasicStatAttribute> basicStats;
  public List<CharacterTemplateCoreStatAttribute> coreStats;
  public List<CharacterTemplateElementStatAttribute> elementStats;
}
[Serializable]
public struct CharacterTemplateBasicStatAttribute
{
  public BasicAttribute attribute;
  public int value;
  public int basicValue;
}
[Serializable]
public struct CharacterTemplateCoreStatAttribute
{
  public CoreAttribute attribute;
  public int value;
}
[Serializable]
public struct CharacterTemplateElementStatAttribute
{
  public Element element;
  public int power;
  public int weakness;
}
