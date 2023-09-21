<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPrincipal
    Inherits AssociacaoSiloMP_JOFEGE.FCadastroSemBotoes

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formPrincipal))
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
        Me.pnlMensagens.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensagens
        '
        Me.pnlMensagens.Location = New System.Drawing.Point(0, 516)
        Me.pnlMensagens.Size = New System.Drawing.Size(1287, 22)
        '
        'lblMensagem
        '
        Me.lblMensagem.Size = New System.Drawing.Size(32144, 17)
        Me.lblMensagem.Text = ""
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 50
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.SILONUMERO, Me.SILODESCRICAO, Me.BalancaDescricao, Me.CodigoMateriaPrima, Me.MateriaPrima, Me.Lote})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(13, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.Size = New System.Drawing.Size(1263, 437)
        Me.DataGridView1.TabIndex = 29
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'SILONUMERO
        '
        Me.SILONUMERO.DataPropertyName = "SILONUMERO"
        Me.SILONUMERO.HeaderText = "SILONUMERO"
        Me.SILONUMERO.Name = "SILONUMERO"
        Me.SILONUMERO.ReadOnly = True
        Me.SILONUMERO.Visible = False
        '
        'SILODESCRICAO
        '
        Me.SILODESCRICAO.DataPropertyName = "SILODESCRICAO"
        Me.SILODESCRICAO.HeaderText = "Silo"
        Me.SILODESCRICAO.Name = "SILODESCRICAO"
        Me.SILODESCRICAO.ReadOnly = True
        Me.SILODESCRICAO.Width = 200
        '
        'BalancaDescricao
        '
        Me.BalancaDescricao.DataPropertyName = "BalancaDescricao"
        Me.BalancaDescricao.HeaderText = "Balança"
        Me.BalancaDescricao.Name = "BalancaDescricao"
        Me.BalancaDescricao.ReadOnly = True
        Me.BalancaDescricao.Width = 350
        '
        'CodigoMateriaPrima
        '
        Me.CodigoMateriaPrima.DataPropertyName = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.HeaderText = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.Name = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.ReadOnly = True
        Me.CodigoMateriaPrima.Visible = False
        '
        'MateriaPrima
        '
        Me.MateriaPrima.DataPropertyName = "MateriaPrima"
        Me.MateriaPrima.HeaderText = "MateriaPrima"
        Me.MateriaPrima.Name = "MateriaPrima"
        Me.MateriaPrima.ReadOnly = True
        Me.MateriaPrima.Width = 650
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "Lote"
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 300
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Image = Global.AssociacaoSiloMP_JOFEGE.My.Resources.Resource1.Sair1
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFechar.Location = New System.Drawing.Point(1156, 456)
        Me.btnFechar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(119, 54)
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
        Me.btnDesassociarTodos.Image = Global.AssociacaoSiloMP_JOFEGE.My.Resources.Resource1.cancel
        Me.btnDesassociarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesassociarTodos.Location = New System.Drawing.Point(387, 456)
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
        Me.btnDesassociar.Image = Global.AssociacaoSiloMP_JOFEGE.My.Resources.Resource1.cancel
        Me.btnDesassociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesassociar.Location = New System.Drawing.Point(182, 456)
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
        Me.btnAssociar.Image = Global.AssociacaoSiloMP_JOFEGE.My.Resources.Resource1.apply
        Me.btnAssociar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssociar.Location = New System.Drawing.Point(13, 456)
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
        Me.Panel2.Location = New System.Drawing.Point(22, 377)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(788, 46)
        Me.Panel2.TabIndex = 30
        Me.Panel2.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(5, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(773, 31)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Atualizando o supervisório com as matérias-primas associadas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'formPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1287, 538)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.btnDesassociarTodos)
        Me.Controls.Add(Me.btnDesassociar)
        Me.Controls.Add(Me.btnAssociar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Associação de Silo com Matéria-Prima"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlMensagens, 0)
        Me.Controls.SetChildIndex(Me.btnAssociar, 0)
        Me.Controls.SetChildIndex(Me.btnDesassociar, 0)
        Me.Controls.SetChildIndex(Me.btnDesassociarTodos, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.pnlMensagens.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
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

    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents SILONUMERO As DataGridViewTextBoxColumn
    Friend WithEvents SILODESCRICAO As DataGridViewTextBoxColumn
    Friend WithEvents BalancaDescricao As DataGridViewTextBoxColumn
    Friend WithEvents CodigoMateriaPrima As DataGridViewTextBoxColumn
    Friend WithEvents MateriaPrima As DataGridViewTextBoxColumn
    Friend WithEvents Lote As DataGridViewTextBoxColumn
End Class
