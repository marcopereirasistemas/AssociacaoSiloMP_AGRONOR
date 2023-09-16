<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLocalizar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formLocalizar))
        Me.lblInformacao = New System.Windows.Forms.Label()
        Me.txtInformacao = New System.Windows.Forms.TextBox()
        Me.btnLocalizar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblInformacao
        '
        Me.lblInformacao.AutoSize = True
        Me.lblInformacao.Location = New System.Drawing.Point(14, 20)
        Me.lblInformacao.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblInformacao.Name = "lblInformacao"
        Me.lblInformacao.Size = New System.Drawing.Size(101, 13)
        Me.lblInformacao.TabIndex = 0
        Me.lblInformacao.Text = "Digite a informação:"
        '
        'txtInformacao
        '
        Me.txtInformacao.Location = New System.Drawing.Point(118, 20)
        Me.txtInformacao.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInformacao.Name = "txtInformacao"
        Me.txtInformacao.Size = New System.Drawing.Size(368, 20)
        Me.txtInformacao.TabIndex = 1
        '
        'btnLocalizar
        '
        Me.btnLocalizar.Image = CType(resources.GetObject("btnLocalizar.Image"), System.Drawing.Image)
        Me.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLocalizar.Location = New System.Drawing.Point(495, 10)
        Me.btnLocalizar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLocalizar.Name = "btnLocalizar"
        Me.btnLocalizar.Size = New System.Drawing.Size(77, 37)
        Me.btnLocalizar.TabIndex = 2
        Me.btnLocalizar.Text = "Localizar"
        Me.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLocalizar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(488, 291)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 31)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(401, 291)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(83, 31)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'formLocalizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 333)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnLocalizar)
        Me.Controls.Add(Me.txtInformacao)
        Me.Controls.Add(Me.lblInformacao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formLocalizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Localizar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents lblInformacao As System.Windows.Forms.Label
    Protected WithEvents txtInformacao As System.Windows.Forms.TextBox
    Protected WithEvents btnLocalizar As System.Windows.Forms.Button
    Protected WithEvents btnCancelar As System.Windows.Forms.Button
    Protected WithEvents btnOK As System.Windows.Forms.Button
End Class
