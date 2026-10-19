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
//using StringBufferInputStream = java.io.StringBufferInputStream;
//using DocumentBuilder = javax.xml.parsers.DocumentBuilder;
//using DocumentBuilderFactory = javax.xml.parsers.DocumentBuilderFactory;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.dom.document;

public class DomDocumentHelper
{
    private DomDocumentHelper()
    {
    }

    public static void init()
    {
        System.setProperty("jdk.xml.maxElementDepth", "0");
        System.setProperty("jdk.xml.xpathExprOpLimit", "0");
        System.setProperty("jdk.xml.xpathTotalOpLimit", "0");
        string LIMIT = "500000";
        System.setProperty("jdk.xml.maxGeneralEntitySizeLimit", LIMIT);
        System.setProperty("jdk.xml.totalEntitySizeLimit", LIMIT);
    }

    public static Document create()
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.newDocument();
            return document;
        } catch (Exception e) {
            return null;
        }
    }

    // throws Exception
    public static Document create(InputStream inputStream)
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(inputStream);
            return document;
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public static Document create(string xmlString)
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(new StringBufferInputStream(xmlString));
            return document;
        } catch (Exception e) {
            throw e;
        }
    }

}

