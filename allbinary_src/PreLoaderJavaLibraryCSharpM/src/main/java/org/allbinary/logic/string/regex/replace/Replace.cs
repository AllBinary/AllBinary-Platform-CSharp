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
using J2SEUtil = org.allbinary.J2SEUtil;
using AppUrlGlobals = org.allbinary.globals.AppUrlGlobals;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.@string.regex.replace;

public class Replace
{
    private readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly J2SEUtil j2seUtil = J2SEUtil.getInstance();
    private readonly string REPLACERS_ = "Replacers: ";
    private readonly string ALL = "all";
    private readonly string FOUND_KEY = "found key total: ";
    private readonly HashMap<object, object> hashMap;
    public Replace(string key, string value)
    {
        this.hashMap = StdUtil.getInstance().createHashMap();
        this.hashMap.put(new string[] { key }, new string[] { value });
    }

    public Replace(string[] keys, string[] values)
    {
        this.hashMap = StdUtil.getInstance().createHashMap();
        this.hashMap.put(keys, values);
    }

    public Replace(HashMap<object, object> hashMap)
    {
        this.hashMap = hashMap;
    }

    public virtual string all(string replace)
    {
        return this.upTo(replace, int.MinValue);
    }

    public virtual string upTo(string replace, int total)
    {
        StringMaker newStringBuffer = new StringMaker();
        int totalNumberOfReplaces = 0;
        string[] keys = null;
        string[] values = null;
        object[] keyArray = this.j2seUtil.getHashMapAsArray(this.hashMap);
        int size = keyArray.Length;
        for (int index2 = 0; index2 < size; index2++) {
            keys = ((string[]) keyArray[index2]);
            values = ((string[]) this.hashMap.get(keys));
            long foundTotal = 0L;
            int index = 0;
            string nextKey = null;
            int end = 0;
            string nextSecondKey = null;
            int begin2 = 0;
            while (index < replace.Length) {
                int begin = replace.IndexOf(keys[0], index);
                if (begin != -1) {
                    foundTotal++;
                    if (foundTotal % 100L == 0L) {
                        Console.WriteLine(this.FOUND_KEY + foundTotal);
                    }
                    nextKey = keys[0];
                    end = begin + nextKey.Length;
                    newStringBuffer.delete(0, newStringBuffer.length());
                    newStringBuffer.append(replace.Substring(0, (begin) - (0)));
                    newStringBuffer.append(values[0]);
                    index = newStringBuffer.length();
                    newStringBuffer.append(replace.Substring(end, (replace.Length) - (end)));
                    replace = newStringBuffer.ToString();
                    if (keys.Length > 1) {
                        nextSecondKey = keys[1];
                        begin2 = replace.IndexOf(nextSecondKey, index);
                        if (begin2 != -1) {
                            int end2 = begin2 + nextSecondKey.Length;
                            newStringBuffer.delete(0, newStringBuffer.length());
                            newStringBuffer.append(replace.Substring(0, (begin2) - (0)));
                            newStringBuffer.append(values[1]);
                            index = newStringBuffer.length();
                            newStringBuffer.append(replace.Substring(end2, (replace.Length) - (end2)));
                            replace = newStringBuffer.ToString();
                        }
                    }
                    totalNumberOfReplaces++;
                    if (total != int.MinValue && totalNumberOfReplaces >= total) {
                        break;
                    }
                } else {
                    break;
                }
            }
        }
        if (totalNumberOfReplaces > 0) {
            if (LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().REPLACE)) {
                this.logUtil.putF("Total Number Of Replaces: " + totalNumberOfReplaces, this, this.ALL);
            }
        }
        return replace;
    }

    public virtual string line(string replace)
    {
        StringMaker newStringBuffer = new StringMaker();
        int totalNumberOfReplaces = 0;
        string key = null;
        string value = null;
        object[] keyArray = this.j2seUtil.getHashMapAsArray(this.hashMap);
        int size = keyArray.Length;
        for (int index2 = 0; index2 < size; index2++) {
            key = ((string) keyArray[index2]);
            value = ((string) this.hashMap.get(key));
            int index = 0;
            while (index < replace.Length) {
                newStringBuffer.delete(0, newStringBuffer.length());
                int begin = replace.IndexOf(key, index);
                if (begin != -1) {
                    Console.WriteLine(this.FOUND_KEY);
                    int end = replace.IndexOf('\n', begin + key.Length) + 1;
                    if (end >= 0) {
                        newStringBuffer.append(replace.Substring(0, (begin) - (0)));
                        index = newStringBuffer.length();
                        newStringBuffer.append(replace.Substring(end, (replace.Length) - (end)));
                        replace = newStringBuffer.ToString();
                        totalNumberOfReplaces++;
                    }
                } else {
                    break;
                }
            }
        }
        if (LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().REPLACE)) {
            this.logUtil.putF("Total Number Of Replaces: " + totalNumberOfReplaces, this, this.ALL);
        }
        return replace;
    }

    public static void main(string[] args)
    {
        try {
            StringUtil stringUtil = StringUtil.getInstance();
            AppUrlGlobals appUrlGlobals = new AppUrlGlobals();
            appUrlGlobals.setWebappPath("G:/mnt/bc/mydev/work/allbinary_src/ToolsJavaLibrary/tools");
            URLGLOBALS.init(appUrlGlobals);
            string testString = "\"super gun\" big tank \"goodgunriflegun";
            Replace replace = new Replace("gun", "abcdefghijklmnopqrstuxwxyzabcdefghijklmnopqrstuxwxyz");
            Console.WriteLine("Old String: " + testString);
            testString = replace.all(testString);
            Console.WriteLine("New String: " + testString);
            Replace replaceCat = new Replace("abcdefghijklmnopqrstuxwxyzabcdefghijklmnopqrstuxwxyz", stringUtil.EMPTY_STRING);
            testString = replaceCat.all(testString);
            Console.WriteLine("New String: " + testString);
        } catch (Exception e) {
        }
    }

}

