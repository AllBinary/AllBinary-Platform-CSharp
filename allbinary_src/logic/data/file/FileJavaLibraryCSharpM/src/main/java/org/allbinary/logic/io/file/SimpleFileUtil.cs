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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
//using Reader = java.io.Reader;
//using Writer = java.io.Writer;
//using CharBuffer = java.nio.CharBuffer;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
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
        return new OutputStream()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws IOException
            public virtual void write(int b)
            {
            }

            // throws IOException
            public virtual void write(sbyte[] b, int off, int len)
            {
            }

            public virtual void close()
            {
            }

#endif
;
    }

    public static Writer nullWriter()
    {
        return new Writer()
#if JAVA_ANONYMOUS_CLASS_BODY
            private bool closed = false;
            // throws IOException
            public virtual Writer append(char c)
            {
                return this;
            }

            // throws IOException
            public virtual Writer append(CharSequence csq)
            {
                return this;
            }

            // throws IOException
            public virtual Writer append(CharSequence csq, int start, int end)
            {
                return this;
            }

            // throws IOException
            public virtual void write(int c)
            {
            }

            // throws IOException
            public virtual void write(char[] cbuf, int off, int len)
            {
            }

            // throws IOException
            public virtual void write(string str)
            {
            }

            // throws IOException
            public virtual void write(string str, int off, int len)
            {
            }

            // throws IOException
            public virtual void flush()
            {
            }

            // throws IOException
            public virtual void close()
            {
            }

#endif
;
    }

    public static Reader nullReader()
    {
        return new Reader()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws IOException
            public virtual int read()
            {
                return -1;
            }

            // throws IOException
            public virtual int read(char[] cbuf, int off, int len)
            {
                return -1;
            }

            // throws IOException
            public virtual int read(CharBuffer target)
            {
                return -1;
            }

            // throws IOException
            public virtual bool ready()
            {
                return false;
            }

            // throws IOException
            public virtual long skip(long n)
            {
                return 0L;
            }

            public virtual void close()
            {
            }

#endif
;
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
            System.IO.MemoryStream outputStream2 = new System.IO.MemoryStream(max);
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
            while (index < size - 1 && byteArray[index] != ((sbyte) '\n')) {
                index++;
            }
            if (includeReturnLine == 0) {
                if (index > 0 && byteArray[index - 1] == ((sbyte) '\r')) {
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

