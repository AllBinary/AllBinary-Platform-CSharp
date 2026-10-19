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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;

namespace org.allbinary.data.tree.dom.document;

public class DocumentToNode
{
    private static readonly string XMLROOT = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
    private static readonly string XMLROOTSTART = "<?xml";
    private static readonly string XMLROOTEND = "?>";
    private static readonly string XMLJSPROOTSTART = "<jsp:root";
    private static readonly string XMLEND = ">";
    private static readonly string XMLJSPROOTENDSTART = "</jsp:root";
    private DocumentToNode()
    {
    }

    // throws Exception
    public static string convertDocumentToNodeString(string documentString)
    {
        documentString = DocumentToNode.remove(documentString, DocumentToNode.XMLJSPROOTSTART, DocumentToNode.XMLEND);
        documentString = DocumentToNode.remove(documentString, DocumentToNode.XMLJSPROOTENDSTART, DocumentToNode.XMLEND);
        Replace replaceXmlRoot = new Replace(XMLROOT, StringUtil.getInstance().EMPTY_STRING);
        return replaceXmlRoot.all(documentString);
    }

    public static string removeXmlDefinitionFromDocumentString(string documentString)
    {
        return DocumentToNode.remove(documentString, XMLROOTSTART, XMLROOTEND);
    }

    public static string remove(string documentString, string start, string end)
    {
        int startIndex = 0;
        while (((startIndex = documentString.IndexOf(start))) != -1) {
            if (startIndex >= 0) {
                int endIndex = documentString.IndexOf(end, startIndex);
                if (endIndex >= 0) {
                    string startString = documentString.Substring(0, (startIndex) - (0));
                    string resultString = documentString.Substring(endIndex + 1);
                    return startString + resultString;
                }
            }
        }
        return documentString;
    }

}

