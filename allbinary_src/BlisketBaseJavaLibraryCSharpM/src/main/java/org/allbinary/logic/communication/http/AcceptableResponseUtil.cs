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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TsUtil = org.allbinary.TsUtil;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.communication.http;

public class AcceptableResponseUtil
{
    private static readonly AcceptableResponseUtil instance = new AcceptableResponseUtil();
    public static AcceptableResponseUtil getInstance()
    {
        return AcceptableResponseUtil.instance;
    }

    static AcceptableResponseUtil()
    {
        TsUtil.getInstance().hashCode(AcceptableResponseFactory.getInstance().HTML);
    }
    public readonly BasicArrayList candidateVector = new BasicArrayListD();
    public readonly BasicArrayList tagNameVector = new BasicArrayListD();
    public virtual string get(int index)
    {
        return ((string) this.candidateVector.get(index));
    }

    public virtual string getTagName(int index)
    {
        return ((string) this.tagNameVector.get(index));
    }

    public virtual int size()
    {
        return this.candidateVector.size();
    }

}

