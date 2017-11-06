namespace GUI
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1CarType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2ClassType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1AddAuto = new System.Windows.Forms.Button();
            this.button2DeleteCar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3RedactionAuto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6RedactionDriver = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4AddDriver = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox9RequestDriver = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button10RedactionCustomer = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12AddCustomer = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button7RedactionRequest = new System.Windows.Forms.Button();
            this.button8DeleteRequest = new System.Windows.Forms.Button();
            this.button9AddRequest = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7RequestCar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 177);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(375, 329);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1CarType
            // 
            this.comboBox1CarType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1CarType.FormattingEnabled = true;
            this.comboBox1CarType.Location = new System.Drawing.Point(281, 32);
            this.comboBox1CarType.Name = "comboBox1CarType";
            this.comboBox1CarType.Size = new System.Drawing.Size(106, 21);
            this.comboBox1CarType.TabIndex = 2;
            this.comboBox1CarType.SelectedIndexChanged += new System.EventHandler(this.comboBox1CarType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(278, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип транспорта";
            // 
            // comboBox2ClassType
            // 
            this.comboBox2ClassType.FormattingEnabled = true;
            this.comboBox2ClassType.Location = new System.Drawing.Point(467, 32);
            this.comboBox2ClassType.Name = "comboBox2ClassType";
            this.comboBox2ClassType.Size = new System.Drawing.Size(121, 21);
            this.comboBox2ClassType.TabIndex = 4;
            this.comboBox2ClassType.SelectedIndexChanged += new System.EventHandler(this.comboBox2ClassType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(464, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Класс автомобиля";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(469, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(278, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Стоимость аренды (1 час) ";
            // 
            // button1AddAuto
            // 
            this.button1AddAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1AddAuto.Location = new System.Drawing.Point(12, 526);
            this.button1AddAuto.Name = "button1AddAuto";
            this.button1AddAuto.Size = new System.Drawing.Size(83, 32);
            this.button1AddAuto.TabIndex = 8;
            this.button1AddAuto.Text = "Добавить";
            this.button1AddAuto.UseVisualStyleBackColor = true;
            this.button1AddAuto.Click += new System.EventHandler(this.button1AddAuto_Click);
            // 
            // button2DeleteCar
            // 
            this.button2DeleteCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2DeleteCar.Location = new System.Drawing.Point(122, 526);
            this.button2DeleteCar.Name = "button2DeleteCar";
            this.button2DeleteCar.Size = new System.Drawing.Size(83, 32);
            this.button2DeleteCar.TabIndex = 9;
            this.button2DeleteCar.Text = "Удалить";
            this.button2DeleteCar.UseVisualStyleBackColor = true;
            this.button2DeleteCar.Click += new System.EventHandler(this.button2DeleteCar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(405, 177);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(183, 329);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // button3RedactionAuto
            // 
            this.button3RedactionAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3RedactionAuto.Location = new System.Drawing.Point(232, 526);
            this.button3RedactionAuto.Name = "button3RedactionAuto";
            this.button3RedactionAuto.Size = new System.Drawing.Size(123, 32);
            this.button3RedactionAuto.TabIndex = 11;
            this.button3RedactionAuto.Text = "Редактировать";
            this.button3RedactionAuto.UseVisualStyleBackColor = true;
            this.button3RedactionAuto.Click += new System.EventHandler(this.button3RedactionAuto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(402, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Тех. характеристики";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.button6RedactionDriver);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4AddDriver);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(627, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 526);
            this.panel1.TabIndex = 14;
            // 
            // button6RedactionDriver
            // 
            this.button6RedactionDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6RedactionDriver.Location = new System.Drawing.Point(50, 473);
            this.button6RedactionDriver.Name = "button6RedactionDriver";
            this.button6RedactionDriver.Size = new System.Drawing.Size(171, 32);
            this.button6RedactionDriver.TabIndex = 23;
            this.button6RedactionDriver.Text = "Редактирование";
            this.button6RedactionDriver.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(50, 413);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(171, 32);
            this.button5.TabIndex = 22;
            this.button5.Text = "Удалить информацию";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4AddDriver
            // 
            this.button4AddDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4AddDriver.Location = new System.Drawing.Point(50, 352);
            this.button4AddDriver.Name = "button4AddDriver";
            this.button4AddDriver.Size = new System.Drawing.Size(171, 32);
            this.button4AddDriver.TabIndex = 21;
            this.button4AddDriver.Text = "Добавить водителя";
            this.button4AddDriver.UseVisualStyleBackColor = true;
            this.button4AddDriver.Click += new System.EventHandler(this.button4AddDriver_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(98, 287);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 20);
            this.textBox4.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(14, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 34);
            this.label8.TabIndex = 19;
            this.label8.Text = "Вредные\r\nпривычки\r\n";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(74, 223);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(173, 20);
            this.textBox3.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(14, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Стаж";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "ФИО";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(74, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(173, 20);
            this.textBox2.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProkatAuto22.Properties.Resources.vod1;
            this.pictureBox2.Location = new System.Drawing.Point(74, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 126);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(674, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Информация о водителе";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.checkBox4);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.textBox9RequestDriver);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.button7RedactionRequest);
            this.panel2.Controls.Add(this.button8DeleteRequest);
            this.panel2.Controls.Add(this.button9AddRequest);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBox7RequestCar);
            this.panel2.Location = new System.Drawing.Point(939, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 526);
            this.panel2.TabIndex = 15;
            // 
            // textBox9RequestDriver
            // 
            this.textBox9RequestDriver.Location = new System.Drawing.Point(17, 89);
            this.textBox9RequestDriver.Name = "textBox9RequestDriver";
            this.textBox9RequestDriver.Size = new System.Drawing.Size(204, 20);
            this.textBox9RequestDriver.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(276, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(164, 17);
            this.label18.TabIndex = 18;
            this.label18.Text = "Информация о клиенте";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(17, 211);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(204, 20);
            this.textBox8.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.button10RedactionCustomer);
            this.panel3.Controls.Add(this.button11);
            this.panel3.Controls.Add(this.button12AddCustomer);
            this.panel3.Controls.Add(this.textBox10);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.textBox11);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.textBox12);
            this.panel3.Location = new System.Drawing.Point(279, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 300);
            this.panel3.TabIndex = 17;
            // 
            // button10RedactionCustomer
            // 
            this.button10RedactionCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10RedactionCustomer.Location = new System.Drawing.Point(50, 248);
            this.button10RedactionCustomer.Name = "button10RedactionCustomer";
            this.button10RedactionCustomer.Size = new System.Drawing.Size(171, 32);
            this.button10RedactionCustomer.TabIndex = 23;
            this.button10RedactionCustomer.Text = "Редактирование";
            this.button10RedactionCustomer.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(50, 196);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(171, 32);
            this.button11.TabIndex = 22;
            this.button11.Text = "Удалить клиента";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12AddCustomer
            // 
            this.button12AddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12AddCustomer.Location = new System.Drawing.Point(50, 141);
            this.button12AddCustomer.Name = "button12AddCustomer";
            this.button12AddCustomer.Size = new System.Drawing.Size(171, 32);
            this.button12AddCustomer.TabIndex = 21;
            this.button12AddCustomer.Text = "Добавить клиента";
            this.button12AddCustomer.UseVisualStyleBackColor = true;
            this.button12AddCustomer.Click += new System.EventHandler(this.button12AddCustomer_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(94, 96);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(153, 20);
            this.textBox10.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(14, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "Город";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(94, 55);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(153, 20);
            this.textBox11.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(14, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 17);
            this.label16.TabIndex = 17;
            this.label16.Text = "Телефон";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(14, 14);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 16;
            this.label17.Text = "ФИО";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(94, 14);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(151, 20);
            this.textBox12.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(14, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "Клиент (id)";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(63, 161);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(158, 20);
            this.textBox6.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(14, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "Цена";
            // 
            // button7RedactionRequest
            // 
            this.button7RedactionRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7RedactionRequest.Location = new System.Drawing.Point(375, 473);
            this.button7RedactionRequest.Name = "button7RedactionRequest";
            this.button7RedactionRequest.Size = new System.Drawing.Size(171, 32);
            this.button7RedactionRequest.TabIndex = 23;
            this.button7RedactionRequest.Text = "Редактирование";
            this.button7RedactionRequest.UseVisualStyleBackColor = true;
            this.button7RedactionRequest.Click += new System.EventHandler(this.button7RedactionRequest_Click);
            // 
            // button8DeleteRequest
            // 
            this.button8DeleteRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8DeleteRequest.Location = new System.Drawing.Point(193, 473);
            this.button8DeleteRequest.Name = "button8DeleteRequest";
            this.button8DeleteRequest.Size = new System.Drawing.Size(171, 32);
            this.button8DeleteRequest.TabIndex = 22;
            this.button8DeleteRequest.Text = "Удалить информацию";
            this.button8DeleteRequest.UseVisualStyleBackColor = true;
            this.button8DeleteRequest.Click += new System.EventHandler(this.button8DeleteRequest_Click);
            // 
            // button9AddRequest
            // 
            this.button9AddRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9AddRequest.Location = new System.Drawing.Point(16, 473);
            this.button9AddRequest.Name = "button9AddRequest";
            this.button9AddRequest.Size = new System.Drawing.Size(171, 32);
            this.button9AddRequest.TabIndex = 21;
            this.button9AddRequest.Text = "Добавить заявку";
            this.button9AddRequest.UseVisualStyleBackColor = true;
            this.button9AddRequest.Click += new System.EventHandler(this.button9AddRequest_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(165, 125);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(56, 20);
            this.textBox5.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(14, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Время аренды (ч)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(14, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Водитель";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(14, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Автомобиль";
            // 
            // textBox7RequestCar
            // 
            this.textBox7RequestCar.Location = new System.Drawing.Point(17, 36);
            this.textBox7RequestCar.Name = "textBox7RequestCar";
            this.textBox7RequestCar.Size = new System.Drawing.Size(204, 20);
            this.textBox7RequestCar.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(1140, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "Аренда автомобиля";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProkatAuto22.Properties.Resources._2016_Honda_Civic;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(89, 236);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 17);
            this.label23.TabIndex = 30;
            this.label23.Text = "Опции";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 256);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 17);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Детские кресла";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(17, 280);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Зимние шины";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(17, 304);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(145, 17);
            this.checkBox3.TabIndex = 33;
            this.checkBox3.Text = "Спортивные крепления";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(17, 328);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(106, 17);
            this.checkBox4.TabIndex = 34;
            this.checkBox4.Text = "GPS- навигатор";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1512, 570);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3RedactionAuto);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2DeleteCar);
            this.Controls.Add(this.button1AddAuto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2ClassType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1CarType);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "ПрокатАвто22";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1CarType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2ClassType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1AddAuto;
        private System.Windows.Forms.Button button2DeleteCar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3RedactionAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6RedactionDriver;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4AddDriver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox9RequestDriver;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button7RedactionRequest;
        private System.Windows.Forms.Button button8DeleteRequest;
        private System.Windows.Forms.Button button9AddRequest;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox7RequestCar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button10RedactionCustomer;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12AddCustomer;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

