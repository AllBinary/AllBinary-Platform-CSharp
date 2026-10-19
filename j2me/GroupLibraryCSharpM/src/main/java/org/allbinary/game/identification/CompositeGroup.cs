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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.identification;

public class CompositeGroup
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Group groupInterface;
    private readonly BasicArrayList list = new BasicArrayListD();
    public CompositeGroup(Group groupInterface)
    {
        this.groupInterface = groupInterface;
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public virtual void add(Group groupInterface)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(groupCommonFactory.ADDING_LABEL);
        stringBuffer.append(groupInterface.ToString());
        stringBuffer.append(groupCommonFactory.TO_LABEL);
        stringBuffer.append(StringUtil.getInstance().toString(this.groupInterface));
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.ADD);
        this.list.add(groupInterface);
    }

    public virtual bool isInGroup(Group groupInterface)
    {
        if (this.list.contains(groupInterface)) {
            return true;
        } else {
            return false;
        }
    }

    public virtual Group getGroup()
    {
        return this.groupInterface;
    }

}

