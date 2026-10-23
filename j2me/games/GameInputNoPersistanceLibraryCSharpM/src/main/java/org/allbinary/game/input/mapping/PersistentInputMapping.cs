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
using java.util;
using GamePersistanceStrings = org.allbinary.game.configuration.persistance.GamePersistanceStrings;
using Input = org.allbinary.game.input.Input;
using InputPersistance = org.allbinary.game.input.InputPersistance;
using InputMappingEvent = org.allbinary.game.input.mapping.@event.InputMappingEvent;
using InputMappingEventListenerInterface = org.allbinary.game.input.mapping.@event.InputMappingEventListenerInterface;
using NullInputMappingEventListener = org.allbinary.game.input.mapping.@event.NullInputMappingEventListener;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;
using org.allbinary.util;

namespace org.allbinary.game.input.mapping;

//GameInputNoPersistanceLibrary
public class PersistentInputMapping
{
    public static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static PersistentInputMapping getNullInstance()
    {
        if (PersistentInputMapping.instance == NullUtil.getInstance().NULL_OBJECT) {
            PersistentInputMapping.instance = new PersistentInputMapping(GamePersistanceStrings.getInstance().SAVED_INPUT_CONFIGURATION_RECORD_ID);
        }
        return ((PersistentInputMapping) PersistentInputMapping.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    private readonly InputToGameKeyMapping inputMapping = new InputToGameKeyMapping();
    private InputMappingEventListenerInterface inputMappingEventListenerInterface = NullInputMappingEventListener.NULL_INPUT_MAPPING_EVENT_LISTENER;
    private readonly InputPersistance inputPersistance;
    public PersistentInputMapping(string name)
    {
        this.inputMappingEvent = new InputMappingEvent(this);
        this.inputPersistance = new InputPersistance(name);
    }

    public virtual int getTotalMapped()
    {
        return this.getInputMapping().getHashtable().size();
    }

    public virtual bool isDefaultNew()
    {
        return false;
    }

    public virtual InputToGameKeyMapping getDefault()
    {
        return InputToGameKeyMapping.getNullInstance();
    }

    // throws Exception
    public virtual void setDefault(AbeClientInformationInterface abeClientInformation)
    {
        this.getInputMapping().removeAll();
        this.getInputMapping().addMapping(this.getDefault());
        this.save(abeClientInformation);
    }

    // throws Exception
    public virtual void update(AbeClientInformationInterface abeClientInformation)
    {
        this.inputPersistance.deleteAll(abeClientInformation);
        this.save(abeClientInformation);
    }

    private InputMappingEvent inputMappingEvent;
    // throws Exception
    public virtual void save(AbeClientInformationInterface abeClientInformation)
    {
        this.inputPersistance.save(abeClientInformation, this.getInputMapping().getHashtable());
        this.inputMappingEvent.setInputToGameKeyMapping(this.getInputMapping());
        if (this.getInputMappingEventListenerInterface() != null) {
            this.getInputMappingEventListenerInterface().onInputMappingEvent(this.inputMappingEvent);
        }
    }

    // throws Exception
    public virtual void init(AbeClientInformationInterface abeClientInformation)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.INIT);
        try {
            this.inputPersistance.loadAll(abeClientInformation);
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
            this.inputPersistance.deleteRecoreStore(abeClientInformation);
            this.setDefault(abeClientInformation);
            this.inputPersistance.loadAll(abeClientInformation);
        }
        BasicArrayList list = this.inputPersistance.getList();
        int totalMappedTo = 0;
        int size = list.size();
        ABHashtable<object, object> hashtable = null;
        Enumeration<object> enumeration = null;
        Input mappedToInput = null;
        Input gameActionInput = null;
        for (int index = 0; index < size; index++) {
            hashtable = ((ABHashtable<object, object>) list.objectArray[index]);
            enumeration = hashtable.keys();
            while (this.enumerationUtil.hasMoreElements(enumeration)) {
                mappedToInput = ((Input) this.enumerationUtil.nextElement(enumeration));
                gameActionInput = ((Input) hashtable.get(mappedToInput));
                totalMappedTo++;
                this.getInputMapping().add(gameActionInput, mappedToInput);
            }
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("End - Total Loaded Keys Mapped: ");
        stringBuffer.appendint(this.getTotalMapped());
        stringBuffer.append(" to: ");
        stringBuffer.appendint(totalMappedTo);
        this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.INIT);
    }

    public virtual void setInputMappingEventListenerInterface(InputMappingEventListenerInterface inputMappingEventListenerInterface)
    {
        this.inputMappingEventListenerInterface = inputMappingEventListenerInterface;
    }

    private InputMappingEventListenerInterface getInputMappingEventListenerInterface()
    {
        return this.inputMappingEventListenerInterface;
    }

    public virtual InputToGameKeyMapping getInputMapping()
    {
        return this.inputMapping;
    }

    // throws Exception
    public virtual bool isDelete(Input input)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual bool isSystemInput(Input input)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

}

