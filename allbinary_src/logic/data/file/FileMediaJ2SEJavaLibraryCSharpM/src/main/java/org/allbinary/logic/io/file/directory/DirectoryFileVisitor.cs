/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
using VisitorInterface = org.allbinary.logic.util.visitor.VisitorInterface;

namespace org.allbinary.logic.io.file.directory;

public class DirectoryFileVisitor : VisitorInterface, FileFilter
{
    public DirectoryFileVisitor()
    {
    }

    public virtual bool accept(java.io.File arg0)
    {
        return (((bool?) this.visit(((object) arg0))));
    }

    public virtual object visit(object anyType)
    {
        File file = ((File) anyType);
        int index = 1;
        File aFile = file.getParentFile();
        while (((aFile = aFile.getParentFile())) != null) {
            index++;
        }
        if (file.isDirectory() && index < 5) {
            return true;
        }
        return false;
    }

}

