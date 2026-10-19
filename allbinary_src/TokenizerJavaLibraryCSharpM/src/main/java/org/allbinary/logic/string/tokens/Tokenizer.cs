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
using TsUtil = org.allbinary.TsUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.@string.tokens;

public class Tokenizer
{
    private string sep;
    private string endSep = StringUtil.getInstance().EMPTY_STRING;
    public Tokenizer(string sep)
    {
        if (sep == null || TsUtil.getInstance().compareTo(sep, StringUtil.getInstance().EMPTY_STRING) == 0) {
            throw new Exception("Sep provided is not valid");
        }
        this.sep = sep;
    }

    public virtual void setSep(string sep)
    {
        this.sep = sep;
    }

    public virtual void setEndSep(string endSep)
    {
        this.endSep = endSep;
    }

    public virtual BasicArrayList getInsideSep(string @string)
    {
        BasicArrayList tokenList = new BasicArrayListD();
        int index = 0;
        int size = @string.Length;
        while (index < size) {
            index = @string.IndexOf(this.sep, index);
            if (index != -1) {
                int end = @string.IndexOf(this.endSep, index + this.sep.Length);
                if (end != -1) {
                    tokenList.add(@string.Substring(index + this.sep.Length, (end - (this.endSep.Length - 1)) - (index + this.sep.Length)));
                    index = end + this.endSep.Length;
                } else {
                }
            } else {
                break;
            }
        }
        return tokenList;
    }

    public virtual BasicArrayList getTokensFromString(string @string, BasicArrayList tokenVector)
    {
        int index = 0;
        int end = 0;
        while (index < @string.Length) {
            end = @string.IndexOf(this.sep, index);
            if (end != -1) {
                tokenVector.add(@string.Substring(index, (end) - (index)));
                index = end + this.sep.Length;
            } else {
                tokenVector.add(@string.Substring(index, (@string.Length) - (index)));
                break;
            }
        }
        return tokenVector;
    }

    public virtual ABHashtable<object, object> getTokens(BasicArrayList stringVector)
    {
        ABHashtable<object, object> tokenHashtable = StdUtil.getInstance().createHashtable();
        string @string = StringUtil.getInstance().EMPTY_STRING;
        int end = 0;
        int size = stringVector.size();
        for (int index = 0; index < size; index++) {
            @string = ((string) stringVector.objectArray[index]);
            end = @string.IndexOf(this.sep);
            if (end >= 0) {
                tokenHashtable.put(@string.Substring(0, (end) - (0)), @string.Substring(end + 1, (@string.Length) - (end + 1)));
            }
        }
        return tokenHashtable;
    }

}

