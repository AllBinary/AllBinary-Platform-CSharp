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
using DomDocumentMappingInterface = org.allbinary.data.tree.dom.document.mapping.DomDocumentMappingInterface;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using CompositeTransformInfoInterface = org.allbinary.logic.visual.transform.info.CompositeTransformInfoInterface;

namespace org.allbinary.logic.visual.transform;

public interface TransformInterface : DomDocumentMappingInterface, CompositeTransformInfoInterface
{
    int getTypeId();

    void setTransformDocumentInterface(TransformDocumentInterface viewDocumentInterface);

    TransformDocumentInterface getTransformDocumentInterface();

    // throws Exception
    string view();

}

