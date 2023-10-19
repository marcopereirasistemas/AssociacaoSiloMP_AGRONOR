﻿
Imports System.IO
Imports System.Net
Imports System
Imports Microsoft.VisualBasic
Imports System.String
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports FixDataSystems

Public Class formPrincipal

#Region "Declarações nivel de formulário"

    Enum TipoTagParaLimpeza
        ADESC_Tag = 1
        ARRAY_Tag = 2
        FIXO_Tag = 3
    End Enum

    Structure TagEscreverRetorno
        Public ErroNumber As Double
        Public Mensagem As String
    End Structure

    Dim FdsTemp As New FixDataSystem

    Dim FIX As New iFIX
    Dim AssociacaoSiloID As Integer
    Dim AssiciacaoSiloDescricao As String
    Dim AssociacaoCodigoMP As String
    Dim AssociacaoMateriaPrimaDescricao As String
    Dim AssociacaoTipo As Integer = 0
    Dim formTrocarSiloNova As Object
    Dim RotinasDiversas As New ClasseRotinasDiversas
    Dim teclaCtrlPressionada As Boolean
    Dim Versao As String = " - Versão 1.0.5 - 18/10/2023"
    Dim horaInicioEnvio As String
    Dim horaFinalEnvio As String
    Dim horaInicial As DateTime
    Dim horaFinal As DateTime
#End Region

