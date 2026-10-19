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
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformInfoDomNode = org.allbinary.logic.visual.transform.info.TransformInfoDomNode;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using StoreFileGenerator = org.allbinary.logic.visual.transform.info.objectConfig.generator.StoreFileGenerator;

namespace org.allbinary.logic.visual.transform.generator;

public class TransformGeneratorUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformGeneratorUtil instance = new TransformGeneratorUtil();
    public static TransformGeneratorUtil getInstance()
    {
        return TransformGeneratorUtil.instance;
    }

    private TransformGeneratorUtil()
    {
    }

    // throws Exception
    public virtual void generate(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, TransformInfoInterface ownerTransformInfoInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Generating View: " + transformInfoInterface.getName(), this, "generate()");
            }
            TransformInterface componentInterface = TransformFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface.getName(), ownerTransformInfoInterface);
            string result = componentInterface.view();
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) componentInterface.getTransformInfoInterface());
            InputOutputTypeData inputOutputTypeData = InputOutputTypeData.getInstance();
            if (result.IndexOf("<HTML>") >= 0) {
                httpTransformInfoInterface.getPropertiesHashMap().put(inputOutputTypeData.NAME, inputOutputTypeData.DEFAULT);
            } else {
                httpTransformInfoInterface.getPropertiesHashMap().put(inputOutputTypeData.NAME, inputOutputTypeData.DEFAULT_FRAGMENT);
            }
            new StoreFileGenerator(componentInterface.getTransformInfoInterface()).process(result);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate a view", this, "generate()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual void generate(AbeClientInformationInterface abeClientInformation, TransformInfoDomNode transformInfoDomNode, TransformInfoInterface ownerTransformInfoInterface)
    {
        this.generate(abeClientInformation, transformInfoDomNode.getTransformInfoInterface(), ownerTransformInfoInterface);
    }

}

