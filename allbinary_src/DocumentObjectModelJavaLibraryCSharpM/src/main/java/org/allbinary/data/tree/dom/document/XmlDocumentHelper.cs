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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using StringReader = java.io.StringReader;
//using StringWriter = java.io.StringWriter;
//using Writer = java.io.Writer;
//using DocumentBuilderFactory = javax.xml.parsers.DocumentBuilderFactory;
//using OutputKeys = javax.xml.transform.OutputKeys;
//using Transformer = javax.xml.transform.Transformer;
//using TransformerFactory = javax.xml.transform.TransformerFactory;
//using DOMSource = javax.xml.transform.dom.DOMSource;
//using StreamResult = javax.xml.transform.stream.StreamResult;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using CharacterSetData = org.allbinary.logic.java.characters.CharacterSetData;
using CommonStrings = org.allbinary.@string.CommonStrings;
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
    private Transformer transformer = null;
    private XmlDocumentHelper()
    {
        this.init(4, true);
    }

    public virtual void init(int indent, bool ignoreDeclaration)
    {
        try {
            BooleanFactory booleanFactory = BooleanFactory.getInstance();
            TransformerFactory transformerFactory = TransformerFactory.newInstance();
            transformerFactory.setAttribute(this.INDENT_NUMBER, indent);
            this.transformer = transformerFactory.newTransformer();
            this.transformer.setOutputProperty(OutputKeys.ENCODING, CharacterSetData.getInstance().UTF_8);
            this.transformer.setOutputProperty(OutputKeys.OMIT_XML_DECLARATION, (ignoreDeclaration ? booleanFactory.YES : booleanFactory.NO));
            this.transformer.setOutputProperty(OutputKeys.INDENT, booleanFactory.YES);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
        }
    }

    // throws Exception
    public virtual string format(string xmlString)
    {
        InputSource src = new InputSource(new StringReader(xmlString));
        Document document = DocumentBuilderFactory.newInstance().newDocumentBuilder().parse(src);
        Writer @out = new StringWriter();
        this.transformer.transform(new DOMSource(document), new StreamResult(@out));
        return @out.ToString();
    }

    // throws Exception
    public static string toString(Document document)
    {
        try {
            DOMSource domSource = new DOMSource(document);
            System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
            StreamResult streamResult = new StreamResult(byteArrayOutputStream);
            TransformerFactory copyTransformerFactory = TransformerFactory.newInstance();
            Transformer copyTransformer = copyTransformerFactory.newTransformer();
            copyTransformer.transform(domSource, streamResult);
            return System.Text.Encoding.UTF8.GetString(byteArrayOutputStream.ToArray());
        } catch (Exception e) {
            throw e;
        }
    }

}

