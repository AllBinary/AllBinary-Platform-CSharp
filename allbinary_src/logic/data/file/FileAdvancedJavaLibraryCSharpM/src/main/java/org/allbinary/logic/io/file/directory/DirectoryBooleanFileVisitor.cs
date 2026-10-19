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
using VisitorInterface = org.allbinary.logic.util.visitor.VisitorInterface;

namespace org.allbinary.logic.io.file.directory;

public class DirectoryBooleanFileVisitor : VisitorInterface
{
    public DirectoryBooleanFileVisitor()
    {
    }

    public virtual object visit(object anyType)
    {
        return ((object) this.visit(((AbFile) anyType)));
    }

    public virtual bool? visit(AbFile file)
    {
        if (file.isDirectory()) {
            return true;
        }
        return false;
    }

}

