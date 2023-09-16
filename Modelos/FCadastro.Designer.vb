<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCadastro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCadastro))
        Me.pnlMensagens = New System.Windows.Forms.Panel()
        Me.lblMensagem = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnClonar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnLocalizar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.pnlMensagens.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensagens
        '
        Me.pnlMensagens.BackColor = System.Drawing.SystemColors.Info
        Me.pnlMensagens.Controls.Add(Me.lblMensagem)
        Me.pnlMensagens.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMensagens.Location = New System.Drawing.Point(0, 374)
        Me.pnlMensagens.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMensagens.Name = "pnlMensagens"
        Me.pnlMensagens.Size = New System.Drawing.Size(918, 27)
        Me.pnlMensagens.TabIndex = 1
        '
        'lblMensagem
        '
        Me.lblMensagem.AutoSize = True
        Me.lblMensagem.Location = New System.Drawing.Point(3, 7)
        Me.lblMensagem.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMensagem.Name = "lblMensagem"
        Me.lblMensagem.Size = New System.Drawing.Size(91, 16)
        Me.lblMensagem.TabIndex = 0
        Me.lblMensagem.Text = "lblMensagem"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnSair)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.btnExcluir)
        Me.Panel1.Controls.Add(Me.btnClonar)
        Me.Panel1.Controls.Add(Me.btnGravar)
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.btnLocalizar)
        Me.Panel1.Controls.Add(Me.btnAdicionar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(918, 65)
        Me.Panel1.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(405, -1)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 60)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSair.Location = New System.Drawing.Point(559, -1)
        Me.btnSair.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(81, 60)
        Me.btnSair.TabIndex = 6
        Me.btnSair.Text = "Fechar"
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(815, -1)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(81, 60)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = Global.AssociacaoSiloMP.My.Resources.Resource1.Excluir
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcluir.Location = New System.Drawing.Point(324, -1)
        Me.btnExcluir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(81, 60)
        Me.btnExcluir.TabIndex = 4
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'btnClonar
        '
        Me.btnClonar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClonar.Image = Global.AssociacaoSiloMP.My.Resources.Resource1.Clipboard_Copy
        Me.btnClonar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClonar.Location = New System.Drawing.Point(647, -1)
        Me.btnClonar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClonar.Name = "btnClonar"
        Me.btnClonar.Size = New System.Drawing.Size(81, 60)
        Me.btnClonar.TabIndex = 3
        Me.btnClonar.Text = "Clonar"
        Me.btnClonar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClonar.UseVisualStyleBackColor = True
        Me.btnClonar.Visible = False
        '
        'btnGravar
        '
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGravar.Location = New System.Drawing.Point(243, 0)
        Me.btnGravar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(81, 60)
        Me.btnGravar.TabIndex = 3
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEditar.Location = New System.Drawing.Point(162, 0)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(81, 60)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnLocalizar
        '
        Me.btnLocalizar.Image = CType(resources.GetObject("btnLocalizar.Image"), System.Drawing.Image)
        Me.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLocalizar.Location = New System.Drawing.Point(81, 0)
        Me.btnLocalizar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLocalizar.Name = "btnLocalizar"
        Me.btnLocalizar.Size = New System.Drawing.Size(81, 60)
        Me.btnLocalizar.TabIndex = 1
        Me.btnLocalizar.Text = "Localizar"
        Me.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLocalizar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Image = CType(resources.GetObject("btnAdicionar.Image"), System.Drawing.Image)
        Me.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdicionar.Location = New System.Drawing.Point(0, 0)
        Me.btnAdicionar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(81, 60)
        Me.btnAdicionar.TabIndex = 0
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'formCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 401)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMensagens)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cadastro"
        Me.pnlMensagens.ResumeLayout(False)
        Me.pnlMensagens.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents btnAdicionar As System.Windows.Forms.Button
    Protected WithEvents btnEditar As System.Windows.Forms.Button
    Protected WithEvents btnLocalizar As System.Windows.Forms.Button
    Protected WithEvents btnImprimir As System.Windows.Forms.Button
    Protected WithEvents btnExcluir As System.Windows.Forms.Button
    Protected WithEvents btnGravar As System.Windows.Forms.Button
    Protected WithEvents btnSair As System.Windows.Forms.Button
    Protected WithEvents lblMensagem As System.Windows.Forms.Label
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents pnlMensagens As System.Windows.Forms.Panel
    Protected WithEvents btnCancelar As System.Windows.Forms.Button
    Protected WithEvents btnClonar As System.Windows.Forms.Button
End Class
