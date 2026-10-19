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
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureChoiceGroups = org.allbinary.game.configuration.feature.GameFeatureChoiceGroups;
using InGameFeatureChoiceGroups = org.allbinary.game.configuration.feature.InGameFeatureChoiceGroups;
using SensorFeatureFactory = org.allbinary.game.configuration.feature.SensorFeatureFactory;
using TouchFeatureFactory = org.allbinary.game.configuration.feature.TouchFeatureFactory;
using Init = org.allbinary.init.Init;
using OrientationData = org.allbinary.input.gyro.OrientationData;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration;

public class InGameFeatures : Init
{
    public override void init()
    {
        string LABEL = "Screen Buttons";
        OrientationData orientationData = OrientationData.getInstance();
        BasicArrayList exclusiveOrientationSensorVector = ((BasicArrayList) GameFeatureChoiceGroups.getExclusiveInstance().get().get(((object) orientationData.ORIENTATION_SENSOR_INPUT)));
        InGameFeatureChoiceGroups inGameFeatureChoiceGroups = InGameFeatureChoiceGroups.getExclusiveInstance();
        if (exclusiveOrientationSensorVector != null) {
            object inGameExclusiveOrientationSensorVectorCanBeNull = inGameFeatureChoiceGroups.get().get(((object) orientationData.ORIENTATION_SENSOR_INPUT));
            if (inGameExclusiveOrientationSensorVectorCanBeNull == null) {
                this.addToInGameMenu();
            } else {
                BasicArrayList inGameExclusiveOrientationSensorVector = ((BasicArrayList) inGameExclusiveOrientationSensorVectorCanBeNull);
                if (inGameExclusiveOrientationSensorVector.size() == 0) {
                    this.addToInGameMenu();
                }
            }
        }
        Features features = Features.getInstance();
        if (features.isFeature(TouchFeatureFactory.getInstance().SHOW_SCREEN_BUTTONS) || features.isFeature(TouchFeatureFactory.getInstance().AUTO_HIDE_SHOW_SCREEN_BUTTONS) || features.isFeature(TouchFeatureFactory.getInstance().HIDE_SCREEN_BUTTONS)) {
            BasicArrayList exclusiveScreenButtonsVector = new BasicArrayListD();
            TouchFeatureFactory touchFeatureFactory = TouchFeatureFactory.getInstance();
            exclusiveScreenButtonsVector.add(touchFeatureFactory.AUTO_HIDE_SHOW_SCREEN_BUTTONS);
            exclusiveScreenButtonsVector.add(touchFeatureFactory.SHOW_SCREEN_BUTTONS);
            exclusiveScreenButtonsVector.add(touchFeatureFactory.HIDE_SCREEN_BUTTONS);
            inGameFeatureChoiceGroups.add(LABEL, exclusiveScreenButtonsVector);
        }
    }

    private void addToInGameMenu()
    {
        OrientationData orientationData = OrientationData.getInstance();
        BasicArrayList inGameExclusiveOrientationSensorVector = new BasicArrayListD();
        inGameExclusiveOrientationSensorVector.add(SensorFeatureFactory.getInstance().ORIENTATION_SENSORS);
        inGameExclusiveOrientationSensorVector.add(SensorFeatureFactory.getInstance().NO_ORIENTATION);
        InGameFeatureChoiceGroups.getExclusiveInstance().add(orientationData.ORIENTATION_SENSOR_INPUT, inGameExclusiveOrientationSensorVector);
    }

    public virtual bool isAny()
    {
        Features features = Features.getInstance();
        TouchFeatureFactory touchFeatureFactory = TouchFeatureFactory.getInstance();
        if (features.isFeature(touchFeatureFactory.SHOW_SCREEN_BUTTONS) || features.isFeature(touchFeatureFactory.AUTO_HIDE_SHOW_SCREEN_BUTTONS) || features.isFeature(touchFeatureFactory.HIDE_SCREEN_BUTTONS)) {
            return true;
        }
        BasicArrayList exclusiveOrientationSensorVector = ((BasicArrayList) GameFeatureChoiceGroups.getExclusiveInstance().get().get(((object) OrientationData.getInstance().ORIENTATION_SENSOR_INPUT)));
        if (exclusiveOrientationSensorVector != null) {
            return true;
        }
        return false;
    }

}

