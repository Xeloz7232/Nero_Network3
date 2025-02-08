namespace Nero_Network3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bResultsFolder = new System.Windows.Forms.Button();
            this.bMegaTraining = new System.Windows.Forms.Button();
            this.rbScale = new System.Windows.Forms.RadioButton();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.logs = new System.Windows.Forms.ListBox();
            this.lRight = new System.Windows.Forms.Label();
            this.lEpoch = new System.Windows.Forms.Label();
            this.bTeachTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.lGuess = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.bStartTesting = new System.Windows.Forms.Button();
            this.bGive = new System.Windows.Forms.Button();
            this.pbWM10 = new System.Windows.Forms.PictureBox();
            this.pbWM6 = new System.Windows.Forms.PictureBox();
            this.pbWM3 = new System.Windows.Forms.PictureBox();
            this.pbWM8 = new System.Windows.Forms.PictureBox();
            this.pbWM9 = new System.Windows.Forms.PictureBox();
            this.pbWM7 = new System.Windows.Forms.PictureBox();
            this.pbWM5 = new System.Windows.Forms.PictureBox();
            this.pbWM4 = new System.Windows.Forms.PictureBox();
            this.pbWM2 = new System.Windows.Forms.PictureBox();
            this.pbWM1 = new System.Windows.Forms.PictureBox();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.bChooseWeights = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // bResultsFolder
            // 
            this.bResultsFolder.Location = new System.Drawing.Point(364, 134);
            this.bResultsFolder.Name = "bResultsFolder";
            this.bResultsFolder.Size = new System.Drawing.Size(100, 40);
            this.bResultsFolder.TabIndex = 70;
            this.bResultsFolder.Text = "Папка с результатами";
            this.bResultsFolder.UseVisualStyleBackColor = true;
            this.bResultsFolder.Click += new System.EventHandler(this.bResultsFolder_Click);
            // 
            // bMegaTraining
            // 
            this.bMegaTraining.Location = new System.Drawing.Point(363, 435);
            this.bMegaTraining.Name = "bMegaTraining";
            this.bMegaTraining.Size = new System.Drawing.Size(313, 23);
            this.bMegaTraining.TabIndex = 68;
            this.bMegaTraining.Text = "Мега-обучение";
            this.bMegaTraining.UseVisualStyleBackColor = true;
            this.bMegaTraining.Click += new System.EventHandler(this.bMegaTraining_Click);
            // 
            // rbScale
            // 
            this.rbScale.AutoSize = true;
            this.rbScale.Checked = true;
            this.rbScale.Location = new System.Drawing.Point(190, 115);
            this.rbScale.Name = "rbScale";
            this.rbScale.Size = new System.Drawing.Size(74, 17);
            this.rbScale.TabIndex = 61;
            this.rbScale.TabStop = true;
            this.rbScale.Text = "Масштаб.";
            this.rbScale.UseVisualStyleBackColor = true;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(190, 138);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(59, 17);
            this.rbCenter.TabIndex = 61;
            this.rbCenter.Text = "Центр.";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(190, 161);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(52, 17);
            this.rbNormal.TabIndex = 61;
            this.rbNormal.Text = "Выкл";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // logs
            // 
            this.logs.FormattingEnabled = true;
            this.logs.Location = new System.Drawing.Point(9, 194);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(348, 264);
            this.logs.TabIndex = 59;
            // 
            // lRight
            // 
            this.lRight.AutoSize = true;
            this.lRight.Location = new System.Drawing.Point(11, 148);
            this.lRight.Name = "lRight";
            this.lRight.Size = new System.Drawing.Size(44, 13);
            this.lRight.TabIndex = 58;
            this.lRight.Text = "Угадал";
            // 
            // lEpoch
            // 
            this.lEpoch.AutoSize = true;
            this.lEpoch.Location = new System.Drawing.Point(11, 126);
            this.lEpoch.Name = "lEpoch";
            this.lEpoch.Size = new System.Drawing.Size(37, 13);
            this.lEpoch.TabIndex = 57;
            this.lEpoch.Text = "Эпохи";
            // 
            // bTeachTest
            // 
            this.bTeachTest.Location = new System.Drawing.Point(9, 9);
            this.bTeachTest.Name = "bTeachTest";
            this.bTeachTest.Size = new System.Drawing.Size(82, 64);
            this.bTeachTest.TabIndex = 56;
            this.bTeachTest.Text = "Обучение и тест";
            this.bTeachTest.UseVisualStyleBackColor = true;
            this.bTeachTest.Click += new System.EventHandler(this.bTeachTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Альфа";
            // 
            // nudAlpha
            // 
            this.nudAlpha.DecimalPlaces = 2;
            this.nudAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Location = new System.Drawing.Point(379, 103);
            this.nudAlpha.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            131072});
            this.nudAlpha.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(66, 20);
            this.nudAlpha.TabIndex = 54;
            this.nudAlpha.Value = new decimal(new int[] {
            90,
            0,
            0,
            131072});
            // 
            // lGuess
            // 
            this.lGuess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGuess.Location = new System.Drawing.Point(97, 9);
            this.lGuess.Name = "lGuess";
            this.lGuess.Size = new System.Drawing.Size(157, 100);
            this.lGuess.TabIndex = 53;
            this.lGuess.Text = "Близнецы";
            this.lGuess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(263, 150);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(88, 24);
            this.bClear.TabIndex = 52;
            this.bClear.Text = "Очистить";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bStartTesting
            // 
            this.bStartTesting.Location = new System.Drawing.Point(9, 79);
            this.bStartTesting.Name = "bStartTesting";
            this.bStartTesting.Size = new System.Drawing.Size(82, 30);
            this.bStartTesting.TabIndex = 51;
            this.bStartTesting.Text = "Тест";
            this.bStartTesting.UseVisualStyleBackColor = true;
            this.bStartTesting.Click += new System.EventHandler(this.bStartTesting_Click);
            // 
            // bGive
            // 
            this.bGive.Location = new System.Drawing.Point(263, 120);
            this.bGive.Name = "bGive";
            this.bGive.Size = new System.Drawing.Size(88, 24);
            this.bGive.TabIndex = 50;
            this.bGive.Text = "Дать";
            this.bGive.UseVisualStyleBackColor = true;
            this.bGive.Click += new System.EventHandler(this.bGive_Click);
            // 
            // pbWM10
            // 
            this.pbWM10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM10.Location = new System.Drawing.Point(470, 327);
            this.pbWM10.Name = "pbWM10";
            this.pbWM10.Size = new System.Drawing.Size(100, 100);
            this.pbWM10.TabIndex = 48;
            this.pbWM10.TabStop = false;
            // 
            // pbWM6
            // 
            this.pbWM6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM6.Location = new System.Drawing.Point(576, 115);
            this.pbWM6.Name = "pbWM6";
            this.pbWM6.Size = new System.Drawing.Size(100, 100);
            this.pbWM6.TabIndex = 47;
            this.pbWM6.TabStop = false;
            // 
            // pbWM3
            // 
            this.pbWM3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM3.Location = new System.Drawing.Point(576, 9);
            this.pbWM3.Name = "pbWM3";
            this.pbWM3.Size = new System.Drawing.Size(100, 100);
            this.pbWM3.TabIndex = 46;
            this.pbWM3.TabStop = false;
            // 
            // pbWM8
            // 
            this.pbWM8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM8.Location = new System.Drawing.Point(470, 221);
            this.pbWM8.Name = "pbWM8";
            this.pbWM8.Size = new System.Drawing.Size(100, 100);
            this.pbWM8.TabIndex = 45;
            this.pbWM8.TabStop = false;
            // 
            // pbWM9
            // 
            this.pbWM9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM9.Location = new System.Drawing.Point(364, 327);
            this.pbWM9.Name = "pbWM9";
            this.pbWM9.Size = new System.Drawing.Size(100, 100);
            this.pbWM9.TabIndex = 44;
            this.pbWM9.TabStop = false;
            // 
            // pbWM7
            // 
            this.pbWM7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM7.Location = new System.Drawing.Point(364, 221);
            this.pbWM7.Name = "pbWM7";
            this.pbWM7.Size = new System.Drawing.Size(100, 100);
            this.pbWM7.TabIndex = 43;
            this.pbWM7.TabStop = false;
            // 
            // pbWM5
            // 
            this.pbWM5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM5.Location = new System.Drawing.Point(470, 115);
            this.pbWM5.Name = "pbWM5";
            this.pbWM5.Size = new System.Drawing.Size(100, 100);
            this.pbWM5.TabIndex = 42;
            this.pbWM5.TabStop = false;
            // 
            // pbWM4
            // 
            this.pbWM4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM4.Location = new System.Drawing.Point(576, 221);
            this.pbWM4.Name = "pbWM4";
            this.pbWM4.Size = new System.Drawing.Size(100, 100);
            this.pbWM4.TabIndex = 41;
            this.pbWM4.TabStop = false;
            // 
            // pbWM2
            // 
            this.pbWM2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM2.Location = new System.Drawing.Point(470, 9);
            this.pbWM2.Name = "pbWM2";
            this.pbWM2.Size = new System.Drawing.Size(100, 100);
            this.pbWM2.TabIndex = 40;
            this.pbWM2.TabStop = false;
            // 
            // pbWM1
            // 
            this.pbWM1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWM1.Location = new System.Drawing.Point(576, 327);
            this.pbWM1.Name = "pbWM1";
            this.pbWM1.Size = new System.Drawing.Size(100, 100);
            this.pbWM1.TabIndex = 49;
            this.pbWM1.TabStop = false;
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Location = new System.Drawing.Point(257, 9);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(100, 100);
            this.pbMain.TabIndex = 39;
            this.pbMain.TabStop = false;
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseMove);
            // 
            // bChooseWeights
            // 
            this.bChooseWeights.Location = new System.Drawing.Point(364, 180);
            this.bChooseWeights.Name = "bChooseWeights";
            this.bChooseWeights.Size = new System.Drawing.Size(100, 35);
            this.bChooseWeights.TabIndex = 71;
            this.bChooseWeights.Text = "Выбор весов";
            this.bChooseWeights.UseVisualStyleBackColor = true;
            this.bChooseWeights.Click += new System.EventHandler(this.bChooseWeights_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 467);
            this.Controls.Add(this.bChooseWeights);
            this.Controls.Add(this.bResultsFolder);
            this.Controls.Add(this.bMegaTraining);
            this.Controls.Add(this.rbScale);
            this.Controls.Add(this.rbCenter);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.lRight);
            this.Controls.Add(this.lEpoch);
            this.Controls.Add(this.bTeachTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAlpha);
            this.Controls.Add(this.lGuess);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bStartTesting);
            this.Controls.Add(this.bGive);
            this.Controls.Add(this.pbWM10);
            this.Controls.Add(this.pbWM6);
            this.Controls.Add(this.pbWM3);
            this.Controls.Add(this.pbWM8);
            this.Controls.Add(this.pbWM9);
            this.Controls.Add(this.pbWM7);
            this.Controls.Add(this.pbWM5);
            this.Controls.Add(this.pbWM4);
            this.Controls.Add(this.pbWM2);
            this.Controls.Add(this.pbWM1);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bResultsFolder;
        private System.Windows.Forms.Button bMegaTraining;
        private System.Windows.Forms.RadioButton rbScale;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.ListBox logs;
        private System.Windows.Forms.Label lRight;
        private System.Windows.Forms.Label lEpoch;
        private System.Windows.Forms.Button bTeachTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Label lGuess;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bStartTesting;
        private System.Windows.Forms.Button bGive;
        private System.Windows.Forms.PictureBox pbWM10;
        private System.Windows.Forms.PictureBox pbWM6;
        private System.Windows.Forms.PictureBox pbWM3;
        private System.Windows.Forms.PictureBox pbWM8;
        private System.Windows.Forms.PictureBox pbWM9;
        private System.Windows.Forms.PictureBox pbWM7;
        private System.Windows.Forms.PictureBox pbWM5;
        private System.Windows.Forms.PictureBox pbWM4;
        private System.Windows.Forms.PictureBox pbWM2;
        private System.Windows.Forms.PictureBox pbWM1;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button bChooseWeights;
    }
}

