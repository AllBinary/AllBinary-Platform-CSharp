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

namespace views.admin.storefront;

public class StoreFrontComponent : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public StoreFrontInterface newStoreFrontInterface;
    public StoreFrontComponent(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.newStoreFrontInterface = ((StoreFrontInterface) new StoreFront(((HttpServletRequest) this.getPageContext().getRequest())));
        if (this.newStoreFrontInterface.getName() == null) {
            this.newStoreFrontInterface.setName(this.getWeblisketSession().getStoreName());
        }
    }

    // throws Exception
    public virtual string view()
    {
        try {
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view", e);
            }
            throw e;
        }
    }

}

