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
using FeatureResourceAnimationInterfaceFactoryInterface = org.allbinary.animation.resource.FeatureResourceAnimationInterfaceFactoryInterface;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using FeaturedResourceFactory = org.allbinary.game.resource.FeaturedResourceFactory;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.animation;

public class FeaturedAnimationInterfaceFactoryInterfaceFactory : FeaturedResourceFactory
{
    private static FeaturedAnimationInterfaceFactoryInterfaceFactory INSTANCE = new FeaturedAnimationInterfaceFactoryInterfaceFactory();
    private FeaturedAnimationInterfaceFactoryInterfaceFactory()
    {
    }

    public static FeaturedAnimationInterfaceFactoryInterfaceFactory getInstance()
    {
        return FeaturedAnimationInterfaceFactoryInterfaceFactory.INSTANCE;
    }

    // throws Exception
    public virtual Rectangle getRectangle(string resource)
    {
        return this.getRectangleXY(resource, 0, 0);
    }

    // throws Exception
    public virtual Rectangle getRectangleXY(string resource, int x, int y)
    {
        PointFactory pointFactory = PointFactory.getInstance();
        BasicArrayList list = this.getList();
        int scale = ((int) GameConfigurationCentral.getInstance().SCALE.getValue());
        int size = this.getList().size();
        for (int index = 0; index < size; index++) {
            FeatureResourceAnimationInterfaceFactoryInterface featureInterface = ((FeatureResourceAnimationInterfaceFactoryInterface) list.objectArray[index]);
            if (featureInterface.isFeature()) {
                Rectangle rectangle = featureInterface.getRectangle(resource);
                if (rectangle != RectangleFactory.SINGLETON) {
                    return new Rectangle(pointFactory.createXY(x, y), ((rectangle.getWidth() * scale) >> 1), ((rectangle.getHeight() * scale) >> 1));
                }
            }
        }
        throw new Exception(new StringMaker().append("No rectangle available for current feature selection or Resource: ").append(resource).ToString());
    }

    // throws Exception
    public virtual ProceduralAnimationInterfaceFactoryInterface getProcedural(string resource)
    {
        return ((ProceduralAnimationInterfaceFactoryInterface) this.getBasicAnimationInterfaceFactoryInstance(resource));
    }

    // throws Exception
    public virtual AnimationInterfaceFactoryInterface get(string resource)
    {
        return ((AnimationInterfaceFactoryInterface) this.getBasicAnimationInterfaceFactoryInstance(resource));
    }

    // throws Exception
    private BasicAnimationInterfaceFactoryInterface getBasicAnimationInterfaceFactoryInstance(string resource)
    {
        BasicArrayList list = this.getList();
        BasicArrayList resourceTypeAvailableList = new BasicArrayListD();
        int size = this.getList().size();
        FeatureResourceAnimationInterfaceFactoryInterface featureInterface = null;
        BasicAnimationInterfaceFactoryInterface animationInterfaceFactoryInterface = null;
        for (int index = 0; index < size; index++) {
            featureInterface = ((FeatureResourceAnimationInterfaceFactoryInterface) list.objectArray[index]);
            if (featureInterface.isFeature()) {
                resourceTypeAvailableList.add(featureInterface);
                animationInterfaceFactoryInterface = featureInterface.getBasicAnimationInterfaceFactoryInstance(resource);
                if (animationInterfaceFactoryInterface != NullAnimationFactory.NULL_NOT_FOR_USE_ANIMATION_FACTORY) {
                    return animationInterfaceFactoryInterface;
                }
            }
        }
        if (resourceTypeAvailableList.size() > 0) {
            string NO_ANIMATION_AVAILABLE_FROM = "No animation available from: ";
            string FOR_FACTORIES = " factories: ";
            string FOR_RESOURCE = " for Resource: ";
            string HAS_KEY = " has: ";
            string RESOURCES_LABEL = " resources ";
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(NO_ANIMATION_AVAILABLE_FROM);
            stringBuffer.appendint(resourceTypeAvailableList.size());
            stringBuffer.append(CommonSeps.getInstance().FORWARD_SLASH);
            stringBuffer.appendint(size);
            stringBuffer.append(FOR_FACTORIES);
            int size2 = resourceTypeAvailableList.size();
            for (int index = 0; index < size2; index++) {
                stringBuffer.append(resourceTypeAvailableList.get(index).ToString());
                stringBuffer.append(CommonSeps.getInstance().COMMA_SEP);
            }
            stringBuffer.append(FOR_RESOURCE);
            stringBuffer.append(resource);
            for (int index = 0; index < size; index++) {
                stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
                featureInterface = ((FeatureResourceAnimationInterfaceFactoryInterface) list.objectArray[index]);
                if (featureInterface.isFeature()) {
                    stringBuffer.append(StringUtil.getInstance().toString(featureInterface));
                    stringBuffer.append(HAS_KEY);
                    stringBuffer.appendint(featureInterface.getHashtable().size());
                    stringBuffer.append(RESOURCES_LABEL);
                }
            }
            throw new Exception(stringBuffer.ToString());
        } else {
            StringMaker stringBuffer = new StringMaker();
            for (int index = 0; index < size; index++) {
                featureInterface = ((FeatureResourceAnimationInterfaceFactoryInterface) list.objectArray[index]);
                stringBuffer.append(featureInterface.ToString());
                stringBuffer.append(CommonSeps.getInstance().SPACE);
            }
            string result = stringBuffer.ToString();
            stringBuffer.delete(0, stringBuffer.length());
            throw new Exception(stringBuffer.append("No feature resource type available for Resource: ").append(resource).append(" Resource Factories Available: ").append(result).ToString());
        }
    }

}

