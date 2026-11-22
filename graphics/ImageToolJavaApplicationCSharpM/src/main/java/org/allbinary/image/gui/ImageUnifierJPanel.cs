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
using File = java.io.File;
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
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using KeyAdapter = java.awt.@event.KeyAdapter;
using KeyEvent = java.awt.@event.KeyEvent;
//using PropertyChangeEvent = java.beans.PropertyChangeEvent;
//using PropertyChangeListener = java.beans.PropertyChangeListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JLabel = javax.swing.JLabel;
//using JList = javax.swing.JList;
//using JPanel = javax.swing.JPanel;
//using JScrollPane = javax.swing.JScrollPane;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.image.gui;

public class ImageUnifierJPanel : JPanel, ImageProcessorInputCompositeInterface
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
            string averageRatioString = ((double)(averageRatio)).ToString();
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
            this.imageUnifierProperties.setRows(((int)(this.rowsJTextField.getText())));
            this.imageUnifierProperties.setColumns(((int)(this.columnsJTextField.getText())));
            ImageUnifierCell imageUnifierCell = new ImageUnifierCell(((int)(this.cellWidthJTextField.getText())), ((int)(this.cellHeightJTextField.getText())));
            this.imageUnifierProperties.setImageUnifierCell(imageUnifierCell);
            double cellRatio = (((double) imageUnifierCell.getWidth()) / imageUnifierCell.getHeight());
            string cellRatioString = ((double)(cellRatio)).ToString();
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
        this.jScrollPane1 = new JScrollPane();
        this.imageJList = new JList();
        this.jScrollPane2 = new JScrollPane();
        this.jPanel1 = new JPanel();
        this.jButton1 = new JButton();
        this.upJButton = new JButton();
        this.downJButton = new JButton();
        this.fudgeItJButton = new JButton();
        this.jLabel2 = new JLabel();
        this.columnsJTextField = new JTextField();
        this.jLabel1 = new JLabel();
        this.rowsJTextField = new JTextField();
        this.jLabel3 = new JLabel();
        this.cellWidthJTextField = new JTextField();
        this.jLabel4 = new JLabel();
        this.cellHeightJTextField = new JTextField();
        this.jLabel5 = new JLabel();
        this.cellRatioJTextField = new JTextField();
        this.jLabel6 = new JLabel();
        this.avgRatioJTextField = new JTextField();
        this.jButton2 = new JButton();
        this.jButtonOrder = new JButton();
        setMinimumSize(new Dimension(500, 375));
        setPreferredSize(new Dimension(0, 0));
        this.imageJList.setMinimumSize(new Dimension(50, 0));
        this.jScrollPane1.setViewportView(this.imageJList);
        this.jButton1.setText("Save");
        this.jButton1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.upJButton.setText("Up");
        this.upJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                upJButtonActionPerformed(evt);
            }

#endif
);
        this.downJButton.setText("Down");
        this.downJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                downJButtonActionPerformed(evt);
            }

#endif
);
        this.fudgeItJButton.setText("Fudge It!");
        this.fudgeItJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                fudgeItJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Columns:");
        this.columnsJTextField.setText(commonPhoneStrings.TWO);
        this.columnsJTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                columnsJTextFieldActionPerformed(evt);
            }

#endif
);
        this.columnsJTextField.addPropertyChangeListener(new PropertyChangeListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void propertyChange(PropertyChangeEvent evt)
            {
                columnsJTextFieldPropertyChange(evt);
            }

#endif
);
        this.columnsJTextField.addKeyListener(new KeyAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void keyPressed(KeyEvent evt)
            {
                columnsJTextFieldKeyPressed(evt);
            }

            public virtual void keyTyped(KeyEvent evt)
            {
                columnsJTextFieldKeyTyped(evt);
            }

#endif
);
        this.jLabel1.setText("Rows:");
        this.rowsJTextField.setText(commonPhoneStrings.TWO);
        this.rowsJTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                rowsJTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Cell Width:");
        this.cellWidthJTextField.setText("200");
        this.cellWidthJTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                cellWidthJTextFieldActionPerformed(evt);
            }

#endif
);
        this.jLabel4.setText("Cell Height:");
        this.cellHeightJTextField.setText("150");
        this.cellHeightJTextField.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
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
        this.jButton2.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton2ActionPerformed(evt);
            }

