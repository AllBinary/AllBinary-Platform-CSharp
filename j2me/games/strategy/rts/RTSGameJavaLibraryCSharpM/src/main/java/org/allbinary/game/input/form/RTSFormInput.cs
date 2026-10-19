/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using GroupCommonFactory = org.allbinary.game.identification.GroupCommonFactory;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using LayerInterfaceFactoryImageItem = org.allbinary.game.layer.item.LayerInterfaceFactoryImageItem;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using org.allbinary.util;

namespace org.allbinary.game.input.form;

public class RTSFormInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly GroupCommonFactory groupCommonFactory = GroupCommonFactory.getInstance();
    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    public readonly CollidableDestroyableDamageableLayer[] newUnconstructedRTSLayerInterfaceArray = new CollidableDestroyableDamageableLayer[7];
    public readonly Group[] groupInterfaceArray;
    private GeographicMapCellPosition selectedGeographicCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private bool stickyItemSelected = false;
    private int selectedStickyItemIndex = 0;
    private ABCustomItem selectedStickyItem = ABCustomItem.getNullInstance();
    public RTSFormInput(Group[] groupInterfaceArray)
    {
        int size = this.newUnconstructedRTSLayerInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            this.newUnconstructedRTSLayerInterfaceArray[index] = CollidableDestroyableDamageableLayer.getNullInstance();
        }
        this.groupInterfaceArray = groupInterfaceArray;
        this.hashtable.put(DirectionFactory.getInstance().NAME, DirectionFactory.getInstance().DOWN);
        if (groupInterfaceArray != null) {
            this.hashtable.put(this.groupCommonFactory.ID, groupInterfaceArray);
        }
    }

    // throws Exception
    public virtual void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
    }

    // throws Exception
    public virtual void processAtPoint(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GPoint point)
    {
        int index = this.getIndexAt(rtsPlayerLayerInterface, point);
        if (index < 0) {
            return;
        }
        ScrollSelectionForm scrollSelectionForm = rtsPlayerLayerInterface.getCurrentScrollSelectionForm();
        ABCustomItem item = scrollSelectionForm.get(index);
        if (item == null) {
            return;
        }
        this.processGameSpecific(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, item, index);
    }

    // throws Exception
    public virtual void process(AllBinaryLayerManager layerManager)
    {
        this.setAllBinaryGameLayerManager(((AllBinaryGameLayerManager) layerManager));
    }

    // throws Exception
    public virtual void processGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int index)
    {
    }

    // throws Exception
    public virtual bool processSticky(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GPoint point)
    {
        int index = this.getIndexAt(rtsPlayerLayerInterface, point);
        if (index < 0) {
            return false;
        }
        ScrollSelectionForm scrollSelectionForm = rtsPlayerLayerInterface.getCurrentScrollSelectionForm();
        ABCustomItem item = scrollSelectionForm.get(index);
        if (item == null) {
            return false;
        }
        this.processStickyGameSpecific(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, item, index);
        return true;
    }

    // throws Exception
    public virtual void processStickyGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int index)
    {
    }

    // throws Exception
    protected virtual ABCustomItem getItemAt(RTSPlayerLayerInterface rtsPlayerLayerInterface, GPoint point)
    {
        this.logUtil.putF(new StringMaker().append("Point: ").append(StringUtil.getInstance().toString(point)).ToString(), this, "getItemAt");
        ScrollSelectionForm scrollSelectionForm = rtsPlayerLayerInterface.getCurrentScrollSelectionForm();
        return scrollSelectionForm.getSelectedItem(point);
    }

    // throws Exception
    protected virtual int getIndexAt(RTSPlayerLayerInterface rtsPlayerLayerInterface, GPoint point)
    {
        this.logUtil.putF(new StringMaker().append("Point: ").append(StringUtil.getInstance().toString(point)).ToString(), this, "getItemAt");
        ScrollSelectionForm scrollSelectionForm = rtsPlayerLayerInterface.getCurrentScrollSelectionForm();
        return scrollSelectionForm.getSelectedIndexForPoint(point);
    }

    // throws Exception
    protected virtual CollidableDestroyableDamageableLayer getInstance(AllBinaryLayerManager layerManager, ABCustomItem aItem, GeographicMapCellPosition geographicMapCellPosition)
    {
        LayerInterfaceFactoryImageItem item = ((LayerInterfaceFactoryImageItem) aItem);
        LayerInterfaceFactoryInterface layerInterfaceFactoryInterface = item.getLayerInterfaceFactoryInterface();
        GPoint cellPoint = geographicMapCellPosition.getPoint();
        if (layerInterfaceFactoryInterface != null) {
            this.hashtable.put(AllBinaryGameLayerManager.ID, layerManager);
            return ((RTSLayer) layerInterfaceFactoryInterface.getNextInstance(this.getHashtable(), cellPoint.getX(), cellPoint.getY(), cellPoint.getZ()));
        }
        return CollidableDestroyableDamageableLayer.getNullInstance();
    }

    public virtual GeographicMapCellPosition getSelectedGeographicCellPosition()
    {
        return this.selectedGeographicCellPosition;
    }

    public virtual void setSelectedGeographicCellPosition(GeographicMapCellPosition selectedGeographicCellPosition)
    {
        this.logUtil.putF(new StringMaker().append("Selected GeographicMapCellPosition: ").append(selectedGeographicCellPosition.ToString()).ToString(), this, "setSelectedGeographicCellPosition");
        this.selectedGeographicCellPosition = selectedGeographicCellPosition;
    }

    public virtual bool isStickyItemSelected()
    {
        return this.stickyItemSelected;
    }

    public virtual void setStickyItemSelected(bool stickyItemSelected)
    {
        this.stickyItemSelected = stickyItemSelected;
    }

    public virtual ABCustomItem getSelectedStickyItem()
    {
        return this.selectedStickyItem;
    }

    public virtual void setSelectedStickyItem(ABCustomItem selectedStickyItem)
    {
        this.selectedStickyItem = selectedStickyItem;
    }

    public virtual int getSelectedStickyItemIndex()
    {
        return this.selectedStickyItemIndex;
    }

    public virtual void setSelectedStickyItemIndex(int selectedStickyItemIndex)
    {
        this.selectedStickyItemIndex = selectedStickyItemIndex;
    }

    public virtual ABHashtable<object, object> getHashtable()
    {
        return this.hashtable;
    }

}

