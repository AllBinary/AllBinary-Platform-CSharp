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
//using BufferedImage = java.awt.image.BufferedImage;
//using File = java.io.File;
//using javax.swing;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using FileWrapperUtil = org.allbinary.logic.io.file.FileWrapperUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ImagePersistanceUtil = org.allbinary.media.image.ImagePersistanceUtil;
using ImageProcessorInput = org.allbinary.media.image.ImageProcessorInput;
using ImageProcessorInputCompositeInterface = org.allbinary.media.image.ImageProcessorInputCompositeInterface;
using ImageStrings = org.allbinary.media.image.ImageStrings;
using ImageUnifierCell = org.allbinary.media.image.ImageUnifierCell;
using ImageUnifierProperties = org.allbinary.media.image.ImageUnifierProperties;
using ImageUnifierUtil = org.allbinary.media.image.ImageUnifierUtil;
using ImageUtil = org.allbinary.media.image.ImageUtil;
using ImagesRatioUtil = org.allbinary.media.image.ImagesRatioUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image.gui;

public class ImageUnifierJPanel : javax.swing.JPanel, ImageProcessorInputCompositeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ImageStrings imageStrings = ImageStrings.getInstance();
    private readonly ImagesRatioUtil imagesRatioUtil = ImagesRatioUtil.getInstance();
    private ImageProcessorInput imageProcessorInput = null;
    private ImageIconUnique[] icon = null;
    private ImageUnifierProperties imageUnifierProperties = null;
    private BufferedImage result = null;
    private bool isImageFillIn = true;
    public ImageUnifierJPanel(ImageProcessorInput imageProcessorInput)
    {
        this.initComponents();
        this.setImageProcessorInput(imageProcessorInput);
    }

    public virtual void init()
    {
        try {
            ImageProcessorInput imageProcessorInput = this.getImageProcessorInput();
            BufferedImage[] bufferedImageArray = imageProcessorInput.getBufferedImageArray();
            this.icon = new ImageIconUnique[bufferedImageArray.Length];
            DefaultListModel defaultListModel = new DefaultListModel();
            for (int index = 0; index < bufferedImageArray.Length; index++) {
                double width = bufferedImageArray[index].getWidth();
                double height = bufferedImageArray[index].getHeight();
                int newWidth = 52;
                double oldRatio = width / height;
                int newHeight = ((int) (((double) newWidth) / oldRatio));
                BufferedImage iconBufferedImage = ImageUtil.getInstance().createBufferedImage(bufferedImageArray[index], newWidth, newHeight, true);
                this.icon[index] = new ImageIconUnique(iconBufferedImage, index);
                defaultListModel.addElement(this.icon[index]);
            }
            this.imageJList.setModel(defaultListModel);
            this.updateOnPropertiesChange();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
        }
    }

    private void updateImage()
    {
        try {
            BufferedImage[] bufferedImageArray = this.getImageProcessorInput().getBufferedImageArray();
            BufferedImage[] tempBufferedImageArray = new BufferedImage[bufferedImageArray.Length];
            for (int index = 0; index < bufferedImageArray.Length; index++) {
                ImageIconUnique indexedImageIcon = ((ImageIconUnique) this.imageJList.getModel().getElementAt(index));
                BufferedImage bufferedImage = ImageUtil.getInstance().createBufferedImage(bufferedImageArray[indexedImageIcon.getId()], this.imageUnifierProperties.getImageUnifierCell().getWidth(), this.imageUnifierProperties.getImageUnifierCell().getHeight(), false);
                tempBufferedImageArray[index] = bufferedImage;
            }
            int totalImages = this.imageUnifierProperties.getRows() * this.imageUnifierProperties.getColumns();
            double averageRatio = this.imagesRatioUtil.getAverage(tempBufferedImageArray, totalImages);
            string averageRatioString = averageRatio.ToString();
            if (averageRatioString.Length > 4) {
                averageRatioString = averageRatioString.Substring(0, (4) - (0));
            }
            this.avgRatioJTextField.setText(averageRatioString);
            this.fudgeItJButton.setEnabled(false);
            if (!this.imagesRatioUtil.isEqual(tempBufferedImageArray, totalImages)) {
                if (this.isImageFillIn) {
                    this.fudgeItJButton.setEnabled(true);
                }
            }
            this.updateImage(tempBufferedImageArray);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateImage", e);
        }
    }

    private void updateImageWithFudgedImages()
    {
        try {
            BufferedImage[] bufferedImageArray = this.getImageProcessorInput().getBufferedImageArray();
            BufferedImage[] tempBufferedImageArray = new BufferedImage[bufferedImageArray.Length];
            for (int index = 0; index < bufferedImageArray.Length; index++) {
                ImageIconUnique indexedImageIcon = ((ImageIconUnique) this.imageJList.getModel().getElementAt(index));
                BufferedImage bufferedImage = ImageUtil.getInstance().createBufferedImage(bufferedImageArray[indexedImageIcon.getId()], this.imageUnifierProperties.getImageUnifierCell().getWidth(), this.imageUnifierProperties.getImageUnifierCell().getHeight(), false);
                tempBufferedImageArray[index] = bufferedImage;
            }
            int totalImages = this.imageUnifierProperties.getRows() * this.imageUnifierProperties.getColumns();
            double averageRatio = this.imagesRatioUtil.getAverage(tempBufferedImageArray, totalImages);
            BufferedImage[] fudgedBufferedImageArray = imagesRatioUtil.fudge(tempBufferedImageArray, totalImages, averageRatio);
            this.updateImage(fudgedBufferedImageArray);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updateImageWithFudgedImages", e);
        }
    }

    private void updateImage(BufferedImage[] tempBufferedImageArray)
    {
        this.result = ImageUnifierUtil.getInstance().getImage(tempBufferedImageArray, this.imageUnifierProperties);
        Icon image = new ImageIcon(this.result);
        JLabel label = new JLabel(image);
        this.jScrollPane2.getViewport().add(label);
        this.updateUI();
    }

    private void updateOnPropertiesChange()
    {
        if (this.rowsJTextField.getText().length() > 0 && this.columnsJTextField.getText().length() > 0 && this.cellWidthJTextField.getText().length() > 0 && this.cellHeightJTextField.getText().length() > 0) {
            this.imageUnifierProperties = new ImageUnifierProperties();
            this.imageUnifierProperties.setRows(this.rowsJTextField.getText());
            this.imageUnifierProperties.setColumns(this.columnsJTextField.getText());
            ImageUnifierCell imageUnifierCell = new ImageUnifierCell(this.cellWidthJTextField.getText(), this.cellHeightJTextField.getText());
            this.imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
            double cellRatio = (((double) imageUnifierCell.getWidth()) / imageUnifierCell.getHeight());
            string cellRatioString = cellRatio.ToString();
            if (cellRatioString.Length > 4) {
                cellRatioString = cellRatioString.Substring(0, (4) - (0));
            }
            this.cellRatioJTextField.setText(cellRatioString);
            this.updateImage();
        }
    }

    private void initComponents()
    {
        CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
        this.jScrollPane1 = new javax.swing.JScrollPane();
        this.imageJList = new javax.swing.JList();
        this.jScrollPane2 = new javax.swing.JScrollPane();
        this.jPanel1 = new javax.swing.JPanel();
        this.jButton1 = new javax.swing.JButton();
        this.upJButton = new javax.swing.JButton();
        this.downJButton = new javax.swing.JButton();
        this.fudgeItJButton = new javax.swing.JButton();
        this.jLabel2 = new javax.swing.JLabel();
        this.columnsJTextField = new javax.swing.JTextField();
        this.jLabel1 = new javax.swing.JLabel();
        this.rowsJTextField = new javax.swing.JTextField();
        this.jLabel3 = new javax.swing.JLabel();
        this.cellWidthJTextField = new javax.swing.JTextField();
        this.jLabel4 = new javax.swing.JLabel();
        this.cellHeightJTextField = new javax.swing.JTextField();
        this.jLabel5 = new javax.swing.JLabel();
        this.cellRatioJTextField = new javax.swing.JTextField();
        this.jLabel6 = new javax.swing.JLabel();
        this.avgRatioJTextField = new javax.swing.JTextField();
        this.jButton2 = new javax.swing.JButton();
        this.jButtonOrder = new javax.swing.JButton();
        setMinimumSize(new java.awt.Dimension(500, 375));
        setPreferredSize(new java.awt.Dimension(0, 0));
        this.imageJList.setMinimumSize(new java.awt.Dimension(50, 0));
        this.jScrollPane1.setViewportView(this.imageJList);
        this.jButton1.setText("Save");
        this.jButton1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.upJButton.setText("Up");
        this.upJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                upJButtonActionPerformed(evt);
            }

