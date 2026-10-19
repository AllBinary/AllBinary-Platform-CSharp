/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.io.file;

public class FileUnamedUtil
{
    private static readonly FileUnamedUtil instance = new FileUnamedUtil();
    public static FileUnamedUtil getInstance()
    {
        return FileUnamedUtil.instance;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public virtual string process(string @string)
    {
        string simplifiedString = @string.ToLower();
        simplifiedString = simplifiedString.Replace(this.commonSeps.SPACE, this.commonSeps.UNDERSCORE);
        simplifiedString = simplifiedString.Replace(this.commonSeps.DASH, this.commonSeps.UNDERSCORE);
        return simplifiedString;
    }

}

