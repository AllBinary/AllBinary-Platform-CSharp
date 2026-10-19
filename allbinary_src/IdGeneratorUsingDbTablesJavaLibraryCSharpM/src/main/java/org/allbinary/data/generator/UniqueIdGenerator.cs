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
using System.Runtime.CompilerServices;
//using IOException = java.io.IOException;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using IdGeneratorEntity = org.allbinary.data.tables.generator.IdGeneratorEntity;
using IdGeneratorEntityFactory = org.allbinary.data.tables.generator.IdGeneratorEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.data.generator;

public class UniqueIdGenerator : IdGeneratorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string EXT = ".unq";
    private readonly IdGeneratorEntity idGeneratorEntity;
    private string name = null;
    public UniqueIdGenerator()
    {
        this.idGeneratorEntity = ((IdGeneratorEntity) IdGeneratorEntityFactory.getInstance());
    }

    public virtual void initialize(int value)
    {
        try {
            BasicArrayList vector = new BasicArrayListD();
            vector.add(this.name);
            vector.add((value).ToString().ToString());
            this.idGeneratorEntity.insert(vector);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "initialize", e);
            }
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setFile(string filePathName, string name)
    {
        this.name = name;
    }

    // throws IOException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string getNext()
    {
        try {
            long? idLong = this.idGeneratorEntity.get(this.name);
            long? newValue = (((long) idLong) + 1).ToString();
            this.idGeneratorEntity.update(this.name, newValue);
            return idLong.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "getNext", e);
            }
            return "Error";
        }
    }

}