#endif
);
        this.jButtonOrder.setText("Order");
        this.jButtonOrder.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButtonOrderActionPerformed(evt);
            }

#endif
);
        GroupLayout jPanel1Layout = new GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup().addContainerGap().addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(jButton1, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addGroup(jPanel1Layout.createSequentialGroup().addComponent(upJButton, GroupLayout.PREFERRED_SIZE, 71, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 10, short.MaxValue).addComponent(downJButton, GroupLayout.PREFERRED_SIZE, 70, GroupLayout.PREFERRED_SIZE)).addComponent(fudgeItJButton, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addGroup(GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addComponent(jLabel3).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 99, GroupLayout.PREFERRED_SIZE)).addGroup(GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addComponent(jLabel4).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 96, GroupLayout.PREFERRED_SIZE)).addComponent(avgRatioJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(jLabel6, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(cellRatioJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(jLabel5, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(cellHeightJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(cellWidthJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addComponent(jButton2, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue).addGroup(GroupLayout.Alignment.LEADING, jPanel1Layout.createSequentialGroup().addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel2).addComponent(jLabel1)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(rowsJTextField, GroupLayout.DEFAULT_SIZE, 103, short.MaxValue).addGroup(jPanel1Layout.createSequentialGroup().addComponent(columnsJTextField, GroupLayout.DEFAULT_SIZE, 102, short.MaxValue).addGap(1, 1, 1)))).addComponent(jButtonOrder, GroupLayout.DEFAULT_SIZE, 151, short.MaxValue)).addContainerGap()));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addContainerGap().addComponent(jButton1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(upJButton).addComponent(downJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jButtonOrder).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(fudgeItJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel2).addComponent(columnsJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(rowsJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel3).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(cellWidthJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel4).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(cellHeightJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jButton2).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel5).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(cellRatioJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addGap(7, 7, 7).addComponent(jLabel6).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(avgRatioJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addGap(66, 66, 66)));
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jScrollPane1, GroupLayout.PREFERRED_SIZE, 84, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jScrollPane2, GroupLayout.DEFAULT_SIZE, 527, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(jPanel1, GroupLayout.Alignment.LEADING, 0, 445, short.MaxValue).addComponent(jScrollPane2, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 445, short.MaxValue).addComponent(jScrollPane1, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 445, short.MaxValue)).addContainerGap()));
    }

    private void jButton2ActionPerformed(ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void columnsJTextFieldKeyPressed(KeyEvent evt)
    {
    }

    private void columnsJTextFieldKeyTyped(KeyEvent evt)
    {
    }

    private void columnsJTextFieldPropertyChange(PropertyChangeEvent evt)
    {
    }

    private void fudgeItJButtonActionPerformed(ActionEvent evt)
    {
        this.updateImageWithFudgedImages();
    }

    private void cellHeightJTextFieldActionPerformed(ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void cellWidthJTextFieldActionPerformed(ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void columnsJTextFieldActionPerformed(ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void rowsJTextFieldActionPerformed(ActionEvent evt)
    {
        this.updateOnPropertiesChange();
    }

    private void jButton1ActionPerformed(ActionEvent evt)
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

    private void downJButtonActionPerformed(ActionEvent evt)
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

    private void upJButtonActionPerformed(ActionEvent evt)
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

    private void jButtonOrderActionPerformed(ActionEvent evt)
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

    private JTextField avgRatioJTextField = null;
    private JTextField cellHeightJTextField = null;
    private JTextField cellRatioJTextField = null;
    private JTextField cellWidthJTextField = null;
    private JTextField columnsJTextField = null;
    private JButton downJButton = null;
    private JButton fudgeItJButton = null;
    private JList imageJList = null;
    private JButton jButton1 = null;
    private JButton jButton2 = null;
    private JButton jButtonOrder = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JLabel jLabel4 = null;
    private JLabel jLabel5 = null;
    private JLabel jLabel6 = null;
    private JPanel jPanel1 = null;
    private JScrollPane jScrollPane1 = null;
    private JScrollPane jScrollPane2 = null;
    private JTextField rowsJTextField = null;
    private JButton upJButton = null;
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

