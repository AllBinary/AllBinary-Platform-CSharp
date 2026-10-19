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
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.business.init;

public class InitInfo2
{
    private static readonly InitInfo2 instance = new InitInfo2();
    public static InitInfo2 getInstance()
    {
        return InitInfo2.instance;
    }

    private readonly Directory directory = Directory.getInstance();
    public virtual bool isTestHtmlPathValid(AbPath value)
    {
        return this.directory.create(value);
    }

    public virtual bool isMainPathValid(AbPath value)
    {
        return this.directory.create(value);
    }

}

