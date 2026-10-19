// Generated Code Do Not Modify

using System;
using System.Linq;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.util.cache;

public class CacheTypeFactory
{
    private static readonly CacheTypeFactory instance = new CacheTypeFactory();
    public static CacheTypeFactory getInstance()
    {
        return CacheTypeFactory.instance;
    }

    public CacheType NO_CACHE = new CacheType(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING);
    public CacheType CACHE = new CacheType(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING);
    public CacheType SET = new CacheType(StringUtil.getInstance().EMPTY_STRING, "Set");
    public CacheType CACHE_VECTOR = new CacheType(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING);
}