#endif
);
        this.downJButton.setText("Down");
        this.downJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                downJButtonActionPerformed(evt);
            }

#endif
);
        this.fudgeItJButton.setText("Fudge It!");
        this.fudgeItJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                fudgeItJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Columns:");
        this.columnsJTextField.setText(commonPhoneStrings.TWO);
        this.columnsJTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                columnsJTextFieldActionPerformed(evt);
            }

#endif
);
        this.columnsJTextField.addPropertyChangeListener(new java.beans.PropertyChangeListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void propertyChange(java.beans.PropertyChangeEvent evt)
            {
                columnsJTextFieldPropertyChange(evt);
            }

#endif
);
        this.columnsJTextField.addKeyListener(new java.awt.event.KeyAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void keyPressed(java.awt.event.KeyEvent evt)
            {
                columnsJTextFieldKeyPressed(evt);
            }

            public virtual void keyTyped(java.awt.event.KeyEvent evt)
            {
                columnsJTextFieldKeyTyped(evt);
            }

#endif
);
        this.jLabel1.setText("Rows:");
        this.rowsJTextField.setText(commonPhoneStrings.TWO);
        this.rowsJTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                rowsJTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Cell Width:");
        this.cellWidthJTextField.setText("200");
        this.cellWidthJTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                cellWidthJTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel4.setText("Cell Height:");
        this.cellHeightJTextField.setText("150");
        this.cellHeightJTextField.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                cellHeightJTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel5.setText("Cell Ratio:");
        this.cellRatioJTextField.setEditable(false);
        this.jLabel6.setText("Avg Image Ratio:");
        this.avgRatioJTextField.setEditable(false);
        this.jButton2.setText(this.commonStrings.UPDATE);
        this.jButton2.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton2ActionPerformed(evt);
            }