#Region "Eventos de componentes"

    Private Sub btnFechar_Click(sender As System.Object, e As System.EventArgs) Handles btnFechar.Click
        Dim TextoMensagem As String = "ATENÇÃO:" & vbCrLf & vbCrLf &
                                        "Atualizar o supervisório com as descrições" & vbCrLf &
                                        "das matérias-primas associadas aos Silos ???"
        Dim ini As String
        Dim fin As String
        Dim temp As String

        If MsgBox(TextoMensagem, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmação") = vbYes Then

            AtualizaAssociacoesSupervisorio()

            If Rotinas.ArquivoExistePastaAplicacao("TESTE.TXT") Then

                ini = $"Inicio: {horaInicial}"
                fin = $"Fim: {horaFinal}"
                temp = $"{DateDiff(DateInterval.Second, horaInicial, horaFinal)} segundos"

                MsgBox($"Descricões atualizadas: " & vbCrLf & vbCrLf &
                       ini & vbCrLf &
                       fin & vbCrLf & vbCrLf &
                       temp, MessageBoxButtons.OK + MessageBoxIcon.Information, "Aviso")

            End If

        End If

        Close()

    End Sub

    Private Sub formAssociacaoSiloMP_Nova_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Text = " Associção Silo X Matéria-Prima" & Versao

        CarregaAssociacoes()

        Rotinas.EscreverEmLog("Associação Iniciada.", ClasseRotinasDiversas.Tipo.Geral)

        Me.Width = 1598
        Me.Height = 892

        StartPosition = FormStartPosition.CenterParent

        'WindowState = FormWindowState.Maximized

    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If DataGridView1.Rows.Count > 1 Then

            AssociacaoSiloID = DataGridView1.CurrentRow.Cells(0).Value.ToString
            AssiciacaoSiloDescricao = DataGridView1.CurrentRow.Cells(2).Value.ToString

            AssociacaoCodigoMP = DataGridView1.CurrentRow.Cells(4).Value.ToString
            AssociacaoMateriaPrimaDescricao = DataGridView1.CurrentRow.Cells(5).Value.ToString

        End If

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView1.DoubleClick

        If DataGridView1.Rows.Count > 1 Then

            AssociacaoTipo = 0
            AssociacaoSiloID = DataGridView1.CurrentRow.Cells(0).Value.ToString
            AssociacaoCodigoMP = DataGridView1.CurrentRow.Cells(4).Value.ToString

            btnAssociar_Click(sender, e)

        End If

    End Sub

    Private Sub btnAssociar_Click(sender As System.Object, e As System.EventArgs) Handles btnAssociar.Click
        Dim CodigoMateriaPrimaSelecionada As String = ""

        If AssociacaoSiloID > 0 Then

            formAssociacaoSelecaoMP.ShowDialog()
            CodigoMateriaPrimaSelecionada = formAssociacaoSelecaoMP.CodigoMP
            formAssociacaoSelecaoMP.Dispose()

            If CodigoMateriaPrimaSelecionada <> "" Then

                '-- remove a associação anterior
                BancoDados.ComandoSQL = "DELETE FROM AssociacaoSiloMP WHERE SiloID = @SiloID"
                BancoDados.CriaComandoSQL()
                BancoDados.AdicionarParametro("@SiloID", AssociacaoSiloID)
                BancoDados.ExecutaSQL()

                BancoDados.ComandoSQL = "INSERT INTO AssociacaoSiloMP " &
                                            "  (siloid  , codigomateriaprima , linhaid ) " &
                                            " VALUES " &
                                            "  (@siloid , @CodigoMateriaPrima, @linhaId)"
                BancoDados.CriaComandoSQL()
                BancoDados.AdicionarParametro("@CodigoMateriaPrima", CodigoMateriaPrimaSelecionada)
                BancoDados.AdicionarParametro("@SiloID", AssociacaoSiloID)
                BancoDados.AdicionarParametro("@LinhaId", LinhaNumero)
                BancoDados.ExecutaSQL()

                Rotinas.EscreverEmLog("Materia-prima: " & CodigoMateriaPrimaSelecionada & " - Associada ao Silo: " & AssociacaoSiloID, ClasseRotinasDiversas.Tipo.Geral)

                CarregaAssociacoes()

            End If

        End If

        teclaCtrlPressionada = False

    End Sub

    Private Sub btnDesassociar_Click(sender As System.Object, e As System.EventArgs) Handles btnDesassociar.Click

        If AssociacaoCodigoMP <> "" And AssociacaoSiloID <> 0 Then

            If Not teclaCtrlPressionada Then

                If MsgBox("Desassociar a Matéria-Prima do Silo" & vbCrLf & vbCrLf & "Confirma ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Solicitação") = MsgBoxResult.No Then Exit Sub

                Rotinas.EscreverEmLog("Materia-prima: " & AssociacaoMateriaPrimaDescricao & " - Desassociada do Silo: " & AssiciacaoSiloDescricao, ClasseRotinasDiversas.Tipo.Geral)

                BancoDados.ComandoSQL = "DELETE FROM AssociacaoSiloMP WHERE CodigoMateriaPrima = @CodigoMateriaPrima AND SiloID = @SiloID"
                BancoDados.CriaComandoSQL()
                BancoDados.AdicionarParametro("@CodigoMateriaPrima", AssociacaoCodigoMP)
                BancoDados.AdicionarParametro("@SiloID", AssociacaoSiloID)
                BancoDados.ExecutaSQL()

                CarregaAssociacoes()

            Else
                Call Button1_Click(sender, e)
            End If
        End If

        teclaCtrlPressionada = False

    End Sub

    Private Sub btnDesassociar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles btnDesassociar.KeyDown

        If e.KeyCode = Keys.ControlKey Then
            teclaCtrlPressionada = True
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnDesassociarTodos.Click

        If MsgBox("Desassociar todos os silos ???" & vbCrLf & vbCrLf &
                  "Não será possivel reverter." & vbCrLf & vbCrLf &
                  "Confirma ?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  "Solicitação") = MsgBoxResult.No Then Exit Sub

        BancoDados.ComandoSQL = "DELETE FROM AssociacaoSiloMP"
        BancoDados.CriaComandoSQL()
        BancoDados.ExecutaSQL()

        CarregaAssociacoes()

    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyCode = Keys.Delete Then

            btnDesassociar_Click(sender, e)

        End If

    End Sub

#End Region

#Region "Funções Diversas"

    Private Sub AtualizaAssociacoesSupervisorio()
        Dim sqlTemp As String
        Dim TagEscrita As String
        Dim TagEscritaValor As String = ""
        Dim NumeroEscritas As Integer = 3
        Dim IntervaloEntreEscritas As Integer = 5
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader

        Dim tipoTagTemp As String
        Dim contadorTagItem As Integer = 1
        Dim nomeTagGrupo As String


        sqlTemp = "SELECT "
        sqlTemp += "    cb.Numero as BalancaNumero, "
        sqlTemp += "    cs.Numero as SiloNumero   , "
        sqlTemp += "    cmp.Descricao "
        sqlTemp += " FROM cadastrosilos cs "
        sqlTemp += "    LEFT JOIN CadastroBalancas cb		ON cb.id = cs.BalancaID "
        sqlTemp += "    LEFT JOIN AssociacaoSiloMP ass		ON ass.siloid = cs.ID  "
        sqlTemp += "    LEFT JOIN CadastroMateriaPrima cmp	ON ass.CodigoMateriaPrima = cmp.CodigoMateriaPrima "
        sqlTemp += " ORDER BY "
        sqlTemp += "    cb.Numero, "
        sqlTemp += "    cs.Numero "

        Try

            btnFechar.Enabled = False
            btnAssociar.Enabled = False
            btnDesassociar.Enabled = False

            cmdComandoSQL = New SqlCommand(sqlTemp, BancoDados.ConexaoAtiva)

            rdrRegistro = cmdComandoSQL.ExecuteReader()

            Panel2.Visible = True

            Me.Refresh()

            horaInicial = Now.ToString

            nomeTagGrupo = "PRODUCAO"

            FIX.SupervisorioCriarTagGrupo(nomeTagGrupo, FdsTemp)

            Debug.Print("------------------------------------------------------------------")
            Debug.Print($"{Now} - INICIO DO ENVIO DOS TAGS AO SUPERVISORIO.")
            Rotinas.EscreverEmLog("INICIO DO ENVIO DOS TAGS AO SUPERVISORIO.", ClasseRotinasDiversas.Tipo.Geral)
            Debug.Print("")

            While rdrRegistro.Read()

                '-- carrega o tag para escrever a descricao da materia-prima associada,
                '-- o tag é composto pelo numero da balanca e o o numero do silo
                Rotinas.EscreverEmLog("AtualizaAssociacoesSupervisorio(): DESC_MP_ASSOCIADA_B<BalancaID> " & rdrRegistro("BalancaNumero") & " _SILO_<NUMERO> " & rdrRegistro("SiloNumero"), ClasseRotinasDiversas.Tipo.Geral)
                Rotinas.EscreverEmLog("", ClasseRotinasDiversas.Tipo.Traco)

                tipoTagTemp = "DESC_MP_ASSOCIADA_B" & rdrRegistro("BalancaNumero").ToString() & "_SILO_" & rdrRegistro("SiloNumero").ToString()
                TagEscrita = BuscarTag(tipoTagTemp)

                If TagEscrita <> "" And TagEscrita <> "Não Definido" And TagEscrita <> "-1" Then

                    If Not IsDBNull(rdrRegistro("descricao")) Then

                        TagEscritaValor = rdrRegistro("descricao").ToString.Trim
                        Rotinas.EscreverEmLog("AtualizaAssociacoesSupervisorio(): Escrevendo no tag: " &
                                              My.Settings.SUPERVISORIO_NODE & "." & TagEscrita &
                                              " - Valor Escrita: " & rdrRegistro("descricao").Trim,
                                              ClasseRotinasDiversas.Tipo.Geral)

                    Else

                        TagEscritaValor = " "
                        Rotinas.EscreverEmLog("AtualizaAssociacoesSupervisorio(): Escrevendo no tag: " &
                                              My.Settings.SUPERVISORIO_NODE & "." & TagEscrita &
                                              " - Valor Escrita: <VAZIO> ",
                                              ClasseRotinasDiversas.Tipo.Geral)

                    End If

                    FIX.SupervisorioAdicionarItemTagGrupo(contadorTagItem, TagEscrita, nomeTagGrupo, TagEscritaValor, FdsTemp)

                    Debug.Print($"[{contadorTagItem.ToString("00")}] - {Now} - TIPO_TAG: {tipoTagTemp} - TAG: {TagEscrita & vbTab} - Valor: {TagEscritaValor}")
                    contadorTagItem += 1

                End If

            End While

            Debug.Print("------------------------------------------------------------------")
            Debug.Print(Now.ToString() & " - FIM DO ENVIO DOS tagsItens AO SUPERVISORIO.")
            Rotinas.EscreverEmLog(" - FIM DO ENVIO DOS tagsItens AO SUPERVISORIO.", ClasseRotinasDiversas.Tipo.Geral)
            Debug.Print("")
            Debug.Print("------------------------------------------------------------------")
            Debug.Print(Now.ToString() & " - EXECUTANDO O COMANDO WRITE INICIO")

            Rotinas.EscreverEmLog(" - EXECUTANDO O COMANDO WRITE INICIO.", ClasseRotinasDiversas.Tipo.Geral)

            FIX.SupervisorioEsreverTagItens(nomeTagGrupo, FdsTemp)

            Debug.Print(Now.ToString() & " - EXECUTANDO O COMANDO WRITE FIM")

            Rotinas.EscreverEmLog(" - EXECUTANDO O COMANDO WRITE FIM.", ClasseRotinasDiversas.Tipo.Geral)

            Debug.Print("------------------------------------------------------------------")

            horaFinal = Now.ToString

            rdrRegistro.Close()
            cmdComandoSQL.Dispose()

            Panel2.Visible = False

            If My.Settings.PASTA_DYNAMICS.ToString <> "" Then

                Process.Start(My.Settings.PASTA_DYNAMICS & "DBBSAVE.exe", "-D")

            End If

        Catch ex As Exception

            MsgBox("AtualizaAssociacoesSupervisorio: Erro: " & ex.Message)

            btnFechar.Enabled = True

        Finally

        End Try

    End Sub

    Private Sub CarregaAssociacoes()
        Dim sqlAssociacoes As String = ""
        Dim dtCadastro As New DataTable
        Dim command As New SqlCommand(sqlAssociacoes, BancoDados.ConexaoAtiva)

        sqlAssociacoes = "SELECT "
        sqlAssociacoes += "	      cs.id                         "
        sqlAssociacoes += "	    , cs.numero as SiloNumero       "
        sqlAssociacoes += "	    , cs.descricao as SiloDescricao "
        sqlAssociacoes += "     , cb.Descricao as BalancaDescricao  "
        sqlAssociacoes += "	    , asm.CodigoMateriaPrima        "
        sqlAssociacoes += "	    , asm.CodigoMateriaPrima + ' - ' + cmp.Descricao as MateriaPrima "
        sqlAssociacoes += "	    , cmp.Lote "
        sqlAssociacoes += "	FROM CadastroSilos cs "
        sqlAssociacoes += "	LEFT JOIN AssociacaoSiloMP	    asm ON cs.id = asm.SiloID "
        sqlAssociacoes += "	LEFT JOIN CadastroMateriaPrima	cmp ON asm.CodigoMateriaPrima = cmp.CodigoMateriaPrima "
        sqlAssociacoes += " INNER JOIN CadastroBalancas		cb	ON cs.BalancaID = cb.ID "
        sqlAssociacoes += " ORDER BY CS.BalancaID, CS.Numero"

        command.CommandText = sqlAssociacoes
        dtCadastro.Load(command.ExecuteReader)
        command.Dispose()

        DataGridView1.DataSource = dtCadastro
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Function BuscarTag(ByVal strTipoTagPesquisar As String) As String
        Dim strTagLido As String = ""
        Dim scriptSqlTemp As String
        Dim cmdBUscarTagComandoSQL As SqlCommand
        Dim rdrBuscarTagRegistro As SqlDataReader
        Dim bolProducaoEmAndamento As Boolean

        BuscarTag = ""

        Try
            scriptSqlTemp = "SELECT  "
            scriptSqlTemp += "* "
            scriptSqlTemp += " FROM referencia_tag "
            scriptSqlTemp += " WHERE tipo_tag = '" & strTipoTagPesquisar.ToString.Trim & "'"

            cmdBUscarTagComandoSQL = New SqlCommand(scriptSqlTemp, BancoDados.ConexaoAtiva)
            rdrBuscarTagRegistro = cmdBUscarTagComandoSQL.ExecuteReader()
            rdrBuscarTagRegistro.Read()

            If rdrBuscarTagRegistro.HasRows Then
                If Not IsDBNull(rdrBuscarTagRegistro("tag")) Then
                    strTagLido = rdrBuscarTagRegistro("tag").ToString.Trim
                Else
                    strTagLido = "-1"
                End If
            End If
            rdrBuscarTagRegistro.Close()
            cmdBUscarTagComandoSQL.Dispose()

            bolProducaoEmAndamento = True

        Catch ex As Exception
            strTagLido = "-1"
        End Try

        BuscarTag = strTagLido

    End Function

    Private Function TagEscreverString(ByVal parGrupoEscrever As String,
                             ByVal parEscritas As Integer,
                             ByVal parIntervaloEscritas As Integer,
                             ByVal parTagEscrever As String,
                             ByVal parValor As String) As TagEscreverRetorno

        Dim retornoTagEscrever As TagEscreverRetorno
        Dim Escrita As Integer = 0
        Dim QtdeEscritas As Integer = parEscritas
        'QtdeEscritas = 1
        With retornoTagEscrever
            .ErroNumber = 0
            .Mensagem = ""
        End With

        Try
            Escrita = 0

            While Escrita <= QtdeEscritas
                FIX.EscreverNoTag(parTagEscrever, parGrupoEscrever, parValor, FdsTemp)
                'Thread.Sleep(parIntervaloEscritas)
                Escrita += 1
            End While

        Catch ex As Exception
            Rotinas.EscreverEmLog("TagEscrever(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Geral)
        End Try

        Return retornoTagEscrever

    End Function

#End Region

End Class
