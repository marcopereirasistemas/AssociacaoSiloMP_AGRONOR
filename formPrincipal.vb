
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

#Region "Declarãções para OPC"

    Private MyOPCServer As RsiOPCAuto.OPCServer

    Private WithEvents MyOPCGroup As RsiOPCAuto.OPCGroup
    '-- DADOS DE PRODUCAO
    Private WithEvents ProducaoOpcGrup As RsiOPCAuto.OPCGroup

    Const OPC_DS_CACHE As Integer = 1
    Const OPC_DS_DEVICE As Integer = 2

    '-- BITS DE CONTROLE
    Const CONTROLE_PRODUTO_DESCRICAO_ID = 0
    Const CONTROLE_PRODUTO_DESCRICAO = "PRODUTO_DESCRICAO"

#End Region

    Private vAppRValue As Object

    Dim _opcItemID As Integer
    Dim _opcItem As String
    Dim _alias As String



#Region "DEFINIÇÕES DO OPC"
    Public Sub ConnectServer()

        Try

            Cursor.Current = Cursors.WaitCursor
            Mensagem("Conectando RSLinx OPC Server ...", LadoMensagem.Esquerdo)
            Me.Refresh()
            MyOPCServer.Connect("RSLinx OPC Server")

            Cursor.Current = Cursors.Default

        Catch ex As Exception

            Cursor.Current = Cursors.Default

            PostMessage(Err.Number)

            Mensagem("ConnectServer gerou excessão ao connectar ao RSlinx: " & ex.Message, LadoMensagem.Direito)

        End Try

    End Sub

    Public Sub DesconectarServidorOPC()

        Try

            MyOPCServer.OPCGroups.RemoveAll()
            MyOPCGroup = Nothing
            MyOPCServer.Disconnect()

        Catch ex As Exception

            Cursor.Current = Cursors.Default

            PostMessage(Err.Number)

        End Try

    End Sub

    Public Sub CreateObject()
        Dim indiceTemp As Integer
        Dim parcialTag As String
        Dim OPCItem As String
        Dim OPCClientHandles As Long
        Dim TamanhoTabelaTag As Integer = 19
        Dim OpcItemID As Integer
        Dim indiceLocal As Integer
        Dim _alias As String
        Dim _tr As New TagRetorno
        Dim _opcGrupoTemp As String
        Dim _tipoAcaoTemp As String

        _tr = New TagRetorno

#Region "Itens de Producao"

        ProducaoOpcGrup = MyOPCServer.OPCGroups.Add("ASSOCIACAO_SILO_MP")
        ProducaoOpcGrup.IsSubscribed = True
        ProducaoOpcGrup.IsActive = False
        ProducaoOpcGrup.UpdateRate = My.Settings.OPC_UPDATE_RATE
        ProducaoOpcGrup.OPCItems.DefaultAccessPath = My.Settings.OPC_TOPICO

#Region "SILO BALANCA 1"


        _opcGrupoTemp = "SP_PRODUCAO"
        _tipoAcaoTemp = "W"

        '-------------------------------------------------
        '-- SILO BALANCA 1
        '-------------------------------------------------
        OpcItemID = 0
        _alias = "SILO_BALANCA_1"
        _tr = RetornaTagOPC(_alias)
        parcialTag = _tr.OPC
        parcialTag = parcialTag.Substring(0, parcialTag.IndexOf("["))
        indiceLocal = 0
        For indiceTemp = _tr.PosicaoInicial To _tr.PosicaoInicial + TamanhoTabelaTag
            OPCItem = $"{parcialTag}[{indiceTemp}]"
            OPCClientHandles = OpcItemID
            ProducaoOpcGrup.OPCItems.AddItem(OPCItem, OPCClientHandles)
            'Debug.Print($"OPCClientHandles: {OPCClientHandles} - OPCItem: {OPCItem}")
            InsertOpcItemTabela(OpcItemID, _opcGrupoTemp, _tipoAcaoTemp, OPCItem, 0, _alias & "_" & indiceLocal.ToString)
            OpcItemID += 1
            indiceLocal += 1
        Next

