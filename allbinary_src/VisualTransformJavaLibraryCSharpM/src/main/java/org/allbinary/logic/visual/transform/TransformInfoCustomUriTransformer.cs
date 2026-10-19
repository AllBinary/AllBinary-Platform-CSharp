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
//using URIResolver = javax.xml.transform.URIResolver;
using BasicUriResolver = org.allbinary.data.tree.dom.BasicUriResolver;
using CustomUriResolver = org.allbinary.data.tree.dom.CustomUriResolver;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigAndManipulatorFactory = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactory;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;

namespace org.allbinary.logic.visual.transform;

public class TransformInfoCustomUriTransformer : BasicTransformer
{
    public TransformInfoCustomUriTransformer(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(abeClientInformation, transformInfoInterface)
    {
        // base(abeClientInformation, transformInfoInterface) is called from the constructor declaration
        TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = ((TransformInfoObjectConfigInterface) TransformInfoObjectConfigAndManipulatorFactory.getInstance().getInstance(abeClientInformation, transformInfoInterface));
        this.setURIResolver(((URIResolver) new CustomUriResolver(transformInfoObjectConfigInterface.getImportUriPath(), ((BasicUriResolver) this.getURIResolver()))));
    }

}

