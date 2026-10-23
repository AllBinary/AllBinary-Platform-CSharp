/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using RTSLayerFormFactory = org.allbinary.game.input.RTSLayerFormFactory;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using ItemArraySingletonFactoryInterface = org.allbinary.graphics.form.item.ItemArraySingletonFactoryInterface;

namespace org.allbinary.game.layer;

public class AdvancedRTSLayerFormFactory : RTSLayerFormFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly ScrollSelectionForm scrollSelectionForm;
    public AdvancedRTSLayerFormFactory(string label, ItemArraySingletonFactoryInterface itemArrayFactoryInterface)
    {
        ScrollSelectionForm scrollSelectionForm = ScrollSelectionForm.getNullScrollSelectionForm();
        try {
            ABCustomItem[] items = itemArrayFactoryInterface.getItems();
            scrollSelectionForm = RTSScrollSelectionFormFactory.getInstance(label, items);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
        this.scrollSelectionForm = scrollSelectionForm;
    }

    public override ScrollSelectionForm getInstance(RTSLayer rtsLayer)
    {
        return this.scrollSelectionForm;
    }

}

