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
//using FileFilter = java.io.FileFilter;
using IncludeFileExtensionsBooleanFileVisitor = org.allbinary.logic.io.file.visitor.IncludeFileExtensionsBooleanFileVisitor;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.io.file.filter;

public class BasicFileFilterUtil
{
    private BasicFileFilterUtil()
    {
    }

    public static FileFilter getInstance(string extension)
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.add(extension);
        IncludeFileExtensionsBooleanFileVisitor includeFileExtensionsBooleanFileVisitor = new IncludeFileExtensionsBooleanFileVisitor(vector);
        return ((FileFilter) new VisitorFileFilter(includeFileExtensionsBooleanFileVisitor));
    }

}

