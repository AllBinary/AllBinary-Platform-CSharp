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
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using InventoryData = org.allbinary.business.user.commerce.inventory.InventoryData;
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchData = org.allbinary.logic.control.search.SearchData;
using SearchParams = org.allbinary.logic.control.search.SearchParams;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using StoreTransformer = org.allbinary.logic.visual.transform.StoreTransformer;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformStoreDocumentFactory = org.allbinary.logic.visual.transform.data.TransformStoreDocumentFactory;
using TransformInfoHttpSearch = org.allbinary.logic.visual.transform.info.TransformInfoHttpSearch;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.inventory;

public class InventorySearchUtil
{
    private static readonly InventorySearchUtil instance = new InventorySearchUtil();
    public static InventorySearchUtil getInstance()
    {
        return InventorySearchUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    // throws Exception
    public virtual BasicArrayList getBasicItemIdColumn(SearchRequest searchRequest)
    {
        InventoryEntity inventoryEntityInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
        StoreFrontInterface storeFrontInterface = searchRequest.getStoreFront();
        InventoryColumnUtil inventorySearchUtil = InventoryColumnUtil.getInstance();
        BasicArrayList column = inventorySearchUtil.getColumnWhereLike(inventoryEntityInterface, storeFrontInterface.getCategoryPath(), basicItemData.ID);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF("Number Of Items Found: " + column.size(), this, "search");
        }
        BasicArrayList subStoreVector = storeFrontInterface.getSubStores();
        int size = subStoreVector.size();
        for (int index = 0; index < size; index++) {
            string subStore = ((string) subStoreVector.get(index));
            BasicArrayList substoreIdColumn = inventorySearchUtil.getColumnWhereLike(inventoryEntityInterface, subStore, basicItemData.ID);
            column.addAllList(substoreIdColumn);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF("Number Of Items Found Including SubStores: " + column.size(), this, "search");
        }
        return column;
    }

