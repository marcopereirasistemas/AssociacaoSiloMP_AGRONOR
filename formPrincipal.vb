﻿
Imports System.IO
Imports System.Net
Imports System
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
Imports VB = Microsoft.VisualBasic

Public Class formPrincipal

    Enum TipoTagParaLimpeza
        ADESC_Tag = 1
        ARRAY_Tag = 2
        FIXO_Tag = 3
    End Enum

    Structure TagEscreverRetorno
        Public ErroNumber As Double
        Public Mensagem As String
    End Structure

    Dim AssociacaoSiloID As Integer
    Dim AssiciacaoSiloDescricao As String
    Dim AssociacaoCodigoMP As String
    Dim AssociacaoMateriaPrimaDescricao As String
    Dim AssociacaoTipo As Integer = 0
    Dim formTrocarSiloNova As Object
    Dim RotinasDiversas As New ClasseRotinasDiversas
    Dim teclaCtrlPressionada As Boolean
    Dim Versao As String = " - Versão 1.0.10 - 24/11/2023"
    Dim horaInicioEnvio As String
    Dim horaFinalEnvio As String
    Dim horaInicial As DateTime
    Dim horaFinal As DateTime
    Dim _opcItemID As Integer
    Dim _opcItem As String
    Dim _alias As String
    Dim OpcTagItens As New List(Of TagItem)
    Dim _indiceGrupo As Integer
    Dim numeroElementos As Integer

    Private vAppRValue As Object

    'Private MyOPCServer As RsiOPCAuto.OPCServer
    ''-- DADOS DE PRODUCAO
    'Private WithEvents AssMpSiloOPC As RsiOPCAuto.OPCGroup

    Const OPC_DS_CACHE As Integer = 1
    Const OPC_DS_DEVICE As Integer = 2

    '-- BITS DE CONTROLE
    Const GROUP_NAME = "ASSOCIACAO_SILO_MP"

    'Public Sub ConnectServer()

    '    Try


    '        Cursor.Current = Cursors.WaitCursor

    '        MyOPCServer = New RsiOPCAuto.OPCServer
    '        If MyOPCServer Is Nothing Then

    '            MsgBox("Falha ao criar referencia para RSLinx OPC." & vbCrLf &
    '               "Verifique se esta em execução e configurado.",
    '               MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "  ATENÇÃO")

    '            Me.Close()

    '            Exit Sub

    '        End If

    '        Mensagem("Conectando RSLinx OPC Server ...", LadoMensagem.Esquerdo)

    '        Me.Refresh()

    '        MyOPCServer.Connect("RSLinx OPC Server")

    '        Cursor.Current = Cursors.Default

    '    Catch ex As Exception

    '        Cursor.Current = Cursors.Default

    '        PostMessage(Err.Number)

    '        Mensagem("ConnectServer gerou excessão ao connectar ao RSlinx: " & ex.Message, LadoMensagem.Direito)

    '    End Try

    'End Sub

    'Public Sub DesconectarServidorOPC()

    '    Try

    '        MyOPCServer.OPCGroups.RemoveAll()
    '        AssMpSiloOPC = Nothing
    '        MyOPCServer.Disconnect()

    '    Catch ex As Exception

    '        Cursor.Current = Cursors.Default

    '        PostMessage(Err.Number)

    '    End Try

    'End Sub

    'Public Sub CreateObject()
    '    Dim OPCItem As String
    '    Dim OPCClientHandles As Long

    '    AssMpSiloOPC = MyOPCServer.OPCGroups.Add(GROUP_NAME)
    '    AssMpSiloOPC.IsSubscribed = True
    '    AssMpSiloOPC.IsActive = False
    '    AssMpSiloOPC.UpdateRate = My.Settings.OPC_UPDATE_RATE
    '    AssMpSiloOPC.OPCItems.DefaultAccessPath = My.Settings.OPC_TOPICO

    '    For Each opcI As TagItem In OpcTagItens

    '        OPCItem = opcI.OpcItem

    '        OPCClientHandles = opcI.OpcItemID

    '        AssMpSiloOPC.OPCItems.AddItem(OPCItem, OPCClientHandles)

    '    Next

    'End Sub

    'Private Function EscreverStringOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                                        ByVal OPCClientHandles As Long,
    '                                        Optional ByVal OPCValue As String = "") As Boolean

    '    Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '    Dim retornoTemp As Boolean
    '    Dim msgErro As String
    '    Try

    '        ObjOPCItem = opcGrupoPar.OPCItems(OPCClientHandles)

    '        ObjOPCItem.Write(OPCValue)

    '        msgErro = $"EscreverOpcItem() - OPCClientHandles: {OPCClientHandles}, Valor:  {OPCValue}"

    '        retornoTemp = True

    '    Catch ex As Exception

    '        msgErro = $"Erro ao escrever no item {OPCClientHandles}. Erro: " & ex.Message

    '        MsgBox(msgErro, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '        Rotinas.EscreverEmLog("" & ex.Message, False)

    '        retornoTemp = False

    '    End Try

    '    Return retornoTemp

    'End Function

    'Private Function EscreverNumeroDoubleOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                                        ByVal OPCClientHandles As Long,
    '                                        Optional ByVal OPCValue As Double = 0) As Boolean

    '    Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '    Dim retornoTemp As Boolean
    '    Dim msgErro As String
    '    Try

    '        ObjOPCItem = ProducaoOpcGrup.OPCItems(OPCClientHandles)

    '        ObjOPCItem.Write(OPCValue)

    '        msgErro = $"EscreverOpcItem() - OPCClientHandles: {OPCClientHandles}, Valor:  {OPCValue}"

    '        retornoTemp = True

    '    Catch ex As Exception

    '        msgErro = $"Erro ao escrever no item {OPCClientHandles}. Erro: " & ex.Message

    '        MsgBox(msgErro, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '        Rotinas.EscreverEmLog("" & ex.Message, False)

    '        retornoTemp = False

    '    End Try

    '    Return retornoTemp

    'End Function

    'Private Function EscreverBitOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                                        ByVal OPCClientHandles As Long,
    '                                        Optional ByVal OPCValue As Byte = 0) As Boolean

    '    Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '    Dim retornoTemp As Boolean
    '    Dim msgErro As String
    '    Try

    '        ObjOPCItem = ProducaoOpcGrup.OPCItems(OPCClientHandles)

    '        ObjOPCItem.Write(OPCValue)

    '        msgErro = $"EscreverOpcItem() - OPCClientHandles: {OPCClientHandles}, Valor:  {OPCValue}"

    '        retornoTemp = True

    '    Catch ex As Exception

    '        msgErro = $"Erro ao escrever no item {OPCClientHandles}. Erro: " & ex.Message

    '        MsgBox(msgErro, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '        Rotinas.EscreverEmLog("" & ex.Message, False)

    '        retornoTemp = False

    '    End Try

    '    Return retornoTemp

    'End Function


    '    Public Function GetErrorString(ByRef lErrCode As Integer) As String
    '        Dim sText As String

    '        On Error GoTo Erro

    '        sText = MyOPCServer.GetErrorString(lErrCode)

    '        If InStr(sText, vbCrLf) Then

    '            sText = VB.Left(sText, Len(sText) - 2)

    '        End If

    '        GetErrorString = sText

    '        Exit Function

    'Erro:

    '    End Function

    '    Public Function ConvertArrayToString(ByRef vArrayData As Object) As String

    '        Dim i As Integer
    '        Dim sTemp As String = ""

    '        On Error GoTo Erro

    '        For i = LBound(vArrayData) To UBound(vArrayData) - 1

    '            sTemp = sTemp & vArrayData(i) & ","

    '        Next

    '        sTemp = sTemp & vArrayData(i)

    '        ConvertArrayToString = sTemp

    '        Exit Function

    'Erro:
    '        'Call EscreverEmlog("Erro na função ConvertArrayToString: " & Err.Description)

    '    End Function

    '    Public Sub PostMessage(ByRef lError As Integer)

    '        Dim sText As String

    '        Cursor.Current = Cursors.Default

    '        sText = MyOPCServer.GetErrorString(lError)

    '        If InStr(sText, vbCrLf) Then
    '            sText = VB.Left(sText, Len(sText) - 2)
    '        End If

    '        MsgBox("Runtime error '" & lError & "' (0x" & Hex(lError) & ")" & vbCrLf & vbCrLf & sText, MsgBoxStyle.Information)

    '        Exit Sub

    'Erro:
    '        'Call EscreverEmlog("Erro no procedimento PostMessage: " & Err.Description)

    '    End Sub

    Private Sub InsertOpcItemTabela(ByVal parOpcItemID As Integer,
                                    ByVal parGrupoOpc As String,
                                    ByVal parTipoAcao As String,
                                    ByVal parOpcItem As String,
                                    ByVal parValor As Double, ByVal parAlias As String)
        'Dim insertTemp As String

        'insertTemp = "Insert INTO OpcTagItens "
        'insertTemp += "("
        'insertTemp += " LinhaID, "
        'insertTemp += " GrupoOpc, "
        'insertTemp += " TipoAcao, "
        'insertTemp += " OpcItemID , "
        'insertTemp += " OpcItem  , "
        'insertTemp += " Valor, "
        'insertTemp += " Alias "
        'insertTemp += ") "
        'insertTemp += " VALUES  "
        'insertTemp += "( "
        'insertTemp += LinhaConfigurada & ", "
        'insertTemp += "'" & parGrupoOpc & "', "
        'insertTemp += "'" & parTipoAcao & "', "
        'insertTemp += parOpcItemID & ", "
        'insertTemp += "'" & parOpcItem & "', "
        'insertTemp += parValor & ", "
        'insertTemp += "'" + parAlias & "'"
        'insertTemp += ")"

        'BancoDados.ComandoSQL = insertTemp
        'BancoDados.CriaComandoSQL()
        'BancoDados.ExecutaSQL()

    End Sub

    Private Sub LimpaOpcItemTabela()

        'BancoDados.ComandoSQL = "DELETE FROM OpcTagItens WHERE LinhaID = " & LinhaConfigurada.ToString
        'BancoDados.CriaComandoSQL()
        'BancoDados.ExecutaSQL()

    End Sub

    'Private Sub SetaValorEscreverItemOPC(ByVal parAlias As String,
    '                                     ByVal parValor As Double)

    '    Dim sqlUpdate As String

    '    sqlUpdate = ""
    '    sqlUpdate += "UPDATE  OpcTagItens "
    '    sqlUpdate += " SET     VALOR = " & Rotinas.VirgulaParaPonto(parValor)
    '    sqlUpdate += " WHERE LinhaID = " & LinhaConfigurada.ToString
    '    sqlUpdate += " And     Alias = '" & parAlias & "'"

    '    BancoDados.ComandoSQL = sqlUpdate
    '    BancoDados.CriaComandoSQL()
    '    BancoDados.ExecutaSQL()

    'End Sub

    '#Region "BITS Funções - Leitura / Escrita"
    '    Private Function LerBitOPC(ByVal IndiceOPC As Long) As Boolean
    '        Dim OPCReadItem As Object
    '        Dim OPCQuality As Object
    '        Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '        Dim _retornoLerBitOPC As Boolean

    '        Try

    '            LerBitOPC = True

    '            ObjOPCItem = ControleOpcGrup.OPCItems(IndiceOPC)

    '            ObjOPCItem.Read(OPC_DS_DEVICE, OPCReadItem, OPCQuality)

    '            vAppRValue = OPCReadItem

    '            _retornoLerBitOPC = True

    '        Catch ex As Exception

    '            Rotinas.EscreverEmLog("LerBitOPC(): Erro: " & ex.Message, False)

    '            _retornoLerBitOPC = False

    '        End Try

    '        Return _retornoLerBitOPC

    '    End Function

    '    Private Function EscreverBitsOPC(OPCClientHandles As Long, OPCValue As Integer) As Boolean
    '        Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '        Dim retornoTemp As Boolean

    '        Try

    '            ObjOPCItem = ControleOpcGrup.OPCItems(OPCClientHandles)

    '            ObjOPCItem.Write(OPCValue)

    '            retornoTemp = True

    '        Catch ex As Exception

    '            MsgBox("Erro ao escrever no grupo de controle. Gerou uma excessão: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '            Rotinas.EscreverEmLog("" & ex.Message, False)

    '            retornoTemp = False

    '        End Try

    '        EscreverBitsOPC = retornoTemp

    '    End Function

    '    Private Function EscreverNumeroOPC(OPCClientHandles As Long, OPCValue As Double) As Boolean
    '        Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '        Dim retornoTemp As Boolean

    '        Try

    '            ObjOPCItem = ControleOpcGrup.OPCItems(OPCClientHandles)

    '            ObjOPCItem.Write(OPCValue)

    '            retornoTemp = True

    '        Catch ex As Exception

    '            MsgBox("EscreverNumeroOPC: Erro: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '            Rotinas.EscreverEmLog("" & ex.Message, False)

    '            retornoTemp = False

    '        End Try

    '        EscreverNumeroOPC = retornoTemp

    '    End Function

    '    Private Function EscreverStringOPC(OPCClientHandles As Long, OPCValue As String) As Boolean
    '        Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '        Dim retornoTemp As Boolean

    '        Try

    '            ObjOPCItem = ControleOpcGrup.OPCItems(OPCClientHandles)

    '            ObjOPCItem.Write(OPCValue)

    '            retornoTemp = True

    '        Catch ex As Exception

    '            MsgBox("EscreverStringOPC(): gerou erro: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

    '            Rotinas.EscreverEmLog("" & ex.Message, False)

    '            retornoTemp = False

    '        End Try

    '        EscreverStringOPC = retornoTemp

    '    End Function

    '#End Region

    Private Sub CarregaOpcItens()
        Dim sqlTemp As String
        Dim cmdTemp As SqlCommand
        Dim rdrTemp As SqlDataReader

        Try

            sqlTemp = "SELECT * FROM OpcTagItens "
            sqlTemp += " WHERE GrupoOpc "
            sqlTemp += " LIKE '%" & GROUP_NAME & "%'"
            sqlTemp += " AND Status = 1"
            sqlTemp += " ORDER BY OpcItemID"

            cmdTemp = New SqlCommand(sqlTemp, BancoDados.ConexaoAtiva)
            rdrTemp = cmdTemp.ExecuteReader()

            If rdrTemp.HasRows Then
                While rdrTemp.Read()
                    OpcTagItens.Add(New TagItem(
                                            rdrTemp("OpcItemId"),
                                            rdrTemp("OpcItem")
                                        )
                                    )
                End While
            End If
            rdrTemp.Close()
            cmdTemp.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    'Private Function BuscaItemOPC(ByVal _parGrupOpc As String, ByVal _parAlias As String) As String
    '    Dim strTagLido As String = ""

    '    Dim strBuscarTagSQL As String
    '    Dim cmdBUscarTagComandoSQL As SqlCommand
    '    Dim rdrBuscarTagRegistro As SqlDataReader

    '    BuscaItemOPC = ""

    '    Try

    '        strBuscarTagSQL = "SELECT "
    '        strBuscarTagSQL += "  *  "
    '        strBuscarTagSQL += " FROM [OpcTagItens] "
    '        strBuscarTagSQL += " WHERE Alias = '" & _parAlias.ToString.Trim & "'"
    '        strBuscarTagSQL += "  AND GrupoOpc = '" & _parGrupOpc.ToString.Trim & "'"

    '        cmdBUscarTagComandoSQL = New SqlCommand(strBuscarTagSQL, BancoDados.ConexaoAtiva)
    '        rdrBuscarTagRegistro = cmdBUscarTagComandoSQL.ExecuteReader()

    '        _opcItemID = -1
    '        _opcItem = ""
    '        _alias = ""

    '        If rdrBuscarTagRegistro.HasRows Then

    '            rdrBuscarTagRegistro.Read()

    '            strTagLido = rdrBuscarTagRegistro("OpcItemID").ToString.Trim

    '            _opcItemID = rdrBuscarTagRegistro("OpcItemID").ToString.Trim
    '            _opcItem = rdrBuscarTagRegistro("OpcItem").ToString.Trim
    '            _alias = rdrBuscarTagRegistro("Alias").ToString.Trim

    '        End If

    '        rdrBuscarTagRegistro.Close()
    '        cmdBUscarTagComandoSQL.Dispose()

    '    Catch ex As Exception

    '        strTagLido = ""

    '    End Try

    '    BuscaItemOPC = strTagLido

    'End Function

    'Private Function RetornaTagOPC(ByVal strTipoTagPesquisar As String) As TagRetorno
    '    Dim strTagLido As String = ""

    '    Dim scriptSql As String
    '    Dim _cmdSql As SqlCommand
    '    Dim _rdr As SqlDataReader

    '    Dim _tagRetorno As New TagRetorno() With {
    '                                            .TipoTag = "",
    '                                            .Tag = "",
    '                                            .OPC = "",
    '                                            .Limpa = 0,
    '                                            .PosicaoInicial = 0,
    '                                            .Tipo = 0
    '                                            }

    '    Try

    '        scriptSql = "SELECT "
    '        scriptSql += "  * "
    '        scriptSql += " FROM referencia_tag "
    '        scriptSql += " WHERE tipo_tag = '" & strTipoTagPesquisar.ToString.Trim & "'"

    '        _cmdSql = New SqlCommand(scriptSql, BancoDados.ConexaoAtiva)
    '        _rdr = _cmdSql.ExecuteReader()

    '        If _rdr.HasRows Then
    '            _rdr.Read()
    '            _tagRetorno.Tag = _rdr("tag").ToString.Trim
    '            _tagRetorno.OPC = _rdr("OPC").ToString.Trim
    '            _tagRetorno.PosicaoInicial = _rdr("PosicaoInicial").ToString.Trim
    '            _tagRetorno.TipoTag = _rdr("Tipo_Tag").ToString.Trim
    '            _tagRetorno.Limpa = _rdr("limpa").ToString.Trim
    '            _tagRetorno.Tipo = _rdr("Tipo").ToString.Trim
    '        End If

    '        _rdr.Close()
    '        _cmdSql.Dispose()

    '    Catch ex As Exception

    '        'Rotinas.EscreverEmLog("BuscarTag(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Simples)
    '        strTagLido = ""

    '    End Try

    '    Return _tagRetorno

    'End Function


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
                fin = $"Fim...: {horaFinal}"
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

        btnAtualizaTAGS.Visible = False
        If HabilitarTestesLOG() Then

            btnAtualizaTAGS.Visible = True

        End If

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

    Private Sub LimparTags()
        Dim opcIdTemp As Long
        Dim valueTemp As String

        For Each opcI As TagItem In OpcTagItens

            opcIdTemp = opcI.OpcItemID

            valueTemp = ""

            'EscreverStringOpcItem(AssMpSiloOPC, opcIdTemp, valueTemp)

            Thread.Sleep(50)

        Next

    End Sub

    Private Sub AtualizaAssociacoesSupervisorio()
        Dim sqlTemp As String
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader
        Dim opcIdTemp As Long
        Dim aliasTemp As String
        Dim valueTemp As String

        Panel2.Visible = True
        btnAssociar.Enabled = False
        btnDesassociar.Enabled = False

        Me.Refresh()

        horaInicial = Now.ToString

        'ConnectServer()

        CarregaOpcItens()

        'CreateObject()

        LimparTags()

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



            While rdrRegistro.Read()

                For Each opcI As TagItem In OpcTagItens

                    aliasTemp = $"MP{rdrRegistro("SiloNumero")}_B{rdrRegistro("BalancaNumero")}_DESC"

                    If UCase(opcI.OpcItem) = UCase(aliasTemp) Then

                        opcIdTemp = opcI.OpcItemID

                        valueTemp = IIf(IsDBNull(rdrRegistro("Descricao")), "", rdrRegistro("Descricao"))

                        'EscreverStringOpcItem(AssMpSiloOPC, opcI.OpcItemID, valueTemp)

                        Debug.Print($"OpcItemID: {opcIdTemp} - {aliasTemp} - Valor: {valueTemp}")

                    End If

                Next

            End While

            'Rotinas.EscreverEmLog(" - FIM Do ENVIO DOS tagsItens AO SUPERVISORIO.", ClasseRotinasDiversas.Tipo.Geral)
            'Rotinas.EscreverEmLog(" - EXECUTANDO O COMANDO WRITE INICIO.", ClasseRotinasDiversas.Tipo.Geral)
            'Rotinas.EscreverEmLog(" - EXECUTANDO O COMANDO WRITE FIM.", ClasseRotinasDiversas.Tipo.Geral)

            horaFinal = Now.ToString

            rdrRegistro.Close()
            cmdComandoSQL.Dispose()

            Panel2.Visible = False

        Catch ex As Exception

            MsgBox("AtualizaAssociacoesSupervisorio: Erro: " & ex.Message)

            btnFechar.Enabled = True

            Panel2.Visible = True

            btnAssociar.Enabled = True

            btnDesassociar.Enabled = True

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

        If HabilitarTestesLOG() Then
            sqlAssociacoes += "	    , Ltrim(str(cs.Numero)) + ' - ' + cs.descricao as SiloDescricao "
        Else
            sqlAssociacoes += "	    , cs.descricao as SiloDescricao "
        End If

        If HabilitarTestesLOG() Then
            sqlAssociacoes += "     , Ltrim(str(cb.Numero)) + ' - ' + cb.Descricao as BalancaDescricao  "
        Else
            sqlAssociacoes += "     , cb.Descricao as BalancaDescricao  "
        End If

        sqlAssociacoes += "	    , asm.CodigoMateriaPrima        "
        sqlAssociacoes += "	    , asm.CodigoMateriaPrima + ' - ' + cmp.Descricao as MateriaPrima "
        sqlAssociacoes += "	    , cmp.Lote "
        sqlAssociacoes += "	FROM CadastroSilos cs "
        sqlAssociacoes += "	LEFT JOIN AssociacaoSiloMP	    asm ON cs.id = asm.SiloID "
        sqlAssociacoes += "	LEFT JOIN CadastroMateriaPrima	cmp ON asm.CodigoMateriaPrima = cmp.CodigoMateriaPrima "
        sqlAssociacoes += " LEFT JOIN CadastroBalancas		cb	ON cs.BalancaID = cb.ID "
        sqlAssociacoes += " ORDER BY CS.BalancaID, CS.Numero"

        command.CommandText = sqlAssociacoes
        dtCadastro.Load(command.ExecuteReader)
        command.Dispose()

        DataGridView1.DataSource = dtCadastro
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Function HabilitarTestesLOG() As Boolean
        Dim retornoHabilitaTestes As Boolean

        retornoHabilitaTestes = False

        If Rotinas.ArquivoExiste(Application.StartupPath & "\TESTE_TAGS.TXT") Then
            retornoHabilitaTestes = True
        End If

        Return retornoHabilitaTestes

    End Function


    Private Function GerarItensOPC(ByVal _linhaID As Integer,
                                   ByVal _numeroElementos As Integer,
                                   ByVal _balancaNumero As Integer,
                                   ByVal _nameGrupo As String,
                                   ByVal _partialNameAlias As String,
                                   ByVal _tagPartial_1 As String,
                                   ByVal _tagPartial_2 As String,
                                   ByVal _indiceInicialTag As Integer,
                                   ByVal _stepTemp As Integer,
                                   ByVal _limpar As Integer,
                                   ByVal _status As Integer,
                                   Optional ByVal _indexado As Integer = 0,
                                   Optional ByVal _valor As Double = 0) As List(Of OpcTagItem)

        Dim _opcTagItens As New List(Of OpcTagItem)()
        Dim _opcTagItem As OpcTagItem
        Dim nameAlias As String
        Dim tag As String
        Dim tagPartial_2 As String
        Dim numeroElementos As Integer
        Dim indicetag As Integer
        Dim indiceTabela As Integer
        indiceTabela = 0
        _numeroElementos = 11
        indicetag = _indiceInicialTag
        For indice = 0 To _numeroElementos

            _opcTagItem = New OpcTagItem()

            _indiceGrupo += 1

            nameAlias = _partialNameAlias & $"_{_balancaNumero}_{indiceTabela:00}"

            tagPartial_2 = _tagPartial_2 & $"{ indicetag }"

            tag = _tagPartial_1 & tagPartial_2


            _opcTagItem.LinhaID = _linhaID
            _opcTagItem.GrupoOPC = _nameGrupo
            _opcTagItem.IndiceGrupo = _indiceGrupo
            _opcTagItem.Indice = indiceTabela
            _opcTagItem.Apelido = nameAlias
            _opcTagItem.TAG = tag
            _opcTagItem.Indexado = _indexado
            _opcTagItem.IndiceMatriz = indiceTabela
            _opcTagItem.Valor = _valor
            _opcTagItem.NumeroElementos = numeroElementos
            _opcTagItem.Limpar = _limpar
            _opcTagItem.Status = _status
            Debug.Print($"{indiceTabela} - TAG: {tag}")
            _opcTagItens.Add(_opcTagItem)
            indiceTabela += 1
            indicetag += _stepTemp
        Next

        Return _opcTagItens

    End Function

    Private Sub btnAtualizaTAGS_Click(sender As Object, e As EventArgs) Handles btnAtualizaTAGS.Click
        Dim _balancaNumero As Integer
        Dim NomeGrupoOPC As String
        Dim partialNameAlias As String
        Dim tagPartial_1 As String
        Dim tagPartial_2 As String
        Dim indiceInicialTag As Integer
        Dim __opcTagItens As New List(Of OpcTagItem)()
        Dim _linhaID As Integer
        Dim ScritpsSqlExecutar As New List(Of ScriptExecutar)()
        'Dim iLinhaID As Integer
        Dim _step As Integer

        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%SILO_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%CODIGO_MP_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%QTDE_DESEJADO_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%TOLERANCIA_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%ERRO_MINIMO_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%ERRO_MAXIMO_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%REAL_ONLINE_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%REAL_BALANCA%'"))
        ScritpsSqlExecutar.Add(New ScriptExecutar("DELETE From OpcTagItens Where LINHAID = 1 And ALIAS Like '%TEMPO_REAL_BALANCA%'"))

        Debug.Print("------------------------------------------------------------------------------------")
        For Each sc As ScriptExecutar In ScritpsSqlExecutar

            Debug.Print($"GUID...: {sc.ID }")
            Debug.Print($"COMANDO: {sc.Comando}")
            Debug.Print("------------------------------------------------------------------------------------")

            BancoDados.ComandoSQL = sc.Comando
            BancoDados.CriaComandoSQL()
            BancoDados.ExecutaSQL()
        Next

        _indiceGrupo = 0
        _linhaID = 1

        For _balancaNumero = 1 To 8

            tagPartial_1 = $"DB100{_balancaNumero}."

            tagPartial_2 = "DBW"
            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "SILO_BALANCA"
            indiceInicialTag = 0
            _step = 2
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)



            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "CODIGO_MP_BALANCA"
            indiceInicialTag = 24
            _step = 2
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            tagPartial_2 = "DBD"
            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "QTDE_DESEJADO_BALANCA"
            indiceInicialTag = 48
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "TOLERANCIA_BALANCA"
            indiceInicialTag = 96
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "ERRO_MINIMO_BALANCA"
            indiceInicialTag = 144
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "ERRO_MAXIMO_BALANCA"
            indiceInicialTag = 192
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_SP_L" & _linhaID
            partialNameAlias = "REAL_ONLINE_BALANCA"
            indiceInicialTag = 336
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_CL_L" & _linhaID
            partialNameAlias = "REAL_BALANCA"
            indiceInicialTag = 384
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            NomeGrupoOPC = "PRODUCAO_CL_L" & _linhaID
            partialNameAlias = "TEMPO_REAL_BALANCA"
            indiceInicialTag = 432
            _step = 4
            __opcTagItens = GerarItensOPC(_linhaID,
                                          numeroElementos,
                                          _balancaNumero,
                                          NomeGrupoOPC,
                                          partialNameAlias,
                                          tagPartial_1,
                                          tagPartial_2,
                                          indiceInicialTag,
                                          _step,
                                          0,
                                          1,
                                          0,
                                          0)

            GravarOpcTagItens(__opcTagItens)


            Thread.Sleep(5000)

        Next

        _indiceGrupo = 0

    End Sub

    Private Sub GravarOpcTagItens(ByRef _tagItens As List(Of OpcTagItem))

        For Each tg As OpcTagItem In _tagItens

            BancoDados.ComandoSQL = "INSERT INTO [dbo].[OpcTagItens] " &
                "  ([LinhaID]           " &
                "  ,[GrupoOpc]          " &
                "  ,[IndiceGrupo]       " &
                "  ,[Indice]            " &
                "  ,[Alias]             " &
                "  ,[TAG]               " &
                "  ,[Indexado]          " &
                "  ,[IndiceMatriz]      " &
                "  ,[Valor]             " &
                "  ,[NumeroElementos]   " &
                "  ,[Limpar]            " &
                "  ,[Status])           " &
                " VALUES " &
                "  (@parLinhaID         " &
                "  ,@parGrupoOpc        " &
                "  ,@parIndiceGrupo     " &
                "  ,@parIndice          " &
                "  ,@parAlias           " &
                "  ,@parTAG             " &
                "  ,@parIndexado        " &
                "  ,@parIndiceMatriz    " &
                "  ,@parValor           " &
                "  ,@parNumeroElementos " &
                "  ,@parLimpar          " &
                "  ,@parStatus)         "
            BancoDados.CriaComandoSQL()
            BancoDados.AdicionarParametro("@parLinhaID", tg.LinhaID)
            BancoDados.AdicionarParametro("@parGrupoOpc", tg.GrupoOPC)
            BancoDados.AdicionarParametro("@parIndiceGrupo", tg.IndiceGrupo)
            BancoDados.AdicionarParametro("@parIndice", tg.Indice)
            BancoDados.AdicionarParametro("@parAlias", tg.Apelido)
            BancoDados.AdicionarParametro("@parTag", tg.TAG)
            BancoDados.AdicionarParametro("@parIndexado", tg.Indexado)
            BancoDados.AdicionarParametro("@parIndiceMatriz", tg.IndiceMatriz)
            BancoDados.AdicionarParametro("@parValor", tg.Valor)
            BancoDados.AdicionarParametro("@parNumeroElementos", tg.NumeroElementos)
            BancoDados.AdicionarParametro("@parLimpar", tg.Limpar)
            BancoDados.AdicionarParametro("@parStatus", tg.Status)
            BancoDados.ExecutaSQL()
        Next

        _tagItens.Clear()

    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click

        CarregaAssociacoes()

    End Sub

    'Private Function TagEscreverString(ByVal parGrupoEscrever As String,
    '                         ByVal parEscritas As Integer,
    '                         ByVal parIntervaloEscritas As Integer,
    '                         ByVal parTagEscrever As String,
    '                         ByVal parValor As String) As TagEscreverRetorno

    '    Dim retornoTagEscrever As TagEscreverRetorno
    '    Dim Escrita As Integer = 0
    '    Dim QtdeEscritas As Integer = parEscritas

    '    'QtdeEscritas = 1

    '    With retornoTagEscrever
    '        .ErroNumber = 0
    '        .Mensagem = ""
    '    End With

    '    Try
    '        Escrita = 0

    '        While Escrita <= QtdeEscritas
    '            FIX.EscreverNoTag(parTagEscrever, parGrupoEscrever, parValor, FdsTemp)
    '            'Thread.Sleep(parIntervaloEscritas)
    '            Escrita += 1
    '        End While

    '    Catch ex As Exception
    '        Rotinas.EscreverEmLog("TagEscrever(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Geral)
    '    End Try

    '    Return retornoTagEscrever

    'End Function

