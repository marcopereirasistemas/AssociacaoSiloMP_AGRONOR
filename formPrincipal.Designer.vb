<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPrincipal
    Inherits AssociacaoSiloMP_AGRONOR.FCadastroSemBotoes

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)



    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SILONUMERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SILODESCRICAO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BalancaDescricao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoMateriaPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MateriaPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnDesassociarTodos = New System.Windows.Forms.Button()
        Me.btnDesassociar = New System.Windows.Forms.Button()
        Me.btnAssociar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAtualizaTAGS = New System.Windows.Forms.Button()
        Me.btnAtualizar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMensagens.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensagens
        '
        Me.pnlMensagens.Location = New System.Drawing.Point(0, 756)
        Me.pnlMensagens.Margin = New System.Windows.Forms.Padding(3)
        Me.pnlMensagens.Size = New System.Drawing.Size(1603, 22)
        '
        'lblMensagem
        '
        Me.lblMensagem.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblMensagem.Size = New System.Drawing.Size(55362, 17)
        Me.lblMensagem.Text = ""
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.SILONUMERO, Me.SILODESCRICAO, Me.BalancaDescricao, Me.CodigoMateriaPrima, Me.MateriaPrima, Me.Lote})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(10, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowHeadersWidth = 40
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.Height = 40
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.Size = New System.Drawing.Size(1583, 628)
        Me.DataGridView1.TabIndex = 29
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 8
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 150
        '
        'SILONUMERO
        '
        Me.SILONUMERO.DataPropertyName = "SILONUMERO"
        Me.SILONUMERO.HeaderText = "SILONUMERO"
        Me.SILONUMERO.MinimumWidth = 8
        Me.SILONUMERO.Name = "SILONUMERO"
        Me.SILONUMERO.ReadOnly = True
        Me.SILONUMERO.Visible = False
        Me.SILONUMERO.Width = 150
        '
        'SILODESCRICAO
        '
        Me.SILODESCRICAO.DataPropertyName = "SILODESCRICAO"
        Me.SILODESCRICAO.HeaderText = "Silo"
        Me.SILODESCRICAO.MinimumWidth = 8
        Me.SILODESCRICAO.Name = "SILODESCRICAO"
        Me.SILODESCRICAO.ReadOnly = True
        Me.SILODESCRICAO.Width = 200
        '
        'BalancaDescricao
        '
        Me.BalancaDescricao.DataPropertyName = "BalancaDescricao"
        Me.BalancaDescricao.HeaderText = "Balança"
        Me.BalancaDescricao.MinimumWidth = 8
        Me.BalancaDescricao.Name = "BalancaDescricao"
        Me.BalancaDescricao.ReadOnly = True
        Me.BalancaDescricao.Width = 350
        '
        'CodigoMateriaPrima
        '
        Me.CodigoMateriaPrima.DataPropertyName = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.HeaderText = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.MinimumWidth = 8
        Me.CodigoMateriaPrima.Name = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.ReadOnly = True
        Me.CodigoMateriaPrima.Visible = False
        Me.CodigoMateriaPrima.Width = 150
        '
        'MateriaPrima
        '
        Me.MateriaPrima.DataPropertyName = "MateriaPrima"
        Me.MateriaPrima.HeaderText = "MateriaPrima"
        Me.MateriaPrima.MinimumWidth = 8
        Me.MateriaPrima.Name = "MateriaPrima"
        Me.MateriaPrima.ReadOnly = True
        Me.MateriaPrima.Width = 700
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "Lote"
        Me.Lote.HeaderText = "Lote"
        Me.Lote.MinimumWidth = 8
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 275
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Image = Global.AssociacaoSiloMP_AGRONOR.My.Resources.Resource1.Sair1
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFechar.Location = New System.Drawing.Point(1473, 692)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(118, 54)
        Me.btnFechar.TabIndex = 28
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'btnDesassociarTodos
        '
        Me.btnDesassociarTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesassociarTodos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnDesassociarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesassociarTodos.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesassociarTodos.Image = Global.AssociacaoSiloMP_AGRONOR.My.Resources.Resource1.cancel
        Me.btnDesassociarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesassociarTodos.Location = New System.Drawing.Point(918, 317)
        Me.btnDesassociarTodos.Margin = New System.Windows.Forms.Padding(10)
        Me.btnDesassociarTodos.Name = "btnDesassociarTodos"
        Me.btnDesassociarTodos.Padding = New System.Windows.Forms.Padding(2)
        Me.btnDesassociarTodos.Size = New System.Drawing.Size(350, 54)
        Me.btnDesassociarTodos.TabIndex = 27
        Me.btnDesassociarTodos.Text = "Desassociar todos os silos"
        Me.btnDesassociarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesassociarTodos.UseVisualStyleBackColor = True
        Me.btnDesassociarTodos.Visible = False
        '
        'btnDesassociar
        '
        Me.btnDesassociar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesassociar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnDesassociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesassociar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesassociar.Image = Global.AssociacaoSiloMP_AGRONOR.My.Resources.Resource1.cancel
        Me.btnDesassociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesassociar.Location = New System.Drawing.Point(171, 692)
        Me.btnDesassociar.Margin = New System.Windows.Forms.Padding(10)
        Me.btnDesassociar.Name = "btnDesassociar"
        Me.btnDesassociar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnDesassociar.Size = New System.Drawing.Size(185, 54)
        Me.btnDesassociar.TabIndex = 26
        Me.btnDesassociar.Text = "Desassociar"
        Me.btnDesassociar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesassociar.UseVisualStyleBackColor = True
        '
        'btnAssociar
        '
        Me.btnAssociar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAssociar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnAssociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssociar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssociar.Image = Global.AssociacaoSiloMP_AGRONOR.My.Resources.Resource1.apply
        Me.btnAssociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssociar.Location = New System.Drawing.Point(10, 692)
        Me.btnAssociar.Margin = New System.Windows.Forms.Padding(10)
        Me.btnAssociar.Name = "btnAssociar"
        Me.btnAssociar.Size = New System.Drawing.Size(149, 54)
        Me.btnAssociar.TabIndex = 25
        Me.btnAssociar.Text = "Associar"
        Me.btnAssociar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAssociar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Yellow
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(507, 692)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(924, 46)
        Me.Panel2.TabIndex = 30
        Me.Panel2.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(5, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(909, 31)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Atualizando as descrições das matérias-primas associadas aos silos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAtualizaTAGS
        '
        Me.btnAtualizaTAGS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAtualizaTAGS.Location = New System.Drawing.Point(14, 648)
        Me.btnAtualizaTAGS.Name = "btnAtualizaTAGS"
        Me.btnAtualizaTAGS.Size = New System.Drawing.Size(86, 31)
        Me.btnAtualizaTAGS.TabIndex = 33
        Me.btnAtualizaTAGS.Text = "Button1"
        Me.btnAtualizaTAGS.UseVisualStyleBackColor = True
        Me.btnAtualizaTAGS.Visible = False
        '
        'btnAtualizar
        '
        Me.btnAtualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAtualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtualizar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtualizar.Image = Global.AssociacaoSiloMP_AGRONOR.My.Resources.Resource1.atualiar_32x32
        Me.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtualizar.Location = New System.Drawing.Point(1898, 692)
        Me.btnAtualizar.Margin = New System.Windows.Forms.Padding(10)
        Me.btnAtualizar.Name = "btnAtualizar"
        Me.btnAtualizar.Size = New System.Drawing.Size(149, 54)
        Me.btnAtualizar.TabIndex = 34
        Me.btnAtualizar.Text = "Atualizar"
        Me.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtualizar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CheckBox4)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Location = New System.Drawing.Point(10, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1583, 36)
        Me.Panel1.TabIndex = 35
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(195, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(128, 27)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "DOSAGEM"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(329, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(131, 27)
        Me.CheckBox2.TabIndex = 0
        Me.CheckBox2.Text = "RECEPÇÃO"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(466, 4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(103, 27)
        Me.CheckBox3.TabIndex = 0
        Me.CheckBox3.Text = "FARELO"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(575, 4)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(141, 27)
        Me.CheckBox4.TabIndex = 0
        Me.CheckBox4.Text = "EXPEDIÇÃO"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Silos das Áreas:"
        '
        'formPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1603, 778)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.btnAtualizaTAGS)
        Me.Controls.Add(Me.btnDesassociarTodos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnDesassociar)
        Me.Controls.Add(Me.btnAssociar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Name = "formPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Associação de Silo com Matéria-Prima"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnAssociar, 0)
        Me.Controls.SetChildIndex(Me.btnDesassociar, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.btnDesassociarTodos, 0)
        Me.Controls.SetChildIndex(Me.pnlMensagens, 0)
        Me.Controls.SetChildIndex(Me.btnAtualizaTAGS, 0)
        Me.Controls.SetChildIndex(Me.btnAtualizar, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlMensagens.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents btnDesassociarTodos As System.Windows.Forms.Button
    Friend WithEvents btnDesassociar As System.Windows.Forms.Button
    Friend WithEvents btnAssociar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Public Sub New()

        InitializeComponent()

    End Sub
    Friend WithEvents btnAtualizaTAGS As Button
    Friend WithEvents btnAtualizar As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents SILONUMERO As DataGridViewTextBoxColumn
    Friend WithEvents SILODESCRICAO As DataGridViewTextBoxColumn
    Friend WithEvents BalancaDescricao As DataGridViewTextBoxColumn
    Friend WithEvents CodigoMateriaPrima As DataGridViewTextBoxColumn
    Friend WithEvents MateriaPrima As DataGridViewTextBoxColumn
    Friend WithEvents Lote As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
