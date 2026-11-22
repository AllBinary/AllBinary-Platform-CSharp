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
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class OverrideStoreTransformInfoObjectConfig : GenericStoreTransformInfoObjectConfig
{
    public OverrideStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(abeClientInformation, transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
    }

    public OverrideStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document) : base(abeClientInformation, transformInfoInterface, document)
    {
        // Constructor invocation emitted in the initializer.
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    public OverrideStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, string name, string type) : base(abeClientInformation, transformInfoInterface, name, type)
    {
        // Constructor invocation emitted in the initializer.
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    // throws Exception
    public override Document generate(Document objectConfigDocument)
    {
        Document newObjectConfigDocument = base.generate(objectConfigDocument);
        return newObjectConfigDocument;
    }

}

