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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.input.automation.module.game.skill;

public class GameSkill
{
    private static HashMap hashMap = StdUtil.getInstance().createHashMap();
    private GameSkillType gameSkillType = null;
    private string extra = null;
    private int time = 0;
    private BasicArrayList vector;
    private readonly string GAME_SKILL_LABEL = "GameSkill: ";
    private readonly string EXTRA_LABEL = "Extra: ";
    private readonly string TIME_LABEL = "Time: ";
    public GameSkill(GameSkillType gameSkillType, string extra, int time)
    {
        this.setGameSkillType(gameSkillType);
        this.setExtra(extra);
        this.setTime(time);
        this.vector = new BasicArrayListD();
        GameSkill.hashMap.put(new StringMaker().append(this.getGameSkillType().getName()).append(CommonSeps.getInstance().SPACE).append(extra).ToString(), this);
    }

    public virtual GameSkillType getGameSkillType()
    {
        return this.gameSkillType;
    }

    public virtual void setGameSkillType(GameSkillType gameSkillType)
    {
        this.gameSkillType = gameSkillType;
    }

    public virtual string getExtra()
    {
        return this.extra;
    }

    public virtual void setExtra(string extra)
    {
        this.extra = extra;
    }

    public virtual int getTime()
    {
        return this.time;
    }

    public virtual void setTime(int time)
    {
        this.time = time;
    }

    public virtual void addProperty(GameSkillPropertyInterface gameSkillPropertyInterface)
    {
        this.vector.add(gameSkillPropertyInterface);
    }

    public virtual BasicArrayList getProperties()
    {
        return this.vector;
    }

    public static GameSkill getInstance(GameSkillType gameSkillType, string extra)
    {
        return ((GameSkill) GameSkill.hashMap.get(new StringMaker().append(gameSkillType.getName()).append(CommonSeps.getInstance().SPACE).append(extra).ToString()));
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GAME_SKILL_LABEL);
        stringBuffer.append(this.getGameSkillType().ToString());
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(this.EXTRA_LABEL);
        stringBuffer.append(this.getExtra());
        stringBuffer.append(commonSeps.SPACE);
        stringBuffer.append(this.TIME_LABEL);
        stringBuffer.appendlong(((long) this.getTime()));
        return stringBuffer.ToString();
    }

}

