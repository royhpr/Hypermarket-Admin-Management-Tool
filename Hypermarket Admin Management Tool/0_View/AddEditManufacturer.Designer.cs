namespace Hypermarket_Admin_Management_Tool._0_View
{
    partial class AddEditManufacturer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditManufacturer));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(167, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(263, 26);
            this.txtName.TabIndex = 0;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Country: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Manufacturer Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Address: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Contact: ";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(167, 65);
            this.txtAdress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(263, 26);
            this.txtAdress.TabIndex = 1;
            this.txtAdress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // cbCountry
            // 
            this.cbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCountry.DropDownHeight = 100;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.IntegralHeight = false;
            this.cbCountry.Items.AddRange(new object[] {
            "Afghanistan",
            "Africa",
            "Albania",
            "Algeria",
            "American Samoa",
            "Andorra",
            "Angola",
            "Anguilla",
            "Antarctica",
            "Antigua & Barbuda",
            "Arabia, Saudi",
            "Argentina",
            "Armenia",
            "Aruba",
            "Asia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas, The",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bermuda",
            "Bhutan",
            "Bolivia",
            "Bonaire, St.Eustat, Saba",
            "Bosnia and Herzegovina",
            "Botswana",
            "Bouvet Island",
            "Brazil",
            "British Indian Ocean T.",
            "British Virgin Islands",
            "Brunei Darussalam",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Caribbean, the",
            "Cayman Islands",
            "Central African Republic",
            "Central America",
            "Chad",
            "Chile",
            "China",
            "Christmas Island",
            "Cocos (Keeling) Islands",
            "Colombia",
            "Comoros",
            "Congo",
            "Congo, Dem. Rep. of the",
            "Cook Islands",
            "Costa Rica",
            "Cote D\'Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor (Timor-Leste)",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Europe",
            "European Union",
            "Falkland Islands (Malvinas)",
            "Faroe Islands",
            "Fiji",
            "Finland",
            "France",
            "French Guiana",
            "French Polynesia",
            "French Southern Terr.",
            "Gabon",
            "Gambia, the",
            "Georgia",
            "Germany",
            "Ghana",
            "Gibraltar",
            "Greece",
            "Greenland",
            "Grenada",
            "Guadeloupe",
            "Guam",
            "Guatemala",
            "Guernsey and Alderney",
            "Guiana, French",
            "Guinea",
            "Guinea-Bissau",
            "Guinea, Equatorial",
            "Guyana",
            "Haiti",
            "Heard & McDonald Is.(AU)",
            "Holy See (Vatican)",
            "Honduras",
            "Hong Kong, (China)",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran, Islamic Republic of",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Ivory Coast (Cote d\'Ivoire)",
            "Jamaica",
            "Japan",
            "Jersey",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea Dem. People\'s Rep.",
            "Korea, (South) Republic of",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Lao People\'s Democ. Rep.",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libyan Arab Jamahiriya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macao, (China)",
            "Macedonia, TFYR",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Man, Isle of",
            "Marshall Islands",
            "Martinique (FR)",
            "Mauritania",
            "Mauritius",
            "Mayotte (FR)",
            "Mexico",
            "Micronesia, Fed. States of",
            "Moldova, Republic of",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Montserrat",
            "Morocco",
            "Mozambique",
            "Myanmar (ex-Burma)",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "Netherlands Antilles",
            "New Caledonia",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Niue",
            "Norfolk Island",
            "North America",
            "Northern Mariana Islands",
            "Norway",
            "Oceania",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestinian Territory",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Pitcairn Island",
            "Poland",
            "Portugal",
            "Puerto Rico",
            "Qatar",
            "Reunion (FR)",
            "Romania",
            "Russia (Russian Fed.)",
            "Rwanda",
            "Sahara, Western",
            "Saint Barthelemy (FR)",
            "Saint Helena (UK)",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Martin (FR)",
            "S Pierre & Miquelon(FR)",
            "S Vincent & Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South America",
            "S.George & S.Sandwich",
            "South Sudan",
            "Spain",
            "Sri Lanka (ex-Ceilan)",
            "Sudan",
            "Suriname",
            "Svalbard & Jan Mayen Is.",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syrian Arab Republic",
            "Taiwan",
            "Tajikistan",
            "Tanzania, United Rep. of",
            "Thailand",
            "Timor-Leste (East Timor)",
            "Togo",
            "Tokelau",
            "Tonga",
            "Trinidad & Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Turks and Caicos Is.",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "US Minor Outlying Isl.",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican (Holy See)",
            "Venezuela",
            "Viet Nam",
            "Virgin Islands, British",
            "Virgin Islands, U.S.",
            "Wallis and Futuna",
            "Western Sahara",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.cbCountry.Location = new System.Drawing.Point(167, 105);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(151, 28);
            this.cbCountry.TabIndex = 2;
            this.cbCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(167, 147);
            this.txtContact.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(151, 26);
            this.txtContact.TabIndex = 3;
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddProductInterace_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(361, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(286, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtError.Location = new System.Drawing.Point(16, 205);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(273, 35);
            this.txtError.TabIndex = 12;
            this.txtError.Text = "Error";
            this.txtError.Visible = false;
            // 
            // AddEditManufacturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(440, 247);
            this.ControlBox = false;
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddEditManufacturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddEditManufacturer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtError;
    }
}