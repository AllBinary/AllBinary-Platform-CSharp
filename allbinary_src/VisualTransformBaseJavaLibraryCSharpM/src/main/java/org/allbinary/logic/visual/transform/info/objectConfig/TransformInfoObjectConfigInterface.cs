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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DomDocumentMappingInterface = org.allbinary.data.tree.dom.document.mapping.DomDocumentMappingInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public interface TransformInfoObjectConfigInterface : DomDocumentMappingInterface
{
    bool containsView(TransformInfoInterface transformInfoInterface);

    // throws Exception
    string getName();

    // throws Exception
    BasicArrayList getTransformsGroup(string group);

    // throws Exception
    BasicArrayList getTransforms();

    // throws Exception
    BasicArrayList getParentTransforms();

    // throws Exception
    BasicArrayList getGroupTransforms();

    // throws Exception
    string getOutputTypeName();

    void setOutputTypeName(string value);

    // throws Exception
    string getInputOutputTypeName();

    // throws Exception
    string getInputOutputTypeFile();

    // throws Exception
    string getImportUriPath();

    string ToString();

}

