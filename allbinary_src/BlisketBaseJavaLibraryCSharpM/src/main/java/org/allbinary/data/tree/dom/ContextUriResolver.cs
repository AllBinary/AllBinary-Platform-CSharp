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
//using Source = javax.xml.transform.Source;
//using TransformerException = javax.xml.transform.TransformerException;
//using URIResolver = javax.xml.transform.URIResolver;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbFilePath = org.allbinary.logic.io.path.AbFilePath;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoTemplateData = org.allbinary.logic.visual.transform.info.template.TransformInfoTemplateData;

namespace org.allbinary.data.tree.dom;

public class ContextUriResolver : URIResolver
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly URIResolverStrings uriResolverStrings = URIResolverStrings.getInstance();
    private BasicUriResolver basicURIResolver;
    public ContextUriResolver(BasicUriResolver basicURIResolver)
    {
        this.basicURIResolver = basicURIResolver;
    }

    // throws TransformerException
    public virtual Source resolve(string href, string @base)
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(URLGLOBALS.getMainPath());
            stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
            stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().INSTALLPATH);
            stringBuffer.append(AbPathData.getInstance().SEPARATOR);
            stringBuffer.append(href);
            AbPath fileAbPath = new AbFilePath(stringBuffer.ToString());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XMLLOGGING)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.uriResolverStrings.ATTEMPT);
                stringBuffer.append(href);
                stringBuffer.append(this.uriResolverStrings.BASE);
                stringBuffer.append(@base);
                stringBuffer.append(this.uriResolverStrings.NEW_PATH);
                stringBuffer.append(fileAbPath.ToString());
                stringBuffer.append(this.uriResolverStrings.NOTE);
                stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
                stringBuffer.append(this.uriResolverStrings.URL_GLOBAL);
                stringBuffer.append(this.uriResolverStrings.REQUIRED_EXTENSION);
                stringBuffer.append(this.basicURIResolver.getExtension());
                this.logUtil.putF(stringBuffer.ToString(), this, this.uriResolverStrings.RESOLVE);
            }
            return new StreamSource(new CryptFileReader(TransformInfoTemplateData.getInstance().UNCRYPTED_EXTENSION, TransformInfoTemplateData.getInstance().ENCRYPTED_EXTENSION).getInputStream(fileAbPath));
        } catch (TransformerException e) {
            throw e;
        } catch (Exception e) {
            throw new TransformerException(e);
        }
    }

    public override string ToString()
    {
        try {
            return URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().INSTALLPATH + this.uriResolverStrings.IMPORT_URL;
        } catch (Exception e) {
            return "ContextUriResolver - Does not work without webapp path should be changed";
        }
    }

}

