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

namespace org.allbinary.game.input;

public class Input
{
    private int id = 0;
    private string name = StringUtil.getInstance().EMPTY_STRING;
    public Input(int id, string name)
    {
        this.setId(id);
        this.setName(name);
    }

    public virtual int getId()
    {
        return this.id;
    }

    private void setId(int key)
    {
        this.id = key;
    }

    public virtual string getName()
    {
        return this.name;
    }

    private void setName(string keyName)
    {
        this.name = keyName;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Name: ");
        stringBuffer.append(this.getName());
        stringBuffer.append(" Id: ");
        stringBuffer.appendint(this.getId());
        return stringBuffer.ToString();
    }

}

