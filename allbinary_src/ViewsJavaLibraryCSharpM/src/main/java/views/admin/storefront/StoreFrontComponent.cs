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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.admin.storefront;

public class StoreFrontComponent : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public StoreFrontInterface newStoreFrontInterface;
    public StoreFrontComponent(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
        this.newStoreFrontInterface = ((StoreFrontInterface) new StoreFront(((HttpServletRequest) this.getPageContext().getRequest())));
        if (this.newStoreFrontInterface.getName() == null) {
            this.newStoreFrontInterface.setName(this.getWeblisketSession().getStoreName());
        }
    }

    // throws Exception
    public override string view()
    {
        try {
            return base.view();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view", e);
            }
            throw e;
        }
    }

}

