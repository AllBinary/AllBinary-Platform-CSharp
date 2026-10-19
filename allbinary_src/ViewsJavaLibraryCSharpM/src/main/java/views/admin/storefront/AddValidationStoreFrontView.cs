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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpContextView = views.business.context.HttpContextView;

namespace views.admin.storefront;

public class AddValidationStoreFrontView : HttpContextView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public StoreFrontInterface newStoreFrontInterface;
    public AddValidationStoreFrontView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.newStoreFrontInterface = ((StoreFrontInterface) new StoreFront(((HttpServletRequest) this.getPageContext().getRequest())));
        if (this.newStoreFrontInterface.getName() == null) {
            this.newStoreFrontInterface.setName(this.getWeblisketSession().getStoreName());
        }
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            if (this.newStoreFrontInterface.isValid() == false) {
                valid = false;
            }
            if (StoreFrontFactory.getInstance(this.newStoreFrontInterface.getName()) != null) {
                valid = false;
            }
            if (AbFile.createAbFileFromAbPath(new AbPath(this.getStoreViewsPath(), StringUtil.getInstance().EMPTY_STRING)).isFile()) {
                valid = false;
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    // throws Exception
    private string getStoreViewsPath()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(this.newStoreFrontInterface.getName());
        return stringBuffer.ToString();
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            if (this.newStoreFrontInterface.isValid() == false) {
                stringBuffer.append(this.newStoreFrontInterface.validationInfo());
            }
            if (StoreFrontFactory.getInstance(this.newStoreFrontInterface.getName()) != null) {
                stringBuffer.append("Store name already used<br/>");
            }
            if (AbFile.createAbFileFromAbPath(new AbPath(this.getStoreViewsPath(), StringUtil.getInstance().EMPTY_STRING)).isFile()) {
                stringBuffer.append("Store name clashes with template name<br/>");
            }
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws Exception
    public virtual string view()
    {
        return views.ValidationOnlyTempUtil.getInstance().view(this);
    }

}