End Class





'********************************
'Misturador 1
'********************************

'00-19=Peso Desejado
'20-39=Peso Min B1
'40-59=Peso Max B1
'60-79=Peso Real B1



'1   N25[00] - Silo
'	F20[00] - Desejado
'	F20[20] - Erro Minimo
'	F20[40] - Erro Maximo
'	F20[60] - Real Online
'1. ok



'2   N25[20]
'	F120[00] - Desejado
'	F120[20] - Erro Minimo
'	F120[40] - Erro Maximo
'	F120[60] - Real Online

'3   N25[40]
'	F22[00] - Desejado
'	F22[20] - Erro Minimo
'	F22[40] - Erro Maximo
'	F22[60] - Real Online

'3. ok


'4   N25[60]
'	F122[00] - Desejado
'	F122[20] - Erro Minimo
'	F122[40] - Erro Maximo
'	F122[60] - Real Online

'5   N25[80]
'	F24[00] - Desejado
'	F24[20] - Erro Minimo
'	F24[40] - Erro Maximo
'	F24[60] - Real Online

'5. ok

'6   N25[100]
'	F124[00] - Desejado
'	F124[20] - Erro Minimo
'	F124[40] - Erro Maximo
'	F124[60] - Real Online


'********************************
'Misturador 2
'********************************

