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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformGeneratorUtil = org.allbinary.logic.visual.transform.generator.TransformGeneratorUtil;
using TransformInfo = org.allbinary.logic.visual.transform.info.TransformInfo;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace views.business.context.modules.storefront.customizer;

public class StoreCustomizerComponentUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StoreCustomizerComponentUtil instance = new StoreCustomizerComponentUtil();
    public static StoreCustomizerComponentUtil getInstance()
    {
        return StoreCustomizerComponentUtil.instance;
    }

    private StoreCustomizerComponentUtil()
    {
    }

    // throws Exception
    public virtual string generate(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Generating Modified Views For: " + transformInfoInterface.getName(), this, "generateModifiedViews()");
        }
        CustomizerUtil customizerUtil = CustomizerUtil.getInstance();
        BasicArrayList allCustomizedViews = customizerUtil.getTransformInfoObjectConfigGroupComponentNodes(transformInfoInterface);
        int size = allCustomizedViews.size();
        for (int index = 0; index < size; index++) {
            TransformInfo nextTransformInfoInterface = ((TransformInfo) allCustomizedViews.get(index));
            BasicArrayList allViewsToBeModified = customizerUtil.getTransformInfoObjectConfigComponentNodesToCustomize(transformInfoInterface, nextTransformInfoInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("View or component that was modified by a Customizer: " + nextTransformInfoInterface.getName(), this, "generateModifiedViews()");
            }
            this.generate(abeClientInformation, transformInfoInterface, allViewsToBeModified);
        }
        return StringUtil.getInstance().EMPTY_STRING;
    }

    // throws Exception
    private void generate(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, BasicArrayList allViewsToBeModifiedVector)
    {
        CustomizerUtil customizerUtil = CustomizerUtil.getInstance();
        int size = allViewsToBeModifiedVector.size();
        for (int index = 0; index < size; index++) {
            TransformInfo nextTransformInfoInterface = ((TransformInfo) allViewsToBeModifiedVector.get(index));
            TransformInfoInterface specifiedTransformInfoInterface = customizerUtil.getTransformInfoInterfaceToCustomize(transformInfoInterface, nextTransformInfoInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Retrieved: " + specifiedTransformInfoInterface.getName(), this, "generateModifiedViews()");
            }
            TransformGeneratorUtil.getInstance().generate(abeClientInformation, nextTransformInfoInterface, specifiedTransformInfoInterface);
        }
    }

}

