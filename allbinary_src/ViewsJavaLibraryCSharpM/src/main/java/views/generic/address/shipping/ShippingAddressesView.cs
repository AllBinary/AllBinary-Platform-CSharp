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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.address.shipping;

public class ShippingAddressesView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HttpServletRequest request;
    public BasicArrayList streetAddressList = null;
    public ShippingAddressesView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
        this.request = ((HttpServletRequest) httpTransformInfoInterface.getPageContext().getRequest());
    }

    protected virtual HttpServletRequest getRequest()
    {
        return this.request;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            Node billingAddressesNode = document.createElement(ShippingAddressData.MULTIPLE);
            int size = this.streetAddressList.size();
            for (int index = 0; index < size; index++) {
                StreetAddress streetAddress = ((StreetAddress) this.streetAddressList.get(index));
                billingAddressesNode.appendChild(streetAddress.toXmlNode(document));
            }
            billingAddressesNode.appendChild(ModDomHelper.createNameValueNodes(document, StreetAddressData.NUMBEROFADDRESSES, streetAddressList.size().ToString()));
            return billingAddressesNode;
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

