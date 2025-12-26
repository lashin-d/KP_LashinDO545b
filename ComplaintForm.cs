using System;
using System.Windows.Forms;

namespace HotelDBClientApp
{
    public partial class ComplaintForm : Form
    {
        public string ComplaintDescription { get; private set; }

        public ComplaintForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Подача скарги";
            this.Size = new System.Drawing.Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label label = new Label
            {
                Text = "Введіть опис скарги:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(340, 20)
            };
            this.Controls.Add(label);

            TextBox descriptionTextBox = new TextBox
            {
                Name = "descriptionTextBox",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(340, 50),
                Multiline = true
            };
            this.Controls.Add(descriptionTextBox);

            Button submitButton = new Button
            {
                Text = "Надіслати",
                Location = new System.Drawing.Point(20, 110),
                Size = new System.Drawing.Size(100, 30)
            };
            submitButton.Click += (s, e) =>
            {
                ComplaintDescription = descriptionTextBox.Text;
                if (string.IsNullOrEmpty(ComplaintDescription))
                {
                    MessageBox.Show("Опис скарги не може бути порожнім!");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(submitButton);

            Button cancelButton = new Button
            {
                Text = "Відміна",
                Location = new System.Drawing.Point(130, 110),
                Size = new System.Drawing.Size(100, 30)
            };
            cancelButton.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(cancelButton);
        }
    }
}