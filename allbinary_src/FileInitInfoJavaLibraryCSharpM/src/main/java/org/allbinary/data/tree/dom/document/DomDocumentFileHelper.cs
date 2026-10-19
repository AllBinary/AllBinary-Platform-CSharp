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
//using Transformer = javax.xml.transform.Transformer;
//using TransformerFactory = javax.xml.transform.TransformerFactory;
//using DOMSource = javax.xml.transform.dom.DOMSource;
//using StreamResult = javax.xml.transform.stream.StreamResult;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.dom.document;

public class DomDocumentFileHelper
{
    private DomDocumentFileHelper()
    {
    }

    // throws Exception
    public static Document createDocument(AbFile xmlFile)
    {
        try {
            return DomDocumentHelper.create(new AbFileInputStream(xmlFile));
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public static void save(AbFile file, Document document)
    {
        AbDataOutputStream dataOutputStream = null;
        try {
            TransformerFactory copyTransformerFactory = TransformerFactory.newInstance();
            Transformer copyTransformer = copyTransformerFactory.newTransformer();
            DOMSource domSource = new DOMSource(document);
            if (file.isFile()) {
                file.delete();
            }
            file.createNewFile();
            dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(file);
            StreamResult streamResult = new StreamResult(dataOutputStream);
            copyTransformer.transform(domSource, streamResult);
            dataOutputStream.flush();
        } catch (Exception e) {
            throw e;
        } finally {
            StreamUtil.getInstance().close(dataOutputStream);
        }
    }

}

