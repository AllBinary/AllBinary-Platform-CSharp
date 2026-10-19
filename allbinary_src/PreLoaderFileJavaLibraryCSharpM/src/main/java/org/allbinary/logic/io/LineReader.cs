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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.io;

public class LineReader
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string fileName = null;
    private string @string = null;
    private int index = 0;
    private AbFileInputStream idFile = null;
    private DataInputStream idData = null;
    public LineReader(string fileName)
    {
        try {
            sbyte[] bytes = new sbyte[100000];
            this.fileName = fileName;
            this.idFile = new AbFileInputStream(fileName);
            this.idFile.read(bytes);
            this.@string = System.Text.Encoding.UTF8.GetString((byte[]) (Array) bytes);
        } catch (Exception e) {
            this.logUtil.put("File: " + fileName, this, "LineReader", e);
            {
            }
        }
    }

    public virtual bool hasNext()
    {
        try {
            int nextIndex = this.@string.IndexOf(CommonSeps.getInstance().NEW_LINE, index);
            if (nextIndex == -1) {
                return false;
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, "hasNext", e);
            {
            }
            return false;
        }
    }

    // throws Exception
    public virtual string next()
    {
        try {
            int nextIndex = this.@string.IndexOf(CommonSeps.getInstance().NEW_LINE, index);
            if (nextIndex == -1) {
                throw new Exception("next() should have been called first");
            }
            string temp = this.@string.Substring(index, (nextIndex) - (index));
            index = nextIndex + 1;
            return temp;
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, "next", e);
            {
            }
            throw e;
        }
    }

}

