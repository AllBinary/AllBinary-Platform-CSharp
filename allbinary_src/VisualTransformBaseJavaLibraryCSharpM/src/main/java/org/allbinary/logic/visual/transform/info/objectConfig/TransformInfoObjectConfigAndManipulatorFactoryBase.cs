/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class TransformInfoObjectConfigAndManipulatorFactoryBase : TransformInfoObjectConfigAndManipulatorFactoryInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, AbPath objectConfigFileAbPath)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document)
    {
        throw new SystemException();
    }

}

