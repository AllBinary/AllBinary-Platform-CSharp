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

namespace org.allbinary.logic.io;

public class AbIOSystem
{
    private static readonly AbIOSystem instance = new AbIOSystem();
    public static AbIOSystem getInstance()
    {
        return AbIOSystem.instance;
    }

    private readonly string type = "java.io";
    public virtual string getType()
    {
        return this.type;
    }

    public virtual bool isType(string type)
    {
        if (string.CompareOrdinal(this.type, type) == 0) {
            return true;
        } else {
            return false;
        }
    }

}

