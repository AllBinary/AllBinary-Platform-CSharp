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
using TransformInfoFactoryInterface = org.allbinary.logic.visual.transform.info.TransformInfoFactoryInterface;
using TransformInfoObjectConfigAndManipulatorFactoryBase = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactoryBase;
using TransformInfoObjectConfigGeneratorFactoryInterface = org.allbinary.logic.visual.transform.info.objectConfig.generator.TransformInfoObjectConfigGeneratorFactoryInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.tables.transform.info;

public class TransformInfoEntityFactory
{
    private TransformInfoEntityFactory()
    {
    }

    public static TransformInfoEntity getInstance(TransformInfoObjectConfigGeneratorFactoryInterface transformInfoObjectConfigGeneratorFactoryInterface, TransformInfoObjectConfigAndManipulatorFactoryBase transformInfoObjectConfigAndManipulatorFactoryInterface, TransformInfoFactoryInterface transformInfoFactoryInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return new TransformInfoEntity(transformInfoObjectConfigGeneratorFactoryInterface, transformInfoObjectConfigAndManipulatorFactoryInterface, transformInfoFactoryInterface);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                logUtil.put(commonStrings.EXCEPTION, "TransformInfoEntityFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

