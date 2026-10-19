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

namespace org.allbinary.audio;

public class AudioContentTypeDataFactory
{
    private static readonly AudioContentTypeDataFactory instance = new AudioContentTypeDataFactory();
    public static AudioContentTypeDataFactory getInstance()
    {
        return AudioContentTypeDataFactory.instance;
    }

    public readonly AudioContentTypeData MIME_AUDIO_TONE = new AudioContentTypeData("audio/x-tone-seq");
    public readonly AudioContentTypeData MIME_AUDIO_AMR = new AudioContentTypeData("audio/amr");
    public readonly AudioContentTypeData MIME_AUDIO_AMR_WB = new AudioContentTypeData("audio/amr-wb");
    public readonly AudioContentTypeData MIME_AUDIO_WAV = new AudioContentTypeData("audio/x-wav");
    public readonly AudioContentTypeData MIME_AUDIO_MIDI = new AudioContentTypeData("audio/midi");
    public readonly AudioContentTypeData MIME_AUDIO_SP_MIDI = new AudioContentTypeData("audio/sp-midi");
    private AudioContentTypeDataFactory()
    {
    }

}

