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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using Activity = android.app.Activity;
using AndroidUtil = org.allbinary.AndroidUtil;
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using PreResourceImageUtil = org.allbinary.image.PreResourceImageUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ExceptionUtil = org.allbinary.logic.java.exception.ExceptionUtil;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using DisplayChangeEventListener = org.allbinary.graphics.displayable.@event.DisplayChangeEventListener;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using ImageScaleUtil = org.allbinary.media.image.ImageScaleUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using ImageAnimation = org.allbinary.animation.image.ImageAnimation;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using ARunnable = org.allbinary.thread.ARunnable;
using NullRunnable = org.allbinary.thread.NullRunnable;

namespace org.allbinary.graphics.canvas.transition.progress;

public class AndroidBasicTitleProgressBar : ProgressCanvas, DisplayChangeEventListener
{
    public static readonly string RESOURCE = "ProgressImage";
    private ARunnable showTitleProgressBarRunnable = NullRunnable.getInstance();
    private ARunnable dismissTitleProgressBarRunnable = NullRunnable.getInstance();
    private ARunnable titleProgressDialogPortionSetProgressRunnable = NullRunnable.getInstance();
    private ARunnable titleProgressDialogSetProgressRunnable = NullRunnable.getInstance();
    private Activity midletActivity = AndroidUtil.NULL_ACTIVITY;
    private int portion = 0;
    private readonly Image[] IMAGE = new Image[4];
    private Image image = NullImage.NULL_IMAGE;
    private Animation animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
    private static int background = 0;
    public AndroidBasicTitleProgressBar(string title, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.init();
        DisplayChangeEventHandler.getInstance().addListenerInterface(this);
        int size = this.IMAGE.Length;
        for (int index = 0; index < size; index++) {
            this.IMAGE[index] = NullImage.NULL_IMAGE;
        }
    }

    private void init()
    {
        try {
            if (AndroidBasicTitleProgressBar.background != 0) {
                ResourceUtil.getInstance().addResource(AndroidBasicTitleProgressBar.RESOURCE, AndroidBasicTitleProgressBar.background);
                GameFeatureImageCacheFactory.init();
                this.image = ImageCacheFactory.getInstance().getWithKey(AndroidBasicTitleProgressBar.RESOURCE);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

    public virtual void initActivity(Activity activity)
    {
        try {
            if (this.midletActivity != activity) {
                this.midletActivity = activity;
                this.showTitleProgressBarRunnable = new ShowTitleProgressBarRunnable(this.midletActivity, this);
                this.dismissTitleProgressBarRunnable = new DismissTitleProgressBarRunnable(this.midletActivity, this);
                this.titleProgressDialogSetProgressRunnable = new TitleProgressBarSetProgressRunnable(this.midletActivity, this);
                this.titleProgressDialogPortionSetProgressRunnable = new TitleProgressBarPortionSetProgressRunnable(this.midletActivity, this);
                this.loadProgressImages();
            }
            this.updateCurrent();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

    private void updateCurrent()
    {
        try {
            if (!this.isBackground()) {
                this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
            } else if (AndroidBasicTitleProgressBar.background != 0) {
                DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
                Image currentImage = null;
                if (displayInfo.isPortrait()) {
                    currentImage = this.getImage(0);
                } else {
                    currentImage = this.getImage(2);
                }
                if (currentImage == null) {
                    this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
                } else {
                    this.animation = new ImageAnimation(currentImage, AnimationBehavior.getInstance());
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        try {
            this.loadProgressImages();
            this.updateCurrent();
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION_LABEL + ExceptionUtil.getInstance().getStackTrace(e), this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT);
            this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        }
    }

    private void loadProgressImages()
    {
        try {
            DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
            int lastWidth = displayInfo.getLastWidth();
            int lastHeight = displayInfo.getLastHeight();
            if (displayInfo.isPortraitWH(lastWidth, lastHeight)) {
                this.setImages(0, lastWidth, lastHeight);
            } else {
                this.setImages(2, lastWidth, lastHeight);
            }
        } catch (ArgumentException e) {
            this.logUtil.putF("IllegalArgumentException " + ExceptionUtil.getInstance().getStackTrace(e), this, "loadProgressImages");
            this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        } catch (Exception e) {
            this.logUtil.putF(this.commonStrings.EXCEPTION_LABEL + ExceptionUtil.getInstance().getStackTrace(e), this, "loadProgressImages");
            this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        }
    }

    public virtual bool isInitialized()
    {
        if (this.midletActivity != AndroidUtil.NULL_ACTIVITY) {
            return true;
        } else {
            return false;
        }
    }

    public override void start()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.START_METHOD_NAME);
            base.start();
            this.midletActivity.runOnUiThread(this.showTitleProgressBarRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.START_METHOD_NAME, e);
        }
    }

    public override void end()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.END_METHOD_NAME);
            this.midletActivity.runOnUiThread(this.dismissTitleProgressBarRunnable);
            base.end();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.END_METHOD_NAME, e);
        }
    }

