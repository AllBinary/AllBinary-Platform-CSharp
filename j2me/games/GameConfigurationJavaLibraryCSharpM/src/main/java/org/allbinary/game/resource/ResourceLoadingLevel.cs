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

namespace org.allbinary.game.resource;

public class ResourceLoadingLevel
{
    private readonly string name;
    private readonly int level;
    public ResourceLoadingLevel(string name, int level)
    {
        this.name = name;
        this.level = level;
    }

    public virtual int getLevel()
    {
        return this.level;
    }

    public virtual string getName()
    {
        return this.name;
    }

}

