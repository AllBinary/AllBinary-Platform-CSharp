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
using InputOutputTypeData = org.allbinary.logic.io.InputOutputTypeData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info.objectConfig.generator;

public class TransformInfoObjectConfigGeneratorFactory : TransformInfoObjectConfigGeneratorFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformInfoObjectConfigGeneratorFactory instance = new TransformInfoObjectConfigGeneratorFactory();
    public static TransformInfoObjectConfigGeneratorFactory getInstance()
    {
        return TransformInfoObjectConfigGeneratorFactory.instance;
    }

    private TransformInfoObjectConfigGeneratorFactory()
    {
    }

    // throws Exception
    public virtual TransformInfoObjectConfigGenerator getInstance(TransformInfoInterface transformInfoInterface)
    {
        string type = ((string) transformInfoInterface.getObjectConfigInterface().getOutputTypeName());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF("Generating Instance for type: " + type, this, commonStrings.GET_INSTANCE);
        }
        if (type == null || string.CompareOrdinal(type, InputOutputTypeData.getInstance().RESPONSE) == 0 || transformInfoInterface.isChild()) {
            return new BasicGenerator();
        } else if (string.CompareOrdinal(type, InputOutputTypeData.getInstance().FILE) == 0) {
            return new StoreFileGenerator(transformInfoInterface);
        } else {
            throw new Exception("No Such TransformInfoObjectConfigGenerator Type");
        }
    }

}

