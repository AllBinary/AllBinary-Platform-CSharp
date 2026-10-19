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
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.generator;

public class QuoteRequestIdGenerator : UniqueIdGenerator
{
    private readonly string IDFILE = "quoterequestId";
    public QuoteRequestIdGenerator()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(PATH_GLOBALS.getInstance().INIT_PATH);
        stringBuffer.append(this.IDFILE);
        stringBuffer.append(UniqueIdGenerator.EXT);
        base.setFile(stringBuffer.ToString(), this.IDFILE);
    }

}

