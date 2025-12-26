namespace HotelDBClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Обов'язкова змінна конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Звільнити всі використані ресурси.
        /// </summary>
        /// <param name="disposing">true, якщо керований ресурс потрібно видалити; інакше false.</param>
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
        /// Обов'язковий метод для підтримки дизайнера - не змінюйте
        /// вміст цього методу за допомогою редактора коду.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableSelectionPanel = new System.Windows.Forms.Panel();
            this.tableLabel = new System.Windows.Forms.Label();
            this.tableComboBox = new System.Windows.Forms.ComboBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.operationsPanel = new System.Windows.Forms.Panel();
            this.showStatisticsButton = new System.Windows.Forms.Button();
            this.submitComplaintButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.countButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchSortPanel = new System.Windows.Forms.Panel();
            this.fieldLabel = new System.Windows.Forms.Label();
            this.fieldComboBox = new System.Windows.Forms.ComboBox();
            this.descendingCheckBox = new System.Windows.Forms.CheckBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.editPanel = new System.Windows.Forms.Panel();
            this.editLabel = new System.Windows.Forms.Label();
            this.editTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableSelectionPanel.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            this.searchSortPanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1295, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.programToolStripMenuItem.Text = "Програма";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.aboutToolStripMenuItem.Text = "Про програму";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.exitToolStripMenuItem.Text = "Вийти";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(16, 298);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 386);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableSelectionPanel
            // 
            this.tableSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableSelectionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tableSelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableSelectionPanel.Controls.Add(this.tableLabel);
            this.tableSelectionPanel.Controls.Add(this.tableComboBox);
            this.tableSelectionPanel.Controls.Add(this.loadButton);
            this.tableSelectionPanel.Location = new System.Drawing.Point(16, 30);
            this.tableSelectionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableSelectionPanel.Name = "tableSelectionPanel";
            this.tableSelectionPanel.Size = new System.Drawing.Size(1262, 73);
            this.tableSelectionPanel.TabIndex = 1;
            // 
            // tableLabel
            // 
            this.tableLabel.AutoSize = true;
            this.tableLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tableLabel.ForeColor = System.Drawing.Color.Navy;
            this.tableLabel.Location = new System.Drawing.Point(13, 25);
            this.tableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(138, 20);
            this.tableLabel.TabIndex = 0;
            this.tableLabel.Text = "Оберіть таблицю:";
            // 
            // tableComboBox
            // 
            this.tableComboBox.BackColor = System.Drawing.Color.White;
            this.tableComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tableComboBox.ForeColor = System.Drawing.Color.Black;
            this.tableComboBox.FormattingEnabled = true;
            this.tableComboBox.Location = new System.Drawing.Point(175, 25);
            this.tableComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.tableComboBox.Name = "tableComboBox";
            this.tableComboBox.Size = new System.Drawing.Size(199, 28);
            this.tableComboBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tableComboBox, "Оберіть таблицю Client, щоб подати скаргу");
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.loadButton.ForeColor = System.Drawing.Color.White;
            this.loadButton.Location = new System.Drawing.Point(388, 25);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(133, 31);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Завантажити";
            this.loadButton.UseVisualStyleBackColor = false;
            // 
            // operationsPanel
            // 
            this.operationsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.operationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationsPanel.Controls.Add(this.showStatisticsButton);
            this.operationsPanel.Controls.Add(this.submitComplaintButton);
            this.operationsPanel.Controls.Add(this.sortButton);
            this.operationsPanel.Controls.Add(this.searchButton);
            this.operationsPanel.Controls.Add(this.countButton);
            this.operationsPanel.Controls.Add(this.addButton);
            this.operationsPanel.Controls.Add(this.editButton);
            this.operationsPanel.Controls.Add(this.deleteButton);
            this.operationsPanel.Location = new System.Drawing.Point(16, 111);
            this.operationsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.operationsPanel.Name = "operationsPanel";
            this.operationsPanel.Size = new System.Drawing.Size(1262, 98);
            this.operationsPanel.TabIndex = 2;
            // 
            // showStatisticsButton
            // 
            this.showStatisticsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.showStatisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showStatisticsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.showStatisticsButton.ForeColor = System.Drawing.Color.White;
            this.showStatisticsButton.Location = new System.Drawing.Point(911, 37);
            this.showStatisticsButton.Margin = new System.Windows.Forms.Padding(4);
            this.showStatisticsButton.Name = "showStatisticsButton";
            this.showStatisticsButton.Size = new System.Drawing.Size(190, 31);
            this.showStatisticsButton.TabIndex = 7;
            this.showStatisticsButton.Text = "Показати статистику";
            this.showStatisticsButton.UseVisualStyleBackColor = false;
            // 
            // submitComplaintButton
            // 
            this.submitComplaintButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.submitComplaintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitComplaintButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.submitComplaintButton.ForeColor = System.Drawing.Color.White;
            this.submitComplaintButton.Location = new System.Drawing.Point(747, 37);
            this.submitComplaintButton.Margin = new System.Windows.Forms.Padding(4);
            this.submitComplaintButton.Name = "submitComplaintButton";
            this.submitComplaintButton.Size = new System.Drawing.Size(150, 31);
            this.submitComplaintButton.TabIndex = 6;
            this.submitComplaintButton.Text = "Подати скаргу";
            this.submitComplaintButton.UseVisualStyleBackColor = false;
            // 
            // sortButton
            // 
            this.sortButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.sortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sortButton.ForeColor = System.Drawing.Color.White;
            this.sortButton.Location = new System.Drawing.Point(13, 37);
            this.sortButton.Margin = new System.Windows.Forms.Padding(4);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(133, 31);
            this.sortButton.TabIndex = 0;
            this.sortButton.Text = "Сортувати";
            this.sortButton.UseVisualStyleBackColor = false;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(160, 37);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(133, 31);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Пошук";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // countButton
            // 
            this.countButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.countButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.countButton.ForeColor = System.Drawing.Color.White;
            this.countButton.Location = new System.Drawing.Point(307, 37);
            this.countButton.Margin = new System.Windows.Forms.Padding(4);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(133, 31);
            this.countButton.TabIndex = 2;
            this.countButton.Text = "Підрахунок";
            this.countButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(453, 37);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(133, 31);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Додати";
            this.addButton.UseVisualStyleBackColor = false;
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.Location = new System.Drawing.Point(600, 37);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(133, 31);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Редагувати";
            this.editButton.UseVisualStyleBackColor = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(1115, 37);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(133, 31);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Видалити";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // searchSortPanel
            // 
            this.searchSortPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchSortPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.searchSortPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchSortPanel.Controls.Add(this.fieldLabel);
            this.searchSortPanel.Controls.Add(this.fieldComboBox);
            this.searchSortPanel.Controls.Add(this.descendingCheckBox);
            this.searchSortPanel.Controls.Add(this.searchLabel);
            this.searchSortPanel.Controls.Add(this.searchTextBox);
            this.searchSortPanel.Location = new System.Drawing.Point(16, 217);
            this.searchSortPanel.Margin = new System.Windows.Forms.Padding(4);
            this.searchSortPanel.Name = "searchSortPanel";
            this.searchSortPanel.Size = new System.Drawing.Size(1262, 73);
            this.searchSortPanel.TabIndex = 3;
            // 
            // fieldLabel
            // 
            this.fieldLabel.AutoSize = true;
            this.fieldLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.fieldLabel.ForeColor = System.Drawing.Color.Navy;
            this.fieldLabel.Location = new System.Drawing.Point(13, 25);
            this.fieldLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fieldLabel.Name = "fieldLabel";
            this.fieldLabel.Size = new System.Drawing.Size(50, 20);
            this.fieldLabel.TabIndex = 0;
            this.fieldLabel.Text = "Поле:";
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.BackColor = System.Drawing.Color.White;
            this.fieldComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fieldComboBox.ForeColor = System.Drawing.Color.Black;
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Location = new System.Drawing.Point(67, 25);
            this.fieldComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(199, 28);
            this.fieldComboBox.TabIndex = 1;
            // 
            // descendingCheckBox
            // 
            this.descendingCheckBox.AutoSize = true;
            this.descendingCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descendingCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.descendingCheckBox.Location = new System.Drawing.Point(280, 25);
            this.descendingCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.descendingCheckBox.Name = "descendingCheckBox";
            this.descendingCheckBox.Size = new System.Drawing.Size(128, 24);
            this.descendingCheckBox.TabIndex = 2;
            this.descendingCheckBox.Text = "За спаданням";
            this.descendingCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.searchLabel.ForeColor = System.Drawing.Color.Navy;
            this.searchLabel.Location = new System.Drawing.Point(430, 25);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(62, 20);
            this.searchLabel.TabIndex = 3;
            this.searchLabel.Text = "Пошук:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchTextBox.ForeColor = System.Drawing.Color.Black;
            this.searchTextBox.Location = new System.Drawing.Point(497, 25);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(265, 27);
            this.searchTextBox.TabIndex = 4;
            // 
            // editPanel
            // 
            this.editPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.editPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editPanel.Controls.Add(this.editLabel);
            this.editPanel.Controls.Add(this.editTextBox);
            this.editPanel.Location = new System.Drawing.Point(16, 692);
            this.editPanel.Margin = new System.Windows.Forms.Padding(4);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(1262, 73);
            this.editPanel.TabIndex = 4;
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.editLabel.ForeColor = System.Drawing.Color.Navy;
            this.editLabel.Location = new System.Drawing.Point(13, 25);
            this.editLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(166, 20);
            this.editLabel.TabIndex = 0;
            this.editLabel.Text = "Редагувати значення:";
            // 
            // editTextBox
            // 
            this.editTextBox.BackColor = System.Drawing.Color.White;
            this.editTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editTextBox.ForeColor = System.Drawing.Color.Black;
            this.editTextBox.Location = new System.Drawing.Point(220, 25);
            this.editTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.editTextBox.Name = "editTextBox";
            this.editTextBox.Size = new System.Drawing.Size(265, 27);
            this.editTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1295, 780);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.searchSortPanel);
            this.Controls.Add(this.operationsPanel);
            this.Controls.Add(this.tableSelectionPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "HotelDB Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableSelectionPanel.ResumeLayout(false);
            this.tableSelectionPanel.PerformLayout();
            this.operationsPanel.ResumeLayout(false);
            this.searchSortPanel.ResumeLayout(false);
            this.searchSortPanel.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel tableSelectionPanel;
        private System.Windows.Forms.Label tableLabel;
        private System.Windows.Forms.ComboBox tableComboBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Panel operationsPanel;
        private System.Windows.Forms.Button showStatisticsButton;
        private System.Windows.Forms.Button submitComplaintButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Panel searchSortPanel;
        private System.Windows.Forms.Label fieldLabel;
        private System.Windows.Forms.ComboBox fieldComboBox;
        private System.Windows.Forms.CheckBox descendingCheckBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.TextBox editTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}