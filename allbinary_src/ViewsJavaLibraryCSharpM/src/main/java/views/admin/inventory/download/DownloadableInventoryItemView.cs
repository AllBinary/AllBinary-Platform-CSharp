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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using DownloadableItemView = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItemView;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using StdUtil = org.allbinary.logic.StdUtil;
using MultipartRequestParams = org.allbinary.logic.communication.http.request.MultipartRequestParams;
using RequestMapInterface = org.allbinary.logic.communication.http.request.RequestMapInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FilePathData = org.allbinary.logic.io.file.FilePathData;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using ZipFileUtil = org.allbinary.logic.io.file.zip.ZipFileUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using FileItem = org.apache.commons.fileupload.FileItem;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.inventory.download;

public class DownloadableInventoryItemView : HttpStoreComponentView, RequestMapInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public readonly HttpServletRequest request;
    public string id = null;
    public ItemInterface itemInterface = null;
    public DownloadableItem downloadableItem = null;
    private HashMap<object, object> requestHashMap = null;
    public DownloadableInventoryItemView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
        this.getFormData();
    }

    public DownloadableInventoryItemView(TransformInfoInterface transformInfoInterface, string empty) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
    }

    public static int TYPE_ID = 11;
    public virtual int getTypeId()
    {
        return DownloadableInventoryItemView.TYPE_ID;
    }

    // throws Exception
    private void getFormData()
    {
        this.setRequestHashMap(new MultipartRequestParams(this.request).toHashMap());
        this.id = ((string) this.getRequestHashMap().get(basicItemData.ID));
    }

    public virtual void addDomNodeInterfaces()
    {
        BasicArrayList vector = new BasicArrayListD();
        if (this.downloadableItem != null) {
            vector.add(new DownloadableItemView(this.downloadableItem));
        }
        this.addDomNodeInterface(new BasicItemView(this.itemInterface, vector));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual void processFile(FileItem fileItem)
    {
        string fileName = fileItem.getName();
        string fullPath = this.getItemFilePath();
        AbFile itemResourceFile = AbFile.createAbFile(fullPath);
        itemResourceFile.mkdir();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(fullPath);
        stringBuffer.append(fileName);
        this.logUtil.putF("FileName: " + fileName, this, "processFile()");
        AbFile file = AbFile.createAbFile(stringBuffer.ToString());
        this.logUtil.putF(file.getPath(), this, "processFiles()");
        file.createNewFile();
        sbyte[] byteArray = fileItem.get();
        FileUtil.getInstance().write(new ByteArrayInputStream(byteArray), file);
    }

    // throws Exception
    public virtual void unzip(FileItem fileItem)
    {
        string fileName = fileItem.getName();
        string fullPath = this.getItemFilePath();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(fullPath);
        stringBuffer.append(fileName);
        this.logUtil.putF("FileName: " + fileName, this, "unzip()");
        AbFile file = AbFile.createAbFile(stringBuffer.ToString());
        this.logUtil.putF(file.getPath(), this, "unzip()");
        ZipFileUtil.getInstance().unzip(fullPath, file, fileName);
    }

    private string getItemFilePath()
    {
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
        FilePathData filePathData = FilePathData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getWebappPath());
        stringBuffer.append(storeFrontInterface.getCurrentHostNamePath());
        stringBuffer.append(this.itemInterface.getCategory());
        stringBuffer.appendchar(filePathData.SEPARATORCHAR);
        stringBuffer.append(this.itemInterface.getId());
        stringBuffer.appendchar(filePathData.SEPARATORCHAR);
        stringBuffer.append(this.downloadableItem.getId());
        stringBuffer.appendchar(filePathData.SEPARATORCHAR);
        return stringBuffer.ToString();
    }

    private void setRequestHashMap(HashMap<object, object> requestHashMap)
    {
        this.requestHashMap = requestHashMap;
    }

    public virtual HashMap<object, object> getRequestHashMap()
    {
        return this.requestHashMap;
    }

    public virtual DownloadableItem getDownloadableItem()
    {
        return this.downloadableItem;
    }

}

