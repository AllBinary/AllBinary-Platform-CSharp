/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
using InputStream = java.io.InputStream;
using OutputStream = java.io.OutputStream;
using Reader = java.io.Reader;
using Writer = java.io.Writer;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using NullOutputStream = org.allbinary.logic.io.NullOutputStream;
using NullReader = org.allbinary.logic.io.NullReader;
using NullWriter = org.allbinary.logic.io.NullWriter;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.io.file;

public class SimpleFileUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SimpleFileUtil instance = new SimpleFileUtil();
    public static SimpleFileUtil getInstance()
    {
        return SimpleFileUtil.instance;
    }

    public static OutputStream nullOutputStream()
    {
        return NullOutputStream.NULL_OUTPUT_STREAM;
    }

    public static Writer nullWriter()
    {
        return NullWriter.NULL_WRITER;
    }

    public static Reader nullReader()
    {
        return NullReader.NULL_READER;
    }

    public readonly Writer NULL_WRITER = SimpleFileUtil.nullWriter();
    public readonly Reader NULL_READER = SimpleFileUtil.nullReader();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly NullUtil nullUtil = NullUtil.getInstance();
    private readonly StreamUtil streamUtil = StreamUtil.getInstance();
    public virtual BasicArrayList loadFileAsList(InputStream inputStream, int max, sbyte[] byteArray1)
    {
        return this.loadFileAsListReturnLine(inputStream, max, byteArray1, 0);
    }

    public virtual BasicArrayList loadFileAsListReturnLine(InputStream inputStream, int max, sbyte[] byteArray1, int includeReturnLine)
    {
        BasicArrayList stringList = new BasicArrayListD();
        if (inputStream == null) {
            return stringList;
        }
        sbyte[] byteArray = this.nullUtil.NULL_BYTE_ARRAY;
        try {
            ByteArrayOutputStream outputStream2 = new ByteArrayOutputStream(max);
            byteArray = this.streamUtil.getByteArray(inputStream, outputStream2, byteArray1);
            this.streamUtil.close(inputStream);
        } catch (Exception e) {
            this.streamUtil.close(inputStream);
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
        }
        if (byteArray == null) {
            return stringList;
        }
        int size = byteArray.Length;
        int index = 0;
        int startIndex = 0;
        int returnLine = 0;
        while (index < size) {
            startIndex = index;
            while (index < size - 1 && byteArray[index] != unchecked(((sbyte) '\n'))) {
                index++;
            }
            if (includeReturnLine == 0) {
                if (index > 0 && byteArray[index - 1] == unchecked(((sbyte) '\r'))) {
                    returnLine = 1;
                } else {
                    returnLine = 0;
                }
            }
            string s = System.Text.Encoding.UTF8.GetString((byte[]) (Array) byteArray, startIndex, (index + includeReturnLine - returnLine - startIndex));
            stringList.add(s);
            index++;
        }
        return stringList;
    }

    public virtual string createStringFromArrayOfStrings(string[] stringArray)
    {
        StringMaker stringMaker = new StringMaker();
        int size = stringArray.Length;
        for (int index = 0; index < size; index++) {
            stringMaker.append(stringArray[index]);
        }
        return stringMaker.ToString();
    }

}