#endif
);
        this.jButtonOrder.setText("Order");
        this.jButtonOrder.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButtonOrderActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup().addContainerGap().addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(jButton1, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addGroup(jPanel1Layout.createSequentialGroup().addComponent(upJButton, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 10, Short.MAX_VALUE).addComponent(downJButton, javax.swing.GroupLayout.PREFERRED_SIZE, 70, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(fudgeItJButton, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addComponent(jLabel3).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 99, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 96, javax.swing.GroupLayout.PREFERRED_SIZE)).addComponent(avgRatioJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(jLabel6, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(cellRatioJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(jLabel5, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(cellHeightJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(cellWidthJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addComponent(jButton2, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE).addGroup(javax.swing.GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jLabel2).addComponent(jLabel1)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(rowsJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 103, Short.MAX_VALUE).addGroup(jPanel1Layout.createSequentialGroup().addComponent(columnsJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 102, Short.MAX_VALUE).addGap(1, 1, 1)))).addComponent(jButtonOrder, javax.swing.GroupLayout.DEFAULT_SIZE, 151, Short.MAX_VALUE)).addContainerGap()));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addContainerGap().addComponent(jButton1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(upJButton).addComponent(downJButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jButtonOrder).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(fudgeItJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel2).addComponent(columnsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(rowsJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel3).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cellWidthJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel4).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(cellHeightJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jButton2).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel5).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(cellRatioJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(7, 7, 7).addComponent(jLabel6).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(avgRatioJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(66, 66, 66)));
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 84, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 527, Short.MAX_VALUE)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(jPanel1, javax.swing.GroupLayout.Alignment.LEADING, 0, 445, Short.MAX_VALUE).addComponent(jScrollPane2, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 445, Short.MAX_VALUE).addComponent(jScrollPane1, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 445, Short.MAX_VALUE)).addContainerGap()));
    }

    private void jButton2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void columnsJTextFieldKeyPressed(java.awt.event.KeyEvent evt)
    {
    }

    private void columnsJTextFieldKeyTyped(java.awt.event.KeyEvent evt)
    {
    }

    private void columnsJTextFieldPropertyChange(java.beans.PropertyChangeEvent evt)
    {
    }

    private void fudgeItJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateImageWithFudgedImages();
    }

    private void cellHeightJTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void cellWidthJTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void columnsJTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void rowsJTextFieldActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            File[] fileArray = this.imageProcessorInput.getFiles();
            File file = fileArray[0];
            string filePath = file.getAbsolutePath();
            int extensionIndex = filePath.IndexOf(this.imageStrings.PNG_EXTENSION);
            filePath = new StringMaker().append(filePath.Substring(0, (extensionIndex) - (0))).append(CommonSeps.getInstance().UNDERSCORE).appendint(((int) this.imageUnifierProperties.getColumns())).append("_By_").appendint(((int) this.imageUnifierProperties.getRows())).append("_Unified").append(this.imageStrings.PNG_EXTENSION).ToString();
            this.logUtil.putF("New File Path: " + filePath, this, StringUtil.getInstance().EMPTY_STRING);
            File outputFile = new File(filePath);
            ImagePersistanceUtil.getInstance().saveWithBatik(FileWrapperUtil.wrapFile(outputFile), this.result);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "jButton1ActionPerformed", e);
        }
    }

    private void downJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        int index = this.imageJList.getSelectedIndex();
        DefaultListModel defaultListModel = ((DefaultListModel) this.imageJList.getModel());
        if (index >= 0 && index + 1 < defaultListModel.size()) {
            ImageIconUnique indexedImageIcon = ((ImageIconUnique) defaultListModel.remove(index));
            defaultListModel.insertElementAt(indexedImageIcon, index + 1);
            this.imageJList.setSelectedIndex(index + 1);
            this.updateImage();
        }
    }

    private void upJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        int index = this.imageJList.getSelectedIndex();
        if (index > 0) {
            DefaultListModel defaultListModel = ((DefaultListModel) this.imageJList.getModel());
            ImageIconUnique indexedImageIcon = ((ImageIconUnique) defaultListModel.remove(index));
            defaultListModel.insertElementAt(indexedImageIcon, index - 1);
            this.imageJList.setSelectedIndex(index - 1);
            this.updateImage();
        }
    }

    private void jButtonOrderActionPerformed(java.awt.event.ActionEvent evt)
    {
        DefaultListModel defaultListModel = ((DefaultListModel) this.imageJList.getModel());
        int size = defaultListModel.size();
        int last = size - 1;
        for (int index = last; index >= 0; index--) {
            ImageIconUnique indexedImageIcon = ((ImageIconUnique) defaultListModel.remove(last));
            defaultListModel.insertElementAt(indexedImageIcon, last - index);
        }
        if (size > 0) {
            this.imageJList.setSelectedIndex(0);
            this.updateImage();
        }
    }

    private javax.swing.JTextField avgRatioJTextField = null;
    private javax.swing.JTextField cellHeightJTextField = null;
    private javax.swing.JTextField cellRatioJTextField = null;
    private javax.swing.JTextField cellWidthJTextField = null;
    private javax.swing.JTextField columnsJTextField = null;
    private javax.swing.JButton downJButton = null;
    private javax.swing.JButton fudgeItJButton = null;
    private javax.swing.JList imageJList = null;
    private javax.swing.JButton jButton1 = null;
    private javax.swing.JButton jButton2 = null;
    private javax.swing.JButton jButtonOrder = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JLabel jLabel3 = null;
    private javax.swing.JLabel jLabel4 = null;
    private javax.swing.JLabel jLabel5 = null;
    private javax.swing.JLabel jLabel6 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JScrollPane jScrollPane1 = null;
    private javax.swing.JScrollPane jScrollPane2 = null;
    private javax.swing.JTextField rowsJTextField = null;
    private javax.swing.JButton upJButton = null;
    public virtual ImageProcessorInput getImageProcessorInput()
    {
        return this.imageProcessorInput;
    }

    public virtual void setImageProcessorInput(ImageProcessorInput imageProcessorInput)
    {
        this.imageProcessorInput = imageProcessorInput;
        this.init();
    }

}