    public override void addEarlyPortion(int value, string text, int index)
    {
        try {
            this.portion = value;
            base.addEarlyPortion(value, text, index);
            if (this.midletActivity != AndroidUtil.NULL_ACTIVITY) {
                this.midletActivity.runOnUiThread(this.titleProgressDialogPortionSetProgressRunnable);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.ADD_PORTION, e);
        }
    }

    public override void addPortion(int value, string text, int index)
    {
        try {
            this.portion = value;
            base.addPortion(value, text, index);
            this.midletActivity.runOnUiThread(this.titleProgressDialogPortionSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.ADD_PORTION, e);
        }
    }

    public override void addNormalPortion(int value, string text)
    {
        try {
            this.portion = value;
            base.addNormalPortion(value, text);
            this.midletActivity.runOnUiThread(this.titleProgressDialogPortionSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.ADD_PORTION, e);
        }
    }

    protected override void setValue(int value)
    {
        try {
            base.setValue(value);
            this.midletActivity.runOnUiThread(this.titleProgressDialogSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "setValue", e);
        }
    }

    public virtual void waitUntilDisplayed()
    {
    }

    // throws Exception
    private void setImages(int index, int lastWidth, int lastHeight)
    {
        Image image = this.image;
        if (image != NullImage.NULL_IMAGE) {
            if (Features.getInstance().isFeature(MainFeatureFactory.getInstance().FULL_SCREEN)) {
                if (this.IMAGE[index] == NullImage.NULL_IMAGE) {
                    this.IMAGE[index] = ImageScaleUtil.getInstance().createImage2(ImageCacheFactory.getInstance(), image, ((float) lastWidth), ((float) image.getWidth()), ((float) lastHeight) - 20f, ((float) image.getHeight()), false);
                }
            } else {
                int nextIndex = index + 1;
                if (this.IMAGE[nextIndex] == NullImage.NULL_IMAGE) {
                    this.IMAGE[nextIndex] = ImageScaleUtil.getInstance().createImage2(ImageCacheFactory.getInstance(), image, ((float) lastWidth), ((float) image.getWidth()), ((float) lastHeight) - 28f, ((float) image.getHeight()), false);
                }
            }
        }
    }

    // throws Exception
    public virtual void initOpenGL(Graphics graphics)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.INIT);
        this.image = GameFeatureImageCacheFactory.getInstance().getWithKey(AndroidBasicTitleProgressBar.RESOURCE);
        PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
        int size = this.IMAGE.Length;
        for (int index = 0; index < size; index++) {
            if (this.IMAGE[index] != NullImage.NULL_IMAGE) {
                this.IMAGE[index] = preResourceImageUtil.encapsulate(this.IMAGE[index]);
            }
        }
        this.updateCurrent();
    }

    // throws Exception
    public override void update(Graphics graphics)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.UPDATE);
        this.initOpenGL(graphics);
        this.image = GameFeatureImageCacheFactory.getInstance().getWithKey(AndroidBasicTitleProgressBar.RESOURCE);
        PreResourceImageUtil preResourceImageUtil = PreResourceImageUtil.getInstance();
        int size = this.IMAGE.Length;
        for (int index = 0; index < size; index++) {
            if (this.IMAGE[index] != NullImage.NULL_IMAGE) {
                preResourceImageUtil.update(graphics, this.IMAGE[index]);
            }
        }
    }

    // throws Exception
    private Image getImage(int index)
    {
        Image image = NullImage.NULL_IMAGE;
        if (Features.getInstance().isFeature(MainFeatureFactory.getInstance().FULL_SCREEN)) {
            image = this.IMAGE[index];
        } else {
            image = this.IMAGE[index + 1];
        }
        return image;
    }

    public override void paint2(Graphics graphics)
    {
        try {
            this.animation.paintXY(graphics, 0, 20);
            base.paint2(graphics);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.PAINT, e);
        }
    }

    public static void setBackgroundResource(int background)
    {
        AndroidBasicTitleProgressBar.background = background;
    }

    protected override void setBackground(bool background)
    {
        base.setBackground(background);
        this.updateCurrent();
    }

    protected virtual void setPortion(int portion)
    {
        this.portion = portion;
    }

    protected virtual int getPortion()
    {
        return this.portion;
    }

}

