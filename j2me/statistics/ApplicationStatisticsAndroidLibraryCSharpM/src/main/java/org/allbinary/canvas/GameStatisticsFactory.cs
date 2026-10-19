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

namespace org.allbinary.canvas;

//ActualPlatform
public class GameStatisticsFactory : AndroidGameStatistics
{
    private static readonly AndroidGameStatistics SINGLETON = new GameStatisticsFactory();
    public static AndroidGameStatistics getInstance()
    {
        return GameStatisticsFactory.SINGLETON;
    }

    private StringMaker stringBuffer = new StringMaker();
    public override void add(string @string)
    {
        if (this.stringBuffer.length() > 12000) {
            this.stringBuffer.delete(0, this.stringBuffer.length());
            this.stringBuffer.append("Old Stats Cleared");
        }
        this.stringBuffer.append(@string);
    }

    public override string ToString()
    {
        return new StringMaker().append(base.ToString()).append(this.stringBuffer.ToString()).ToString();
    }

}

