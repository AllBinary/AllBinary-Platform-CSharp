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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using GameAdStateFactory = org.allbinary.business.advertisement.GameAdStateFactory;
using Processor = org.allbinary.canvas.Processor;
using GameAdState = org.allbinary.game.GameAdState;
using GameNotification = org.allbinary.game.ag.layer.hud.basic.notification.GameNotification;
using GameNotificationHud = org.allbinary.game.ag.layer.hud.basic.notification.GameNotificationHud;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using CustomGPoint = org.allbinary.graphics.CustomGPoint;
using GPoint = org.allbinary.graphics.GPoint;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.game.ag.layer.hud.basic;

public class PlayerGameNotificationHud : GameNotificationHud, UpdateMyFontInterface
{
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(0);
    private readonly CircularIndexUtil circularIndexUtil;
    private readonly GameNotification gameNotification = new GameNotification();
    private readonly GameNotification permanentGameNotification = new GameNotification();
    private class SetAndRemoveProcessor : Processor
    {
        private readonly PlayerGameNotificationHud updateMeasurementProcessor;
        public SetAndRemoveProcessor(PlayerGameNotificationHud updateMeasurementProcessor)
        {
            this.updateMeasurementProcessor = updateMeasurementProcessor;
        }

        // throws Exception
        public override void process()
        {
            this.updateMeasurementProcessor.setAndRemoveProcess();
        }

    }
    private class NextUnremoveableProcessor : Processor
    {
        private readonly PlayerGameNotificationHud updateMeasurementProcessor;
        public NextUnremoveableProcessor(PlayerGameNotificationHud updateMeasurementProcessor)
        {
            this.updateMeasurementProcessor = updateMeasurementProcessor;
        }

        // throws Exception
        public override void process()
        {
            this.updateMeasurementProcessor.setNextUnremoveableProcess();
        }

    }
    private readonly Processor setAndRemoveProcessor;
    private readonly Processor nextUnremoveableProcessor;
    private Processor processor = Processor.getInstance();
    private readonly string PERMANENT_GAME_NOTIFICATION = "Permanent Game Notification: ";
    private string lastString = StringUtil.getInstance().EMPTY_STRING;
    private string @string;
    private CustomGPoint point = CustomGPoint.NULL_CUSTOM_POINT;
    private int width = 0;
    public PlayerGameNotificationHud(int location, int direction, int bufferZone, BasicColor basicColor) : base(location, direction, bufferZone, basicColor)
    {
        this.setAndRemoveProcessor = new SetAndRemoveProcessor(this);
        this.nextUnremoveableProcessor = new NextUnremoveableProcessor(this);
        this.@string = this.EMPTY_STRING;
        // base(location, direction, bufferZone, basicColor) is called from the constructor declaration
        this.circularIndexUtil = CircularIndexUtil.createInstance(0);
        GameNotificationEventHandler gameNotificationEventHandler = GameNotificationEventHandler.getInstance();
        gameNotificationEventHandler.removeAllListeners();
        gameNotificationEventHandler.addListenerInterface(this);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        try {
            base.updateMeasurement(graphics);
            Font font = graphics.getFont();
            this.width = font.stringWidth(this.@string);
            this.processor.process();
            this.processor = Processor.getInstance();
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.UPDATE, e);
        }
    }

    public override GPoint getPoint(int x, int y)
    {
        this.point = CustomGPoint.getInstance3(0, 0);
        this.point.setX(x);
        this.point.setY(y);
        return this.point;
    }

    public override void add(string @string, int? seconds, BasicColor basicColor, bool? permanent)
    {
        if (permanent.Value) {
            if (this.lastString != @string) {
                this.lastString = @string;
                this.logUtil.putF(new StringMaker().append(this.PERMANENT_GAME_NOTIFICATION).append(@string).ToString(), this, this.commonStrings.ADD);
            }
            this.permanentGameNotification.add(@string, seconds, basicColor);
            this.circularIndexUtil.setSize(this.permanentGameNotification.getSize());
        } else {
            this.gameNotification.add(@string, seconds, basicColor);
        }
    }

    // throws Exception
    public override void processTick()
    {
        if (this.timeDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            GameAdState gameAdState = GameAdStateFactory.getInstance().getCurrentInstance();
            if (gameAdState.isShowingAtLocation(this.getLocation())) {
                this.offsetY = -54;
            } else {
                this.offsetY = 0;
            }
            if (this.gameNotification.getSize() > 0) {
                this.setAndRemove();
            } else if (this.permanentGameNotification.getSize() > 0) {
                this.setNextUnremoveable();
            } else {
                this.@string = this.EMPTY_STRING;
            }
        }
    }

    // throws Exception
    private void setAndRemove()
    {
        this.@string = ((string) this.gameNotification.stringList.removeAt(0));
        this.processor = this.setAndRemoveProcessor;
    }

    // throws Exception
    private void setAndRemoveProcess()
    {
        this.setX((this.displayInfo.getLastWidth() - this.width) >> 1);
        this.point.setX(this.getX());
        this.point.setY(this.getY());
        int? time = ((int?) this.gameNotification.timeList.removeAt(0));
        int iTime = ((int) time) * 1000;
        if (iTime == 0) {
            iTime = 500;
        }
        this.timeDelayHelper.delay = iTime;
        this.setBasicColorP(((BasicColor) this.gameNotification.colorList.removeAt(0)));
    }

    // throws Exception
    private void setNextUnremoveable()
    {
        int index = this.circularIndexUtil.getIndex();
        this.@string = ((string) this.permanentGameNotification.stringList.objectArray[index]);
        this.processor = this.nextUnremoveableProcessor;
    }

    // throws Exception
    private void setNextUnremoveableProcess()
    {
        int index = this.circularIndexUtil.getIndex();
        this.setX((this.displayInfo.getLastWidth() - this.width) >> 1);
        this.point.setX(this.getX());
        this.point.setY(this.getY());
        int? time = ((int?) this.permanentGameNotification.timeList.objectArray[index]);
        this.timeDelayHelper.delay = ((int) time) * 1000;
        this.setBasicColorP(((BasicColor) this.permanentGameNotification.colorList.objectArray[index]));
        this.circularIndexUtil.next();
    }

    public override void clear()
    {
        this.gameNotification.clear();
        this.permanentGameNotification.clear();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        base.paintString(graphics, this.@string);
    }

}

