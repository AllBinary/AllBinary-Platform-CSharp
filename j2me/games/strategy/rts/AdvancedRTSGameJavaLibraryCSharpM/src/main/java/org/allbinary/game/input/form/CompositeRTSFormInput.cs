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
using RTSPlayerLayerInterface = org.allbinary.game.layer.RTSPlayerLayerInterface;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Group = org.allbinary.game.identification.Group;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using GPoint = org.allbinary.graphics.GPoint;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.game.input.form;

public class CompositeRTSFormInput : RTSFormInput
{
    private readonly RTSFormInput[] rtsFormInputArray;
    private readonly int[] itemIndex;
    private readonly bool isPrimaryWaypointCreator;
    public CompositeRTSFormInput(Group[] groupInterface, bool isPrimaryWaypointCreator, int[] itemIndex) : base(groupInterface)
    {
        // base(groupInterface) is called from the constructor declaration
        this.itemIndex = itemIndex;
        this.isPrimaryWaypointCreator = isPrimaryWaypointCreator;
        this.rtsFormInputArray = new RTSFormInput[2];
        this.rtsFormInputArray[0] = new WaypointRTSFormInput(this.groupInterfaceArray, isPrimaryWaypointCreator);
        this.rtsFormInputArray[1] = new UnitRTSFormInput(this.groupInterfaceArray);
    }

    // throws Exception
    public override void setAllBinaryGameLayerManager(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        base.setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) allBinaryGameLayerManager);
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        int size = this.rtsFormInputArray.Length;
        for (int index = 0; index < size; index++) {
            this.rtsFormInputArray[index].setAllBinaryGameLayerManager(allBinaryGameLayerManager);
        }
    }

    // throws Exception
    public override void processAtPoint(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GPoint point)
    {
        ScrollSelectionForm scrollSelectionForm = rtsPlayerLayerInterface.getCurrentScrollSelectionForm();
        int index = scrollSelectionForm.getSelectedIndexForPoint(point);
        if (this.isStickyItemSelected() && associatedRtsLayer == CollidableDestroyableDamageableLayer.getNullInstance()) {
            if (this.getSelectedStickyItemIndex() <= this.itemIndex[0]) {
                this.rtsFormInputArray[0].processAtPoint(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, point);
            }
        } else if (index > this.itemIndex[0]) {
            this.rtsFormInputArray[1].processAtPoint(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, point);
        }
    }

    // throws Exception
    public override void processGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int index)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(CommonLabels.getInstance().INDEX_LABEL + index + " > " + this.itemIndex[0], this, commonStrings.PROCESS);
        if (this.isStickyItemSelected() && associatedRtsLayer == CollidableDestroyableDamageableLayer.getNullInstance()) {
            if (this.getSelectedStickyItemIndex() <= this.itemIndex[0]) {
                this.rtsFormInputArray[0].processGameSpecific(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, item, index);
            }
        } else if (index > this.itemIndex[0]) {
            this.rtsFormInputArray[1].processGameSpecific(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, item, index);
        }
    }

    // throws Exception
    public override bool processSticky(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, GPoint point)
    {
        return this.rtsFormInputArray[0].processSticky(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, point);
    }

    // throws Exception
    public override void processStickyGameSpecific(CollidableDestroyableDamageableLayer associatedRtsLayer, RTSPlayerLayerInterface rtsPlayerLayerInterface, AllBinaryLayerManager layerManager, ABCustomItem item, int index)
    {
        this.rtsFormInputArray[0].processStickyGameSpecific(associatedRtsLayer, rtsPlayerLayerInterface, layerManager, item, index);
    }

    public override int getSelectedStickyItemIndex()
    {
        return this.rtsFormInputArray[0].getSelectedStickyItemIndex();
    }

    public override bool isStickyItemSelected()
    {
        return this.rtsFormInputArray[0].isStickyItemSelected();
    }

    public override void setStickyItemSelected(bool stickyItemSelected)
    {
        this.rtsFormInputArray[0].setStickyItemSelected(stickyItemSelected);
    }

    public override ABCustomItem getSelectedStickyItem()
    {
        return this.rtsFormInputArray[0].getSelectedStickyItem();
    }

    public override void setSelectedStickyItem(ABCustomItem selectedStickyItem)
    {
        this.rtsFormInputArray[0].setSelectedStickyItem(selectedStickyItem);
    }

}

