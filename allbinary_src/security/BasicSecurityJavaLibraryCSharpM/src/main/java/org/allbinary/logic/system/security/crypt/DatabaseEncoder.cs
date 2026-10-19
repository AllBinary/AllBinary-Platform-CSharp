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
using NullUtil = org.allbinary.logic.NullUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.system.security.crypt;

public class DatabaseEncoder
{
    private DatabaseEncoder()
    {
    }

    public static string encode(sbyte[] value)
    {
        try {
            sbyte[] array = value;
            StringMaker stringBuffer = new StringMaker();
            for (int index = 0; index < array.Length; index++) {
                stringBuffer.append(array[index].ToString());
                if (index < array.Length - 1) {
                    stringBuffer.append(CommonSeps.getInstance().SPACE);
                }
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, "DatabaseEncoder", "decode", e);
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

    public static sbyte[] decode(string value)
    {
        try {
            Tokenizer tokenizer = new Tokenizer(CommonSeps.getInstance().SPACE);
            BasicArrayList vector = tokenizer.getTokensFromString(value, new BasicArrayListD());
            BasicArrayList byteVector = new BasicArrayListD();
            int size = vector.size();
            string byteOfData = null;
            for (int index = 0; index < size; index++) {
                byteOfData = ((string) vector.objectArray[index]);
                byteVector.add(byteOfData);
            }
            sbyte[] decode = new sbyte[byteVector.size()];
            int decodeIndex = 0;
            sbyte? aByte = null;
            for (int index = 0; index < size; index++) {
                aByte = ((sbyte?) byteVector.objectArray[index]);
                decode[decodeIndex] = ((sbyte) aByte);
                decodeIndex++;
            }
            return decode;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putSE(commonStrings.EXCEPTION, "DatabaseEncoder", "decode", e);
            return NullUtil.getInstance().NULL_BYTE_ARRAY;
        }
    }

}

