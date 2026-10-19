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

namespace org.allbinary.logic.system.hardware.components.linux;

public class CpuInfo
{
    private string name;
    private CpuInfo(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return this.name;
    }

    public static readonly CpuInfo PROCESSOR = new CpuInfo("processor");
    public static readonly CpuInfo VENDORID = new CpuInfo("vendor_id");
    public static readonly CpuInfo CPUFAMILY = new CpuInfo("cpu family");
    public static readonly CpuInfo MODEL = new CpuInfo("model");
    public static readonly CpuInfo MODELNAME = new CpuInfo("model name");
    public static readonly CpuInfo STEPPING = new CpuInfo("stepping");
    public static readonly CpuInfo CPUMHZ = new CpuInfo("cpu MHz");
    public static readonly CpuInfo CACHESIZE = new CpuInfo("cache size");
    public static readonly CpuInfo FDIVBUG = new CpuInfo("fdiv_bug");
    public static readonly CpuInfo HLTBUG = new CpuInfo("hlt_bug");
    public static readonly CpuInfo F00FBUG = new CpuInfo("f00f_bug");
    public static readonly CpuInfo COMABUG = new CpuInfo("coma_bug");
    public static readonly CpuInfo FPU = new CpuInfo("fpu");
    public static readonly CpuInfo FPUEXCEPTION = new CpuInfo("fpu_exception");
    public static readonly CpuInfo CPUIDLEVEL = new CpuInfo("cache size");
    public static readonly CpuInfo WP = new CpuInfo("yes");
    public static readonly CpuInfo FLAGS = new CpuInfo("flags");
    public static readonly CpuInfo BOGOMIPS = new CpuInfo("bogomips");
}

