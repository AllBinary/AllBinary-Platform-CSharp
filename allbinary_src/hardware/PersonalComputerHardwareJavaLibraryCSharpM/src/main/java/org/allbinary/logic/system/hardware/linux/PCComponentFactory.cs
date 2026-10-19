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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using ComponentFactory = org.allbinary.logic.system.hardware.components.ComponentFactory;
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using Bridge = org.allbinary.logic.system.hardware.components.linux.Bridge;
using Ethernet = org.allbinary.logic.system.hardware.components.linux.Ethernet;
using HardDriveController = org.allbinary.logic.system.hardware.components.linux.HardDriveController;
using Media = org.allbinary.logic.system.hardware.components.linux.Media;
using PCI = org.allbinary.logic.system.hardware.components.linux.PCI;
using Unknown = org.allbinary.logic.system.hardware.components.linux.Unknown;
using Usb = org.allbinary.logic.system.hardware.components.linux.Usb;
using Video = org.allbinary.logic.system.hardware.components.linux.Video;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.hardware.linux;

public class PCComponentFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PCComponentFactory instance = new PCComponentFactory();
    public static PCComponentFactory getInstance()
    {
        return PCComponentFactory.instance;
    }

    private readonly ComponentFactory componentFactory = ComponentFactory.getInstance();
    private PCComponentFactory()
    {
    }

    public virtual HardwareComponentInterface getInstance(string component, string componentData)
    {
        try {
            if (component != null) {
                if (string.CompareOrdinal(component, this.componentFactory.ETHERNET.ToString()) == 0) {
                    return ((HardwareComponentInterface) new Ethernet(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.BRIDGE.ToString()) == 0) {
                    return ((HardwareComponentInterface) new Bridge(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.IDE.ToString()) == 0) {
                    return ((HardwareComponentInterface) new HardDriveController(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.MULTIMEDIA.ToString()) == 0) {
                    return ((HardwareComponentInterface) new Media(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.SCSI.ToString()) == 0) {
                    return ((HardwareComponentInterface) new HardDriveController(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.USB.ToString()) == 0) {
                    return ((HardwareComponentInterface) new Usb(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.VGA.ToString()) == 0) {
                    return ((HardwareComponentInterface) new Video(componentData));
                } else if (string.CompareOrdinal(component, this.componentFactory.PCI.ToString()) == 0) {
                    return ((HardwareComponentInterface) new PCI(componentData));
                }
            }
            return ((HardwareComponentInterface) new Unknown(componentData));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return new Unknown(commonStrings.EXCEPTION);
        }
    }

    public virtual string getComponentType(string component)
    {
        if (component.IndexOf(this.componentFactory.ETHERNET.ToString()) >= 0) {
            return this.componentFactory.ETHERNET.ToString();
        } else if (component.IndexOf(this.componentFactory.BRIDGE.ToString()) >= 0) {
            return this.componentFactory.BRIDGE.ToString();
        } else if (component.IndexOf(this.componentFactory.IDE.ToString()) >= 0) {
            return this.componentFactory.IDE.ToString();
        } else if (component.IndexOf(this.componentFactory.MULTIMEDIA.ToString()) >= 0) {
            return this.componentFactory.MULTIMEDIA.ToString();
        } else if (component.IndexOf(this.componentFactory.SCSI.ToString()) >= 0) {
            return this.componentFactory.SCSI.ToString();
        } else if (component.IndexOf(this.componentFactory.USB.ToString()) >= 0) {
            return this.componentFactory.USB.ToString();
        } else if (component.IndexOf(this.componentFactory.VGA.ToString()) >= 0) {
            return this.componentFactory.VGA.ToString();
        } else if (string.CompareOrdinal(component, this.componentFactory.PCI.ToString()) == 0) {
            return this.componentFactory.PCI.ToString();
        }
        return this.componentFactory.UNKNOWN.ToString();
    }

}

