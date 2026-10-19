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
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileStreamFactory = org.allbinary.logic.io.FileStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using SimpleFileUtil = org.allbinary.logic.io.file.SimpleFileUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

public class LicenseServerInitFileUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly OutputStream NULL_OUTPUT_STREAM = SimpleFileUtil.nullOutputStream();
    public void init()
    {
        try {
            string filePath = LicenseInitInfoUtil.getInstance().INITFILENAME;
            LicenseInitInfoUtil.getInstance().setFilePath(StringUtil.getInstance().EMPTY_STRING);
            if (FileFactory.getInstance().isFile(filePath)) {
                this.logUtil.putF("Using Existing License File", this, this.commonStrings.INIT);
            } else {
                this.write();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

    private void write()
    {
        OutputStream fileOutputStream = this.NULL_OUTPUT_STREAM;
        try {
            ResourceUtil resourceUtil = ResourceUtil.getInstance();
            string filePath = LicenseInitInfoUtil.getInstance().INITFILENAME;
            InputStream inputStream = resourceUtil.getResourceAsStream(filePath);
            this.logUtil.putF("Writing Default License File", this, this.commonStrings.INIT);
            FileStreamFactory fileStreamFactory = FileStreamFactory.getInstance();
            fileOutputStream = fileStreamFactory.getFileOutputStreamInstance(StringUtil.getInstance().EMPTY_STRING, filePath);
            int b = 0;
            int index = 0;
            while (true) {
                b = inputStream.read();
                if (b == -1) {
                    break;
                }
                fileOutputStream.write(b);
                index++;
            }
            this.logUtil.putF("Wrote Bytes: " + index, this, this.commonStrings.INIT);
            fileOutputStream.flush();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        } finally {
            StreamUtil.getInstance().close(fileOutputStream);
        }
    }

}

