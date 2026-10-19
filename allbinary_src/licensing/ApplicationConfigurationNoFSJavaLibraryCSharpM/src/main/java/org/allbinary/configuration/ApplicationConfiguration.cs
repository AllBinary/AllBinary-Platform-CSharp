// Generated Code Do Not Modify

using System;
using System.Linq;
using Feature = org.allbinary.game.configuration.feature.Feature;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.configuration;

public class ApplicationConfiguration
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static ApplicationConfiguration getInstance()
    {
        if (ApplicationConfiguration.instance == NullUtil.getInstance().NULL_OBJECT) {
            ApplicationConfiguration.instance = new ApplicationConfiguration();
        }
        return ((ApplicationConfiguration) ApplicationConfiguration.instance);
    }

    private bool fullscreen = true;
    private bool showTitleBar = false;
    private bool progressBarView = false;
    private ApplicationConfiguration()
    {
        try {
            this.read();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    // throws Exception
    private void read()
    {
        this.setFullscreen(true);
        this.setProgressBarView(false);
        this.setShowTitleBar(false);
        this.logUtil.putF("Read Configuration: " + this.ToString(), this, "read");
    }

    // throws Exception
    public virtual void write()
    {
    }

    // throws Exception
    public virtual void update(Feature gameFeature)
    {
        if (gameFeature == MainFeatureFactory.getInstance().FULL_SCREEN) {
            Features features = Features.getInstance();
            if (features.isFeature(gameFeature)) {
                if (!this.isFullscreen()) {
                    this.setFullscreen(true);
                    this.write();
                }
            } else {
                if (this.isFullscreen()) {
                    this.setFullscreen(false);
                    this.write();
                }
            }
        }
    }

    public virtual void setFullscreen(bool fullscreen)
    {
        this.fullscreen = fullscreen;
    }

    public virtual bool isFullscreen()
    {
        return this.fullscreen;
    }

    public virtual void setShowTitleBar(bool showTitleBar)
    {
        this.showTitleBar = showTitleBar;
    }

    public virtual bool isShowTitleBar()
    {
        return this.showTitleBar;
    }

    public virtual void setProgressBarView(bool progressBarView)
    {
        this.progressBarView = progressBarView;
    }

    public virtual bool isProgressBarView()
    {
        return this.progressBarView;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("isFullscreen: ");
        stringBuffer.appendboolean(this.isFullscreen());
        stringBuffer.append(" isProgressBarView: ");
        stringBuffer.appendboolean(this.isProgressBarView());
        stringBuffer.append(" isShowTitleBar: ");
        stringBuffer.appendboolean(this.isShowTitleBar());
        return stringBuffer.ToString();
    }

}

