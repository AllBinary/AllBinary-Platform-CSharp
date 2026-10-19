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
//using URIResolver = javax.xml.transform.URIResolver;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using XslHelper = org.allbinary.data.tree.dom.XslHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigGenerator = org.allbinary.logic.visual.transform.info.objectConfig.generator.TransformInfoObjectConfigGenerator;
using TransformInfoObjectConfigGeneratorFactory = org.allbinary.logic.visual.transform.info.objectConfig.generator.TransformInfoObjectConfigGeneratorFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform;

public class AbTransformer : BasicTransformerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private TransformInfoInterface transformInfoInterface;
    private InputStream inputStream = null;
    private URIResolver uriResolver = null;
    public AbTransformer(TransformInfoInterface transformInfoInterface)
    {
        this.transformInfoInterface = transformInfoInterface;
    }

    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    public virtual void setInputStream(InputStream inputStream)
    {
        this.inputStream = inputStream;
    }

    public virtual void setURIResolver(URIResolver uriResolver)
    {
        this.uriResolver = uriResolver;
    }

    public virtual InputStream getInputStream()
    {
        return this.inputStream;
    }

    public virtual URIResolver getURIResolver()
    {
        return this.uriResolver;
    }

    public virtual StreamSource getStreamSource()
    {
        return new StreamSource(this.getInputStream());
    }

    // throws Exception
    public virtual string translate(string xmlDocumentStr)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XMLLOGGING)) {
                this.logUtil.putF("xml: \n" + xmlDocumentStr, this, "translate(String xmlDocumentStr)");
            }
            if (this.getURIResolver() == null) {
                throw new Exception("No URIResolver");
            }
            string result = XslHelper.getInstance().translate(this.getURIResolver(), new StreamSource(this.getInputStream()), new StreamSource(new StringBufferInputStream(xmlDocumentStr)));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGING)) {
                this.logUtil.putF("translated xml: " + result, this, "translate(String xmlDocumentStr)");
            }
            TransformInfoObjectConfigGenerator transformInfoObjectConfigGeneratorInterface = TransformInfoObjectConfigGeneratorFactory.getInstance().getInstance(this.getTransformInfoInterface());
            return transformInfoObjectConfigGeneratorInterface.process(result);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.transformInfoInterface.log(), this, "translate(document)", e);
            }
            throw e;
        }
    }

}