    // throws Exception
    private string getNoResults(TransformDocumentInterface viewDocumentInterface, Node inventoryNode)
    {
        inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.TOTAL_NUMBER_PAGES, this.commonPhoneStrings.ZERO));
        inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.TOTAL_NUMBER_ITEMS, this.commonPhoneStrings.ZERO));
        string success = XmlDocumentHelper.toString(viewDocumentInterface.getDoc());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF("No Results Xml: " + success, this, "search");
        }
        return success;
    }

    public virtual string[] search(AbeClientInformationInterface abeClientInformation, SearchRequest searchRequest, BasicArrayList column)
    {
        try {
            InventoryEntity inventoryEntityInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            SearchParams searchParams = searchRequest.getParams();
            int startPage = ((int) searchParams.getStartPageInt());
            int endPage = ((int) searchParams.getEndPageInt());
            int pageLength = ((int) searchParams.getLengthInt());
            int savedPagesInRange = 0;
            HashMap columnValueHashMap = searchParams.get();
            string keyword = new Replace("-", CommonSeps.getInstance().SPACE).all(((string) columnValueHashMap.get(basicItemData.KEYWORDS)));
            if (StringValidationUtil.getInstance().isEmpty(keyword)) {
                return null;
            }
            StringMaker stringBuffer = new StringMaker();
            if (startPage >= 0) {
                if (pageLength == 0) {
                    pageLength = SearchData.DEFAULT_PAGE_LENGTH;
                }
                int MAXPAGES = 100;
                string[] productListingPages = new string[MAXPAGES];
                Document[] documents = new Document[MAXPAGES];
                Node[] inventoryNodes = new Node[MAXPAGES];
                keyword = keyword.ToUpper();
                int lastPage = -1;
                int numberOfResultsOnCurrentPage = 0;
                int numberOfResults = 0;
                TransformDocumentInterface viewDocumentInterface = TransformStoreDocumentFactory.getInstance(searchRequest);
                Node inventoryNode = viewDocumentInterface.getDoc().createElement(InventoryData.INVENTORY);
                viewDocumentInterface.getBaseNode().appendChild(inventoryNode);
                inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.PAGE, startPage.ToString()));
                if (searchRequest.getFileBaseName() != null) {
                    inventoryNode.appendChild(searchRequest.getFileBaseNameNode(viewDocumentInterface.getDoc()));
                }
                int currentPage = -1;
                int size = column.size();
                for (int index = 0; index < size; index++) {
                    string product = new string((((string) column.get(index))).ToCharArray());
                    ItemInterface itemInterface = inventoryEntityInterface.getItem(product);
                    string keywords = itemInterface.getKeywords();
                    keywords = keywords.ToUpper();
                    if (keywords.IndexOf(keyword) != -1) {
                        if (currentPage + 1 >= startPage && currentPage + 1 <= endPage) {
                            Node itemNode = new BasicItemView(itemInterface, new BasicArrayListD()).toXmlNode(viewDocumentInterface.getDoc());
                            itemNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), BasketData.ITEMTOTALINBASKET, this.commonPhoneStrings.ONE));
                            inventoryNode.appendChild(itemNode.cloneNode(true));
                        }
                        currentPage = ((numberOfResults + 1) / pageLength) - 1;
                        numberOfResultsOnCurrentPage++;
                        if (lastPage < currentPage) {
                            if (currentPage >= startPage && currentPage <= endPage) {
                                inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.TOTAL_NUMBER_ITEMS_ON_THIS_PAGE, numberOfResultsOnCurrentPage.ToString()));
                                documents[currentPage] = viewDocumentInterface.getDoc();
                                inventoryNodes[currentPage] = inventoryNode;
                                savedPagesInRange++;
                                viewDocumentInterface = TransformStoreDocumentFactory.getInstance(searchRequest);
                                inventoryNode = viewDocumentInterface.getDoc().createElement(InventoryData.INVENTORY);
                                viewDocumentInterface.getBaseNode().appendChild(inventoryNode);
                                inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.PAGE, currentPage + 1.ToString()));
                                if (searchRequest.getFileBaseName() != null) {
                                    inventoryNode.appendChild(searchRequest.getFileBaseNameNode(viewDocumentInterface.getDoc()));
                                }
                            }
                            lastPage = currentPage;
                            numberOfResultsOnCurrentPage = 0;
                        }
                        numberOfResults++;
                        if (lastPage >= MAXPAGES - 1) {
                            break;
                        }
                    }
                }
                if (numberOfResultsOnCurrentPage > 0 && (currentPage + 1 >= startPage && currentPage + 1 <= endPage)) {
                    inventoryNode.appendChild(ModDomHelper.createNameValueNodes(viewDocumentInterface.getDoc(), SearchData.TOTAL_NUMBER_ITEMS_ON_THIS_PAGE, numberOfResultsOnCurrentPage - 1.ToString()));
                    documents[lastPage + 1] = viewDocumentInterface.getDoc();
                    inventoryNodes[lastPage + 1] = inventoryNode;
                    savedPagesInRange++;
                }
                if (numberOfResultsOnCurrentPage > 0) {
                    lastPage++;
                }
                if (endPage > MAXPAGES - 1) {
                    endPage = MAXPAGES - 1;
                }
                for (int index = startPage; index <= endPage; index++) {
                    if (index <= lastPage) {
                        Document tempDocument = documents[index];
                        inventoryNodes[index].appendChild(ModDomHelper.createNameValueNodes(tempDocument, SearchData.TOTAL_NUMBER_PAGES, lastPage + 1.ToString()));
                        inventoryNodes[index].appendChild(ModDomHelper.createNameValueNodes(tempDocument, SearchData.TOTAL_NUMBER_ITEMS, numberOfResults.ToString()));
                        for (int pageIndex = 0; pageIndex <= lastPage; pageIndex++) {
                            stringBuffer.delete(0, stringBuffer.length());
                            stringBuffer.append(searchRequest.getFileBaseName());
                            if (stringBuffer.length() > 0) {
                                if (pageIndex != 0) {
                                    stringBuffer.append((pageIndex).ToString());
                                }
                                inventoryNodes[index].appendChild(ModDomHelper.createNameValueNodes(tempDocument, SearchData.PAGE_INFO, (pageIndex).ToString(), stringBuffer.ToString()));
                            } else {
                                inventoryNodes[index].appendChild(ModDomHelper.createNameValueNodes(tempDocument, SearchData.PAGE_INFO, (pageIndex).ToString(), SearchData.SEARCH));
                            }
                        }
                        string success = XmlDocumentHelper.toString(tempDocument);
                        productListingPages[index] = new StoreTransformer(abeClientInformation, ((TransformInfoInterface) new TransformInfoHttpSearch(searchRequest))).translate(success);
                    }
                }
                if (savedPagesInRange == 0) {
                    string result = this.getNoResults(viewDocumentInterface, inventoryNode);
                    productListingPages[0] = new StoreTransformer(abeClientInformation, new TransformInfoHttpSearch(searchRequest)).translate(result);
                }
                return productListingPages;
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "search", e);
            }
            return null;
        }
    }

}

