<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCadastroSemBotoes
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
        Me.pnlMensagens = New System.Windows.Forms.Panel()
        Me.lblMensagem = New System.Windows.Forms.Label()
        Me.pnlMensagens.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensagens
        '
        Me.pnlMensagens.BackColor = System.Drawing.SystemColors.Info
        Me.pnlMensagens.Controls.Add(Me.lblMensagem)
        Me.pnlMensagens.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMensagens.Location = New System.Drawing.Point(0, 240)
        Me.pnlMensagens.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMensagens.Name = "pnlMensagens"
        Me.pnlMensagens.Size = New System.Drawing.Size(468, 22)
        Me.pnlMensagens.TabIndex = 2
        '
        'lblMensagem
        '
        Me.lblMensagem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMensagem.Location = New System.Drawing.Point(3, 4)
        Me.lblMensagem.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMensagem.Name = "lblMensagem"
        Me.lblMensagem.Size = New System.Drawing.Size(463, 17)
        Me.lblMensagem.TabIndex = 0
        Me.lblMensagem.Text = "lblMensagem"
        '
        'FCadastroSemBotoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 262)
        Me.Controls.Add(Me.pnlMensagens)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCadastroSemBotoes"
        Me.Text = "FCadastroSemBotoes"
        Me.pnlMensagens.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents pnlMensagens As System.Windows.Forms.Panel
    Protected WithEvents lblMensagem As System.Windows.Forms.Label

End Class
