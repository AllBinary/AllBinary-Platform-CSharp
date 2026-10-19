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
using System.Runtime.CompilerServices;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using CategoryProperties = org.allbinary.business.category.properties.CategoryProperties;
using CategoryPropertiesInterface = org.allbinary.business.category.properties.CategoryPropertiesInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.data.tree.category;

public class CategoryLoader : CategoryModifierTree, CategoryLoaderInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CategoryLoader(CategoryFactoryInterface categoryFactoryInterface) : base(categoryFactoryInterface)
    {
        // base(categoryFactoryInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(this.commonStrings.START, this, "CategoryLoader(CategoryFactoryInterface categoryFactoryInterface)");
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual Document getDoc(CategoryInterface categoryInterface)
    {
        try {
            if (categoryInterface.getProperties().getPath(categoryInterface.getHierarchy()) != null) {
                if (categoryInterface.getHierarchy().getLevel() == 1) {
                    AbFile rootAbFile = AbFile.createAbFileFromAbPath(categoryInterface.getRootFilePath());
                    if (!rootAbFile.isDirectory()) {
                        rootAbFile.mkdirs();
                        if (!rootAbFile.isDirectory()) {
                            throw new Exception("Could Not Create Directory");
                        }
                        this.save(categoryInterface);
                    }
                }
                AbPath fileAbPath = categoryInterface.getFilePath();
                CryptFileReader cryptFileReader = new CryptFileReader(CategoryData.getInstance().UNCRYPTED_EXTENSION, CategoryData.getInstance().ENCRYPTED_EXTENSION);
                Document document = DomDocumentHelper.create(cryptFileReader.get(fileAbPath));
                return document;
            } else {
                throw new Exception("Null Category");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                try {
                    categoryInterface.log();
                } catch (Exception e2) {
                    this.logUtil.put("Could Not Log Category", this, "getDoc", e);
                }
                this.logUtil.put(this.commonStrings.FAILURE, this, "getDoc", e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual CategoryInterface get(CategoryInterface categoryInterface)
    {
        try {
            Document document = this.getDoc(categoryInterface);
            Node categoryNode = DomSearchHelper.getNode(CategoryData.getInstance().NAME, document.getChildNodes());
            return this.addProperties(categoryInterface, categoryNode.getChildNodes());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual CategoryInterface get(Document document)
    {
        try {
            Node categoryNode = DomSearchHelper.getNode(CategoryData.getInstance().NAME, document.getChildNodes());
            CategoryInterface loadedCategoryInterface = this.categoryFactoryInterface.getRootInstanceFromNode(categoryNode);
            return this.addProperties(loadedCategoryInterface, categoryNode.getChildNodes());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual CategoryInterface getAll(CategoryInterface categoryInterface)
    {
        try {
            Document document = this.getDoc(categoryInterface);
            return this.getAll(document);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private CategoryInterface getAll(Document document)
    {
        try {
            Node categoryNode = DomSearchHelper.getNode(CategoryData.getInstance().NAME, document.getChildNodes());
            CategoryInterface loadedCategoryInterface = this.categoryFactoryInterface.getRootInstanceFromNode(categoryNode);
            return this.addProperties(loadedCategoryInterface, categoryNode.getChildNodes());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private CategoryInterface getAll(CategoryInterface parentCategoryInterface, NodeList categoryNodeList)
    {
        try {
            if (categoryNodeList != null) {
                for (int index = 0; index < categoryNodeList.getLength(); index++) {
                    Node categoryNode = categoryNodeList.item(index);
                    if (categoryNode != null && categoryNode.getNodeName().compareTo(CategoryData.getInstance().NAME) == 0) {
                        CategoryInterface categoryInterface = ((CategoryInterface) this.categoryFactoryInterface.getInstance(parentCategoryInterface.getHierarchy().getRoot(), parentCategoryInterface, categoryNode));
                        parentCategoryInterface.addChild(categoryInterface);
                    }
                }
            }
            return parentCategoryInterface;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private CategoryInterface addProperties(CategoryInterface loadedCategoryInterface, NodeList categoryNodeList)
    {
        try {
            if (categoryNodeList != null) {
                for (int index = 0; index < categoryNodeList.getLength(); index++) {
                    Node categoryNode = categoryNodeList.item(index);
                    if (categoryNode != null && categoryNode.getNodeName().compareTo(CategoryData.getInstance().NAME) == 0) {
                        CategoryPropertiesInterface categoryPropertiesInterface = ((CategoryPropertiesInterface) new CategoryProperties(categoryNode));
                        loadedCategoryInterface.addChildProperty(categoryPropertiesInterface);
                    }
                }
            }
            return loadedCategoryInterface;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

}

