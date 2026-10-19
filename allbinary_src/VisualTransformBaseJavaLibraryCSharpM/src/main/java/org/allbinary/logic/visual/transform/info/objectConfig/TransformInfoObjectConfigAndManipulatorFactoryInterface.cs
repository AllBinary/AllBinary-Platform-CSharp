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
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public interface TransformInfoObjectConfigAndManipulatorFactoryInterface
{
    // throws Exception
    TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, AbPath objectConfigFileAbPath);

    // throws Exception
    TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface);

    // throws Exception
    TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document);

}

