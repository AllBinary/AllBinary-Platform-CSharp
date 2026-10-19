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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file.visitor;

public class IncludeFileExtensionsBooleanFileVisitor : BooleanFileVisitor
{
    public IncludeFileExtensionsBooleanFileVisitor(BasicArrayList filterStringBasicArrayList) : base(filterStringBasicArrayList)
    {
        // base(filterStringBasicArrayList) is called from the constructor declaration
    }

    public override bool? visit(AbFile file)
    {
        if (this.getFilterStringBasicArrayList().size() == 0) {
            return false;
        }
        return base.visit(file);
    }

    public override bool? visit(AbFile file, string fileNameString)
    {
        string fileNameAndExtension = file.getPath();
        if (fileNameAndExtension.Length > fileNameString.Length) {
            int startIndex = fileNameAndExtension.Length - fileNameString.Length;
            string fileName = fileNameAndExtension.Substring(startIndex);
            if (string.CompareOrdinal(fileName, fileNameString) == 0) {
                return true;
            }
        }
        return false;
    }

}

