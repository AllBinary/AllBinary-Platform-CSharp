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
//using Set = java.util.Set;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using CategoryComponent = org.allbinary.business.category.CategoryComponent;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using StoreCategoryFactory = org.allbinary.business.category.store.StoreCategoryFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using CategoryLoaderFactory = org.allbinary.data.tree.category.CategoryLoaderFactory;
using CategoryLoaderInterface = org.allbinary.data.tree.category.CategoryLoaderInterface;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoBasic = org.allbinary.logic.visual.transform.info.TransformInfoBasic;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace admin.taghelpers;

public class CategoryRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private PageContext pageContext = null;
    private HashMap hashMap = null;
    private HttpServletRequest request = null;
    private CategoryLoaderInterface categoryLoaderInterface = null;
    private CategoryInterface categoryInterface = null;
    private CategoryInterface childCategoryInterface = null;
    private TransformInfoInterface transformInfoInterface = null;
    public CategoryRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        try {
            this.request = ((HttpServletRequest) pageContext.getRequest());
            this.pageContext = pageContext;
            this.hashMap = hashMap;
            this.getXmlData();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "CategoryRequestHelper()", e);
            }
        }
    }

    private static readonly string categoryRequest = new StringMaker().append("<").append(CategoryData.getInstance().REQUEST).append(">").ToString();
    public virtual void getXmlData()
    {
        try {
            Map map = this.request.getParameterMap();
            CategoryData categoryData = CategoryData.getInstance();
            Set keys = map.keySet();
            object[] keyArray = keys.toArray();
            int size = keyArray.Length;
            if (size > 0) {
                string xmlRequest = ((string) keyArray[0]);
                int index = 1;
                while (index < size && !xmlRequest.StartsWith(CategoryRequestHelper.categoryRequest)) {
                    xmlRequest = ((string) keyArray[index]);
                    if (xmlRequest.StartsWith(CategoryRequestHelper.categoryRequest)) {
                        break;
                    }
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF(xmlRequest, this, "getXmlData()");
                }
                Document document = DomDocumentHelper.create(xmlRequest);
                Node requestNode = DomSearchHelper.getNode(categoryData.REQUEST, document.getChildNodes());
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.logUtil.putF(XmlDocumentHelper.toString(document), this, "getXmlData()");
                }
                this.setCategoryLoader(requestNode);
                Node parentCategoryNode = DomSearchHelper.getNode(categoryData.PARENT, requestNode.getChildNodes());
                Node categoryNode = DomSearchHelper.getNode(categoryData.NAME, parentCategoryNode.getChildNodes());
                this.categoryInterface = ((CategoryInterface) new StoreCategoryFactory(this.transformInfoInterface).getRootInstanceFromNode(categoryNode));
                this.categoryInterface = this.categoryLoaderInterface.get(this.categoryInterface);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                    this.categoryInterface.log();
                    this.logUtil.putF("Loaded Parent Category", this, "getXmlData()");
                }
                Node childCategoryNode = DomSearchHelper.getNodeNoThrow(categoryData.NAME, requestNode.getChildNodes());
                if (childCategoryNode != null) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                        this.logUtil.putF("Loading Child Category", this, "getXmlData()");
                    }
                    this.childCategoryInterface = ((CategoryInterface) new StoreCategoryFactory(this.transformInfoInterface).getInstance(childCategoryNode));
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                        this.childCategoryInterface.log();
                        this.logUtil.putF("Loaded Child Category", this, "getXmlData()");
                    }
                } else {
                    this.childCategoryInterface = this.categoryInterface;
                }
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getXmlData()", e);
            }
        }
    }

    // throws Exception
    private void setCategoryLoader(Node requestNode)
    {
        Node storeNameNode = DomSearchHelper.getNode(StoreFrontData.getInstance().NAME, requestNode.getChildNodes());
        if (storeNameNode != null) {
            string storeName = DomNodeHelper.getTextNodeValue(storeNameNode);
            if (storeName != null) {
                StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(storeName);
                this.transformInfoInterface = ((TransformInfoInterface) new TransformInfoBasic(storeFrontInterface, this.hashMap, this.pageContext));
                if (this.transformInfoInterface == null) {
                    throw new Exception("TransformInfo null");
                }
                StoreCategoryFactory storeCategoryFactory = new StoreCategoryFactory(this.transformInfoInterface);
                this.categoryLoaderInterface = CategoryLoaderFactory.getInstance(storeCategoryFactory);
            } else {
                throw new Exception("Store Name Error: " + storeName);
            }
        }
    }

    public virtual string insert()
    {
        try {
            string success = "Successfully Added the following to the Category table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("inserting", this, "insert()");
            }
            this.categoryLoaderInterface.insert(this.categoryInterface, this.childCategoryInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add item to Category";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Successfully Removed " + CategoryData.getInstance().NAME + "=" + this.childCategoryInterface.getPath();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Deleting", this, "delete()");
            }
            this.categoryLoaderInterface.delete(this.categoryInterface, this.childCategoryInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            try {
                string error = "Failed to remove category: " + this.childCategoryInterface.getPath();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                    this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
                }
                return error;
            } catch (Exception e2) {
                string error = "Failed to remove category and show the path of the failed category";
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                    this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e2);
                }
                return error;
            }
        }
    }

    public virtual string viewCategory()
    {
        try {
            Document document = new CategoryComponent(this.childCategoryInterface).toXmlDoc();
            string xmlString = XmlDocumentHelper.toString(document);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(xmlString, this, "viewCategory()");
            }
            return xmlString;
        } catch (Exception e) {
            string error = "Failed to get Category";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewCategory()", e);
            }
            return error;
        }
    }

    public virtual string viewCategories()
    {
        try {
            string success = StringUtil.getInstance().EMPTY_STRING;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "viewCategories()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to view Categories table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "viewCategories()", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            string success = "New Item Successfully added";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add Item";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

