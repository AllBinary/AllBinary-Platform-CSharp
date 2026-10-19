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
//using StreamResult = javax.xml.transform.stream.StreamResult;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.data.tree.dom;

public class AbXslHelper
{
    private static readonly AbXslHelper instance = new AbXslHelper();
    public static AbXslHelper getInstance()
    {
        return AbXslHelper.instance;
    }

    // throws Exception
    public virtual string translate(AbFile xslFile, AbFile xmlFile)
    {
        return this.translate(xslFile.getAbsolutePath(), xmlFile.getAbsolutePath());
    }

    // throws Exception
    public virtual string translate(AbPath xslPath, AbPath xmlPath)
    {
        return this.translate(xslPath.getPath(), xmlPath.getPath());
    }

    // throws Exception
    public virtual string translate(string xsltFilePath, string xmlFilePath)
    {
        try {
            System.IO.MemoryStream outputStream = new System.IO.MemoryStream();
            return XslHelper.getInstance().translate(new StreamSource(xsltFilePath), new StreamSource(xmlFilePath), new StreamResult(outputStream)).ToString();
        } catch (Exception e) {
            throw e;
        }
    }

}

