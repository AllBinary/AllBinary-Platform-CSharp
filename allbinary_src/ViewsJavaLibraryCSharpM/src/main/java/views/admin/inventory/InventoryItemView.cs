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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasicItem = org.allbinary.business.user.commerce.inventory.item.BasicItem;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using DownloadableItemView = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItemView;
using StdUtil = org.allbinary.logic.StdUtil;
using HttpFileUploadUtil = org.allbinary.logic.communication.http.file.upload.HttpFileUploadUtil;
using HttpRequestUtil = org.allbinary.logic.communication.http.request.HttpRequestUtil;
using MultipartRequestParams = org.allbinary.logic.communication.http.request.MultipartRequestParams;
using RequestMapInterface = org.allbinary.logic.communication.http.request.RequestMapInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using PathUtil = org.allbinary.logic.io.path.PathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using MediaData = org.allbinary.logic.visual.media.MediaData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using FileItem = org.apache.commons.fileupload.FileItem;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.inventory;

public class InventoryItemView : HttpStoreComponentView, RequestMapInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public readonly HttpServletRequest request;
    private string imageFileName = null;
    private MediaData mediaData = null;
    public ItemInterface itemInterface = null;
    public BasicArrayList downloadableItemVector = null;
    private HashMap<object, object> requestHashMap = null;
    public InventoryItemView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
        this.getFormData();
    }

    public InventoryItemView(TransformInfoInterface transformInfoInterface, string empty) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
    }

    public static int TYPE_ID = 10;
    public virtual int getTypeId()
    {
        return InventoryItemView.TYPE_ID;
    }

    // throws Exception
    private void getFormData()
    {
        this.setRequestHashMap(new MultipartRequestParams(this.request).toHashMap());
        object imageFileItemObject = this.getRequestHashMap().get(basicItemData.IMAGE);
        if (HttpFileUploadUtil.getInstance().isValid(imageFileItemObject)) {
            FileItem fileItem = ((FileItem) imageFileItemObject);
            if (fileItem != null && fileItem.getSize() > 1) {
                this.imageFileName = HttpRequestUtil.getInstance().generateFileName(fileItem.getName());
                AbPathData pathData = AbPathData.getInstance();
                PathUtil pathUtil = PathUtil.getInstance();
                this.mediaData = MediaData.get(pathData.getExtension(this.imageFileName));
                this.imageFileName = pathUtil.getWithoutExtension(this.imageFileName);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                    StringMaker stringBuffer = new StringMaker();
                    stringBuffer.append("Uploaded File Data: ");
                    stringBuffer.append(this.imageFileName);
                    stringBuffer.append(" Extension: ");
                    stringBuffer.append(this.mediaData.getName());
                    this.logUtil.putF(stringBuffer.ToString(), this, "getFormData()");
                }
            }
        }
        this.itemInterface = ((ItemInterface) new BasicItem(this.getRequestHashMap()));
    }

    public virtual void addDomNodeInterfaces()
    {
        BasicArrayList vector = new BasicArrayListD();
        DownloadableItem downloadableItem = null;
        int size = this.downloadableItemVector.size();
        for (int index = 0; index < size; index++) {
            downloadableItem = ((DownloadableItem) this.downloadableItemVector.get(index));
            vector.add(new DownloadableItemView(downloadableItem));
        }
        this.addDomNodeInterface(new BasicItemView(this.itemInterface, vector));
    }

    public virtual ItemInterface getItemInterface()
    {
        return this.itemInterface;
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
    public virtual void processImageFiles()
    {
        Set<object> set = this.getRequestHashMap().keySet();
        object[] fieldNameArray = set.toArray();
        int size = fieldNameArray.Length;
        for (int index = 0; index < size; index++) {
            string fieldName = ((string) fieldNameArray[index]);
            if (string.CompareOrdinal(fieldName, basicItemData.IMAGE) == 0) {
                StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(this.getWeblisketSession().getStoreName());
                InventoryUploadMediaUtil inventoryUploadMediaUtil = new InventoryUploadMediaUtil(storeFrontInterface, this.itemInterface);
                FileItem fileItem = ((FileItem) this.getRequestHashMap().get(basicItemData.IMAGE));
                this.itemInterface = inventoryUploadMediaUtil.saveFiles(fileItem.get(), this.imageFileName, this.mediaData);
            }
        }
    }

    private void setRequestHashMap(HashMap<object, object> requestHashMap)
    {
        this.requestHashMap = requestHashMap;
    }

    public virtual HashMap<object, object> getRequestHashMap()
    {
        return this.requestHashMap;
    }

}

