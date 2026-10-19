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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.identification;

public class GroupFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static GroupFactory instance = new GroupFactory();
    public static GroupFactory getInstance()
    {
        return GroupFactory.instance;
    }

    public readonly Group[] NULL_GROUP_ARRAY = new Group[0];
    private readonly BasicArrayList list = new BasicArrayListD();
    private int index = 0;
    public virtual Group getNextGroup()
    {
        Group group = ((Group) this.list.objectArray[this.index]);
        this.index++;
        return group;
    }

    public virtual Group getNextGroupByName(string name)
    {
        Group group = this.getNextGroup();
        group.setName(name);
        return group;
    }

    public virtual void init(short groups, string[] nameArray)
    {
        StringMaker stringMaker = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        string TEAM = "Team ";
        this.list.clear();
        this.index = 0;
        int size = this.list.size();
        while (size < ((int) groups)) {
            string name = stringUtil.EMPTY_STRING;
            if (size < nameArray.Length) {
                name = nameArray[size];
            } else {
                stringMaker.delete(0, stringMaker.length());
                name = stringMaker.append(TEAM).appendint(size).ToString();
            }
            this.list.add(new Group(name, ((short) (size + 3))));
            size++;
        }
    }

}

