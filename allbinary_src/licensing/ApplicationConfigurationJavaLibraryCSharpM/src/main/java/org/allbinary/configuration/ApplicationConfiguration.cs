// Generated Code Do Not Modify

using System;
using System.Linq;
//using Closeable = java.io.Closeable;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
using Feature = org.allbinary.game.configuration.feature.Feature;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDataInputStream = org.allbinary.logic.io.AbDataInputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using FileStreamFactory = org.allbinary.logic.io.FileStreamFactory;
using NullCloseable = org.allbinary.logic.io.NullCloseable;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
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
    private readonly string FILE = "ReloadConfiguration.dat";
    private ApplicationConfiguration()
    {
        try {
            if (FileFactory.getInstance().isFile(this.FILE)) {
                this.read();
            } else {
                this.write();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    // throws Exception
    private void read()
    {
        FileStreamFactory fileInputStreamFactory = FileStreamFactory.getInstance();
        InputStream fileInputStream = fileInputStreamFactory.getFileInputStreamInstance(StringUtil.getInstance().EMPTY_STRING, this.FILE);
        AbDataInputStream dataInputStream = new AbDataInputStream(fileInputStream);
        int fullScreen = dataInputStream.readInt();
        if (fullScreen == 0) {
            this.setFullscreen(false);
        } else if (fullScreen == 1) {
            this.setFullscreen(true);
        } else {
            throw new Exception("Invalid FullScreen ActivityConfiguration");
        }
        int progressBarView = dataInputStream.readInt();
        if (progressBarView == 0) {
            this.setProgressBarView(false);
        } else if (progressBarView == 1) {
            this.setProgressBarView(true);
        } else {
            throw new Exception("Invalid ProgressBarView ActivityConfiguration");
        }
        int showTitleBar = dataInputStream.readInt();
        if (showTitleBar == 0) {
            this.setShowTitleBar(false);
        } else if (showTitleBar == 1) {
            this.setShowTitleBar(true);
        } else {
            throw new Exception("Invalid ShowTitleBar ActivityConfiguration");
        }
        this.logUtil.putF("Read Configuration: " + this.ToString(), this, "read");
    }

    // throws Exception
    public virtual void write()
    {
        Closeable closeable = NullCloseable.NULL_CLOSEABLE;
        try {
            this.logUtil.putF("Write Configuration: " + this.ToString(), this, "write");
            FileStreamFactory fileInputStreamFactory = FileStreamFactory.getInstance();
            OutputStream fileOutputStream = fileInputStreamFactory.getFileOutputStreamInstance(StringUtil.getInstance().EMPTY_STRING, this.FILE);
            AbDataOutputStream dataOutputStream = new AbDataOutputStream(fileOutputStream);
            closeable = dataOutputStream;
            if (this.isFullscreen()) {
                dataOutputStream.writeInt(1);
            } else {
                dataOutputStream.writeInt(0);
            }
            if (this.isProgressBarView()) {
                dataOutputStream.writeInt(1);
            } else {
                dataOutputStream.writeInt(0);
            }
            if (this.isShowTitleBar()) {
                dataOutputStream.writeInt(1);
            } else {
                dataOutputStream.writeInt(0);
            }
            dataOutputStream.flush();
        } catch (Exception e) {
            throw e;
        } finally {
            StreamUtil.getInstance().close(closeable);
        }
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

