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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.communication.java.vm.stats;

public class JvmStatisticsMapping : JvmStatistics, TableMappingInterface
{
    public JvmStatisticsMapping() : base()
    {
        // base() is called from the constructor declaration
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(JvmStatisticsData.FREE_MEMORY_BYTES, this.getFreeMemoryBytesString());
        hashMap.put(JvmStatisticsData.FREE_MEMORY_KILOBYTES, this.getFreeMemoryKilobytesString());
        hashMap.put(JvmStatisticsData.FREE_MEMORY_MEGABYTES, this.getFreeMemoryMegabytesString());
        hashMap.put(JvmStatisticsData.MAX_MEMORY_BYTES, this.getMaxMemoryBytesString());
        hashMap.put(JvmStatisticsData.MAX_MEMORY_KILOBYTES, this.getMaxMemoryKilobytesString());
        hashMap.put(JvmStatisticsData.MAX_MEMORY_MEGABYTES, this.getMaxMemoryMegabytesString());
        hashMap.put(JvmStatisticsData.NUMBER_OF_THREADS, this.getNumberOfThreadsString());
        hashMap.put(JvmStatisticsData.TOTAL_MEMORY_BYTES, this.getTotalMemoryBytesString());
        hashMap.put(JvmStatisticsData.TOTAL_MEMORY_KILOBYTES, this.getTotalMemoryKilobytesString());
        hashMap.put(JvmStatisticsData.TOTAL_MEMORY_MEGABYTES, this.getTotalMemoryMegabytesString());
        return hashMap;
    }

    // throws Exception
    public virtual object getKey()
    {
        return JvmStatisticsData.NAME;
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.add(this.getFreeMemoryBytesString());
        vector.add(this.getFreeMemoryKilobytesString());
        vector.add(this.getFreeMemoryMegabytesString());
        vector.add(this.getMaxMemoryBytesString());
        vector.add(this.getMaxMemoryKilobytesString());
        vector.add(this.getMaxMemoryMegabytesString());
        vector.add(this.getNumberOfThreadsString());
        vector.add(this.getTotalMemoryBytesString());
        vector.add(this.getTotalMemoryKilobytesString());
        vector.add(this.getTotalMemoryMegabytesString());
        return vector;
    }

}

