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
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ContextTransformer = org.allbinary.logic.visual.transform.ContextTransformer;
using TransformHttpRequestDocumentFactory = org.allbinary.logic.visual.transform.data.TransformHttpRequestDocumentFactory;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using HttpComponentView = views.HttpComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.business.context;

public class HttpContextView : HttpComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public HttpContextView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.setTransformDocumentInterface(TransformHttpRequestDocumentFactory.getInstance(this.getPageContext(), this.getWeblisketSession()));
    }

    // throws Exception
    public override string view()
    {
        try {
            this.toXmlDoc();
            string success = XmlDocumentHelper.toString(this.getDoc());
            string result = new ContextTransformer(this.abeClientInformation, this.getTransformInfoInterface()).translate(success);
            return result;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view", e);
            }
            throw e;
        }
    }

}

