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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using StaticPagesEntity = org.allbinary.data.tables.staticpages.StaticPagesEntity;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchParams = org.allbinary.logic.control.search.SearchParams;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using InputOutputTypeData = org.allbinary.logic.io.InputOutputTypeData;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using InventoryViewSearchInterface = views.admin.inventory.listings.InventoryViewSearchInterface;

namespace views.generic.inventory;

public class InventorySearch : InventoryViewSearchInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly SearchRequest searchRequest;
    public InventorySearch(SearchRequest searchRequest) : base()
    {
        // base() is called from the constructor declaration
        this.searchRequest = searchRequest;
    }

    // throws Exception
    public virtual string searchSingleStaticPage()
    {
        try {
            StoreFrontInterface storeFront = this.searchRequest.getStoreFront();
            SearchParams searchParams = this.searchRequest.getParams();
            HashMap columnValueHashMap = searchParams.get();
            string file = new StaticPagesEntity().getFile(storeFront.getName(), new Replace("-", CommonSeps.getInstance().SPACE).all(((string) columnValueHashMap.get(basicItemData.KEYWORDS))));
            if (StringValidationUtil.getInstance().isEmpty(file)) {
                return null;
            } else {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append(storeFront.getCurrentHostName());
                stringBuffer.append(storeFront.getCurrentHostNamePath());
                stringBuffer.append(storeFront.getStaticPath());
                stringBuffer.append(file);
                stringBuffer.append(this.searchRequest.getParams().getEndPage());
                stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
                stringBuffer.append(InputOutputTypeData.getInstance().DEFAULT);
                string filePath = new Replace(CommonSeps.getInstance().SPACE, "%20").all(stringBuffer.ToString());
                return filePath;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "searchSingleStaticPage", e);
            }
            throw new Exception("Failed retrieve Single Product Page Static");
        }
    }

    // throws Exception
    public virtual string searchSingleDynamicPage()
    {
        try {
            string[] str = this.search();
            return str[((int) this.searchRequest.getParams().getStartPageInt())];
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "searchSingleDynamicPage", e);
            }
            throw new Exception("Failed retrieve Single Product Page Dynamically");
        }
    }

    // throws Exception
    public virtual string[] search()
    {
        AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
        InventorySearchUtil inventorySearchUtil = InventorySearchUtil.getInstance();
        BasicArrayList vector = inventorySearchUtil.getBasicItemIdColumn(this.searchRequest);
        return inventorySearchUtil.search(abeClientInformation, searchRequest, vector);
    }

    // throws Exception
    public virtual string getProduct(string product)
    {
        AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
        return InventorySearchProductUtil.getInstance().getProduct(abeClientInformation, this.searchRequest, product);
    }

}

