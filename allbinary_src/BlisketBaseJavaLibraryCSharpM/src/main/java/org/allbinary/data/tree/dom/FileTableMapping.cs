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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileData = org.allbinary.logic.io.file.FileData;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using PathUtil = org.allbinary.logic.io.path.PathUtil;

namespace org.allbinary.data.tree.dom;

public class FileTableMapping : TableMappingInterface
{
    private AbFile file;
    public FileTableMapping(AbFile file)
    {
        this.file = file;
    }

    // throws Exception
    public virtual object getKey()
    {
        return ((object) this.file.getPath());
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList filePropertyVector = new BasicArrayListD();
        filePropertyVector.add(this.file.getAbsolutePath());
        filePropertyVector.add(this.file.getCanonicalPath());
        filePropertyVector.add(this.file.getName());
        filePropertyVector.add(this.file.getParent());
        filePropertyVector.add(this.file.getPath());
        return filePropertyVector;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        HashMap filePropertyHashMap = StdUtil.getInstance().createHashMap();
        AbPathData pathData = AbPathData.getInstance();
        PathUtil pathUtil = PathUtil.getInstance();
        string rootFileName = pathData.getNameFromPath(pathUtil.getWithoutExtension(this.file.getPath()));
        FileData fileData = FileData.getInstance();
        filePropertyHashMap.put(fileData.ROOT_NAME, rootFileName);
        filePropertyHashMap.put(fileData.ISFILE, (this.file.isFile()).ToString().ToString());
        filePropertyHashMap.put(fileData.ISDIRECTORY, (this.file.isDirectory()).ToString().ToString());
        filePropertyHashMap.put(fileData.ISHIDDEN, (this.file.isHidden()).ToString().ToString());
        filePropertyHashMap.put(fileData.ISABSOLUTE, (this.file.isAbsolute()).ToString().ToString());
        filePropertyHashMap.put(fileData.ABSOLUTE_PATH, file.getAbsolutePath());
        filePropertyHashMap.put(fileData.CANONICAL_PATH, file.getCanonicalPath());
        filePropertyHashMap.put(fileData.NAME, file.getName());
        filePropertyHashMap.put(fileData.PARENT, file.getParent());
        filePropertyHashMap.put(fileData.PATH, file.getPath());
        return filePropertyHashMap;
    }

}

