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
using System.Runtime.CompilerServices;
//using IOException = java.io.IOException;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDataInputStream = org.allbinary.logic.io.AbDataInputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.generator;

public class UniqueIdGenerator : IdGeneratorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string EXT = ".unq";
    private AbFile newFile = null;
    private long id = 0L;
    public UniqueIdGenerator()
    {
    }

    public virtual void initialize(int value)
    {
        try {
            this.newFile.createNewFile();
            AbDataOutputStream idData = DataOutputStreamFactory.getInstance().getInstanceForAbFile(this.newFile);
            idData.writeLong(value);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "initialize", e);
            }
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setFile(string filePathName, string name)
    {
        this.newFile = AbFile.createAbFile(filePathName);
    }

    // throws IOException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string getNext()
    {
        AbDataInputStream idData = null;
        AbDataOutputStream idOutData = null;
        try {
            AbFileInputStream idFile = new AbFileInputStream(this.newFile);
            idData = new AbDataInputStream(idFile);
            this.id = idData.readLong();
            AbFileOutputStream idOutFile = AbFileOutputStream.createFromAbFile(this.newFile);
            idOutData = new AbDataOutputStream(idOutFile);
            idOutData.writeLong(this.id + 1L);
            long? idLong = this.id;
            return idLong.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "getNext", e);
            }
            return "Error";
        } finally {
            StreamUtil.getInstance().close(idData);
            StreamUtil.getInstance().close(idOutData);
        }
    }

}

