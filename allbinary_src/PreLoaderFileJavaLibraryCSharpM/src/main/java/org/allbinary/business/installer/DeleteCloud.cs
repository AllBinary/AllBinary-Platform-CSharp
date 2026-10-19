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
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using FileUploadData = org.allbinary.logic.communication.http.file.upload.FileUploadData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbIOSystem = org.allbinary.logic.io.AbIOSystem;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.business.installer;

public class DeleteCloud
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public DeleteCloud()
    {
    }

    public virtual bool delete(string prePath, int current, int total)
    {
        try {
            if (AbIOSystem.getInstance().isType("com.vobject.appengine.java.io")) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append(URLGLOBALS.getWebappPath());
                stringBuffer.append(prePath);
                AbPath path = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
                AbFile file = AbFile.createAbFileFromAbPath(path);
                BasicArrayList fileBasicArrayList = Directory.getInstance().search(file, true);
                int size = fileBasicArrayList.size();
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Searched: ");
                stringBuffer.append(path.toFileSystemString());
                stringBuffer.append(" BasicArrayList: ");
                stringBuffer.appendint(size);
                int portion = size / total + 1;
                int start = portion * current;
                int end = start + portion;
                if (end > size) {
                    end = size;
                }
                stringBuffer.append(" Section: ");
                stringBuffer.appendint(start);
                stringBuffer.append(" - ");
                stringBuffer.appendint(end);
                this.logUtil.putF(stringBuffer.ToString(), this, "initialize()");
                AbFile nextFile = null;
                for (int index = start; index < end; index++) {
                    nextFile = ((AbFile) fileBasicArrayList.get(index));
                    try {
                        if (nextFile.getPath().indexOf(FileUploadData.getInstance().FILE) < 0) {
                            nextFile.delete();
                        }
                    } catch (Exception e) {
                    }
                }
                this.logUtil.putF("Deleted Files From Cloud", this, "initialize()");
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put("Unable to copy installer files into cloud", this, "initialize()", e);
            return false;
        }
    }

}

