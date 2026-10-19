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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using QuoteRequest = org.allbinary.business.user.quoterequest.QuoteRequest;
using QuoteRequestEntityFactory = org.allbinary.data.tables.user.quoterequest.QuoteRequestEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

//TWB - Am I missing the correct Quote Request? Probably not
public class QuoteRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private StoreFrontInterface storeFrontInterface = null;
    private QuoteRequest quoteRequest;
    public QuoteRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        HttpServletRequest request = ((HttpServletRequest) pageContext.getRequest());
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.quoteRequest = new QuoteRequest(this.weblisketSession.getUserName(), request);
        string storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        }
    }

    public virtual bool? isValid()
    {
        return this.quoteRequest.isValid();
    }

    public virtual string validationInfo()
    {
        return this.quoteRequest.validationInfo();
    }

    public virtual string insert()
    {
        try {
            BasicArrayList values = this.quoteRequest.toVector();
            QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance().insert(values);
            string success = "New QuoteRequest Successfully added to the QuoteRequest Table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "add()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add QuoteRequest";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "add()", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            HashMap values = this.quoteRequest.toHashMap();
            QuoteRequestEntityFactory.getInstance().getQuoteRequestEntityInstance().update(this.quoteRequest.getUserName(), values);
            string success = "New QuoteRequest Successfully updated";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update QuoteRequest";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        return commonStrings.NOT_IMPLEMENTED;
    }

}

