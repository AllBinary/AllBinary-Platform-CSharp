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
using AdvertisementAreaData = org.allbinary.business.advertisement.area.AdvertisementAreaData;
using AdvertisementAreaInterface = org.allbinary.business.advertisement.area.AdvertisementAreaInterface;
using AdvertisementAreasEntityFactory = org.allbinary.data.tables.advertisement.areas.AdvertisementAreasEntityFactory;
using AdvertisementAreasEntityInterface = org.allbinary.data.tables.advertisement.areas.AdvertisementAreasEntityInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.advertisement.area;

public class AdvertisementAreaView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string advertisementAreaName;
    public AdvertisementAreaView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.advertisementAreaName = ((string) this.getPropertiesHashMap().get(AdvertisementAreaData.getInstance().NAME));
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            AdvertisementAreasEntityInterface advertisementAreasEntityInterface = AdvertisementAreasEntityFactory.getInstance();
            AdvertisementAreaInterface advertisementAreaInterface = advertisementAreasEntityInterface.get(this.getTransformInfoInterface().getStoreName(), this.advertisementAreaName);
            return null;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            throw e;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
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

