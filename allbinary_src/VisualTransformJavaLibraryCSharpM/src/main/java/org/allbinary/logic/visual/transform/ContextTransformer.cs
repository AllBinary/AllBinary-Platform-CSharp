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
using ContextUriResolver = org.allbinary.data.tree.dom.ContextUriResolver;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace org.allbinary.logic.visual.transform;

public class ContextTransformer : BasicTransformer
{
    public ContextTransformer(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(abeClientInformation, transformInfoInterface)
    {
        // base(abeClientInformation, transformInfoInterface) is called from the constructor declaration
        this.setURIResolver(((URIResolver) new ContextUriResolver(((BasicUriResolver) this.getURIResolver()))));
    }

}

