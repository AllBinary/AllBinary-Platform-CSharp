/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using System.Runtime.CompilerServices;
using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
using StringReader = java.io.StringReader;
//using StringWriter = java.io.StringWriter;
using Writer = java.io.Writer;
//using DocumentBuilderFactory = javax.xml.parsers.DocumentBuilderFactory;
//using OutputKeys = javax.xml.transform.OutputKeys;
//using Transformer = javax.xml.transform.Transformer;
//using TransformerConfigurationException = javax.xml.transform.TransformerConfigurationException;
//using TransformerFactory = javax.xml.transform.TransformerFactory;
//using DOMSource = javax.xml.transform.dom.DOMSource;
//using StreamResult = javax.xml.transform.stream.StreamResult;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using CharacterSetData = org.allbinary.logic.java.characters.CharacterSetData;
using Document = org.w3c.dom.Document;
using InputSource = org.xml.sax.InputSource;

namespace org.allbinary.data.tree.dom.document;

public class XmlDocumentHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly XmlDocumentHelper instance = new XmlDocumentHelper();
    public static XmlDocumentHelper getInstance()
    {
        return XmlDocumentHelper.instance;
    }

    private readonly string INDENT_NUMBER = "indent-number";
    private int indent = 0;
    private bool ignoreDeclaration = false;
    private XmlDocumentHelper()
    {
        this.init(4, true);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void init(int indent, bool ignoreDeclaration)
    {
        this.indent = indent;
        this.ignoreDeclaration = ignoreDeclaration;
    }

    // throws TransformerConfigurationException
    private Transformer createTransformer(int indent, bool ignoreDeclaration)
    {
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        TransformerFactory transformerFactory = TransformerFactory.newInstance();
        transformerFactory.setAttribute(this.INDENT_NUMBER, indent);
        Transformer transformer = transformerFactory.newTransformer();
        transformer.setOutputProperty(OutputKeys.ENCODING, CharacterSetData.getInstance().UTF_8);
        transformer.setOutputProperty(OutputKeys.OMIT_XML_DECLARATION, (ignoreDeclaration ? booleanFactory.YES : booleanFactory.NO));
        transformer.setOutputProperty(OutputKeys.INDENT, booleanFactory.YES);
        return transformer;
    }

    // throws TransformerConfigurationException
    public virtual Transformer createTransformer()
    {
        int currentIndent = 0;
        bool currentIgnoreDeclaration = false;
        lock (this) {
            currentIndent = this.indent;
            currentIgnoreDeclaration = this.ignoreDeclaration;
        }
        return this.createTransformer(currentIndent, currentIgnoreDeclaration);
    }

    // throws Exception
    public virtual string format(string xmlString)
    {
        return this.formatWithTransformer(xmlString, this.createTransformer());
    }

    // throws Exception
    public virtual string formatWithTransformer(string xmlString, Transformer transformer)
    {
        InputSource src = new InputSource(new StringReader(xmlString));
        Document document = DocumentBuilderFactory.newInstance().newDocumentBuilder().parse(src);
        Writer @out = new StringWriter();
        transformer.transform(new DOMSource(document), new StreamResult(@out));
        return @out.ToString();
    }

    // throws Exception
    public static string toString(Document document)
    {
        try {
            DOMSource domSource = new DOMSource(document);
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            StreamResult streamResult = new StreamResult(byteArrayOutputStream);
            TransformerFactory copyTransformerFactory = TransformerFactory.newInstance();
            Transformer copyTransformer = copyTransformerFactory.newTransformer();
            copyTransformer.transform(domSource, streamResult);
            return byteArrayOutputStream.ToString();
        } catch (Exception e) {
            throw e;
        }
    }

}

