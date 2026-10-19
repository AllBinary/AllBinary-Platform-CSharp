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
//using ZipEntry = java.util.zip.ZipEntry;
//using ZipInputStream = java.util.zip.ZipInputStream;
//using ZipOutputStream = java.util.zip.ZipOutputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using AbFileOutputStream = org.allbinary.logic.io.AbFileOutputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.io.file.zip;

public class ZipFileUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ZipFileUtil instance = new ZipFileUtil();
    public static ZipFileUtil getInstance()
    {
        return ZipFileUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual void create(string outFilename, BasicArrayList fileBasicArrayList)
    {
        try {
            AbFile zipFile = AbFile.createAbFile(outFilename);
            if (zipFile.exists()) {
                zipFile.delete();
            }
            zipFile.createNewFile();
            ZipOutputStream outputStream = new ZipOutputStream(AbFileOutputStream.createFromAbFile(zipFile));
            StreamUtil streamUtil = StreamUtil.getInstance();
            StringMaker stringBuffer = new StringMaker();
            sbyte[] byteArray = new sbyte[16384];
            AbFileInputStream fileInputStream = null;
            int size = fileBasicArrayList.size();
            int current = 0;
            for (int i = 0; i < size; i++) {
                AbFile file = ((AbFile) fileBasicArrayList.get(i));
                if (file.isDirectory()) {
                } else if (file.isFile()) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.appendint(current);
                    stringBuffer.append(" Creating Zip File Entry: ");
                    stringBuffer.append(file.getPath());
                    this.logUtil.putF(stringBuffer.ToString(), this, "create()");
                    try {
                        fileInputStream = new AbFileInputStream(file);
                        outputStream.putNextEntry(new ZipEntry(file.getPath()));
                        streamUtil.get(fileInputStream, outputStream, byteArray);
                        outputStream.closeEntry();
                        streamUtil.close(fileInputStream);
                    } catch (Exception e) {
                        this.logUtil.putF("Skipping File (Probably Local): " + file.getPath(), this, "create()");
                    }
                }
                current++;
            }
            streamUtil.close(outputStream);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "create", e);
        }
    }

    // throws Exception
    public virtual void unzip(string path, AbFile zipFile, string fileName)
    {
        sbyte[] buffer = new sbyte[16384];
        ZipInputStream inputStream = null;
        try {
            inputStream = new ZipInputStream(new AbFileInputStream(zipFile));
            ZipEntry zipEntry = null;
            StringMaker stringBuffer = new StringMaker();
            FileUtil fileUtil = FileUtil.getInstance();
            while (((zipEntry = inputStream.getNextEntry())) != null) {
                string entryName = zipEntry.getName();
                if (zipEntry.isDirectory()) {
                } else {
                    AbFile entryFile = AbFile.createAbFile(path + entryName);
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append("ZipEntry Name: ");
                    stringBuffer.append(entryName);
                    stringBuffer.append(" isFile: ");
                    stringBuffer.appendboolean(entryFile.isFile());
                    stringBuffer.append(" isDirectory: ");
                    stringBuffer.appendboolean(entryFile.isDirectory());
                    stringBuffer.append(" getParent: ");
                    stringBuffer.append(entryFile.getParent());
                    this.logUtil.putF(stringBuffer.ToString(), this, "unzip");
                    AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(entryFile);
                    fileUtil.write(inputStream, dataOutputStream, buffer);
                }
                inputStream.closeEntry();
            }
        } finally {
            StreamUtil.getInstance().close(inputStream);
        }
    }

}

