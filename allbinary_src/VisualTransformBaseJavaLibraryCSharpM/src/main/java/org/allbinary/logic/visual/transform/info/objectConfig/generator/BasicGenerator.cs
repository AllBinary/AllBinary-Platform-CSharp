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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.visual.transform.info.objectConfig.generator;

public class BasicGenerator : TransformInfoObjectConfigGenerator
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public BasicGenerator()
    {
    }

    public override string process(string input)
    {
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Processing", this, this.commonStrings.PROCESS);
        }
        return input;
    }

}

