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
//using Arrays = java.util.Arrays;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringComparator = org.allbinary.logic.control.sort.StringComparator;
using CustomizerTransformInfoData = org.allbinary.logic.visual.transform.info.CustomizerTransformInfoData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformTemplateCustomizerData = org.allbinary.logic.visual.transform.template.customizer.TransformTemplateCustomizerData;
using TransformTemplateCustomizersData = org.allbinary.logic.visual.transform.template.customizer.TransformTemplateCustomizersData;
using BodyData = org.allbinary.logic.visual.transform.template.customizer.bodies.BodyData;
using TitleData = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleData;
using TransformTemplateCustomizerUtil = org.allbinary.logic.visual.transform.template.util.TransformTemplateCustomizerUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.customizers;

public class CustomizersView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly BasicArrayList customizersVector;
    public CustomizersView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.customizersVector = TransformInfoEntityBuilder.getInstance().getNames(this.getWeblisketSession().getStoreName());
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            Node node = document.createElement(TransformTemplateCustomizersData.NAME);
            BasicArrayList unsortedCustomizerViewVector = new BasicArrayListD();
            int size = this.customizersVector.size();
            for (int index = 0; index < size; index++) {
                string viewName = ((string) this.customizersVector.get(index));
                if (viewName.IndexOf(CustomizerTransformInfoData.NAME) > 0 && viewName.IndexOf(GLOBALS2.EDIT) > 0 && viewName.IndexOf(BodyData.getInstance().VIEWNAMEKEY) > 0 && viewName.IndexOf(TitleData.getInstance().VIEWNAMEKEY) > 0) {
                    unsortedCustomizerViewVector.add(viewName);
                }
            }
            object[] objectArray = ((object[]) unsortedCustomizerViewVector.toArray());
            Arrays.sort(objectArray, new StringComparator());
            for (int index = 0; index < objectArray.Length; index++) {
                string viewName = ((string) objectArray[index]);
                Node viewNameNode = ModDomHelper.createNameValueNodes(document, TransformTemplateCustomizerData.NAME, viewName, TransformTemplateCustomizerUtil.getInstance().getPageNameHack(viewName, this.getWeblisketSession().getStoreName()));
                node.appendChild(viewNameNode);
            }
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            return null;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

