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
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.business.context.modules.storefront.customizer.generic.page;

//implements DomNodeInterface
public class PageView : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PageView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    public override string view()
    {
        try {
            return base.view();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

