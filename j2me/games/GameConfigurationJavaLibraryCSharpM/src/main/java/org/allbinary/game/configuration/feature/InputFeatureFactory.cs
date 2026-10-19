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

namespace org.allbinary.game.configuration.feature;

public class InputFeatureFactory
{
    private static readonly InputFeatureFactory instance = new InputFeatureFactory();
    public static InputFeatureFactory getInstance()
    {
        return InputFeatureFactory.instance;
    }

    private InputFeatureFactory()
    {
    }

    public readonly InputFeature REMOVE_DUPLICATE_KEY_PRESSES = new InputFeature("Remove Duplicate Key Presses");
    public readonly InputFeature INPUT_MAPPING = new InputFeature("Input Mapping");
    public readonly InputFeature MULTI_KEY_PRESS = new InputFeature("Multi Key Press");
    public readonly InputFeature SINGLE_KEY_REPEAT_PRESS = new InputFeature("Single Key Repeat Press");
    public readonly InputFeature SINGLE_KEY_PRESS = new InputFeature("Single Key Press");
    public virtual bool isSingleKeyProcessing()
    {
        Features features = Features.getInstance();
        if (features.isFeature(this.SINGLE_KEY_REPEAT_PRESS) || features.isFeature(this.SINGLE_KEY_PRESS)) {
            return true;
        } else {
            return false;
        }
    }

}

