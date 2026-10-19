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
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using StoreThemeCategoryFactory = org.allbinary.business.category.store.theme.StoreThemeCategoryFactory;
using StoreThemeCategoryInterface = org.allbinary.business.category.store.theme.StoreThemeCategoryInterface;
using StoreThemeCategoryPathValidationView = org.allbinary.business.category.store.theme.StoreThemeCategoryPathValidationView;
using CategoryLoaderFactory = org.allbinary.data.tree.category.CategoryLoaderFactory;
using CategoryLoaderInterface = org.allbinary.data.tree.category.CategoryLoaderInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.business.context.modules.storefront.customizer.includes.style.theme;

public class EditThemeValidationView : ThemeCustomizerView, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public EditThemeValidationView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            CategoryFactoryInterface categoryFactoryInterface = new StoreThemeCategoryFactory(this.getTransformInfoInterface());
            CategoryLoaderInterface categoryLoaderInterface = CategoryLoaderFactory.getInstance(categoryFactoryInterface);
            StoreThemeCategoryInterface rootStoreThemeCategoryInterface = ((StoreThemeCategoryInterface) categoryFactoryInterface.getRootInstance());
            StoreThemeCategoryInterface storeThemeCategoryInterface = ((StoreThemeCategoryInterface) categoryLoaderInterface.getAll(((CategoryInterface) rootStoreThemeCategoryInterface)));
            this.validationInterface = new StoreThemeCategoryPathValidationView(((StoreThemeCategoryInterface) storeThemeCategoryInterface));
            isValid = this.validationInterface.isValid();
            DomNodeInterface domNodeInterface = ((DomNodeInterface) this.validationInterface);
            Document document = DomDocumentHelper.create();
            document.appendChild(domNodeInterface.toXmlNode(document));
            string documentString = XmlDocumentHelper.toString(document);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.putF("Setting Data: " + documentString, this, this.commonStrings.CONSTRUCTOR);
            }
            this.getTransformInfoInterface().setData(documentString);
            return isValid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.validationInterface.validationInfo());
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Getting Validation Info";
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

}

