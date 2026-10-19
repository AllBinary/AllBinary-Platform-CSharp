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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using VisitorInterface = org.allbinary.logic.util.visitor.VisitorInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file.visitor;

public class BooleanFileVisitor : VisitorInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private BasicArrayList filterStringBasicArrayList = null;
    public BooleanFileVisitor(BasicArrayList filterStringBasicArrayList)
    {
        this.setFilterStringBasicArrayList(filterStringBasicArrayList);
        PreLogUtil.put("Filter BasicArrayList: " + this.getFilterStringBasicArrayList().ToString(), this, this.commonStrings.CONSTRUCTOR);
    }

    public virtual object visit(object anyType)
    {
        return ((object) this.visit(((AbFile) anyType)));
    }

    public virtual bool? visit(AbFile file)
    {
        BasicArrayList list = this.getFilterStringBasicArrayList();
        int size = list.size();
        string nextFileFilterString = null;
        for (int index = 0; index < size; index++) {
            nextFileFilterString = ((string) list.get(index));
            if (this.visit(file, nextFileFilterString)) {
                return true;
            }
        }
        return false;
    }

    public virtual BasicArrayList getFilterStringBasicArrayList()
    {
        return this.filterStringBasicArrayList;
    }

    public virtual void setFilterStringBasicArrayList(BasicArrayList filterStringBasicArrayList)
    {
        this.filterStringBasicArrayList = filterStringBasicArrayList;
    }

    public virtual bool? visit(AbFile file, string fileNameString)
    {
        return false;
    }

}

