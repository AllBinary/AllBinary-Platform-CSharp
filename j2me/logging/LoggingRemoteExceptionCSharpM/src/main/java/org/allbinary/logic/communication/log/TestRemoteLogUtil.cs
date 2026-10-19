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
using Globals = org.allbinary.globals.Globals;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.log;

public class TestRemoteLogUtil
{
    public static readonly string PATH = "G:\\mnt\\bc\\mydev\\work\\allbinary_src\\licensing\\data\\";
    public TestRemoteLogUtil()
    {
        Globals.getInstance().init(this.GetType().getClassLoader(), TestRemoteLogUtil.PATH);
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.put(commonStrings.EXCEPTION, "Test", "TestClass", new Exception("Pretend Exception"));
    }

    // throws Exception
    public static void main(string[] args)
    {
        new TestRemoteLogUtil();
    }

}

