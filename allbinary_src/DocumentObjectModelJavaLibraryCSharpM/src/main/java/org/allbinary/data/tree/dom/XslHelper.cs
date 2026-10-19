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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using File = java.io.File;
//using OutputStream = java.io.OutputStream;
//using StringBufferInputStream = java.io.StringBufferInputStream;
//using Transformer = javax.xml.transform.Transformer;
//using TransformerFactory = javax.xml.transform.TransformerFactory;
//using URIResolver = javax.xml.transform.URIResolver;
//using StreamResult = javax.xml.transform.stream.StreamResult;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.dom;

//import org.allbinary.data.tree.dom.document.DomDocumentHelper;
public class XslHelper
{
    private static readonly XslHelper instance = new XslHelper();
    public static XslHelper getInstance()
    {
        return XslHelper.instance;
    }

    private XslHelper()
    {
    }

    // throws Exception
    public virtual OutputStream translate(StreamSource xsltStreamSource, StreamSource xmlStreamSource, StreamResult streamResult)
    {
        try {
            TransformerFactory transformerFactory = TransformerFactory.newInstance();
            Transformer transformer = transformerFactory.newTransformer(xsltStreamSource);
            transformer.transform(xmlStreamSource, streamResult);
            return streamResult.getOutputStream();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual OutputStream translate(URIResolver resolver, StreamSource xsltStreamSource, StreamSource xmlStreamSource, StreamResult streamResult)
    {
        try {
            TransformerFactory tFactory = TransformerFactory.newInstance();
            tFactory.setURIResolver(resolver);
            Transformer transformer = tFactory.newTransformer(xsltStreamSource);
            transformer.transform(xmlStreamSource, streamResult);
            return streamResult.getOutputStream();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual string translate(StreamSource xsltStreamSource, Document xmlDocument)
    {
        try {
            System.IO.MemoryStream outputStream = new System.IO.MemoryStream();
            return this.translate(xsltStreamSource, new StreamSource(new StringBufferInputStream(XmlDocumentHelper.toString(xmlDocument))), new StreamResult(outputStream)).ToString();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual string translate(StreamSource xsltStreamSource, StreamSource xmlStreamSource)
    {
        try {
            System.IO.MemoryStream outputStream = new System.IO.MemoryStream();
            return this.translate(xsltStreamSource, xmlStreamSource, new StreamResult(outputStream)).ToString();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual string translate(URIResolver resolver, StreamSource xsltStreamSource, StreamSource xmlStreamSource)
    {
        try {
            System.IO.MemoryStream outputStream = new System.IO.MemoryStream();
            return this.translate(resolver, xsltStreamSource, xmlStreamSource, new StreamResult(outputStream)).ToString();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual void export(File outputFile, string xsltFilePath, Document xmlDocument)
    {
        try {
            outputFile.createNewFile();
            this.translate(new StreamSource(xsltFilePath), new StreamSource(new StringBufferInputStream(XmlDocumentHelper.toString(xmlDocument))), new StreamResult(outputFile));
        } catch (Exception e) {
            throw e;
        }
    }

}

