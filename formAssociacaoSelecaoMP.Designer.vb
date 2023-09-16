<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAssociacaoSelecaoMP
    Inherits AssociacaoSiloMP.FCadastroSemBotoes

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtPesquisa = New System.Windows.Forms.TextBox()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.cmsPesquisa = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PorCódigoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorDescriçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDescricaoPesquisa = New System.Windows.Forms.Label()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.grdRegistros = New System.Windows.Forms.DataGridView()
        Me.CodigoMateriaPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescricaoMateriaPrima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlMensagens.SuspendLayout()
        Me.cmsPesquisa.SuspendLayout()
        CType(Me.grdRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMensagens
        '
        Me.pnlMensagens.Location = New System.Drawing.Point(0, 464)
        Me.pnlMensagens.Size = New System.Drawing.Size(1433, 22)
        '
        'lblMensagem
        '
        Me.lblMensagem.Size = New System.Drawing.Size(5777, 17)
        Me.lblMensagem.Text = ""
        '
        'txtPesquisa
        '
        Me.txtPesquisa.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesquisa.Location = New System.Drawing.Point(399, 12)
        Me.txtPesquisa.MaxLength = 50
        Me.txtPesquisa.Name = "txtPesquisa"
        Me.txtPesquisa.Size = New System.Drawing.Size(844, 37)
        Me.txtPesquisa.TabIndex = 19
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPesquisar.ContextMenuStrip = Me.cmsPesquisa
        Me.btnPesquisar.FlatAppearance.BorderSize = 0
        Me.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPesquisar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPesquisar.Location = New System.Drawing.Point(1273, 6)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(148, 40)
        Me.btnPesquisar.TabIndex = 20
        Me.btnPesquisar.Text = "Pesquisar"
        Me.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPesquisar.UseVisualStyleBackColor = True
        Me.btnPesquisar.Visible = False
        '
        'cmsPesquisa
        '
        Me.cmsPesquisa.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorCódigoToolStripMenuItem, Me.PorDescriçãoToolStripMenuItem})
        Me.cmsPesquisa.Name = "cmsPesquisa"
        Me.cmsPesquisa.Size = New System.Drawing.Size(147, 48)
        '
        'PorCódigoToolStripMenuItem
        '
        Me.PorCódigoToolStripMenuItem.Name = "PorCódigoToolStripMenuItem"
        Me.PorCódigoToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PorCódigoToolStripMenuItem.Text = "Por Código"
        '
        'PorDescriçãoToolStripMenuItem
        '
        Me.PorDescriçãoToolStripMenuItem.Name = "PorDescriçãoToolStripMenuItem"
        Me.PorDescriçãoToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.PorDescriçãoToolStripMenuItem.Text = "Por Descrição"
        '
        'lblDescricaoPesquisa
        '
        Me.lblDescricaoPesquisa.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescricaoPesquisa.Location = New System.Drawing.Point(190, 10)
        Me.lblDescricaoPesquisa.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDescricaoPesquisa.Name = "lblDescricaoPesquisa"
        Me.lblDescricaoPesquisa.Size = New System.Drawing.Size(206, 37)
        Me.lblDescricaoPesquisa.TabIndex = 24
        Me.lblDescricaoPesquisa.Text = "Matéria-Prima:"
        Me.lblDescricaoPesquisa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConfirma
        '
        Me.btnConfirma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirma.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.Image = Global.AssociacaoSiloMP.My.Resources.Resource1.apply
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(639, 406)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(154, 53)
        Me.btnConfirma.TabIndex = 23
        Me.btnConfirma.Text = "Confirma"
        Me.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirma.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFechar.Image = Global.AssociacaoSiloMP.My.Resources.Resource1.FINALIZAR1
        Me.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFechar.Location = New System.Drawing.Point(1311, 406)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(116, 53)
        Me.btnFechar.TabIndex = 22
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'grdRegistros
        '
        Me.grdRegistros.AllowUserToAddRows = False
        Me.grdRegistros.AllowUserToDeleteRows = False
        Me.grdRegistros.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRegistros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdRegistros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdRegistros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdRegistros.ColumnHeadersHeight = 43
        Me.grdRegistros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoMateriaPrima, Me.DescricaoMateriaPrima, Me.Lote})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdRegistros.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdRegistros.Location = New System.Drawing.Point(5, 56)
        Me.grdRegistros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdRegistros.Name = "grdRegistros"
        Me.grdRegistros.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdRegistros.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRegistros.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.grdRegistros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRegistros.RowTemplate.Height = 43
        Me.grdRegistros.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdRegistros.Size = New System.Drawing.Size(1422, 343)
        Me.grdRegistros.TabIndex = 21
        '
        'CodigoMateriaPrima
        '
        Me.CodigoMateriaPrima.DataPropertyName = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.HeaderText = "Código"
        Me.CodigoMateriaPrima.Name = "CodigoMateriaPrima"
        Me.CodigoMateriaPrima.ReadOnly = True
        Me.CodigoMateriaPrima.Width = 180
        '
        'DescricaoMateriaPrima
        '
        Me.DescricaoMateriaPrima.DataPropertyName = "DescricaoMateriaPrima"
        Me.DescricaoMateriaPrima.HeaderText = "Matéria-Prima"
        Me.DescricaoMateriaPrima.Name = "DescricaoMateriaPrima"
        Me.DescricaoMateriaPrima.ReadOnly = True
        Me.DescricaoMateriaPrima.Width = 850
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "LOTE"
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 300
        '
        'formAssociacaoSelecaoMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1433, 486)
        Me.Controls.Add(Me.txtPesquisa)
        Me.Controls.Add(Me.btnPesquisar)
        Me.Controls.Add(Me.lblDescricaoPesquisa)
        Me.Controls.Add(Me.btnConfirma)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.grdRegistros)
        Me.Name = "formAssociacaoSelecaoMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleção de Matéria-Prima"
        Me.Controls.SetChildIndex(Me.pnlMensagens, 0)
        Me.Controls.SetChildIndex(Me.grdRegistros, 0)
        Me.Controls.SetChildIndex(Me.btnFechar, 0)
        Me.Controls.SetChildIndex(Me.btnConfirma, 0)
        Me.Controls.SetChildIndex(Me.lblDescricaoPesquisa, 0)
        Me.Controls.SetChildIndex(Me.btnPesquisar, 0)
        Me.Controls.SetChildIndex(Me.txtPesquisa, 0)
        Me.pnlMensagens.ResumeLayout(False)
        Me.cmsPesquisa.ResumeLayout(False)
        CType(Me.grdRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents btnPesquisar As System.Windows.Forms.Button
    Friend WithEvents lblDescricaoPesquisa As System.Windows.Forms.Label
    Friend WithEvents btnConfirma As System.Windows.Forms.Button
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents grdRegistros As System.Windows.Forms.DataGridView
    Friend WithEvents cmsPesquisa As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PorCódigoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorDescriçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodigoMateriaPrima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescricaoMateriaPrima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
