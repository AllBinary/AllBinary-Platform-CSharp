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
//using FileReader = java.io.FileReader;
//using LineNumberReader = java.io.LineNumberReader;
using java.util;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using SubDirectory = org.allbinary.logic.io.file.directory.SubDirectory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CpuInterface = org.allbinary.logic.system.hardware.components.interfaces.CpuInterface;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.hardware.components.linux;

public class Cpu : CpuInterface, HardwareComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string CPUFILE = "/proc/cpuinfo";
    private HashMap<object, object> cpuHashMap = null;
    public Cpu(string filePath)
    {
        this.init(filePath);
    }

    public Cpu()
    {
        this.init(this.CPUFILE);
    }

    // throws Exception
    private void init(string filePath)
    {
        LineNumberReader lineNumberReader = null;
        try {
            this.init(lineNumberReader, filePath);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                this.logUtil.put(new StringMaker().append("Cpu Data: ").append(this.ToString()).ToString(), this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw e;
        }
    }

    // throws Exception
    private void init(LineNumberReader lineNumberReader, string filePath)
    {
        try {
            FileReader fileReader = new FileReader(filePath);
            lineNumberReader = new LineNumberReader(fileReader);
            this.cpuHashMap = StdUtil.getInstance().createHashMap();
            if (lineNumberReader == null) {
                BasicArrayList fileVector = SubDirectory.getInstance().search(filePath, AbFile.createAbFile(FilePathData.getInstance().PATH_START));
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().OS)) {
                    this.logUtil.putF(new StringMaker().append("Cpu File BasicArrayList Size: ").appendint(fileVector.size()).ToString(), this, this.commonStrings.CONSTRUCTOR);
                }
                if (!fileVector.isEmpty()) {
                    AbFile file = ((AbFile) fileVector.get(0));
                    lineNumberReader = new LineNumberReader(new FileReader(file.getPath()));
                }
            }
            if (lineNumberReader != null) {
                string nextLine = lineNumberReader.readLine();
                while (lineNumberReader != null && nextLine != null) {
                    int index = nextLine.IndexOf(':');
                    if (index >= 0) {
                        string key = nextLine.Substring(0, (index) - (0));
                        int valueIndex = index + 1;
                        string value = nextLine.Substring(valueIndex, (nextLine.Length) - (valueIndex));
                        if (key.IndexOf(CpuInfo.PROCESSOR.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.PROCESSOR, value);
                        }
                        if (key.IndexOf(CpuInfo.VENDORID.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.VENDORID, value);
                        }
                        if (key.IndexOf(CpuInfo.CPUFAMILY.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.CPUFAMILY, value);
                        }
                        if (key.IndexOf(CpuInfo.MODEL.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.MODEL, value);
                        }
                        if (key.IndexOf(CpuInfo.MODELNAME.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.MODELNAME, value);
                        }
                        if (key.IndexOf(CpuInfo.STEPPING.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.STEPPING, value);
                        }
                        if (key.IndexOf(CpuInfo.CPUMHZ.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.CPUMHZ, value);
                        }
                        if (key.IndexOf(CpuInfo.CACHESIZE.ToString()) >= 0) {
                            this.cpuHashMap.put(CpuInfo.CACHESIZE, value);
                        }
                    }
                    nextLine = lineNumberReader.readLine();
                }
            }
        } finally {
            if (lineNumberReader != null) {
                lineNumberReader.close();
            }
        }
    }

    public virtual string getProcessor()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.PROCESSOR));
    }

    public virtual string getVendorId()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.VENDORID));
    }

    public virtual string getCpuFamily()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.CPUFAMILY));
    }

    public virtual string getModel()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.MODEL));
    }

    public virtual string getModelName()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.MODELNAME));
    }

    public virtual string getStepping()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.STEPPING));
    }

    public virtual string getCpuSpeed()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.CPUMHZ));
    }

    public virtual string getCacheSize()
    {
        return ((string) this.cpuHashMap.get(CpuInfo.CACHESIZE));
    }

    public virtual bool compareTo(CpuInterface cpuInterface)
    {
        return true;
    }

    public virtual bool compareTo(HardwareComponentInterface componentInterface)
    {
        return true;
    }

    public override string ToString()
    {
        CommonLabels commonLabels = CommonLabels.getInstance();
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringMaker = new StringMaker();
        stringMaker.append(CpuInfo.PROCESSOR.ToString()).append(commonLabels.COLON_SEP).append(this.getProcessor());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.VENDORID.ToString()).append(commonLabels.COLON_SEP).append(this.getVendorId());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.CPUFAMILY.ToString()).append(commonLabels.COLON_SEP).append(this.getCpuFamily());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.MODEL.ToString()).append(commonLabels.COLON_SEP).append(this.getModel());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.MODELNAME.ToString()).append(commonLabels.COLON_SEP).append(this.getModelName());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.STEPPING.ToString()).append(commonLabels.COLON_SEP).append(this.getStepping());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.CPUMHZ.ToString()).append(commonLabels.COLON_SEP).append(this.getCpuSpeed());
        stringMaker.append(commonSeps.NEW_LINE);
        stringMaker.append(CpuInfo.CACHESIZE.ToString()).append(commonLabels.COLON_SEP).append(this.getCacheSize());
        return stringMaker.ToString();
    }

}

