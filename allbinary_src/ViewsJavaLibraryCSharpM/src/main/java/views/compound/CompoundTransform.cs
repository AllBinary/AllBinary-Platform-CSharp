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
//using InputStream = java.io.InputStream;
//using URIResolver = javax.xml.transform.URIResolver;
using BasicUriResolver = org.allbinary.data.tree.dom.BasicUriResolver;
using StoreUriResolver = org.allbinary.data.tree.dom.StoreUriResolver;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using AbTransformer = org.allbinary.logic.visual.transform.AbTransformer;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CompoundContextTransformInfoObjectConfig = views.compound.objectConfig.CompoundContextTransformInfoObjectConfig;

namespace views.compound;

public class CompoundTransform : AbTransformer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    public CompoundTransform(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.setURIResolver(((URIResolver) new StoreUriResolver(this.getTransformInfoInterface(), ((BasicUriResolver) this.getURIResolver()))));
        CompoundContextTransformInfoObjectConfig objectConfig = new CompoundContextTransformInfoObjectConfig(this.abeClientInformation, this.getTransformInfoInterface(), this.getTransformInfoInterface().getObjectConfigInterface().toXmlDoc());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("\nObjectConfig: \n" + objectConfig.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        InputStream templateInputStream = objectConfig.createInputStream();
        this.setInputStream(templateInputStream);
    }

}

