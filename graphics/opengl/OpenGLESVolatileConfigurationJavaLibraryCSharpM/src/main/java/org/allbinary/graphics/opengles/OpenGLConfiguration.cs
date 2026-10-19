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
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using Feature = org.allbinary.game.configuration.feature.Feature;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.opengles;

public class OpenGLConfiguration
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static OpenGLConfiguration getInstance()
    {
        if (OpenGLConfiguration.instance == NullUtil.getInstance().NULL_OBJECT) {
            OpenGLConfiguration.instance = new OpenGLConfiguration();
        }
        return ((OpenGLConfiguration) OpenGLConfiguration.instance);
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private bool opengl = false;
    private OpenGLFeature type = OpenGLFeatureFactory.getInstance().OPENGL_AS_GAME_THREAD;
    private OpenGLFeature imageColor = OpenGLFeatureFactory.getInstance().IMAGE_COLOR_DEPTH_4444;
    private OpenGLFeature color = OpenGLFeatureFactory.getInstance().IMAGE_COLOR_DEPTH_4444;
    private OpenGLFeature versionSelector = OpenGLFeatureFactory.getInstance().OPENGL_AUTO_SELECT;
    private OpenGLConfiguration()
    {
    }

    public virtual void write()
    {
    }

    // throws Exception
    public virtual void init()
    {
        Features features = Features.getInstance();
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(MainFeatureFactory.getInstance().STATIC)) {
            if (this.isOpenGL()) {
                if (!features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
                    this.logUtil.putF("Turning on OpenGL", this, this.commonStrings.INIT);
                    features.addDefault(OpenGLFeatureFactory.getInstance().OPENGL);
                    this.logUtil.putF("Using OpenGL Type Feature: " + this.getType(), this, this.commonStrings.INIT);
                    features.addDefault(this.getType());
                    this.logUtil.putF("Using OpenGL ImageColor Feature: " + this.getImageColor(), this, this.commonStrings.INIT);
                    features.addDefault(this.getImageColor());
                    this.logUtil.putF("Using OpenGL Color Feature: " + this.getColor(), this, this.commonStrings.INIT);
                    features.addDefault(this.getColor());
                    this.logUtil.putF("Using OpenGL Version Selector Feature: " + this.getVersionSelector(), this, this.commonStrings.INIT);
                    features.addDefault(this.getVersionSelector());
                }
            } else {
                this.logUtil.putF("OpenGL is Off", this, this.commonStrings.INIT);
            }
        } else {
            if (this.isOpenGL() && !features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
                PreLogUtil.put("OpenGL is set but not Enabled since Statics where not cleared (Reboot or Complete exit is Required)", this, this.commonStrings.INIT);
            }
        }
        PreLogUtil.put(this.ToString(), this, this.commonStrings.INIT);
    }

    // throws Exception
    public virtual void update(Feature gameFeature, bool colorLocked)
    {
        Features features = Features.getInstance();
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        bool modified = false;
        if (gameFeature == openGLFeatureFactory.OPENGL) {
            if (features.isFeature(gameFeature)) {
                if (!this.isOpenGL()) {
                    this.setOpenGL(true);
                    modified = true;
                }
            } else {
                if (this.isOpenGL()) {
                    this.setOpenGL(false);
                    modified = true;
                }
            }
        }
        if (gameFeature == openGLFeatureFactory.OPENGL_AND_GAME_HAVE_DIFFERENT_THREADS || gameFeature == openGLFeatureFactory.OPENGL_AS_GAME_THREAD) {
            if (features.isFeature(gameFeature)) {
                if (gameFeature != this.getType()) {
                    this.setType(((OpenGLFeature) gameFeature));
                    modified = true;
                }
            }
        }
        if (gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_4444 || gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_565 || gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_8888) {
            if (features.isFeature(gameFeature)) {
                if (this.getImageColor() != gameFeature) {
                    this.setImageColor(((OpenGLFeature) gameFeature));
                    if (colorLocked) {
                        if (gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_4444) {
                            this.setColor(openGLFeatureFactory.OPENGL_COLOR_DEPTH_4444);
                        } else if (gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_565) {
                            this.setColor(openGLFeatureFactory.OPENGL_COLOR_DEPTH_565);
                        } else if (gameFeature == openGLFeatureFactory.IMAGE_COLOR_DEPTH_8888) {
                            this.setColor(openGLFeatureFactory.OPENGL_COLOR_DEPTH_8888);
                        }
                    }
                    modified = true;
                }
            }
        }
        if (gameFeature == openGLFeatureFactory.OPENGL_COLOR_DEPTH_4444 || gameFeature == openGLFeatureFactory.OPENGL_COLOR_DEPTH_565 || gameFeature == openGLFeatureFactory.OPENGL_COLOR_DEPTH_8888) {
            if (features.isFeature(gameFeature)) {
                if (this.getColor() != gameFeature) {
                    this.setColor(((OpenGLFeature) gameFeature));
                    modified = true;
                }
            }
        }
        if (gameFeature == openGLFeatureFactory.OPENGL_AUTO_SELECT || gameFeature == openGLFeatureFactory.OPENGL_MINIMUM) {
            if (features.isFeature(gameFeature)) {
                this.setVersionSelector(((OpenGLFeature) gameFeature));
            }
            modified = true;
        }
    }

    public virtual void setOpenGL(bool opengl)
    {
        this.opengl = opengl;
    }

    public virtual bool isOpenGL()
    {
        return this.opengl;
    }

    public virtual void setImageColor(OpenGLFeature imageColor)
    {
        this.imageColor = imageColor;
    }

    public virtual OpenGLFeature getImageColor()
    {
        return this.imageColor;
    }

    public virtual void setColor(OpenGLFeature color)
    {
        this.color = color;
    }

    public virtual OpenGLFeature getColor()
    {
        return this.color;
    }

    public virtual void setVersionSelector(OpenGLFeature versionSelector)
    {
        this.versionSelector = versionSelector;
    }

    public virtual OpenGLFeature getVersionSelector()
    {
        return this.versionSelector;
    }

    public virtual void setType(OpenGLFeature type)
    {
        this.type = type;
    }

    public virtual OpenGLFeature getType()
    {
        return this.type;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        stringBuffer.append(" isOpenGL: ");
        stringBuffer.appendboolean(this.isOpenGL());
        stringBuffer.append(" VersionSelector: ");
        stringBuffer.append(stringUtil.toString(this.getVersionSelector()));
        stringBuffer.append(" Type: ");
        stringBuffer.append(stringUtil.toString(this.getType()));
        stringBuffer.append(" Image Color: ");
        stringBuffer.append(stringUtil.toString(this.getImageColor()));
        stringBuffer.append(" Color: ");
        stringBuffer.append(stringUtil.toString(this.getColor()));
        return stringBuffer.ToString();
    }

}

