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
using Font = javax.microedition.lcdui.Font;
using Graphics = javax.microedition.lcdui.Graphics;
using NumberStringHud = org.allbinary.game.ag.layer.hud.basic.NumberStringHud;
using NumberStringHudFactory = org.allbinary.game.ag.layer.hud.basic.NumberStringHudFactory;
using SelectionHudPaintable = org.allbinary.game.layer.SelectionHudPaintable;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using MathUtil = org.allbinary.logic.math.MathUtil;

namespace org.allbinary.game.layer.building;

public class BuildingInfoHudPaintable : SelectionHudPaintable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BuildingInfoHudPaintable instance = new BuildingInfoHudPaintable();
    public static BuildingInfoHudPaintable getInstance()
    {
        return BuildingInfoHudPaintable.instance;
    }

    private readonly string HEALTH = "Health:";
    private readonly NumberStringHud productivityHud;
    private readonly NumberStringHud efficiencyHud;
    private readonly NumberStringHud healthHud;
    private readonly NumberStringHud maxHealthHud;
    private PathFindingLayerInterface rtsLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    private int currentHealth = 0;
    private BuildingInfoHudPaintable()
    {
        NumberStringHudFactory numberStringHudFactory = NumberStringHudFactory.getInstance();
        NumberStringHud productivityHud = numberStringHudFactory.NULL_NUMBER_STRING_HUD;
        NumberStringHud efficiencyHud = numberStringHudFactory.NULL_NUMBER_STRING_HUD;
        NumberStringHud healthHud = numberStringHudFactory.NULL_NUMBER_STRING_HUD;
        NumberStringHud maxHealthHud = numberStringHudFactory.NULL_NUMBER_STRING_HUD;
        try {
            BasicHudFactory basicHudFactory = BasicHudFactory.getInstance();
            BasicColor basicColor = this.getBasicColorP();
            int textX = this.textX;
            int y = this.y;
            productivityHud = new BuildingNumberHud("Productivity:", 999, basicHudFactory, basicColor, textX, y, 1, 0, true);
            efficiencyHud = new BuildingNumberHud("Efficiency:", 999, basicHudFactory, basicColor, textX, y, 2, 0, false);
            healthHud = new BuildingNumberHud(this.HEALTH, 99999, basicHudFactory, basicColor, textX, y, 3, 0, true);
            maxHealthHud = new BuildingNumberHud("/ ", 99999, basicHudFactory, basicColor, textX, y, 3, this.HEALTH.Length + 1, false);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
        this.productivityHud = productivityHud;
        this.efficiencyHud = efficiencyHud;
        this.healthHud = healthHud;
        this.maxHealthHud = maxHealthHud;
    }

    private class BuildingNumberHud : NumberStringHud
    {
        private readonly int baseTextX;
        private readonly int baseY;
        private readonly int row;
        private readonly int prefixLength;
        private readonly bool positionBeforeMeasurement;
        public BuildingNumberHud(string label, int maximum, BasicHudFactory basicHudFactory, BasicColor basicColor, int baseTextX, int baseY, int row, int prefixLength, bool positionBeforeMeasurement) : base(label, maximum, basicHudFactory.ABSOLUTE, basicHudFactory.HORIZONTAL, 0, basicColor)
        {
            // Constructor invocation emitted in the initializer.
            this.baseTextX = baseTextX;
            this.baseY = baseY;
            this.row = row;
            this.prefixLength = prefixLength;
            this.positionBeforeMeasurement = positionBeforeMeasurement;
        }

        public override void updateMeasurement(Graphics graphics)
        {
            if (!this.positionBeforeMeasurement) {
                base.updateMeasurement(graphics);
            }
            Font font = graphics.getFont();
            this.updateMaxWidth = this.baseTextX + this.prefixLength * font.getHeight();
            this.updateMaxHeight = this.baseY + this.row * font.getHeight();
            if (this.positionBeforeMeasurement) {
                base.updateMeasurement(graphics);
            }
        }

    }
    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        int totalLength = this.HEALTH.Length + MathUtil.getInstance().getTotalDigits(this.currentHealth);
        this.maxHealthHud.setX(this.textX + MyFontProcessor.defaultStringWidth(font, totalLength));
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        base.setBasicColorP(basicColor);
        this.productivityHud.setBasicColorP(basicColor);
        this.efficiencyHud.setBasicColorP(basicColor);
        this.healthHud.setBasicColorP(basicColor);
        this.maxHealthHud.setBasicColorP(basicColor);
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.myFontProcessor.process(graphics);
        this.productivityHud.paint(graphics);
        this.efficiencyHud.paint(graphics);
        this.healthHud.paint(graphics);
        this.maxHealthHud.paint(graphics);
        this.getAnimationInterface().paintXY(graphics, this.imageX, this.y);
    }

    public override void updateSelectionInfo()
    {
        BuildingLayer buildingLayer = ((BuildingLayer) this.rtsLayer);
        this.setName(buildingLayer.getName());
        this.setAnimationInterface(buildingLayer.getVerticleBuildAnimationInterface());
        this.productivityHud.set(buildingLayer.getProductivity());
        this.efficiencyHud.set(buildingLayer.getEfficiency() / 100);
        this.currentHealth = buildingLayer.getHealthInterface().getHealth();
        this.healthHud.set(this.currentHealth);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.maxHealthHud.set(buildingLayer.getHealthInterface().getMaxHealth());
    }

    public virtual void setRtsLayer(PathFindingLayerInterface rtsLayer)
    {
        this.rtsLayer = rtsLayer;
    }

}

