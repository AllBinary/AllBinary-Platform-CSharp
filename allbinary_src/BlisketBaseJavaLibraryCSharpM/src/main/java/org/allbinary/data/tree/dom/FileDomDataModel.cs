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
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.data.tree.dom;

public class FileDomDataModel : DomNodeInterface
{
    private AbFile file;
    public FileDomDataModel(AbFile file)
    {
        this.file = file;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        TableMappingInterface tableMappingInterface = ((TableMappingInterface) new FileTableMapping(this.file));
        HashMap<object, object> hashMap = tableMappingInterface.toHashMap();
        return ModDomHelper.createNodeWithValueNodes(document, "file", hashMap);
    }

}

