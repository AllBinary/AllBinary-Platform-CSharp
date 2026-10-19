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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontViewFactory = org.allbinary.business.context.modules.storefront.StoreFrontViewFactory;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;

namespace org.allbinary.logic.visual.transform.data;

public class TransformStoreDocument : TransformHttpRequestDocument
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TransformStoreDocument(PageContext pageContext, WeblisketSession weblisketSession) : base(pageContext, weblisketSession)
    {
        // base(pageContext, weblisketSession) is called from the constructor declaration
        try {
            string storeName = weblisketSession.getStoreName();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Using Session StoreName: " + storeName, this, this.commonStrings.CONSTRUCTOR);
            }
            this.getBaseNode().appendChild(StoreFrontViewFactory.getInstance(storeName).toXmlNode(this.getDoc()));
            this.getBaseNode().appendChild(new RequestParams(((HttpServletRequest) pageContext.getRequest())).toXmlNode(this.getDoc()));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

    public TransformStoreDocument(SearchRequest searchRequest) : base(searchRequest)
    {
        // base(searchRequest) is called from the constructor declaration
        try {
            this.getBaseNode().appendChild(StoreFrontViewFactory.getInstance(searchRequest.getStoreFront().getName()).toXmlNode(this.getDoc()));
            this.getBaseNode().appendChild(searchRequest.getParams().getParamsNode(this.getDoc()));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

}

