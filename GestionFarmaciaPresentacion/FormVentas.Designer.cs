namespace GestionFarmaciaPresentacion
{
    partial class FormVentas
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelNumeroComprobante = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.txtb_Total = new System.Windows.Forms.TextBox();
            this.txtb_Cantidad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtb_IVA = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtb_Precio = new System.Windows.Forms.TextBox();
            this.txtb_Subtotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtb_Presentacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtb_NombreGenerico = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtb_NombreComercial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_Venta = new System.Windows.Forms.DataGridView();
            this.btn_Productos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtbCorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbTelefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbNombres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbCedulaRuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.preferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaPreviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelNumeroComprobante);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Location = new System.Drawing.Point(23, 66);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(778, 98);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DETALLE DE VENTA";
            // 
            // labelNumeroComprobante
            // 
            this.labelNumeroComprobante.AutoSize = true;
            this.labelNumeroComprobante.Location = new System.Drawing.Point(560, 32);
            this.labelNumeroComprobante.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumeroComprobante.Name = "labelNumeroComprobante";
            this.labelNumeroComprobante.Size = new System.Drawing.Size(16, 13);
            this.labelNumeroComprobante.TabIndex = 14;
            this.labelNumeroComprobante.Text = "...";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 32);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Número de Comprobante";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 32);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Fecha de Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(134, 28);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Agregar);
            this.groupBox2.Controls.Add(this.txtb_Total);
            this.groupBox2.Controls.Add(this.txtb_Cantidad);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtb_IVA);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtb_Precio);
            this.groupBox2.Controls.Add(this.txtb_Subtotal);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtb_Presentacion);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtb_NombreGenerico);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtb_NombreComercial);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dgv_Venta);
            this.groupBox2.Controls.Add(this.btn_Productos);
            this.groupBox2.Location = new System.Drawing.Point(23, 337);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(778, 344);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Venta";
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(704, 42);
            this.btn_Agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(56, 33);
            this.btn_Agregar.TabIndex = 12;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            // 
            // txtb_Total
            // 
            this.txtb_Total.Location = new System.Drawing.Point(685, 311);
            this.txtb_Total.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_Total.Name = "txtb_Total";
            this.txtb_Total.ReadOnly = true;
            this.txtb_Total.Size = new System.Drawing.Size(76, 20);
            this.txtb_Total.TabIndex = 9;
            this.txtb_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtb_Cantidad
            // 
            this.txtb_Cantidad.Location = new System.Drawing.Point(591, 44);
            this.txtb_Cantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_Cantidad.Name = "txtb_Cantidad";
            this.txtb_Cantidad.Size = new System.Drawing.Size(66, 20);
            this.txtb_Cantidad.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(640, 316);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(592, 23);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Cantidad";
            // 
            // txtb_IVA
            // 
            this.txtb_IVA.Location = new System.Drawing.Point(685, 288);
            this.txtb_IVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_IVA.Name = "txtb_IVA";
            this.txtb_IVA.ReadOnly = true;
            this.txtb_IVA.Size = new System.Drawing.Size(76, 20);
            this.txtb_IVA.TabIndex = 7;
            this.txtb_IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(626, 293);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "IVA(15%)";
            // 
            // txtb_Precio
            // 
            this.txtb_Precio.Location = new System.Drawing.Point(503, 44);
            this.txtb_Precio.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_Precio.Name = "txtb_Precio";
            this.txtb_Precio.ReadOnly = true;
            this.txtb_Precio.Size = new System.Drawing.Size(48, 20);
            this.txtb_Precio.TabIndex = 9;
            // 
            // txtb_Subtotal
            // 
            this.txtb_Subtotal.Location = new System.Drawing.Point(685, 266);
            this.txtb_Subtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_Subtotal.Name = "txtb_Subtotal";
            this.txtb_Subtotal.ReadOnly = true;
            this.txtb_Subtotal.Size = new System.Drawing.Size(76, 20);
            this.txtb_Subtotal.TabIndex = 5;
            this.txtb_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtb_Subtotal.TextChanged += new System.EventHandler(this.txtb_Subtotal_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(501, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Precio";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(626, 271);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "SubTotal";
            // 
            // txtb_Presentacion
            // 
            this.txtb_Presentacion.Location = new System.Drawing.Point(299, 44);
            this.txtb_Presentacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_Presentacion.Name = "txtb_Presentacion";
            this.txtb_Presentacion.ReadOnly = true;
            this.txtb_Presentacion.Size = new System.Drawing.Size(166, 20);
            this.txtb_Presentacion.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(297, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Presentacion";
            // 
            // txtb_NombreGenerico
            // 
            this.txtb_NombreGenerico.Location = new System.Drawing.Point(157, 44);
            this.txtb_NombreGenerico.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_NombreGenerico.Name = "txtb_NombreGenerico";
            this.txtb_NombreGenerico.ReadOnly = true;
            this.txtb_NombreGenerico.Size = new System.Drawing.Size(105, 20);
            this.txtb_NombreGenerico.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre Generico";
            // 
            // txtb_NombreComercial
            // 
            this.txtb_NombreComercial.Location = new System.Drawing.Point(15, 44);
            this.txtb_NombreComercial.Margin = new System.Windows.Forms.Padding(2);
            this.txtb_NombreComercial.Name = "txtb_NombreComercial";
            this.txtb_NombreComercial.ReadOnly = true;
            this.txtb_NombreComercial.Size = new System.Drawing.Size(105, 20);
            this.txtb_NombreComercial.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nombre Comercial";
            // 
            // dgv_Venta
            // 
            this.dgv_Venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Venta.Location = new System.Drawing.Point(15, 80);
            this.dgv_Venta.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Venta.Name = "dgv_Venta";
            this.dgv_Venta.RowHeadersWidth = 51;
            this.dgv_Venta.RowTemplate.Height = 24;
            this.dgv_Venta.Size = new System.Drawing.Size(745, 179);
            this.dgv_Venta.TabIndex = 1;
            // 
            // btn_Productos
            // 
            this.btn_Productos.Location = new System.Drawing.Point(704, 17);
            this.btn_Productos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Productos.Name = "btn_Productos";
            this.btn_Productos.Size = new System.Drawing.Size(56, 19);
            this.btn_Productos.TabIndex = 0;
            this.btn_Productos.Text = "Productos";
            this.btn_Productos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtbCorreo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbDireccion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtbTelefono);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtbNombres);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbApellidos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtbCedulaRuc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 168);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(778, 164);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL CLIENTE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(643, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtbCorreo
            // 
            this.txtbCorreo.Location = new System.Drawing.Point(379, 84);
            this.txtbCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtbCorreo.Name = "txtbCorreo";
            this.txtbCorreo.ReadOnly = true;
            this.txtbCorreo.Size = new System.Drawing.Size(172, 20);
            this.txtbCorreo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Correo";
            // 
            // txtbDireccion
            // 
            this.txtbDireccion.Location = new System.Drawing.Point(379, 53);
            this.txtbDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtbDireccion.Name = "txtbDireccion";
            this.txtbDireccion.ReadOnly = true;
            this.txtbDireccion.Size = new System.Drawing.Size(172, 20);
            this.txtbDireccion.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Direccion";
            // 
            // txtbTelefono
            // 
            this.txtbTelefono.Location = new System.Drawing.Point(379, 23);
            this.txtbTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtbTelefono.Name = "txtbTelefono";
            this.txtbTelefono.ReadOnly = true;
            this.txtbTelefono.Size = new System.Drawing.Size(172, 20);
            this.txtbTelefono.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Telefono";
            // 
            // txtbNombres
            // 
            this.txtbNombres.Location = new System.Drawing.Point(122, 84);
            this.txtbNombres.Margin = new System.Windows.Forms.Padding(2);
            this.txtbNombres.Name = "txtbNombres";
            this.txtbNombres.ReadOnly = true;
            this.txtbNombres.Size = new System.Drawing.Size(117, 20);
            this.txtbNombres.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombres";
            // 
            // txtbApellidos
            // 
            this.txtbApellidos.Location = new System.Drawing.Point(122, 53);
            this.txtbApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtbApellidos.Name = "txtbApellidos";
            this.txtbApellidos.ReadOnly = true;
            this.txtbApellidos.Size = new System.Drawing.Size(117, 20);
            this.txtbApellidos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellidos";
            // 
            // txtbCedulaRuc
            // 
            this.txtbCedulaRuc.Location = new System.Drawing.Point(122, 18);
            this.txtbCedulaRuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtbCedulaRuc.Name = "txtbCedulaRuc";
            this.txtbCedulaRuc.Size = new System.Drawing.Size(120, 20);
            this.txtbCedulaRuc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cedula/Ruc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Venta de Productos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Location = new System.Drawing.Point(11, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 10);
            this.panel1.TabIndex = 14;
            // 
            // preferenciasToolStripMenuItem
            // 
            this.preferenciasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.vistaPreviaToolStripMenuItem});
            this.preferenciasToolStripMenuItem.Name = "preferenciasToolStripMenuItem";
            this.preferenciasToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.preferenciasToolStripMenuItem.Text = "Preferencias";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // vistaPreviaToolStripMenuItem
            // 
            this.vistaPreviaToolStripMenuItem.Name = "vistaPreviaToolStripMenuItem";
            this.vistaPreviaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.vistaPreviaToolStripMenuItem.Text = "Vista Previa";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.verToolStripMenuItem.Text = "Salir";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.preferenciasToolStripMenuItem,
            this.verToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 686);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelNumeroComprobante;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.TextBox txtb_Total;
        private System.Windows.Forms.TextBox txtb_Cantidad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtb_IVA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtb_Precio;
        private System.Windows.Forms.TextBox txtb_Subtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtb_Presentacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtb_NombreGenerico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtb_NombreComercial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_Venta;
        private System.Windows.Forms.Button btn_Productos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtbCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbTelefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbNombres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbCedulaRuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem preferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vistaPreviaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}