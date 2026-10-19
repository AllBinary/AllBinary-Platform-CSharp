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
using PageData = org.allbinary.business.page.PageData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using StoreTransformer = org.allbinary.logic.visual.transform.StoreTransformer;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TitleBodyValidation = org.allbinary.logic.visual.transform.template.customizer.bodies.title.TitleBodyValidation;
using TransformTemplateCustomizerUtil = org.allbinary.logic.visual.transform.template.util.TransformTemplateCustomizerUtil;
using StringEscapeUtils = org.apache.commons.lang3.StringEscapeUtils;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.business.context.modules.storefront.customizer.bodies.generic.title;

public class TitleBodyCustomizerView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TitleBodyValidation titleBody = null;
    public TitleBodyCustomizerView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this.titleBody));
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    private static readonly string NAME = "None";
    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        string pageName = TransformTemplateCustomizerUtil.getInstance().getPageNameHack(this.getTransformInfoInterface().getName(), this.getWeblisketSession().getStoreName());
        if (StringValidationUtil.getInstance().isEmpty(pageName)) {
            pageName = TitleBodyCustomizerView.NAME;
        }
        return ModDomHelper.createNameValueNodes(document, PageData.getInstance().NAME, pageName);
    }

    // throws Exception
    public virtual string view()
    {
        try {
            string success = XmlDocumentHelper.toString(this.getDoc());
            string result = new StoreTransformer(this.abeClientInformation, this.getTransformInfoInterface()).translate(success);
            return StringEscapeUtils.unescapeHtml3(result);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

