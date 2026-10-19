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
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace views.business.context.modules.storefront.generator;

public class PreviewGeneratorStoreFrontContextView : GeneratorStoreFrontContextView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PreviewGeneratorStoreFrontContextView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual string view()
    {
        try {
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
            httpTransformInfoInterface.getPropertiesHashMap().put(TransformInfoData.getInstance().PARTIAL, CommonSeps.getInstance().SPACE + TransformInfosData.getInstance().PREVIEW);
            return this.view(TransformInfosData.getInstance().PREVIEW);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