'1   N29[00] - Silo
'	F21[00] - Desejado
'	F21[20] - Erro Minimo
'	F21[40] - Erro Maximo
'	F21[60] - Real Online

'2   N29[20]
'	F121[00] - Desejado
'	F121[20] - Erro Minimo
'	F121[40] - Erro Maximo
'	F121[60] - Real Online

'3   N29[40]
'	F23[00] - Desejado
'	F23[20] - Erro Minimo
'	F23[40] - Erro Maximo
'	F23[60] - Real Online

'4   N29[60]
'	F123[00] - Desejado
'	F123[20] - Erro Minimo
'	F123[40] - Erro Maximo
'	F123[60] - Real Online

'5   N29[80]
'	F27[00] - Desejado
'	F27[20] - Erro Minimo
'	F27[40] - Erro Maximo
'	F27[60] - Real Online

'6   N29[100]
'	F127[00] - Desejado
'	F127[20] - Erro Minimo
'	F127[40] - Erro Maximo
'	F127[60] - Real Online

'********************************
'Coletor
'********************************

'1   F26[00] - Real B1 ok
'2   F26[20] - Real B2
'3   F26[40] - Real B3 ok 
'4   F26[60] - Real B4
'5   F26[80] - Real B5
'6   F26[100] - Real B6

