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
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.tree.category;

public class CategoryModifierTree : CategoryPrivateTree, CategoryModifierTreeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Directory directory = Directory.getInstance();
    public CategoryModifierTree(CategoryFactoryInterface categoryFactoryInterface) : base(categoryFactoryInterface)
    {
        // base(categoryFactoryInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
            this.logUtil.putF(this.commonStrings.START, this, "CategoryModifierTree(CategoryFactoryInterface categoryFactoryInterface)");
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void insert(CategoryInterface parentCategoryInterface, CategoryInterface newChildCategoryInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                this.logUtil.putF("Inserting", this, "insert()");
            }
            if (parentCategoryInterface.isValid()) {
                parentCategoryInterface.addChild(newChildCategoryInterface);
                AbPath directoryToBeCreatedAbPath = new AbPath(newChildCategoryInterface.getRootFilePath().ToString() + newChildCategoryInterface.getPath().ToString(), StringUtil.getInstance().EMPTY_STRING);
                this.directory.create(directoryToBeCreatedAbPath);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().CATEGORY)) {
                    this.logUtil.putF("Saving", this, "insert()");
                }
                this.save(parentCategoryInterface);
                this.save(newChildCategoryInterface);
            } else {
                throw new Exception("Will Not Add Null Category");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "insert", e);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void delete(CategoryInterface parentCategoryInterface, CategoryInterface existingChildCategoryInterface)
    {
        try {
            if (parentCategoryInterface.isValid()) {
                parentCategoryInterface.addChild(existingChildCategoryInterface);
                AbPath directoryToBeDeletedAbPath = new AbPath(existingChildCategoryInterface.getRootFilePath().ToString() + existingChildCategoryInterface.getPath().ToString(), StringUtil.getInstance().EMPTY_STRING);
                this.delete(existingChildCategoryInterface);
                parentCategoryInterface.removeChild(existingChildCategoryInterface);
                this.save(parentCategoryInterface);
                this.directory.remove(directoryToBeDeletedAbPath);
            } else {
                throw new Exception("Will Not Add Null Category");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

}

