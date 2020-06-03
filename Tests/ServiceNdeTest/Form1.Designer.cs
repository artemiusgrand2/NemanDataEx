namespace ServiceNdeTest
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.button1 = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      this.txtTargetThreadId = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txtSourceThreadId = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(33, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(33, 82);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(520, 212);
      this.tabControl1.TabIndex = 8;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.button2);
      this.tabPage1.Controls.Add(this.txtTargetThreadId);
      this.tabPage1.Controls.Add(this.label8);
      this.tabPage1.Controls.Add(this.txtSourceThreadId);
      this.tabPage1.Controls.Add(this.label7);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(512, 186);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Bind";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(431, 157);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 4;
      this.button2.Text = "Execute";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // txtTargetThreadId
      // 
      this.txtTargetThreadId.Location = new System.Drawing.Point(135, 41);
      this.txtTargetThreadId.Name = "txtTargetThreadId";
      this.txtTargetThreadId.Size = new System.Drawing.Size(100, 20);
      this.txtTargetThreadId.TabIndex = 3;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(19, 48);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(85, 13);
      this.label8.TabIndex = 2;
      this.label8.Text = "Target thread id:";
      // 
      // txtSourceThreadId
      // 
      this.txtSourceThreadId.Location = new System.Drawing.Point(135, 15);
      this.txtSourceThreadId.Name = "txtSourceThreadId";
      this.txtSourceThreadId.Size = new System.Drawing.Size(100, 20);
      this.txtSourceThreadId.TabIndex = 1;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(19, 22);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(88, 13);
      this.label7.TabIndex = 0;
      this.label7.Text = "Source thread id:";
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(512, 186);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(583, 314);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox txtTargetThreadId;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtSourceThreadId;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TabPage tabPage2;
  }
}

