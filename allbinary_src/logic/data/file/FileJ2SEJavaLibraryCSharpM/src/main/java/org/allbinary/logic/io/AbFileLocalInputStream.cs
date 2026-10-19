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
//using FileNotFoundException = java.io.FileNotFoundException;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;

namespace org.allbinary.logic.io;

public class AbFileLocalInputStream : AbFileInputStream
{
    public AbFileLocalInputStream(AbFile file) : base(AbFileNativeUtil.get(file))
    {
        // base(AbFileNativeUtil.get(file)) is called from the constructor declaration
    }

}

