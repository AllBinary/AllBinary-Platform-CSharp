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

public class J2MEGameKey : Input
{
    public J2MEGameKey(int key, string keyName) : base(key, keyName)
    {
        // base(key, keyName) is called from the constructor declaration
        int id = this.getId();
        if (id >= 0) {
            InputFactory inputFactory = InputFactory.getInstance();
            inputFactory.add(id, this);
        }
    }

    public override string ToString()
    {
        return new StringMaker().append("J2MEGameKey: ").append(base.ToString()).ToString();
    }

    public static string getString(int keyCode)
    {
        Input input = InputFactory.getInstance().getInstanceById(keyCode);
        if (input != null) {
            return input.getName();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

}

