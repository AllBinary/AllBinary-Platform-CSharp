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
//using StringBufferInputStream = java.io.StringBufferInputStream;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using AbFileLocalInputStream = org.allbinary.logic.io.AbFileLocalInputStream;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.dom;

public class SimpleTransform
{
    private readonly AbPath xsltFilePath;
    private readonly AbPath dataFilePath;
    public SimpleTransform(AbPath xsltFilePath, AbPath dataFilePath)
    {
        this.xsltFilePath = xsltFilePath;
        this.dataFilePath = dataFilePath;
    }

    // throws Exception
    public virtual string transform()
    {
        AbFileLocalInputStream inputStream = new AbFileLocalInputStream(AbFile.createAbFileFromAbPath(this.xsltFilePath));
        Document document = DomDocumentHelper.create(new AbFileLocalInputStream(AbFile.createAbFileFromAbPath(this.dataFilePath)));
        string result = XslHelper.getInstance().translate(new StreamSource(inputStream), new StreamSource(new StringBufferInputStream(XmlDocumentHelper.toString(document))));
        return result;
    }

}

