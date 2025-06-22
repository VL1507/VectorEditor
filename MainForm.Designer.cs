namespace VectorEditor;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        shapesGroupBox = new System.Windows.Forms.GroupBox();
        button4 = new System.Windows.Forms.Button();
        BezierButton = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        outlineColorButton = new System.Windows.Forms.Button();
        fillColorButton = new System.Windows.Forms.Button();
        colorDialog1 = new System.Windows.Forms.ColorDialog();
        groupBox1 = new System.Windows.Forms.GroupBox();
        numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        colorDialog2 = new System.Windows.Forms.ColorDialog();
        shapesGroupBox.SuspendLayout();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // shapesGroupBox
        // 
        shapesGroupBox.Controls.Add(button4);
        shapesGroupBox.Controls.Add(BezierButton);
        shapesGroupBox.Controls.Add(button3);
        shapesGroupBox.Controls.Add(button1);
        shapesGroupBox.Controls.Add(button2);
        shapesGroupBox.Location = new System.Drawing.Point(0, 0);
        shapesGroupBox.Name = "shapesGroupBox";
        shapesGroupBox.Size = new System.Drawing.Size(76, 320);
        shapesGroupBox.TabIndex = 1;
        shapesGroupBox.TabStop = false;
        shapesGroupBox.Text = "Фигуры";
        // 
        // button4
        // 
        button4.BackColor = System.Drawing.SystemColors.Window;
        button4.BackgroundImage = global::VectorEditor.Properties.Resources.pentagon;
        button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        button4.Location = new System.Drawing.Point(0, 254);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(50, 50);
        button4.TabIndex = 8;
        button4.UseVisualStyleBackColor = false;
        // 
        // BezierButton
        // 
        BezierButton.BackColor = System.Drawing.SystemColors.Window;
        BezierButton.BackgroundImage = global::VectorEditor.Properties.Resources.bezier;
        BezierButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        BezierButton.Location = new System.Drawing.Point(0, 30);
        BezierButton.Name = "BezierButton";
        BezierButton.Size = new System.Drawing.Size(50, 50);
        BezierButton.TabIndex = 4;
        BezierButton.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        button3.BackColor = System.Drawing.SystemColors.Window;
        button3.BackgroundImage = global::VectorEditor.Properties.Resources.rectangle;
        button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        button3.Location = new System.Drawing.Point(0, 198);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(50, 50);
        button3.TabIndex = 7;
        button3.UseVisualStyleBackColor = false;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.Window;
        button1.BackgroundImage = global::VectorEditor.Properties.Resources.polygonal;
        button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        button1.Location = new System.Drawing.Point(0, 86);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(50, 50);
        button1.TabIndex = 5;
        button1.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.BackColor = System.Drawing.SystemColors.Window;
        button2.BackgroundImage = global::VectorEditor.Properties.Resources.ellipse;
        button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        button2.Location = new System.Drawing.Point(0, 142);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(50, 50);
        button2.TabIndex = 6;
        button2.UseVisualStyleBackColor = false;
        // 
        // outlineColorButton
        // 
        outlineColorButton.Location = new System.Drawing.Point(0, 80);
        outlineColorButton.Name = "outlineColorButton";
        outlineColorButton.Size = new System.Drawing.Size(80, 35);
        outlineColorButton.TabIndex = 2;
        outlineColorButton.Text = "Граница";
        outlineColorButton.UseVisualStyleBackColor = true;
        outlineColorButton.Click += OutlineColorButton_Click;
        // 
        // fillColorButton
        // 
        fillColorButton.Location = new System.Drawing.Point(0, 30);
        fillColorButton.Name = "fillColorButton";
        fillColorButton.Size = new System.Drawing.Size(80, 35);
        fillColorButton.TabIndex = 3;
        fillColorButton.Text = "Заливка";
        fillColorButton.UseVisualStyleBackColor = true;
        fillColorButton.Click += FillColorButton_Click;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        groupBox1.Controls.Add(numericUpDown1);
        groupBox1.Controls.Add(fillColorButton);
        groupBox1.Controls.Add(outlineColorButton);
        groupBox1.Location = new System.Drawing.Point(698, 0);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(111, 172);
        groupBox1.TabIndex = 4;
        groupBox1.TabStop = false;
        groupBox1.Text = "Настройки";
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new System.Drawing.Point(0, 130);
        numericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new System.Drawing.Size(80, 27);
        numericUpDown1.TabIndex = 5;
        numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(groupBox1);
        Controls.Add(shapesGroupBox);
        Text = "Супер векторный редактор";
        shapesGroupBox.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private System.Windows.Forms.ColorDialog colorDialog2;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.Button BezierButton;


    private System.Windows.Forms.Button fillColorButton;
    private System.Windows.Forms.ColorDialog colorDialog1;

    private System.Windows.Forms.Button outlineColorButton;

    private System.Windows.Forms.GroupBox shapesGroupBox;

    #endregion
}