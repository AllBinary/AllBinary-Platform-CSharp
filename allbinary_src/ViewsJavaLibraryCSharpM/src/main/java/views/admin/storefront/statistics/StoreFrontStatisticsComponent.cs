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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using RealTimeStoreFrontStatistics = org.allbinary.business.context.modules.storefront.statistics.RealTimeStoreFrontStatistics;
using RealTimeStoreFrontStatisticsView = org.allbinary.business.context.modules.storefront.statistics.RealTimeStoreFrontStatisticsView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.storefront.statistics;

public class StoreFrontStatisticsComponent : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public StoreFrontInterface newStoreFrontInterface;
    private DomNodeInterface domNodeInterface;
    public StoreFrontStatisticsComponent(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.newStoreFrontInterface = ((StoreFrontInterface) StoreFrontFactory.getInstance(transformInfoInterface.getStoreName()));
        this.domNodeInterface = new RealTimeStoreFrontStatisticsView(new RealTimeStoreFrontStatistics(this.newStoreFrontInterface), this.getWeblisketSession().getRole());
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this.domNodeInterface));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

