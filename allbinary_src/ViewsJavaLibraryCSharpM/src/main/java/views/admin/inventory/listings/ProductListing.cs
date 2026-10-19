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
//using HashSet = java.util.HashSet;
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using StoreFrontsEntity = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntity;
using StaticPagesEntity = org.allbinary.data.tables.staticpages.StaticPagesEntity;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchParams = org.allbinary.logic.control.search.SearchParams;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using InputOutputTypeData = org.allbinary.logic.io.InputOutputTypeData;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using SpecialCharacterUtil = org.allbinary.logic.@string.SpecialCharacterUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using UniqueTokens = org.allbinary.logic.@string.tokens.UniqueTokens;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using InventoryColumnUtil = views.generic.inventory.InventoryColumnUtil;
using InventorySearchUtil = views.generic.inventory.InventorySearchUtil;

namespace views.admin.inventory.listings;

public class ProductListing : ProductListingInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Directory directory = Directory.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly StoreFrontsEntity storeFronts;
    private readonly StaticPagesEntity staticPages;
    private readonly InventoryEntity inventory;
    private readonly SearchRequest searchRequest;
    private readonly string INVENTORY = ".InventoryView";
    public ProductListing(SearchRequest searchRequest)
    {
        this.searchRequest = searchRequest;
        this.storeFronts = new StoreFrontsEntity();
        this.staticPages = new StaticPagesEntity();
        this.inventory = new InventoryEntity();
    }

    // throws Exception
    private HashSet getHashSet(StoreFrontInterface storeFront)
    {
        InventoryColumnUtil inventoryColumnUtil = InventoryColumnUtil.getInstance();
        BasicArrayList keywords = inventoryColumnUtil.getColumnWhereLike(this.inventory, storeFront.getCategoryPath(), basicItemData.KEYWORDS);
        BasicArrayList subStoreVector = storeFront.getSubStores();
        int size = subStoreVector.size();
        for (int index = 0; index < size; index++) {
            string subStore = ((string) subStoreVector.get(index));
            BasicArrayList substoreKeywords = inventoryColumnUtil.getColumnWhereLike(this.inventory, AbPathData.getInstance().SEPARATOR + subStore, basicItemData.CATEGORY);
            keywords.addAllList(substoreKeywords);
        }
        UniqueTokens uniqueTokens = new UniqueTokens();
        HashSet keywordHashSet = uniqueTokens.getWhithoutDashesAndSkipNumberOnlyTokens(keywords);
        return keywordHashSet;
    }

    // throws Exception
    private void savePage(string file, string data)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STATICPAGEGENERATIONLOGGING)) {
            this.logUtil.putF("Creating File: " + file, this, "generateAll()");
        }
        AbFile newFile = AbFile.createAbFile(file);
        if (newFile.exists()) {
            newFile.delete();
        }
        newFile.createNewFile();
        if (newFile.exists()) {
            AbDataOutputStream idOutData = DataOutputStreamFactory.getInstance().getInstanceForAbFile(newFile);
            idOutData.writeBytes(data);
            idOutData.flush();
            StreamUtil.getInstance().close(idOutData);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STATICPAGEGENERATIONLOGGING)) {
                this.logUtil.putF("Wrote Total Bytes: " + newFile.length(), this, "generateAll()");
            }
        } else {
            throw new Exception("Could Not Create: " + file);
        }
    }

    // throws Exception
    private void create(string keywordData, HashMap keywordFilenameHashMap, BasicArrayList vector, AbPath staticPath)
    {
        StringMaker stringBuffer = new StringMaker();
        HashMap hashMap = SpecialCharacterUtil.getHashMap();
        hashMap.put(CommonSeps.getInstance().SPACE, StringUtil.getInstance().EMPTY_STRING);
        string pageName = new Replace(hashMap).all(keywordData);
        SearchParams searchParams = this.searchRequest.getParams();
        searchParams.add(basicItemData.KEYWORDS, keywordData);
        searchParams.setStartPage(CommonPhoneStrings.getInstance().ZERO);
        this.searchRequest.setParams(searchParams);
        this.searchRequest.setFileBaseName(pageName);
        AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
        InventorySearchUtil inventorySearchUtil = InventorySearchUtil.getInstance();
        string[] productListingPages = inventorySearchUtil.search(abeClientInformation, searchRequest, vector);
        for (int index = 0; index < productListingPages.Length; index++) {
            if (productListingPages[index] == null) {
                break;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STATICPAGEGENERATIONLOGGING)) {
                this.logUtil.putF("Saving Listing: " + index, this, "generateAll()");
            }
            string indexStr = StringUtil.getInstance().EMPTY_STRING;
            if (index > 0) {
                indexStr = index.ToString();
            }
            keywordFilenameHashMap.put(keywordData, pageName + indexStr);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(staticPath.ToString());
            stringBuffer.append(pageName);
            stringBuffer.append(indexStr);
            stringBuffer.append(AbPathData.getInstance().EXTENSION_SEP);
            stringBuffer.append(InputOutputTypeData.getInstance().DEFAULT);
            string file = stringBuffer.ToString();
            if (!this.directory.create(staticPath)) {
                throw new Exception("Could Not Create Directory: " + staticPath);
            }
            this.savePage(file, productListingPages[index]);
        }
    }

    private void addStaticPageInfoToDatabase(StoreFrontInterface storeFront, HashMap keywordFilenameHashMap)
    {
        Set keywordHashSet = keywordFilenameHashMap.keySet();
        object[] keywordArray = keywordHashSet.toArray();
        int size = keywordArray.Length;
        for (int index = 0; index < size; index++) {
            BasicArrayList insertVector = new BasicArrayListD();
            string keywordData = ((string) keywordArray[index]);
            string fileName = ((string) keywordFilenameHashMap.get(keywordData));
            insertVector.add(storeFront.getName());
            insertVector.add(keywordData);
            insertVector.add(fileName);
            this.staticPages.insert(insertVector);
        }
    }

    // throws Exception
    public virtual string generateAll()
    {
        try {
            StoreFrontInterface storeFront = this.searchRequest.getStoreFront();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getWebappPath());
            stringBuffer.append(storeFront.getName());
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            stringBuffer.append(storeFront.getStaticPath());
            AbPath staticPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STATICPAGEGENERATIONLOGGING)) {
                this.logUtil.putF("Store Static Pages Path: " + staticPath, this, "generateAll()");
            }
            HashSet keywordHashSet = this.getHashSet(storeFront);
            object[] keywordArray = keywordHashSet.toArray();
            int size = keywordArray.Length;
            HashMap keywordFilenameHashMap = StdUtil.getInstance().createHashMap();
            if (size == 0) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Products For ");
                stringBuffer.append(storeFront.getName());
                stringBuffer.append(" Store Not Found");
                return stringBuffer.ToString();
            }
            InventorySearchUtil inventorySearchUtil = InventorySearchUtil.getInstance();
            BasicArrayList vector = inventorySearchUtil.getBasicItemIdColumn(this.searchRequest);
            for (int index = 0; index < size; index++) {
                string keywordData = ((string) keywordArray[index]);
                if (keywordData.Length > 1) {
                    this.create(keywordData, keywordFilenameHashMap, vector, staticPath);
                }
            }
            this.addStaticPageInfoToDatabase(storeFront, keywordFilenameHashMap);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("Static Files Generated Successfully For ");
            stringBuffer.append(storeFront.getName());
            stringBuffer.append(" it used packages ");
            stringBuffer.append(storeFront.getPackageLocation());
            stringBuffer.append(this.INVENTORY);
            return stringBuffer.ToString();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual string generateAll(string storeName)
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (storeName != null) {
                if (string.CompareOrdinal(storeName, GLOBALS2.GENERATEALLSTORES) != 0) {
                    this.searchRequest.setStoreFront(this.storeFronts.getStoreFrontInterface(storeName));
                    stringBuffer.append(this.generateAll());
                    stringBuffer.append("<br />");
                } else {
                    BasicArrayList storeFrontVector = this.storeFronts.getStoreFrontNames();
                    int size = storeFrontVector.size();
                    for (int index = 0; index < size; index++) {
                        storeName = ((string) storeFrontVector.get(index));
                        this.searchRequest.setStoreFront(this.storeFronts.getStoreFrontInterface(storeName));
                        stringBuffer.append(this.generateAll());
                        stringBuffer.append("<br />");
                    }
                }
            } else {
                return "Generation Failed No Store Specified<br/>";
            }
            stringBuffer.append("All Static Pages Generated<br/>");
            return stringBuffer.ToString();
        } catch (Exception e) {
            throw e;
        }
    }

}

