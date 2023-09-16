
Imports System.Linq
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class formAssociacaoSelecaoMP

#Region "Declarações Nivel de Formulario"

    Property CodigoMP As String
    Property DescricaoMP As String
    Property IdSiloSelecionado As Integer

#End Region

#Region "Eventos de Componentes"

    Private Sub btnFechar_Click(sender As System.Object, e As System.EventArgs) Handles btnFechar.Click, btnConfirma.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        MateriaPrimaSelecionada = False
        Close()

    End Sub

    Private Sub formAssociacaoSelecaoMP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Me.BackColor = System.Drawing.Color.DarkGray
        'If My.Settings.LINHA_NUMERO.ToString() = 1 Then
        '    Me.BackColor = System.Drawing.Color.Gold
        'End If

        CarregaGrid()

        Me.Height = formPrincipal.Height - 20
        Me.Top = formPrincipal.Top + 10

    End Sub

    Private Sub btnPesquisar_Click(sender As System.Object, e As System.EventArgs) Handles btnPesquisar.Click

        CarregaGrid()

    End Sub

    Private Sub txtPesquisa_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPesquisa.TextChanged

        btnPesquisar_Click(sender, e)

    End Sub

    Private Sub grdRegistros_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRegistros.CellClick

        If grdRegistros.Rows.Count >= 1 Then

            CodigoMP = grdRegistros.CurrentRow.Cells(0).Value.ToString
            DescricaoMP = grdRegistros.CurrentRow.Cells(1).Value.ToString

        End If

    End Sub

#End Region


#Region "Funções Diversas"

    Private Sub CarregaGrid()
        Dim strPartePesquisar As String = ""
        Dim SqlCampos As String = ""
        Dim SqlFiltro As String = ""
        Dim dtCadastro As New DataTable
        Dim command As New SqlCommand(SqlCampos & SqlFiltro, BancoDados.ConexaoAtiva)

        SqlCampos = ""
        SqlCampos += "SELECT "
        SqlCampos += "  CodigoMateriaPrima, "
        SqlCampos += "  DEscricao as DescricaoMateriaPrima, Lote"
        SqlCampos += "  FROM CadastroMateriaPrima "
        SqlCampos += " WHERE CodigoMateriaPrima LIKE '%" & txtPesquisa.Text.Trim & "%'"
        SqlCampos += " OR DEscricao LIKE '%" & txtPesquisa.Text.Trim & "%'"
        SqlCampos += " OR LOTE LIKE '%" & txtPesquisa.Text.Trim & "%'"
        SqlCampos += " ORDER BY Descricao "

        command.CommandText = SqlCampos
        dtCadastro.Load(command.ExecuteReader)
        command.Dispose()

        grdRegistros.DataSource = dtCadastro
        grdRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

#End Region


    Private Sub grdRegistros_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grdRegistros.DoubleClick
        MateriaPrimaSelecionada = False
        If CodigoMP <> "" And DescricaoMP <> "" Then
            MateriaPrimaSelecionada = True
            btnFechar_Click(sender, e)
        End If

    End Sub
End Class
