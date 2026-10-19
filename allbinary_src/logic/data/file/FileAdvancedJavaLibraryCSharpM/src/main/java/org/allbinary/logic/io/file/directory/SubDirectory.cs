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
using AbFile = org.allbinary.logic.io.file.AbFile;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file.directory;

public class SubDirectory
{
    private static readonly SubDirectory instance = new SubDirectory();
    public static SubDirectory getInstance()
    {
        return SubDirectory.instance;
    }

    private readonly Directory directory = Directory.getInstance();
    private SubDirectory()
    {
    }

    public virtual BasicArrayList search(FileFilter fileFilter, AbFile file)
    {
        return this.directory.search(fileFilter, file, true);
    }

    public virtual BasicArrayList search(AbFile file)
    {
        return this.directory.search(file, true);
    }

    public virtual BasicArrayList search(string searchValue, AbFile file)
    {
        return this.directory.search(searchValue, file, true);
    }

    public virtual BasicArrayList search(int level, AbFile file)
    {
        return this.directory.search(level, file, true);
    }

    public static string toString(BasicArrayList files)
    {
        StringMaker stringBuffer = new StringMaker();
        string NEW_LINE = CommonSeps.getInstance().NEW_LINE;
        int size = files.size();
        for (int index = 0; index < size; index++) {
            AbFile file = ((AbFile) files.get(index));
            stringBuffer.append(file.getPath());
            stringBuffer.append(NEW_LINE);
        }
        return stringBuffer.ToString();
    }

}

