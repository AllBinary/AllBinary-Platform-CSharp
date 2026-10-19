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
using Init = org.allbinary.init.Init;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.input;

public class KeyFactoryInitializer : Init
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public override void init()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.INIT);
    }

}

