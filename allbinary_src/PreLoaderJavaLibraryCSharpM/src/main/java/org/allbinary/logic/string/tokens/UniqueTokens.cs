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
using java.util;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.@string.tokens;

public class UniqueTokens
{
    private readonly BasicArrayList specialCharacters = new BasicArrayListD();
    public UniqueTokens()
    {
        this.specialCharacters.add("!");
        this.specialCharacters.add("@");
        this.specialCharacters.add(CommonPhoneStrings.getInstance().POUND);
        this.specialCharacters.add("$");
        this.specialCharacters.add("%");
        this.specialCharacters.add("^");
        this.specialCharacters.add(CommonSeps.getInstance().AMPERSAND);
        this.specialCharacters.add(CommonPhoneStrings.getInstance().STAR);
        this.specialCharacters.add("(");
        this.specialCharacters.add(")");
        this.specialCharacters.add("-");
        this.specialCharacters.add("_");
        this.specialCharacters.add("+");
        this.specialCharacters.add("=");
        this.specialCharacters.add("\\");
        this.specialCharacters.add("|");
        this.specialCharacters.add(AbPathData.getInstance().EXTENSION_SEP);
        this.specialCharacters.add(",");
        this.specialCharacters.add("<");
        this.specialCharacters.add(">");
        this.specialCharacters.add("?");
        this.specialCharacters.add("/");
        this.specialCharacters.add("~");
        this.specialCharacters.add("`");
    }

    // throws Exception
    public virtual HashSet getWhithoutDashesAndSkipNumberOnlyTokens(BasicArrayList stringVector)
    {
        try {
            HashSet hashSet = new HashSet();
            int index = 0;
            CommonSeps commonSeps = CommonSeps.getInstance();
            while (index < stringVector.size()) {
                string keywords = ((string) stringVector.get(index));
                Tokenizer tokenizer = new Tokenizer(commonSeps.COMMA);
                BasicArrayList keywordVector = tokenizer.getTokensFromString(keywords, new BasicArrayListD());
                for (int forIndex = 0; forIndex < keywordVector.size(); forIndex++) {
                    string cleanString = ((string) keywordVector.get(forIndex));
                    cleanString = cleanString.Trim();
                    if (cleanString.IndexOf('-') != -1) {
                        cleanString = new Replace("-", commonSeps.SPACE).all(cleanString);
                    }
                    hashSet.add(cleanString);
                    if (cleanString.IndexOf(' ') != -1) {
                        Tokenizer spaceTokenizer = new Tokenizer(commonSeps.SPACE);
                        BasicArrayList subKeywordVector = spaceTokenizer.getTokensFromString(cleanString, new BasicArrayListD());
                        for (int spaceIndex = 0; spaceIndex < subKeywordVector.size(); spaceIndex++) {
                            string subCleanString = ((string) subKeywordVector.get(spaceIndex));
                            if (!isSpecialCharacter(subCleanString) && !numberOnly(subCleanString)) {
                                hashSet.add(subCleanString);
                            }
                        }
                    }
                }
                index++;
            }
            return hashSet;
        } catch (Exception e) {
            throw e;
        }
    }

    private bool numberOnly(string subCleaningString)
    {
        try {
            int.Parse(subCleaningString);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    private bool isSpecialCharacter(string subCleaningString)
    {
        for (int index = 0; index < this.specialCharacters.size(); index++) {
            if (string.CompareOrdinal(subCleaningString, ((string) this.specialCharacters.get(index))) == 0) {
                return true;
            }
        }
        return false;
    }

}