#End Region

    End Sub

    'Private Function LerOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                            ByVal IndiceOPC As Long) As LeituraOpcRetorno
    '    Dim OPCReadItem As Object
    '    Dim OPCQuality As Object
    '    Dim ObjOPCItem As RsiOPCAuto.OPCItem
    '    Dim _retornoLeitura As New LeituraOpcRetorno() With {.Valor = 0, .Status = True}

    '    Try

    '        ObjOPCItem = opcGrupoPar.OPCItems(IndiceOPC)
    '        ObjOPCItem.Read(OPC_DS_DEVICE, OPCReadItem, OPCQuality)
    '        vAppRValue = OPCReadItem
    '        _retornoLeitura.Valor = OPCReadItem

    '    Catch ex As Exception

    '        Rotinas.EscreverEmLog("LerBitOPC(): Erro: " & ex.Message, False)

    '        _retornoLeitura.Valor = -1
    '        _retornoLeitura.Status = False

    '    End Try

    '    Return _retornoLeitura

    'End Function

    'Private Function EscreverOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                                 ByVal OPCClientHandles As Long,
    '                                 Optional ByVal OPCValue As Long = 0) As Boolean

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

    'Private Function EscreverNumeroInteiroOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
    '                                             ByVal OPCClientHandles As Long,
    '                                             Optional ByVal OPCValue As Integer = 0) As Boolean

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

    Private Function EscreverStringOpcItem(ByVal opcGrupoPar As RsiOPCAuto.OPCGroup,
                                            ByVal OPCClientHandles As Long,
                                            Optional ByVal OPCValue As String = "") As Boolean

        Dim ObjOPCItem As RsiOPCAuto.OPCItem
        Dim retornoTemp As Boolean
        Dim msgErro As String
        Try

            ObjOPCItem = ProducaoOpcGrup.OPCItems(OPCClientHandles)

            ObjOPCItem.Write(OPCValue)

            msgErro = $"EscreverOpcItem() - OPCClientHandles: {OPCClientHandles}, Valor:  {OPCValue}"

            retornoTemp = True

        Catch ex As Exception

            msgErro = $"Erro ao escrever no item {OPCClientHandles}. Erro: " & ex.Message

            MsgBox(msgErro, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")

            Rotinas.EscreverEmLog("" & ex.Message, False)

            retornoTemp = False

        End Try

        Return retornoTemp

    End Function

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


#End Region

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

    Public Sub PostMessage(ByRef lError As Integer)

        Dim sText As String

        Cursor.Current = Cursors.Default

        sText = MyOPCServer.GetErrorString(lError)

        If InStr(sText, vbCrLf) Then
            sText = VB.Left(sText, Len(sText) - 2)
        End If

        MsgBox("Runtime error '" & lError & "' (0x" & Hex(lError) & ")" & vbCrLf & vbCrLf & sText, MsgBoxStyle.Information)

        Exit Sub

Erro:
        'Call EscreverEmlog("Erro no procedimento PostMessage: " & Err.Description)

    End Sub

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

    ''' <summary>
    ''' Busca o tag pelo tipo_tag e retorna o tag do opc
    ''' </summary>
    ''' <param name="strTipoTagPesquisar"></param>
    ''' <returns></returns>
    Private Function BuscarTagOPC(ByVal strTipoTagPesquisar As String) As String
        Dim strTagLido As String = ""

        Dim strBuscarTagSQL As String
        Dim cmdBUscarTagComandoSQL As SqlCommand
        Dim rdrBuscarTagRegistro As SqlDataReader
        Dim bolProducaoEmAndamento As Boolean

        BuscarTagOPC = ""

        Try

            strBuscarTagSQL = "SELECT "
            strBuscarTagSQL += "  * "
            strBuscarTagSQL += " FROM referencia_tag "
            strBuscarTagSQL += " WHERE "
            strBuscarTagSQL += "  AND tipo_tag = '" & strTipoTagPesquisar.ToString.Trim & "'"

            cmdBUscarTagComandoSQL = New SqlCommand(strBuscarTagSQL, BancoDados.ConexaoAtiva)
            rdrBuscarTagRegistro = cmdBUscarTagComandoSQL.ExecuteReader()

            If rdrBuscarTagRegistro.HasRows Then

                rdrBuscarTagRegistro.Read()

                strTagLido = rdrBuscarTagRegistro("OPC").ToString.Trim

            End If

            rdrBuscarTagRegistro.Close()
            cmdBUscarTagComandoSQL.Dispose()

            bolProducaoEmAndamento = True

        Catch ex As Exception

            strTagLido = ""

        End Try

        BuscarTagOPC = strTagLido

    End Function

    Private Function BuscaItemOPC(ByVal _parGrupOpc As String, ByVal _parAlias As String) As String
        Dim strTagLido As String = ""

        Dim strBuscarTagSQL As String
        Dim cmdBUscarTagComandoSQL As SqlCommand
        Dim rdrBuscarTagRegistro As SqlDataReader

        BuscaItemOPC = ""

        Try

            strBuscarTagSQL = "SELECT "
            strBuscarTagSQL += "  *  "
            strBuscarTagSQL += " FROM [OpcTagItens] "
            strBuscarTagSQL += " WHERE Alias = '" & _parAlias.ToString.Trim & "'"
            strBuscarTagSQL += "  AND GrupoOpc = '" & _parGrupOpc.ToString.Trim & "'"

            cmdBUscarTagComandoSQL = New SqlCommand(strBuscarTagSQL, BancoDados.ConexaoAtiva)
            rdrBuscarTagRegistro = cmdBUscarTagComandoSQL.ExecuteReader()

            _opcItemID = -1
            _opcItem = ""
            _alias = ""

            If rdrBuscarTagRegistro.HasRows Then

                rdrBuscarTagRegistro.Read()

                strTagLido = rdrBuscarTagRegistro("OpcItemID").ToString.Trim

                _opcItemID = rdrBuscarTagRegistro("OpcItemID").ToString.Trim
                _opcItem = rdrBuscarTagRegistro("OpcItem").ToString.Trim
                _alias = rdrBuscarTagRegistro("Alias").ToString.Trim

            End If

            rdrBuscarTagRegistro.Close()
            cmdBUscarTagComandoSQL.Dispose()

        Catch ex As Exception

            strTagLido = ""

        End Try

        BuscaItemOPC = strTagLido

    End Function

    Private Function RetornaTagOPC(ByVal strTipoTagPesquisar As String) As TagRetorno
        Dim strTagLido As String = ""

        Dim scriptSql As String
        Dim _cmdSql As SqlCommand
        Dim _rdr As SqlDataReader

        Dim _tagRetorno As New TagRetorno() With {
                                                .TipoTag = "",
                                                .Tag = "",
                                                .OPC = "",
                                                .Limpa = 0,
                                                .PosicaoInicial = 0,
                                                .Tipo = 0
                                                }

        Try

            scriptSql = "SELECT "
            scriptSql += "  * "
            scriptSql += " FROM referencia_tag "
            scriptSql += " WHERE tipo_tag = '" & strTipoTagPesquisar.ToString.Trim & "'"

            _cmdSql = New SqlCommand(scriptSql, BancoDados.ConexaoAtiva)
            _rdr = _cmdSql.ExecuteReader()

            If _rdr.HasRows Then
                _rdr.Read()
                _tagRetorno.Tag = _rdr("tag").ToString.Trim
                _tagRetorno.OPC = _rdr("OPC").ToString.Trim
                _tagRetorno.PosicaoInicial = _rdr("PosicaoInicial").ToString.Trim
                _tagRetorno.TipoTag = _rdr("Tipo_Tag").ToString.Trim
                _tagRetorno.Limpa = _rdr("limpa").ToString.Trim
                _tagRetorno.Tipo = _rdr("Tipo").ToString.Trim
            End If

            _rdr.Close()
            _cmdSql.Dispose()

        Catch ex As Exception

            'Rotinas.EscreverEmLog("BuscarTag(): Erro: " & ex.Message, ClasseRotinasDiversas.Tipo.Simples)
            strTagLido = ""

        End Try

        Return _tagRetorno

    End Function

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


        'Select Case
        'cs.id,
        'cb.Numero As BalancaNumero, 
        'cs.Numero as SiloNumero,
        'ass.codigoMateriaPrima,
        'cmp.Descricao,
        '(SELECT Tipo_Tag FROM Referencia_Tag r WHERE r.Tipo_Tag Like 'DESC_MP_ASSOCIADA_B'+LTRIM(RTRIM(STR(CB.NUMERO)))+'_SILO_'+LTRIM(RTRIM(STR(CS.Numero)))) AS TIPO_TAG
        'From cadastrosilos cs 	
        'Left Join AssociacaoSiloMP ass		ON ass.siloid = cs.ID      
        'Left Join CadastroBalancas cb		ON cb.id = cs.BalancaID     
        'Left Join CadastroMateriaPrima cmp	ON ass.CodigoMateriaPrima = cmp.CodigoMateriaPrima  
        'ORDER BY cb.Numero, cs.Numero 

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

            'FIX.SupervisorioCriarTagGrupo(nomeTagGrupo, FdsTemp)

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

                    'If Not IsDBNull(rdrRegistro("descricao")) Then

                    '    TagEscritaValor = rdrRegistro("descricao").ToString.Trim
                    '    Rotinas.EscreverEmLog("AtualizaAssociacoesSupervisorio(): Escrevendo no tag: " &
                    '                          My.Settings.SUPERVISORIO_NODE & "." & TagEscrita &
                    '                          " - Valor Escrita: " & rdrRegistro("descricao").Trim,
                    '                          ClasseRotinasDiversas.Tipo.Geral)

                    'Else

                    '    TagEscritaValor = " "
                    '    Rotinas.EscreverEmLog("AtualizaAssociacoesSupervisorio(): Escrevendo no tag: " &
                    '                          My.Settings.SUPERVISORIO_NODE & "." & TagEscrita &
                    '                          " - Valor Escrita: <VAZIO> ",
                    '                          ClasseRotinasDiversas.Tipo.Geral)

                    'End If

                    'FIX.SupervisorioAdicionarItemTagGrupo(contadorTagItem, TagEscrita, nomeTagGrupo, TagEscritaValor, FdsTemp)

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

            'FIX.SupervisorioEsreverTagItens(nomeTagGrupo, FdsTemp)

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


    Private Sub btnAtualizaTAGS_Click(sender As Object, e As EventArgs) Handles btnAtualizaTAGS.Click

        BancoDados.ComandoSQL = "INSERT INTO [dbo].[OpcTagItens] " &
        "  ([LinhaID]          " &
        "  ,[GrupoOpc]         " &
        "  ,[OpcItemID]        " &
        "  ,[Alias]            " &
        "  ,[OpcItem]          " &
        "  ,[Indexado]         " &
        "  ,[IndiceMatriz]     " &
        "  ,[TipoAcao]         " &
        "  ,[Valor]            " &
        "  ,[TipoTag]          " &
        "  ,[NumeroElementos]  " &
        "  ,[Limpar]           " &
        "  ,[Status])          " &
    " VALUES " &
    "      (@parLinhaID          " &
    "      ,@parGrupoOpc         " &
    "      ,@parOpcItemID        " &
    "      ,@parAlias           " &
    "      ,@parOpcItem          " &
    "      ,@parIndexado         " &
    "      ,@parIndiceMatriz     " &
    "      ,@parTipoAcao         " &
    "      ,@parValor            " &
    "      ,@parTipoTag          " &
    "      ,@parNumeroElementos  " &
    "      ,@parLimpar           " &
    "      ,@parStatus)          "
        BancoDados.CriaComandoSQL()
        BancoDados.AdicionarParametro("@CodigoMateriaPrima", " ")
        BancoDados.AdicionarParametro("@SiloID", AssociacaoSiloID)
        BancoDados.AdicionarParametro("@LinhaId", LinhaNumero)
        BancoDados.ExecutaSQL()

    End Sub


    '********** Descrições das MP's da Associação **********

    'MP1_B1_Desc.DATA
    '...
    'MP9_B1_Desc.DATA

    'MP1_B2_Desc.DATA
    '...
    'MP9_B2_Desc.DATA

    'MP1_B3_Desc.DATA
    '...
    'MP9_B3_Desc.DATA

    'MP1_B4_Desc.DATA
    '...
    'MP9_B4_Desc.DATA

    'MP1_B5_Desc.DATA
    '...
    'MP9_B5_Desc.DATA

    'MP1_B6_Desc.DATA
    '...
    'MP9_B6_Desc.DATA

    '    EscreverStringOPC(CONTROLE_PRODUTO_DESCRICAO_ID, lblProduto.Text.Trim)
    'EscreverStringOPC(CONTROLE_FORMULA_DESCRICAO_ID, lblFormula.Text.Trim)
    'EscreverNumeroOPC(CONTROLE_TAMANHO_BATCH_ID, Convert.ToDouble(lblTamanhoBatch.Text))




#End Region

End Class
