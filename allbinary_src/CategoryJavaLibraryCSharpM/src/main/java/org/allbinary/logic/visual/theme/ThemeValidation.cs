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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CategoryData = org.allbinary.business.category.CategoryData;
using CategoryFactoryInterface = org.allbinary.business.category.CategoryFactoryInterface;
using StoreThemeCategoryFactory = org.allbinary.business.category.store.theme.StoreThemeCategoryFactory;
using StoreThemeCategoryInterface = org.allbinary.business.category.store.theme.StoreThemeCategoryInterface;
using CategoryLoaderFactory = org.allbinary.data.tree.category.CategoryLoaderFactory;
using CategoryLoaderInterface = org.allbinary.data.tree.category.CategoryLoaderInterface;
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using PathUtil = org.allbinary.logic.io.path.PathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CompositeTransformInfoInterface = org.allbinary.logic.visual.transform.info.CompositeTransformInfoInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CssStyleValidation = org.allbinary.logic.visual.transform.template.customizer.includes.style.css.template.retail.CssStyleValidation;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.theme;

public class ThemeValidation : ThemeInterface, ValidationInterface, DomNodeInterface, CompositeTransformInfoInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private TransformInfoInterface transformInfoInterface;
    private ValidationInterface styleValidationInterface;
    private string themeName;
    private string themePreviewImageName;
    private AbPath webAppAbPath;
    private AbPath categoryAbPath;
    private AbPath fileAbPath = null;
    public ThemeValidation(TransformInfoInterface transformInfoInterface, CssStyleValidation cssStyleValidation, string categoryThemePath)
    {
        this.transformInfoInterface = transformInfoInterface;
        AbPathData pathData = AbPathData.getInstance();
        PathUtil pathUtil = PathUtil.getInstance();
        this.categoryAbPath = pathUtil.removeNameFromPath(categoryThemePath);
        this.themeName = pathData.getNameFromPath(categoryThemePath);
        this.styleValidationInterface = cssStyleValidation;
        this.init();
    }

    public ThemeValidation(TransformInfoInterface transformInfoInterface, HashMap<object, object> hashMap)
    {
        this.transformInfoInterface = transformInfoInterface;
        AbPath categoryThemeAbPath = new AbPath(((string) hashMap.get(ThemeData.getInstance().PATH)), StringUtil.getInstance().EMPTY_STRING);
        AbPathData pathData = AbPathData.getInstance();
        PathUtil pathUtil = PathUtil.getInstance();
        this.categoryAbPath = pathUtil.removeNameFromPath(categoryThemeAbPath.ToString());
        this.themeName = pathData.getNameFromPath(categoryThemeAbPath.ToString());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("CategoryThemePath: ");
            stringBuffer.append(categoryThemeAbPath.ToString());
            stringBuffer.append(" & CategoryPath: ");
            stringBuffer.append(this.categoryAbPath.ToString());
            stringBuffer.append(" & ThemeName: ");
            stringBuffer.append(this.themeName);
            this.logUtil.putF("Http Request Constructor", this, stringBuffer.ToString());
        }
        this.init();
    }

    public ThemeValidation(StoreThemeCategoryInterface storeThemeCategoryInterface, Node node)
    {
        this.transformInfoInterface = storeThemeCategoryInterface.getTransformInfoInterface();
        this.categoryAbPath = storeThemeCategoryInterface.getPath();
        Node themeNameNode = DomSearchHelper.getNode(ThemeData.getInstance().NAME, node.getChildNodes());
        Node valueNode = DomSearchHelper.getNode(DomData.VALUE, themeNameNode.getChildNodes());
        this.themeName = DomNodeHelper.getTextNodeValue(valueNode);
        Node previewImageNameNode = DomSearchHelper.getNode(ThemeData.getInstance().PREVIEW_IMAGE_NAME, node.getChildNodes());
        Node previewImageNameValueNode = DomSearchHelper.getNode(DomData.VALUE, previewImageNameNode.getChildNodes());
        this.themePreviewImageName = DomNodeHelper.getTextNodeValue(previewImageNameValueNode);
        this.webAppAbPath = storeThemeCategoryInterface.getWebAppPath();
        this.init(storeThemeCategoryInterface);
    }

    // throws Exception
    private void init()
    {
        CategoryFactoryInterface categoryFactoryInterface = new StoreThemeCategoryFactory(this.getTransformInfoInterface());
        CategoryLoaderInterface categoryLoaderInterface = CategoryLoaderFactory.getInstance(categoryFactoryInterface);
        StoreThemeCategoryInterface rootStoreThemeCategoryInterface = ((StoreThemeCategoryInterface) categoryFactoryInterface.getRootInstance());
        this.init(rootStoreThemeCategoryInterface);
    }

    // throws Exception
    private void init(StoreThemeCategoryInterface storeThemeCategoryInterface)
    {
        this.fileAbPath = new AbPath(storeThemeCategoryInterface.getRootFilePath().ToString() + this.categoryAbPath.ToString(), StringUtil.getInstance().EMPTY_STRING);
        this.webAppAbPath = storeThemeCategoryInterface.getWebAppPath();
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    public virtual string getName()
    {
        return this.themeName;
    }

    public virtual string getPreviewImageName()
    {
        return this.themePreviewImageName;
    }

    public virtual string getPreviewImagePath()
    {
        return this.webAppAbPath.ToString() + this.categoryAbPath.ToString();
    }

    public virtual string getPath()
    {
        return this.categoryAbPath.ToString();
    }

    // throws Exception
    public virtual CssStyleValidation getCssStyleValidation()
    {
        if (this.styleValidationInterface == null) {
            AbPath cssStyleFileAbPath = new AbPath(this.fileAbPath.ToString(), this.themeName + AbPathData.getInstance().EXTENSION_SEP + CategoryData.getInstance().UNCRYPTED_EXTENSION);
            CryptFileReader cryptFileReader = new CryptFileReader(CategoryData.getInstance().UNCRYPTED_EXTENSION, CategoryData.getInstance().ENCRYPTED_EXTENSION);
            Document document = DomDocumentHelper.create(cryptFileReader.get(cssStyleFileAbPath));
            this.styleValidationInterface = new CssStyleValidation(document);
        }
        return ((CssStyleValidation) this.styleValidationInterface);
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            if (!StringValidationUtil.getInstance().isValidRequired(this.categoryAbPath.ToString(), AbSqlData.MINSTRING, AbSqlData.MAXSTRING)) {
                isValid = false;
            }
            if (!StringValidationUtil.getInstance().isValidRequired(this.themeName, AbSqlData.MINSTRING, AbSqlData.MAXSTRING)) {
                isValid = false;
            }
            if (!this.getCssStyleValidation().isValid()) {
                isValid = false;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("End: " + isValid, this, this.commonStrings.IS_VALID);
            }
            return isValid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Theme Validation Error");
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

    public virtual object getKey()
    {
        return ((object) this.getName());
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.add(this.getName());
        vector.add(this.getPath());
        vector.add(this.getPreviewImageName());
        vector.add(this.getPreviewImagePath());
        return vector;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        ThemeData themeData = ThemeData.getInstance();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(themeData.NAME, this.getName());
        hashMap.put(themeData.PATH, this.getPath());
        hashMap.put(themeData.PREVIEW_IMAGE_NAME, this.getPreviewImageName());
        hashMap.put(themeData.PREVIEW_IMAGE_PATH, this.getPreviewImagePath());
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNameValueNodes(document, ThemeData.getInstance().NAME, this.toHashMap());
        DomNodeInterface domNodeInterface = ((DomNodeInterface) this.getCssStyleValidation());
        node.appendChild(domNodeInterface.toXmlNode(document));
        return node;
    }

}

