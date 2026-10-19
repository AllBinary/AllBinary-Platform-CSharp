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
//using File = java.io.File;
//using FileFilter = java.io.FileFilter;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using VisitorInterface = org.allbinary.logic.util.visitor.VisitorInterface;

namespace org.allbinary.logic.io.file.filter;

public class VisitorFileFilter : FileFilter
{
    private VisitorInterface booleanVisitorInterface;
    public VisitorFileFilter(VisitorInterface booleanVisitorInterface)
    {
        this.booleanVisitorInterface = booleanVisitorInterface;
    }

    public virtual bool accept(File file)
    {
        AbFile abFile = FileWrapperUtil.wrapFile(file);
        bool isFileAcceptable = (((bool?) this.booleanVisitorInterface.visit(abFile)));
        return isFileAcceptable || file.isDirectory();
    }

    public virtual bool accept(AbFile file)
    {
        bool isFileAcceptable = (((bool?) this.booleanVisitorInterface.visit(file)));
        return isFileAcceptable || file.isDirectory();
    }

}

