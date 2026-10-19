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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.identification;

public class Group : GroupInterface
{
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private readonly short teamId;
    private string @string = StringUtil.getInstance().EMPTY_STRING;
    public Group(string teamName, short teamId)
    {
        this.teamId = teamId;
        this.setName(teamName);
    }

    public virtual string getGroupName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
        GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(groupCommonFactory.GROUP_NAME_LABEL);
        stringBuffer.append(this.name);
        stringBuffer.append(groupCommonFactory.ID_LABEL);
        stringBuffer.appendshort(this.teamId);
        this.@string = stringBuffer.ToString();
    }

    public virtual short getGroupId()
    {
        return this.teamId;
    }

    public override string ToString()
    {
        return this.@string;
    }

}

