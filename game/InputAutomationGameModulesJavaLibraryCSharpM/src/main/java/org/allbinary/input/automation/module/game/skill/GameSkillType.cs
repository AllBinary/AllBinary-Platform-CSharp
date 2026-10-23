/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.input.automation.module.game.skill;

public class GameSkillType
{
    public static GameSkillType MANA = new GameSkillType("Mana");
    public static GameSkillType REPLENISH = new GameSkillType("Replenish");
    public static GameSkillType TIMED = new GameSkillType("Timed");
    public static GameSkillType ATTACK = new GameSkillType("Attack");
    public static GameSkillType TRANSPORT = new GameSkillType("Transport");
    private readonly string SPELL_GAME_SKILL_TYPE = "SpellGameSkillType: ";
    private string name = null;
    private GameSkillType(string name)
    {
        this.setName(name);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return this.SPELL_GAME_SKILL_TYPE + this.getName();
    }

}

