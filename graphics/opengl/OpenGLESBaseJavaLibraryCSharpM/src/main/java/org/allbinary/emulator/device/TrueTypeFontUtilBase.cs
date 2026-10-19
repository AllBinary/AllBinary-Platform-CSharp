/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
using AvianUtil = org.allbinary.AvianUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.emulator.device;

public class TrueTypeFontUtilBase
{
    public readonly string shortPattern;
    private readonly sbyte[] patternAsBytes = new sbyte[] { 32, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 32, 32, 32, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 32, 32, 32, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 32, 32, 32, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 32, 32, 32, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 46, 63, 32, 32, 32, 33, 36, 37, 96, ((sbyte) (-62)), ((sbyte) (-84)), ((sbyte) (-62)), ((sbyte) (-84)), 34, ((sbyte) (-62)), ((sbyte) (-93)), ((sbyte) (-62)), ((sbyte) (-93)), 94, 38, 42, 40, 32, 32, 32, 41, 95, 43, 45, 61, 91, 93, 123, 125, 59, 39, 35, 58, 32, 32, 32, 64, 126, 44, 47, 60, 62, 92, 124, ((sbyte) (-62)), ((sbyte) (-82)), ((sbyte) (-62)), ((sbyte) (-82)), ((sbyte) (-62)), ((sbyte) (-87)), ((sbyte) (-62)), ((sbyte) (-87)) };
    public readonly string pattern;
    public readonly short[] charArray = new short[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x6f, 0x50, 0x56, 0x6b, 0x51, 0x52, 0x5a, 0x6a, 0x5c, 0x60, 0x5b, 0x62, 0x72, 0x63, 0x4b, 0x73, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xa, 0x6c, 0x69, 0x74, 0x64, 0x75, 0x4c, 0x70, 0xb, 0xc, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x65, 0x76, 0x66, 0x59, 0x61, 0x53, 0x2b, 0x2c, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x67, 0x77, 0x68, 0x71, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x58, 0x0, 0x0, 0x0, 0x0, 0x0, 0x7b, 0x0, 0x0, 0x55, 0x0, 0x79, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
    public readonly int[] _characterWidth;
    public readonly char[] characterArray = new char[1];
    public readonly int size;
    public readonly int lastCapIndex;
    public Font currentFont = Font.getDefaultFont();
    public readonly int scale;
    public readonly int CELLS_PER_ROW;
    public readonly int fontSize;
    public readonly int baseCharWidth;
    public readonly int cellSize;
    public readonly int textureSize;
    public readonly int actualCellsPerRow;
    public TrueTypeFontUtilBase(int scale)
    {
        this.pattern = System.Text.Encoding.UTF8.GetString((byte[]) (Array) this.patternAsBytes);
        this._characterWidth = new int[this.pattern.Length];
        this.size = this.pattern.Length;
        this.lastCapIndex = this.pattern.IndexOf('Z');
        string shortPattern = StringUtil.getInstance().EMPTY_STRING;
        if (AvianUtil.isAvian()) {
            sbyte[] shortPatterAsByteArray = new sbyte[] { 32, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 46, 63, 33, 36, 37, 96, ((sbyte) (-62)), ((sbyte) (-84)), ((sbyte) (-62)), ((sbyte) (-84)), 34, ((sbyte) (-62)), ((sbyte) (-93)), ((sbyte) (-62)), ((sbyte) (-93)), 94, 38, 42, 40, 41, 95, 43, 45, 61, 91, 93, 123, 125, 59, 39, 35, 58, 64, 126, 44, 47, 60, 62, 92, 124, ((sbyte) (-62)), ((sbyte) (-82)), ((sbyte) (-62)), ((sbyte) (-82)), ((sbyte) (-62)), ((sbyte) (-87)), ((sbyte) (-62)), ((sbyte) (-87)) };
            shortPattern = System.Text.Encoding.UTF8.GetString((byte[]) (Array) shortPatterAsByteArray);
        } else {
            sbyte[] shortPatterAsByteArray = new sbyte[] { 32, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 46, 63, 33, 36, 37, 96, ((sbyte) (-62)), ((sbyte) (-84)), 34, ((sbyte) (-62)), ((sbyte) (-93)), 94, 38, 42, 40, 41, 95, 43, 45, 61, 91, 93, 123, 125, 59, 39, 35, 58, 64, 126, 44, 47, 60, 62, 92, 124, ((sbyte) (-62)), ((sbyte) (-82)), ((sbyte) (-62)), ((sbyte) (-87)) };
            shortPattern = System.Text.Encoding.UTF8.GetString((byte[]) (Array) shortPatterAsByteArray);
        }
        this.shortPattern = shortPattern;
        this.scale = scale;
        this.CELLS_PER_ROW = 16;
        this.fontSize = (20 + 6) * this.scale;
        this.baseCharWidth = this.fontSize + (6 * this.scale);
        this.cellSize = this.fontSize + (6 * this.scale);
        this.textureSize = this.getAsTextureSize(this.CELLS_PER_ROW * this.cellSize);
        this.actualCellsPerRow = this.textureSize / this.cellSize;
    }

    public virtual int getAsTextureSize(int textureSize)
    {
        if (textureSize <= 64) {
            textureSize = 64;
        } else if (textureSize <= 128) {
            textureSize = 128;
        } else if (textureSize <= 256) {
            textureSize = 256;
        } else if (textureSize <= 512) {
            textureSize = 512;
        } else if (textureSize <= 1024) {
            textureSize = 1024;
        }
        return textureSize;
    }

    public virtual int getCellSize(int cellSize)
    {
        if (cellSize <= 16) {
            cellSize = 16;
        } else if (cellSize <= 32) {
            cellSize = 32;
        } else if (cellSize <= 64) {
            cellSize = 64;
        } else if (cellSize <= 128) {
            cellSize = 128;
        } else if (cellSize <= 256) {
            cellSize = 256;
        }
        return cellSize;
    }

    public virtual int getYOffset()
    {
        return ((this.scale - 1) * this.cellSize);
    }

}

