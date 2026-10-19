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
using NullProgressActivity = org.allbinary.android.activity.NullProgressActivity;
using ProgressActivityInterface = org.allbinary.android.activity.ProgressActivityInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.canvas.transition.progress;

public class AndroidTitleProgressBar : ProgressCanvas
{
    public class TitleProgressBarSetProgressRunnable : Runnable
    {
        private readonly AndroidTitleProgressBar androidTitleProgressBar;
        public TitleProgressBarSetProgressRunnable(AndroidTitleProgressBar androidTitleProgressBar)
        {
            this.androidTitleProgressBar = androidTitleProgressBar;
        }

        public virtual void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            try {
                int value = ((int) this.androidTitleProgressBar.getValue());
                this.androidTitleProgressBar.progressActivity.onTitleProgressBarSetProgress(value);
            } catch (Exception e) {
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    public class TitleProgressBarPortionSetProgressRunnable : Runnable
    {
        private readonly AndroidTitleProgressBar androidTitleProgressBar;
        public TitleProgressBarPortionSetProgressRunnable(AndroidTitleProgressBar androidTitleProgressBar)
        {
            this.androidTitleProgressBar = androidTitleProgressBar;
        }

        public virtual void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            try {
                int value = ((int) (this.androidTitleProgressBar.getValue() + this.androidTitleProgressBar.getMaxValue() / this.androidTitleProgressBar.portion));
                this.androidTitleProgressBar.progressActivity.onTitleProgressBarSetProgress(value);
            } catch (Exception e) {
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    public class ShowTitleProgressBarRunnable : Runnable
    {
        private readonly AndroidTitleProgressBar androidTitleProgressBar;
        public ShowTitleProgressBarRunnable(AndroidTitleProgressBar androidTitleProgressBar)
        {
            this.androidTitleProgressBar = androidTitleProgressBar;
        }

        public virtual void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            try {
                int maxValue = ((int) this.androidTitleProgressBar.getMaxValue());
                this.androidTitleProgressBar.progressActivity.onShowTitleProgressBar(maxValue, false);
            } catch (Exception e) {
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    public class DismissTitleProgressBarRunnable : Runnable
    {
        private readonly AndroidTitleProgressBar androidTitleProgressBar;
        public DismissTitleProgressBarRunnable(AndroidTitleProgressBar androidTitleProgressBar)
        {
            this.androidTitleProgressBar = androidTitleProgressBar;
        }

        public virtual void run()
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            try {
                this.androidTitleProgressBar.progressActivity.onDismissTitleProgressBar();
            } catch (Exception e) {
                logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            }
        }

    }
    private ShowTitleProgressBarRunnable showTitleProgressBarRunnable;
    private DismissTitleProgressBarRunnable dismissTitleProgressBarRunnable;
    private TitleProgressBarPortionSetProgressRunnable progressDialogPortionSetProgressRunnable;
    private TitleProgressBarSetProgressRunnable progressDialogSetProgressRunnable;
    private ProgressActivityInterface progressActivity = NullProgressActivity.NULL_PROGRESS_ACTIVITY;
    private int portion = 0;
    protected AndroidTitleProgressBar(string title, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, backgroundBasicColor, foregroundBasicColor)
    {
        this.showTitleProgressBarRunnable = new ShowTitleProgressBarRunnable(this);
        this.dismissTitleProgressBarRunnable = new DismissTitleProgressBarRunnable(this);
        this.progressDialogPortionSetProgressRunnable = new TitleProgressBarPortionSetProgressRunnable(this);
        this.progressDialogSetProgressRunnable = new TitleProgressBarSetProgressRunnable(this);
        // base(title, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    public virtual void init(ProgressActivityInterface activity)
    {
        this.progressActivity = activity;
    }

    public virtual bool isInitialized()
    {
        if (this.progressActivity != NullProgressActivity.NULL_PROGRESS_ACTIVITY) {
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
            this.progressActivity.runOnUiThread(this.showTitleProgressBarRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.START_METHOD_NAME, e);
        }
    }

    public override void end()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.END_METHOD_NAME);
            this.progressActivity.runOnUiThread(this.dismissTitleProgressBarRunnable);
            base.end();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.END_METHOD_NAME, e);
        }
    }

    public override void addPortion(int value, string text, int index)
    {
        try {
            base.addPortion(value, text, index);
            this.portion = value;
            this.progressActivity.runOnUiThread(this.progressDialogPortionSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.ADD_PORTION, e);
        }
    }

    public override void addNormalPortion(int value, string text)
    {
        try {
            base.addNormalPortion(value, text);
            this.portion = value;
            this.progressActivity.runOnUiThread(this.progressDialogPortionSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.ADD_PORTION, e);
        }
    }

    protected override void setValue(int value)
    {
        try {
            base.setValue(value);
            this.progressActivity.runOnUiThread(this.progressDialogSetProgressRunnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "setValue", e);
        }
    }

    public virtual void waitUntilDisplayed()
    {
    }

    public override void paint(Graphics graphics)
    {
    }

}

