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
//using PageContext = javax.servlet.jsp.PageContext;
using TransformInfoObjectConfigNoManipulationFactory = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigNoManipulationFactory;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpStoreNoManipulation : TransformInfoHttpStore
{
    public TransformInfoHttpStoreNoManipulation(HashMap propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
    }

    // throws Exception
    protected virtual void setObjectConfigFile(string value)
    {
        this.setObjectConfigFileName(value);
        this.setObjectConfigInterface(TransformInfoObjectConfigNoManipulationFactory.getInstance().getInstance(this, this.getObjectConfigFilePath()));
    }

    // throws Exception
    protected virtual void setObjectConfig(string value)
    {
        throw new Exception("Should not set from config");
    }

}

