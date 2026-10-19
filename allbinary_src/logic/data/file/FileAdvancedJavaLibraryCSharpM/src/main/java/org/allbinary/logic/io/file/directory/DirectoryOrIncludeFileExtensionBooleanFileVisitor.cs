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
using AbFile = org.allbinary.logic.io.file.AbFile;
using IncludeFileExtensionsBooleanFileVisitor = org.allbinary.logic.io.file.visitor.IncludeFileExtensionsBooleanFileVisitor;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file.directory;

public class DirectoryOrIncludeFileExtensionBooleanFileVisitor : IncludeFileExtensionsBooleanFileVisitor
{
    private readonly string includesString;
    public DirectoryOrIncludeFileExtensionBooleanFileVisitor(BasicArrayList filterStringBasicArrayList) : base(filterStringBasicArrayList)
    {
        // base(filterStringBasicArrayList) is called from the constructor declaration
        this.includesString = null;
    }

    public DirectoryOrIncludeFileExtensionBooleanFileVisitor(BasicArrayList filterStringBasicArrayList, string includesString) : base(filterStringBasicArrayList)
    {
        // base(filterStringBasicArrayList) is called from the constructor declaration
        this.includesString = includesString;
    }

    public override bool? visit(AbFile file)
    {
        if (file.isDirectory()) {
            return true;
        }
        if (this.includesString == null || file.getAbsolutePath().indexOf(this.includesString) >= 0) {
            return base.visit(file);
        } else {
            return false;
        }
    }

}

