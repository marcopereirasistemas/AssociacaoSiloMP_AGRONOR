﻿
Public Class formCadastro

    Protected Rotinas As ClasseRotinasDiversas
    Protected BancoDados As ClasseBancoDados

    Protected Sub Mensagem(ByVal strTexto As String)
        lblMensagem.Text = strTexto
    End Sub


#Region "Funções diversas"

#End Region

#Region "Eventos do formulario"

#End Region


    Private Sub btnSair_Click(sender As System.Object, e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub formCadastro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            e.KeyChar = Microsoft.VisualBasic.Chr(0)
            System.Windows.Forms.SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub formCadastro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim stringConexao As String

        Rotinas = New ClasseRotinasDiversas

        stringConexao = My.Settings.JOFEGE_ARGAMASSA_ConnectionString

        BancoDados = New ClasseBancoDados(stringConexao)

        BancoDados.Abrir()
        Rotinas.LimparCampos(Me)
        Mensagem("")

    End Sub

    Private Sub formCadastro_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'If BancoDados.ConexaoAtiva Then
        'BancoDados.Fechar()
        BancoDados = Nothing
        Rotinas = Nothing
        'End If
    End Sub

    Private Sub btnAdicionar_Click(sender As System.Object, e As System.EventArgs) Handles btnAdicionar.Click
        BancoDados.Operacao = "ADICIONAR"
        Rotinas.LimparCampos(Me)
        Mensagem("Adição de registro...")
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        BancoDados.Operacao = "EDITAR"
        Mensagem("Edição de registro...")
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        BancoDados.Operacao = ""
        Mensagem("")

    End Sub

    Private Sub btnGravar_Click(sender As System.Object, e As System.EventArgs) Handles btnGravar.Click, btnClonar.Click
        Mensagem("")
    End Sub
End Class