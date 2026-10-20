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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using HttpServletResponse = javax.servlet.http.HttpServletResponse;
//using PageContext = javax.servlet.jsp.PageContext;
using TagHelper = admin.taghelpers.TagHelper;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using AcceptableResponseGenerator = org.allbinary.logic.communication.http.AcceptableResponseGenerator;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchParams = org.allbinary.logic.control.search.SearchParams;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using InventoryViewFactory = views.admin.inventory.listings.InventoryViewFactory;
using InventoryViewSearchInterface = views.admin.inventory.listings.InventoryViewSearchInterface;

namespace taghelpers;

public class InventoryHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private WeblisketSession weblisketSession = null;
    private HttpServletResponse response;
    private HttpServletRequest request;
    private StreetAddress streetAddress = null;
    private string id = null;
    private SearchRequest searchRequest = null;
    public InventoryHelper(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        this.response = ((HttpServletResponse) pageContext.getResponse());
        this.request = ((HttpServletRequest) pageContext.getRequest());
        string storeName = ((string) propertiesHashMap.get(StoreFrontData.getInstance().NAME));
        string xslFile = ((string) propertiesHashMap.get(TransformInfoData.getInstance().TEMPLATEFILENAME));
        if (storeName != null) {
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(storeName);
            string contentType = AcceptableResponseGenerator.getInstance().get(this.request);
            SearchParams searchParams = new SearchParams(this.request);
            this.searchRequest = new SearchRequest(storeFrontInterface, searchParams, xslFile, contentType, propertiesHashMap, pageContext);
        }
        this.getFormData();
    }

    private void getFormData()
    {
        this.id = this.request.getParameter(basicItemData.ID);
    }

    public virtual string viewSummary()
    {
        try {
            InventoryViewSearchInterface inventoryViewSearchInterface = InventoryViewFactory.getInstance(this.searchRequest);
            string result = inventoryViewSearchInterface.getProduct(this.id);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfull Inventory View Summary", this, "viewSummary()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to View Summary";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewSummary()", e);
            }
            return error + "<br>" + "Exception: " + e + "<br>";
        }
    }

    public virtual string search()
    {
        try {
            StringUtil stringUtil = StringUtil.getInstance();
            string keywords = ((string) this.searchRequest.getParams().get().get(basicItemData.KEYWORDS));
            if (keywords == null || string.CompareOrdinal(keywords, stringUtil.EMPTY_STRING) == 0) {
                return "Please enter a keyword in the search field above the Search button.";
            }
            InventoryViewSearchInterface inventoryViewSearchInterface = InventoryViewFactory.getInstance(this.searchRequest);
            string result = inventoryViewSearchInterface.searchSingleDynamicPage();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successful Inventory Dynamic Search", this, "searchSingleDynamicPage()");
            }
            return result;
        } catch (Exception e) {
            string error = "Failed to search Inventory by keyword";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "searchSingleDynamicPage()", e);
            }
            return error + "<br>" + "Exception: " + e + "<br>";
        }
    }

}

