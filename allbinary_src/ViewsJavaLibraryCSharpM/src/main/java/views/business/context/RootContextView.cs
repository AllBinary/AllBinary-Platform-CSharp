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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformInfo = org.allbinary.logic.visual.transform.info.TransformInfo;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformTemplateInterface = org.allbinary.logic.visual.transform.template.TransformTemplateInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using NoTemplateTransformInfoObjectConfig = views.business.context.modules.storefront.customizer.template.objectConfig.NoTemplateTransformInfoObjectConfig;

namespace views.business.context;

public class RootContextView : HttpStoreComponentView, TransformTemplateInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public RootContextView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "RootContextView()");
        }
    }

    // throws Exception
    public virtual string view()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("View Name: " + this.getTransformInfoInterface().getName(), this, "view()");
            }
            string viewName = this.getName();
            TransformInterface componentInterface = TransformFactory.getInstance().getInstance(this.abeClientInformation, viewName, this.getTransformInfoInterface());
            return componentInterface.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual string getName()
    {
        try {
            NoTemplateTransformInfoObjectConfig objectConfig = new NoTemplateTransformInfoObjectConfig(this.getTransformInfoInterface(), this.getTransformInfoInterface().getObjectConfigInterface().toXmlDoc());
            BasicArrayList componentsVector = objectConfig.getTransforms();
            if (componentsVector.size() == 0) {
                throw new Exception("Template View Not Set - No Components");
            }
            if (componentsVector.size() > 1) {
                throw new Exception("To Many Root Template Views: " + componentsVector.size());
            }
            TransformInfo transformInfoInterface = ((TransformInfo) componentsVector.get(0));
            string viewName = transformInfoInterface.getName();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Root Template With View Name: " + viewName, this, "getName()");
            }
            if (StringValidationUtil.getInstance().isEmpty(viewName)) {
                throw new Exception("Template View Not Set - No View Name");
            }
            return viewName;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getName()", e);
            }
            throw e;
        }
    }

}

