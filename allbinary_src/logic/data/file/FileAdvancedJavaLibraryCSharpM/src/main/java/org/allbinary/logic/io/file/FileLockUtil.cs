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
//using FileChannel = java.nio.channels.FileChannel;
//using FileLock = java.nio.channels.FileLock;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using StreamUtil = org.allbinary.logic.io.StreamUtil;

namespace org.allbinary.logic.io.file;

public class FileLockUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly FileLockUtil instance = new FileLockUtil();
    public static FileLockUtil getInstance()
    {
        return FileLockUtil.instance;
    }

    private FileLockUtil()
    {
    }

    // throws Exception
    public virtual BasicArrayList getAll(BasicArrayList vector, bool isReturnOnFailure)
    {
        BasicArrayList fileLockVector = new BasicArrayListD();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            AbFile file = ((AbFile) vector.get(index));
            FileLock fileLock = this.getLock(file);
            if (fileLock != null) {
                this.logUtil.putF("File Lock Obtained: " + file.getAbsolutePath(), this, "getAll");
                fileLockVector.add(fileLock);
            } else if (isReturnOnFailure) {
                this.logUtil.putF("Total Locks Obtained: " + fileLockVector.size(), this, "getAll");
                return fileLockVector;
            }
        }
        this.logUtil.putF("Total Locks Obtained: " + fileLockVector.size(), this, "getAll");
        return fileLockVector;
    }

    // throws Exception
    public virtual BasicArrayList getAllPossible(BasicArrayList vector)
    {
        return this.getAll(vector, false);
    }

    // throws Exception
    public virtual BasicArrayList getAllOrNone(BasicArrayList vector)
    {
        BasicArrayList fileLockVector = this.getAll(vector, true);
        if (vector.size() != fileLockVector.size()) {
            return new BasicArrayListD();
        } else {
            return fileLockVector;
        }
    }

    // throws Exception
    public virtual FileLock getLock(AbFile file)
    {
        try {
            return this.getLock(AbFileOutputStream.createFromAbFileAppend(file, true));
        } catch (Exception e) {
            this.logUtil.put("Exception returns null", this, "getLock", e);
            return null;
        } finally {
        }
    }

    // throws Exception
    public virtual FileLock getLock(AbFileOutputStream fileOutputStream)
    {
        try {
            FileLock fileLock = this.getLock(fileOutputStream.getChannel());
            return fileLock;
        } catch (Exception e) {
            this.logUtil.put("Exception returns null", this, "getLock", e);
            return null;
        } finally {
            this.logUtil.putF("Finally - Closing FileOutputStream", this, "getLock");
            StreamUtil.getInstance().close(fileOutputStream);
        }
    }

    // throws Exception
    public virtual FileLock getLock(FileChannel fileChannel)
    {
        try {
            FileLock fileLock = fileChannel.tryLock();
            return fileLock;
        } catch (Exception e) {
            this.logUtil.put("Exception returns null", this, "getLock", e);
            return null;
        } finally {
            this.logUtil.putF("Finally - Closing FileChannel", this, "getLock");
            fileChannel.close();
        }
    }

}

