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
//using DataInputStream = java.io.DataInputStream;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using FileStreamFactory = org.allbinary.logic.io.FileStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.logic.system.security.licensing.registration;

public class RegistrationConfiguration
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly RegistrationConfiguration SINGLETON = new RegistrationConfiguration();
    private string registrationCode = "No Registration Code";
    public readonly string NAME = "registrationid";
    private readonly string FILE = "Registration.dat";
    private RegistrationConfiguration()
    {
        try {
            if (FileFactory.getInstance().isFile(this.FILE)) {
                this.read();
            } else {
                this.write();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    public static RegistrationConfiguration getInstance()
    {
        return RegistrationConfiguration.SINGLETON;
    }

    // throws Exception
    private void read()
    {
        FileStreamFactory fileInputStreamFactory = FileStreamFactory.getInstance();
        InputStream fileInputStream = fileInputStreamFactory.getFileInputStreamInstance(StringUtil.getInstance().EMPTY_STRING, this.FILE);
        DataInputStream dataInputStream = new DataInputStream(fileInputStream);
        this.setRegistrationCode(dataInputStream.readUTF());
        PreLogUtil.put(new StringMaker().append("Read Configuration: ").append(this.ToString()).ToString(), this, "read");
    }

    // throws Exception
    public virtual void write()
    {
        AbDataOutputStream dataOutputStream = null;
        try {
            this.logUtil.putF(new StringMaker().append("Write Configuration: ").append(this.ToString()).ToString(), this, "write");
            FileStreamFactory fileInputStreamFactory = FileStreamFactory.getInstance();
            OutputStream fileOutputStream = fileInputStreamFactory.getFileOutputStreamInstance(StringUtil.getInstance().EMPTY_STRING, this.FILE);
            dataOutputStream = new AbDataOutputStream(fileOutputStream);
            dataOutputStream.writeUTF(this.getRegistrationCode());
            dataOutputStream.flush();
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
        }
    }

    public override string ToString()
    {
        return new StringMaker().append("Registration Code: ").append(this.getRegistrationCode()).ToString();
    }

    public virtual void setRegistrationCode(string registrationCode)
    {
        this.registrationCode = registrationCode;
    }

    public virtual string getRegistrationCode()
    {
        return this.registrationCode;
    }

}

