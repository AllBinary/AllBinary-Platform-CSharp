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
using AndroidResources = org.allbinary.AndroidResources;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using Init = org.allbinary.init.Init;
using CommonButtons = org.allbinary.input.motion.button.CommonButtons;
using TouchButtonBlankResource = org.allbinary.input.motion.button.TouchButtonBlankResource;
using TouchButtonDownResource = org.allbinary.input.motion.button.TouchButtonDownResource;
using TouchButtonGenericActionResource = org.allbinary.input.motion.button.TouchButtonGenericActionResource;
using TouchButtonResource = org.allbinary.input.motion.button.TouchButtonResource;
using TouchButtonStartResource = org.allbinary.input.motion.button.TouchButtonStartResource;
using TouchButtonStrafeLeftResource = org.allbinary.input.motion.button.TouchButtonStrafeLeftResource;
using TouchButtonStrafeRightResource = org.allbinary.input.motion.button.TouchButtonStrafeRightResource;
using TouchButtonTurnLeftResource = org.allbinary.input.motion.button.TouchButtonTurnLeftResource;
using TouchButtonTurnRightResource = org.allbinary.input.motion.button.TouchButtonTurnRightResource;
using TouchButtonUpResource = org.allbinary.input.motion.button.TouchButtonUpResource;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;

namespace org.allbinary.android.input.motion.button;

public class TouchButtonAndroidResources : Init
{
    public override void init()
    {
        ResourceUtil resourceUtil = ResourceUtil.getInstance();
        AndroidResources androidResources = AndroidResources.getInstance();
        TouchButtonResource[] RESOURCE_STRING_ARRAY = new TouchButtonResource[] { TouchButtonBlankResource.getInstance(), TouchButtonGenericActionResource.getInstance(), TouchButtonStartResource.getInstance(), TouchButtonUpResource.getInstance(), TouchButtonDownResource.getInstance(), TouchButtonTurnLeftResource.getInstance(), TouchButtonTurnRightResource.getInstance(), TouchButtonStrafeLeftResource.getInstance(), TouchButtonStrafeRightResource.getInstance() };
        int[] RESOURCE_ARRAY = new int[RESOURCE_STRING_ARRAY.Length];
        if (CommonButtons.getInstance().STANDARD_BUTTON_SIZE == 128) {
            RESOURCE_ARRAY[0] = androidResources.raw.touch_button_128_by_128;
            RESOURCE_ARRAY[1] = androidResources.raw.touch_button_generic_action_128_by_128;
            RESOURCE_ARRAY[2] = androidResources.raw.touch_button_start_128_by_128;
            RESOURCE_ARRAY[3] = androidResources.raw.touch_button_up_arrow_128_by_128;
            RESOURCE_ARRAY[4] = androidResources.raw.touch_button_down_arrow_128_by_128;
            RESOURCE_ARRAY[5] = androidResources.raw.touch_button_turn_left_arrow_128_by_128;
            RESOURCE_ARRAY[6] = androidResources.raw.touch_button_turn_right_arrow_128_by_128;
            RESOURCE_ARRAY[7] = androidResources.raw.touch_button_strafe_left_arrow_128_by_128;
            RESOURCE_ARRAY[8] = androidResources.raw.touch_button_strafe_right_arrow_128_by_128;
            if (OperatingSystemFactory.getInstance().getOperatingSystemInstance().isOverScan()) {
                resourceUtil.addResource(RESOURCE_STRING_ARRAY[2].HINT, (androidResources.raw.ouya_o).ToString());
            }
        } else {
            RESOURCE_ARRAY[0] = androidResources.raw.touch_button_64_by_64;
            RESOURCE_ARRAY[1] = androidResources.raw.touch_button_generic_action_64_by_64;
            RESOURCE_ARRAY[2] = androidResources.raw.touch_button_start_64_by_64;
            RESOURCE_ARRAY[3] = androidResources.raw.touch_button_up_arrow_64_by_64;
            RESOURCE_ARRAY[4] = androidResources.raw.touch_button_down_arrow_64_by_64;
            RESOURCE_ARRAY[5] = androidResources.raw.touch_button_turn_left_arrow_64_by_64;
            RESOURCE_ARRAY[6] = androidResources.raw.touch_button_turn_right_arrow_64_by_64;
            RESOURCE_ARRAY[7] = androidResources.raw.touch_button_strafe_left_arrow_64_by_64;
            RESOURCE_ARRAY[8] = androidResources.raw.touch_button_strafe_right_arrow_64_by_64;
        }
        for (int index = 0; index < RESOURCE_ARRAY.Length; index++) {
            resourceUtil.addResource(RESOURCE_STRING_ARRAY[index].RESOURCE, (RESOURCE_ARRAY[index]).ToString());
        }
    }

}

