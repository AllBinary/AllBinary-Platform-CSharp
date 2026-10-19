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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoDomNode = org.allbinary.logic.visual.transform.info.TransformInfoDomNode;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;

namespace org.allbinary.logic.visual.transform.generator;

public class TransformsGeneratorUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformsGeneratorUtil instance = new TransformsGeneratorUtil();
    public static TransformsGeneratorUtil getInstance()
    {
        return TransformsGeneratorUtil.instance;
    }

    private TransformsGeneratorUtil()
    {
    }

    // throws Exception
    public virtual string generateComponentsFromObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, string group)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Started Group: " + group, this, "generateComponentsFromObjectConfig(2)");
        }
        TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = transformInfoInterface.getObjectConfigInterface();
        string result = this.generateComponentsFromObjectConfig(abeClientInformation, transformInfoObjectConfigInterface, transformInfoInterface, group);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("End Group: " + group, this, "generateComponentsFromObjectConfig(2)");
        }
        return result;
    }

    // throws Exception
    public virtual string generateComponentsFromObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoObjectConfigInterface transformInfoObjectConfigInterface, TransformInfoInterface transformInfoInterface, string group)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Started Group: " + group, this, "generateComponentsFromObjectConfig()");
        }
        BasicArrayList transformInfoObjectConfigComponentVector = transformInfoObjectConfigInterface.getTransformsGroup(group);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Processing ");
            stringBuffer.appendint(transformInfoObjectConfigComponentVector.size());
            stringBuffer.append(" Components Group: ");
            stringBuffer.append(group);
            this.logUtil.putF(stringBuffer.ToString(), this, "generateComponentsFromObjectConfig()");
        }
        if (transformInfoObjectConfigComponentVector.size() < 1) {
            throw new Exception("No Pages Generated For Template.");
        }
        int size = transformInfoObjectConfigComponentVector.size();
        for (int index = 0; index < size; index++) {
            TransformInfoDomNode transformInfoObjectConfigComponent = ((TransformInfoDomNode) transformInfoObjectConfigComponentVector.get(index));
            TransformGeneratorUtil.getInstance().generate(abeClientInformation, transformInfoObjectConfigComponent, transformInfoInterface);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Done Group: " + group, this, "generateComponentsFromObjectConfig()");
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("<!-- Generated all template views successfully for View: ");
        stringBuffer.append(transformInfoInterface.getName());
        stringBuffer.append("-->");
        return stringBuffer.ToString();
    }

}

