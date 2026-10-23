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
using CategoryComponent = org.allbinary.business.category.CategoryComponent;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileWriter = org.allbinary.logic.control.crypt.file.CryptFileWriter;
using AbFile = org.allbinary.logic.io.file.AbFile;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.category;

public class CategoryPrivateTree
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CategoryFactoryInterface categoryFactoryInterface;
    public CategoryPrivateTree(CategoryFactoryInterface categoryFactoryInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, "CategoryPrivateTree(CategoryFactoryInterface categoryFactoryInterface)");
        }
        this.categoryFactoryInterface = categoryFactoryInterface;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void save(CategoryInterface categoryInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("Saving Category File: " + categoryInterface.getFilePath(), this, "save()");
        }
        Document document = new CategoryComponent(categoryInterface).toXmlDoc();
        CryptFileWriter cryptFileWriter = new CryptFileWriter(CategoryData.getInstance().UNCRYPTED_EXTENSION, CategoryData.getInstance().ENCRYPTED_EXTENSION);
        cryptFileWriter.write(categoryInterface.getFilePath(), document);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("end", this, "save()");
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void delete(CategoryInterface categoryInterface)
    {
        if (categoryInterface.isLeaf()) {
            AbFile categoryFile = AbFile.createAbFileFromAbPath(categoryInterface.getFilePath());
            if (categoryFile.delete()) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF("Removed: " + categoryInterface.getFilePath(), this, "delete(CategoryInterface)");
                }
            }
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF("Not a leaf unable to remove", this, "delete(CategoryInterface)");
            }
        }
    }

}

