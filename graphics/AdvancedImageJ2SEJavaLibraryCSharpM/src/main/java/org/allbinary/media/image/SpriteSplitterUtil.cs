/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using BufferedImage = java.awt.image.BufferedImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image;

public class SpriteSplitterUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly SpriteSplitterUtil instance = new SpriteSplitterUtil();
    public static SpriteSplitterUtil getInstance()
    {
        return SpriteSplitterUtil.instance;
    }

    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string[] ANIMATIONS_LABELS = new string[] { "Row Total:", "Column Total:", "Column Total:", "Row Total:", "Column Total:", "Row Total:" };
    public readonly string DIRECTIONAL_ANIMATIONS = "Directional DLRU";
    public readonly string HORIZONTAL_ANIMATIONS = "Horizontal Animations";
    public readonly string HORIZONTAL_SPRITE = "Horizontal A=R=Y F=C=X";
    private readonly string[] ROW_NAME = new string[] { "idle", "walk", "attack", "defeat" };
    private readonly string _ROW = "_row";
    // throws Exception
    public virtual void process(ImageProcessorInput imageProcessorInput, int totalFrames, int totalAnimations, int widthReduction, int heightReduction, int increaseWidth, int increaseHeight, string spriteType, ImageProcessedVisitor visitor)
    {
        BufferedImage bufferedImage = null;
        BufferedImage[][] generatedBufferedImageArray = null;
        BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
        for (int index = 0; index < bufferedImageArray.Length; index++) {
            bufferedImage = bufferedImageArray[index];
            this.logUtil.putF(spriteType, this, this.commonStrings.RUN);
            if (spriteType == this.HORIZONTAL_SPRITE) {
                int cellHeight = bufferedImage.getHeight() / totalAnimations;
                int cellWidth = bufferedImage.getWidth() / totalFrames;
                int columns = totalFrames;
                int rows = totalAnimations;
                generatedBufferedImageArray = System.Linq.Enumerable.Range(0, rows).Select(_ => new BufferedImage[columns]).ToArray();
                this.logUtil.putF("Processing Individual Cells columns: " + columns + " rows: " + rows, this, this.commonStrings.RUN);
                this.logUtil.putF("Processing Individual Cells cellHeight: " + cellHeight + " cellWidth: " + cellWidth, this, this.commonStrings.RUN);
                ImageUtil imageUtil = ImageUtil.getInstance();
                string nameEnding = null;
                int x = 0;
                int y = 0;
                for (int index2_4 = 0; index2_4 < rows; index2_4++) {
                    y = cellHeight * index2_4;
                    for (int index3_4 = 0; index3_4 < columns; index3_4++) {
                        x = cellWidth * index3_4;
                        generatedBufferedImageArray[index2_4][index3_4] = bufferedImage.getSubimage(x + widthReduction, y + heightReduction, cellWidth - (widthReduction * 2), cellHeight - (heightReduction * 2));
                        if (increaseWidth != 0 || increaseHeight != 0) {
                            generatedBufferedImageArray[index2_4][index3_4] = imageUtil.createBufferedImageAllowTranslate(generatedBufferedImageArray[index2_4][index3_4], cellWidth + increaseWidth, cellHeight + increaseHeight, false, true);
                        }
                        nameEnding = new StringMaker().appendint(index2_4).append(this.commonSeps.UNDERSCORE).appendint(index3_4).ToString();
                        visitor.visit(generatedBufferedImageArray[index2_4][index3_4], nameEnding, index);
                    }
                }
                this.logUtil.putF("Processing Rows from Cells", this, this.commonStrings.RUN);
                ImageUnifierProperties imageUnifierProperties = new ImageUnifierProperties();
                imageUnifierProperties.setRows(int.Parse((1).ToString()));
                imageUnifierProperties.setColumns(int.Parse((columns).ToString()));
                ImageUnifierCell imageUnifierCell = new ImageUnifierCell(int.Parse((cellWidth - (2 * widthReduction)).ToString()), int.Parse((cellHeight - (2 * heightReduction)).ToString()));
                imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
                for (int index2_6 = 0; index2_6 < rows; index2_6++) {
                    y = cellHeight * index2_6;
                    BufferedImage[] tempBufferedImageArray = new BufferedImage[columns];
                    for (int index3_6 = 0; index3_6 < columns; index3_6++) {
                        tempBufferedImageArray[index3_6] = generatedBufferedImageArray[index2_6][index3_6];
                        nameEnding = new StringMaker().appendint(index2_6).append(this.commonSeps.UNDERSCORE).appendint(1).append(this._ROW).ToString();
                    }
                    BufferedImage generatedBufferedImage = ImageUnifierUtil.getInstance().getImage(tempBufferedImageArray, imageUnifierProperties);
                    visitor.visit(generatedBufferedImage, nameEnding, index);
                }
            } else if (spriteType == HORIZONTAL_ANIMATIONS) {
            } else if (spriteType == this.DIRECTIONAL_ANIMATIONS) {
                int totalFrames2 = 4;
                int cellHeight = bufferedImage.getHeight() / totalFrames2;
                int cellWidth = bufferedImage.getWidth() / totalAnimations;
                int columns = totalAnimations;
                int rows = totalFrames2;
                generatedBufferedImageArray = System.Linq.Enumerable.Range(0, rows).Select(_ => new BufferedImage[columns]).ToArray();
                this.logUtil.putF("Processing Individual Cells for each Direction", this, this.commonStrings.RUN);
                string nameEnding = null;
                int x = 0;
                int y = 0;
                for (int index2_0 = 0; index2_0 < rows; index2_0++) {
                    y = cellHeight * index2_0;
                    for (int index3_0 = 0; index3_0 < columns; index3_0++) {
                        x = cellWidth * index3_0;
                        generatedBufferedImageArray[index2_0][index3_0] = bufferedImage.getSubimage(x + widthReduction, y + heightReduction, cellWidth - (widthReduction * 2), cellHeight - (heightReduction * 2));
                        if (increaseWidth != 0 || increaseHeight != 0) {
                            generatedBufferedImageArray[index2_0][index3_0] = ImageUtil.getInstance().createBufferedImageAllowTranslate(generatedBufferedImageArray[index2_0][index3_0], cellWidth + increaseWidth, cellHeight + increaseHeight, false, true);
                        }
                        nameEnding = new StringMaker().append(this.commonStrings.DIRECTION_NAME[index2_0]).append(this.commonSeps.UNDERSCORE).appendint(index3_0).ToString();
                        visitor.visit(generatedBufferedImageArray[index2_0][index3_0], nameEnding, index);
                    }
                }
                ImageUnifierProperties imageUnifierProperties = new ImageUnifierProperties();
                imageUnifierProperties.setRows(int.Parse((1).ToString()));
                imageUnifierProperties.setColumns(int.Parse((columns).ToString()));
                ImageUnifierCell imageUnifierCell = new ImageUnifierCell(int.Parse((cellWidth - (2 * widthReduction)).ToString()) + increaseWidth, int.Parse((cellHeight - (2 * heightReduction) + increaseHeight).ToString()));
                imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
                this.logUtil.putF("Processing Rows from Cells for each Direction", this, this.commonStrings.RUN);
                for (int index2_2 = 0; index2_2 < rows; index2_2++) {
                    y = cellHeight * index2_2;
                    BufferedImage[] tempBufferedImageArray = new BufferedImage[columns];
                    for (int index3_2 = 0; index3_2 < columns; index3_2++) {
                        tempBufferedImageArray[index3_2] = generatedBufferedImageArray[index2_2][index3_2];
                        nameEnding = new StringMaker().append(this.commonStrings.DIRECTION_NAME[index2_2]).append(this.commonSeps.UNDERSCORE).appendint(1).append(this._ROW).ToString();
                    }
                    BufferedImage generatedBufferedImage = ImageUnifierUtil.getInstance().getImage(tempBufferedImageArray, imageUnifierProperties);
                    visitor.visit(generatedBufferedImage, nameEnding, index);
                }
            }
        }
    }

}

