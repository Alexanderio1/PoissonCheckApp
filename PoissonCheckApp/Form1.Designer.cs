namespace PoissonCheckApp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateSample2 = new System.Windows.Forms.Button();
            this.btnGenerateSample1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownLambda = new System.Windows.Forms.NumericUpDown();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCheckHypothesis = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerateSample2);
            this.groupBox1.Controls.Add(this.btnGenerateSample1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownLambda);
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Code", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 416);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки генерации";
            // 
            // btnGenerateSample2
            // 
            this.btnGenerateSample2.Location = new System.Drawing.Point(7, 313);
            this.btnGenerateSample2.Name = "btnGenerateSample2";
            this.btnGenerateSample2.Size = new System.Drawing.Size(429, 85);
            this.btnGenerateSample2.TabIndex = 5;
            this.btnGenerateSample2.Text = "Сгенерировать выборку 2";
            this.btnGenerateSample2.UseVisualStyleBackColor = true;
            this.btnGenerateSample2.Click += new System.EventHandler(this.btnGenerateSample2_Click);
            // 
            // btnGenerateSample1
            // 
            this.btnGenerateSample1.Location = new System.Drawing.Point(6, 204);
            this.btnGenerateSample1.Name = "btnGenerateSample1";
            this.btnGenerateSample1.Size = new System.Drawing.Size(429, 85);
            this.btnGenerateSample1.TabIndex = 4;
            this.btnGenerateSample1.Text = "Сгенерировать выборку 1";
            this.btnGenerateSample1.UseVisualStyleBackColor = true;
            this.btnGenerateSample1.Click += new System.EventHandler(this.btnGenerateSample1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "размер выборки (N)";
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(7, 126);
            this.numericUpDownN.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(120, 39);
            this.numericUpDownN.TabIndex = 2;
            this.numericUpDownN.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "λ (среднее пуассоновского распределения)";
            // 
            // numericUpDownLambda
            // 
            this.numericUpDownLambda.DecimalPlaces = 2;
            this.numericUpDownLambda.Location = new System.Drawing.Point(7, 58);
            this.numericUpDownLambda.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownLambda.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownLambda.Name = "numericUpDownLambda";
            this.numericUpDownLambda.ReadOnly = true;
            this.numericUpDownLambda.Size = new System.Drawing.Size(120, 39);
            this.numericUpDownLambda.TabIndex = 0;
            this.numericUpDownLambda.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(842, 12);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(642, 366);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(842, 408);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(642, 366);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            // 
            // btnCheckHypothesis
            // 
            this.btnCheckHypothesis.Font = new System.Drawing.Font("Cascadia Code", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckHypothesis.Location = new System.Drawing.Point(19, 434);
            this.btnCheckHypothesis.Name = "btnCheckHypothesis";
            this.btnCheckHypothesis.Size = new System.Drawing.Size(351, 94);
            this.btnCheckHypothesis.TabIndex = 3;
            this.btnCheckHypothesis.Text = "Проверить гипотезу";
            this.btnCheckHypothesis.UseVisualStyleBackColor = true;
            this.btnCheckHypothesis.Click += new System.EventHandler(this.btnCheckHypothesis_Click);
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Font = new System.Drawing.Font("Cascadia Code", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(194, 556);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(456, 382);
            this.lblResult.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1720, 1027);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCheckHypothesis);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownLambda;
        private System.Windows.Forms.Button btnGenerateSample2;
        private System.Windows.Forms.Button btnGenerateSample1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btnCheckHypothesis;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label3;
    }
}

