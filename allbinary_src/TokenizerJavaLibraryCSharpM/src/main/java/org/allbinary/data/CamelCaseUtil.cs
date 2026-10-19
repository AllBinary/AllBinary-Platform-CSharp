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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.data;

public class CamelCaseUtil
{
    private static readonly CamelCaseUtil instance = new CamelCaseUtil();
    public static CamelCaseUtil getInstance()
    {
        return CamelCaseUtil.instance;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    // throws Exception
    public virtual string getAsCamelCase(string @string, StringMaker stringBuilder)
    {
        if (@string == null) {
            return StringUtil.getInstance().EMPTY_STRING;
        }
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        stringBuilder.delete(0, stringBuilder.length());
        BasicArrayList list = new BasicArrayListD();
        Tokenizer tokenizer = new Tokenizer(this.commonSeps.UNDERSCORE);
        tokenizer.getTokensFromString(@string, list);
        int size = list.size();
        string word = null;
        for (int i = 0; i < size; i++) {
            word = ((string) list.get(i));
            word = (stringValidationUtil.isEmpty(word) ? word : new StringMaker().appendchar(char.ToUpper(word[0])).append(word.Substring(1).ToLower()).ToString());
            stringBuilder.append(word);
        }
        return stringBuilder.ToString();
    }

}

