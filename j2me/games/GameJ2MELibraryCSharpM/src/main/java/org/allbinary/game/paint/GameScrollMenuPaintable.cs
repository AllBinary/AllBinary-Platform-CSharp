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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ColorChangeEventHandler = org.allbinary.graphics.color.ColorChangeEventHandler;
using ColorChangeListener = org.allbinary.graphics.color.ColorChangeListener;
using FormPaintable = org.allbinary.graphics.form.FormPaintable;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using ABStringComponent = org.allbinary.graphics.form.item.ABStringComponent;
using ABTextItem = org.allbinary.graphics.form.item.ABTextItem;
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.paint;

public class GameScrollMenuPaintable : BasicGameDemoPaintable, ColorChangeListener
{
    public GameScrollMenuPaintable(Paintable mainDemoStatePaintable, Paintable ownershipPaintable, Paintable helpPaintableInterface, BasicColor basicColor) : base(mainDemoStatePaintable, ownershipPaintable, helpPaintableInterface)
    {
        // base(mainDemoStatePaintable, ownershipPaintable, helpPaintableInterface) is called from the constructor declaration
        this.setColor(basicColor);
        ColorChangeEventHandler.getInstance().addListenerInterface(this);
    }

    public override void setState(int state)
    {
        this.setCurrentStatePaintable(this.getMainDemoStatePaintable());
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
    }

    protected virtual void setColor(BasicColor basicColor)
    {
        MainGameDemoStatePaintable mainGameDemoStatePaintable = ((MainGameDemoStatePaintable) this.getMainDemoStatePaintable());
        FormPaintable formPaintable = ((FormPaintable) mainGameDemoStatePaintable.getMenuPaintableInterface());
        ScrollSelectionForm scrollSelectionForm = ((ScrollSelectionForm) formPaintable.getForm());
        mainGameDemoStatePaintable.getOwnershipPaintableInterface().setBasicColorP(basicColor);
        scrollSelectionForm.setButtonBasicColor(basicColor);
        ABTextItem item = null;
        ABStringComponent stringComponent = null;
        for (int index = scrollSelectionForm.size() - 1; index >= 0; index--) {
            item = ((ABTextItem) scrollSelectionForm.get(index));
            stringComponent = item.getLabelStringComponent();
            if (stringComponent != null) {
                stringComponent.setForegroundBasicColor(basicColor);
            }
        }
    }

}

