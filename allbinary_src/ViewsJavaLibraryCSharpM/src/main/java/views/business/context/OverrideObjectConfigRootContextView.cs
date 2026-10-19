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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using GeneratorTransformInfoData = org.allbinary.logic.visual.transform.info.GeneratorTransformInfoData;
using RootTransformInfoData = org.allbinary.logic.visual.transform.info.RootTransformInfoData;
using TransformInfoHttp = org.allbinary.logic.visual.transform.info.TransformInfoHttp;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigAndManipulatorFactory = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactory;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using TransformTemplateInterface = org.allbinary.logic.visual.transform.template.TransformTemplateInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.business.context;

public class OverrideObjectConfigRootContextView : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public OverrideObjectConfigRootContextView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "OverrideObjectRootContextView()");
        }
    }

    // throws Exception
    public virtual string view()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("View Name: " + this.getTransformInfoInterface().getName(), this, "view()");
            }
            TransformInfoInterface rootTransformInfoInterface = ((TransformInfoInterface) new TransformInfoHttp(((TransformInfoHttp) this.getTransformInfoInterface())));
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.getTransformInfoInterface().getStoreName());
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            string nameStart = stringBuffer.ToString();
            if (this.getTransformInfoInterface().getName().indexOf(GeneratorTransformInfoData.NAME) > 0) {
                rootTransformInfoInterface.setName(nameStart + GeneratorTransformInfoData.NAME);
            } else if (this.getTransformInfoInterface().getName().indexOf(RootTransformInfoData.NAME) > 0) {
                rootTransformInfoInterface.setName(nameStart + RootTransformInfoData.NAME);
            } else {
                throw new Exception("Override Currently Not Supported");
            }
            Document overrideObjectConfigDocument = this.getTransformInfoInterface().getObjectConfigInterface().toXmlDoc();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Retrieved OverrideObjectConfig: " + XmlDocumentHelper.toString(overrideObjectConfigDocument), this, "view()");
            }
            TransformFactory transformFactory = TransformFactory.getInstance();
            TransformInterface rootComponentInterface = transformFactory.getInstance(this.abeClientInformation, rootTransformInfoInterface.getName(), rootTransformInfoInterface);
            TransformTemplateInterface transformTemplateInterface = ((TransformTemplateInterface) rootComponentInterface);
            TransformInterface componentInterface = transformFactory.getInstance(this.abeClientInformation, transformTemplateInterface.getName(), rootComponentInterface.getTransformInfoInterface());
            TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = TransformInfoObjectConfigAndManipulatorFactory.getInstance().getInstance(this.abeClientInformation, componentInterface.getTransformInfoInterface(), overrideObjectConfigDocument);
            componentInterface.getTransformInfoInterface().setObjectConfigInterface(transformInfoObjectConfigInterface);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Set OverrideObjectConfig: " + componentInterface.getTransformInfoInterface().getObjectConfigInterface().ToString(), this, "view()");
            }
            return componentInterface.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

