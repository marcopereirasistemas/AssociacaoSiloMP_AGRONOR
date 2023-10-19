
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.NetworkInformation

''' <summary>
''' Classe com rotinas diversas utilizadas no sistema.
''' </summary>
''' <remarks></remarks>
Public Class ClasseRotinasDiversas

    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    ''' <summary>
    ''' Parametro que define o tipo de log
    ''' </summary>
    ''' <remarks></remarks>
    Enum Tipo
        Simples = 1
        Geral = 2
        Traco = 3
    End Enum

    Enum enumEstiloTraco
        Simples = 1
        Duplo = 2
    End Enum

#Region "Funções INI"

    Public Function LeArquivoINI(ByVal parNomeArquivoINI As String,
                                  ByVal parSecao As String,
                                  ByVal parChave As String,
                                  ByVal parValorPadrao As String) As String

        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        GetPrivateProfileString(parSecao,
                                parChave,
                                parValorPadrao,
                                string_builder,
                                MAX_LENGTH,
                                parNomeArquivoINI)

        Return string_builder.ToString()

    End Function

    Public Sub EscreverArquivoINI(ByVal parSecao As String,
                                  ByVal parChave As String,
                                  ByVal parValor As String,
                                  ByVal parNomeArquivoINI As String)

        WritePrivateProfileString(parSecao, parChave, parValor.Trim, parNomeArquivoINI)

    End Sub

#End Region

#Region "Funções 2018"
    ''' <summary>
    ''' Verifica se um arquivo passado como parametro existe em uma pasta
    ''' </summary>
    ''' <param name="parArquivoVerificar">O nome, extensao e caminho do arquivo deve ser </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ArquivoExiste(ByVal parArquivoVerificar As String) As Boolean

        Return My.Computer.FileSystem.FileExists(parArquivoVerificar)

    End Function

    ''' <summary>
    ''' Verifica se um arquivo existe na pasta da aplicacao
    ''' </summary>
    ''' <param name="parArquivoVerificar"></param>
    ''' <returns>TRUE = arquivo existe, FALSE = arquivo nao existe</returns>
    Public Function ArquivoExistePastaAplicacao(ByVal parArquivoVerificar As String) As Boolean

        Dim localFolder As String = Application.StartupPath & "\"

        Return My.Computer.FileSystem.FileExists(localFolder & parArquivoVerificar)

    End Function

    Public Sub EscreverArquivoTXT(ByVal NomeArquivo As String, ByVal TextoEscrever As String)

        FileOpen(9, NomeArquivo, OpenMode.Append)

        PrintLine(9, TextoEscrever)

        FileClose(9)

    End Sub

    Public Function StatusIP(ByVal parIP As String) As Boolean
        Dim ping As New Ping()
        Dim reply As PingReply
        Dim retornoStatusIP As Boolean = True

        Try
            reply = ping.Send(parIP, 1000)

            Select Case reply.Status

                Case IPStatus.Success

                    retornoStatusIP = True

                Case IPStatus.BadDestination

                    retornoStatusIP = False

                Case IPStatus.TimedOut

                    retornoStatusIP = False

            End Select

        Catch ex As Exception

            MsgBox("Erro ao verificar o status do IP: " & parIP)

            retornoStatusIP = False

        End Try

        Return retornoStatusIP

    End Function

    Public Sub AjustarTamanhoForm(ByRef FormularioTemp As Form, ByVal Altura As Boolean, Largura As Boolean)

        'If Altura Then
        '    FormularioTemp.Height = formPrincipal.Height - 50
        'End If

        'If Largura Then
        '    FormularioTemp.Top = formPrincipal.Top + 25
        'End If

    End Sub

    Public Function retornaIP() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim ipEntry As IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        Dim retornoNomeComputador As String

        retornoNomeComputador = ""

        For Each ipAddress As IPAddress In ipEntry.AddressList
            If ipAddress.AddressFamily.ToString() = "InterNetwork" Then
                retornoNomeComputador = ipAddress.ToString()
            End If
        Next

        Return retornoNomeComputador

    End Function

    Public Sub AjustarConfiguracaoRegional()

        'Seta a configuração do programa para português e altera o formato numerico para decimal = "." e agrupador = ","

        'Altera para português
        System.Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("pt-BR", False)

        'Altera o separador de decimal para . quando moeda
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."

        'Altera o separador de agrupamento para , quando moeda
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ""

        'Altera o separador de decimal para . quando número
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        'Altera o separador de agrupamento para , quando número
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ""

    End Sub

#End Region

    Public Sub EscreverEmLog(ByVal strTexto As String,
                             Optional intOutroTipo As Tipo = Tipo.Geral,
                             Optional iQtdeTracos As Integer = 80,
                             Optional iTipoTraco As enumEstiloTraco = enumEstiloTraco.Simples)

        Dim TracoString As String = "-"
        Dim iContaTraco As Integer = 0
        Dim sEstiloTraco As String = ""

        If iTipoTraco = enumEstiloTraco.Simples Then
            sEstiloTraco = "-"
        Else
            sEstiloTraco = "="
        End If

        On Error Resume Next

        FileOpen(9, Application.StartupPath & "\" & My.Application.Info.AssemblyName & "_" & Trim$(Now.ToString("ddMMyyyy")) & ".txt", OpenMode.Append)

        If intOutroTipo = Tipo.Geral Then

            PrintLine(9, Now.ToString("HH:mm:ss"), SPC(2), strTexto)

        ElseIf intOutroTipo = Tipo.Simples Then

            PrintLine(9, "")

        ElseIf intOutroTipo = Tipo.Traco Then

            For iContaTraco = 1 To iQtdeTracos
                TracoString += sEstiloTraco
            Next

            PrintLine(9, TracoString)

        End If

        FileClose(9)

    End Sub

    Public Function RetornaValorTabelaBD(ByVal parNomeTabela As String,
                                         ByVal parCampo As String,
                                         ByVal parWhere As String,
                                         ByRef parCon As SqlConnection) As String

        Dim strComandoSQL As String
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader
        Dim stringConexao As String
        Dim ValorRetornoTmp As String = ""

        Try

            stringConexao = My.Settings.JOFEGE_ARGAMASSA_ConnectionString

            strComandoSQL = "SELECT  " & parCampo
            strComandoSQL += " FROM  " & parNomeTabela
            If parWhere <> "" Then
                strComandoSQL += " WHERE " & parWhere
            End If
            cmdComandoSQL = New SqlCommand(strComandoSQL, parCon)

            rdrRegistro = cmdComandoSQL.ExecuteReader()
            rdrRegistro.Read()
            If Not IsDBNull(rdrRegistro(parCampo)) Then
                ValorRetornoTmp = rdrRegistro(parCampo)
            End If

            rdrRegistro.Close()
            cmdComandoSQL.Dispose()

        Catch ex As Exception

            EscreverEmLog("Erro ao carregar a descricao da linha configurada.", Tipo.Geral, 80, enumEstiloTraco.Simples)

            ValorRetornoTmp = ""

        End Try

        Return ValorRetornoTmp

    End Function

    ''' <summary>
    ''' Retorna se o usuario possui ou nao acesso ao botão do formulario de cadastro
    ''' </summary>
    ''' <param name="strTabela">Tabela do banco de dados a verifica o acesso</param>
    ''' <param name="strBotao">Botão a validar</param>
    ''' <param name="intNivelAcesso">Nivel de acesso</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HabilitaBotao(ByVal strTabela As String, ByVal strBotao As String, ByVal intNivelAcesso As Integer) As Boolean

        Dim strComandoSQL, strNomeCampo As String
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader
        Dim BancoDados As ClasseBancoDados
        Dim blnRetorno As Boolean
        Dim stringConexao As String

        blnRetorno = True
        strNomeCampo = ""

        stringConexao = My.Settings.JOFEGE_ARGAMASSA_ConnectionString

        BancoDados = New ClasseBancoDados(stringConexao)

        BancoDados.Abrir()

        strComandoSQL = "SELECT * FROM CadNivelAcesso WHERE Nivel_Acesso = " + intNivelAcesso.ToString

        cmdComandoSQL = New SqlCommand(strComandoSQL, BancoDados.ConexaoAtiva)

        rdrRegistro = cmdComandoSQL.ExecuteReader()
        rdrRegistro.Read()

        If strBotao.ToUpper = "BTNADICIONAR" Or strBotao.ToUpper = "BTNASSOCIAR" Then

            strNomeCampo = "Cadastrar"

        ElseIf strBotao.ToUpper = "BTNEDITAR" Then

            strNomeCampo = "Editar"

        ElseIf strBotao.ToUpper = "BTNEXCLUIR" Or strBotao.ToUpper = "BTNDESASSOCIAR" Then

            strNomeCampo = "Excluir"

        End If

        If strTabela.ToUpper = "CadUsuarios".ToUpper Then

            strNomeCampo = strNomeCampo + "_usuario"

        ElseIf strTabela.ToUpper = "CadastroMateriaPrima".ToUpper Then

            strNomeCampo = strNomeCampo + "_MateriaPrima"

        ElseIf strTabela.ToUpper = "CadastroBalancas".ToUpper Then

            strNomeCampo = strNomeCampo + "_Balancas"

        ElseIf strTabela.ToUpper = "CadastroDestinos".ToUpper Then

            strNomeCampo = strNomeCampo + "_Destinos"

        ElseIf strTabela.ToUpper = "CadastroFormulas".ToUpper Then

            strNomeCampo = strNomeCampo + "_Formulas"

        ElseIf strTabela.ToUpper = "CadastroMisturadores".ToUpper Then

            strNomeCampo = strNomeCampo + "_Misturador"

        ElseIf strTabela.ToUpper = "CadastroMoegas".ToUpper Then

            strNomeCampo = strNomeCampo + "_Moegas"

        ElseIf strTabela.ToUpper = "CadastroOrdensProducao".ToUpper Then

            strNomeCampo = strNomeCampo + "_OrdensProducao"

        ElseIf strTabela.ToUpper = "CadastroProdutos".ToUpper Then

            strNomeCampo = strNomeCampo + "_Produto"

        ElseIf strTabela.ToUpper = "CadastroSilos".ToUpper Then

            strNomeCampo = strNomeCampo + "_Silo"

        ElseIf strTabela.ToUpper = "Sistema".ToUpper Then

            strNomeCampo = strNomeCampo + "_Sistema"

        ElseIf strTabela.ToUpper = "Relatorios".ToUpper Then

            strNomeCampo = strNomeCampo + "_Relatorio"

        ElseIf strTabela.ToUpper = "AssociacaoSiloMP".ToUpper Then

            strNomeCampo = strNomeCampo + "_Associacao"

        End If

        If Not IsDBNull(rdrRegistro(strNomeCampo).ToString) Then

            blnRetorno = IIf(rdrRegistro(strNomeCampo).ToString = "N" Or rdrRegistro(strNomeCampo).ToString = "", False, True)

        Else

            blnRetorno = False

        End If

        rdrRegistro.Close()
        cmdComandoSQL.Dispose()

        BancoDados.Fechar()
        BancoDados = Nothing

        Return blnRetorno

    End Function


    ''' <summary>
    ''' Altera a cor do fundo quando o controle recebe o foco
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <remarks></remarks>
    Public Sub CorEntrada(ByVal Sender As Object)
        Dim Objeto As Object

        If (TypeOf Sender Is TextBox) Then
            Objeto = CType(Sender, TextBox)
        Else
            Objeto = CType(Sender, MaskedTextBox)
        End If


        If Objeto.tag = 0 Then
            Objeto.backcolor = Color.Yellow
        Else
            Objeto.backcolor = Color.Aqua
        End If

    End Sub

    ''' <summary>
    ''' Altera a cor do fundo quando o controle perde o foco
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Public Sub CorSaida(ByVal sender As Object)
        Dim Objeto As Object

        If (TypeOf sender Is TextBox) Then
            Objeto = CType(sender, TextBox)
        Else
            Objeto = CType(sender, MaskedTextBox)
        End If

        Objeto.backcolor = Color.White
    End Sub

    ''' <summary>
    ''' verifica se o  preenchimento de controle é obrigatório
    ''' </summary>
    ''' <param name="Objeto">Valida o campo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChecarObrigatorio(ByVal Objeto As Object) As Boolean
        Dim strValorCampo As String = Objeto.text.ToString
        Dim blnRetorno As Boolean = True

        If Objeto.tag = 1 Then

            If (Trim(strValorCampo) = "") Or (strValorCampo = "     -   ") Then

                MsgBox("É obrigatório o preenchimento desse campo !", MsgBoxStyle.Exclamation)

                blnRetorno = False

                Objeto.focus()

            End If

        End If

        Return blnRetorno

    End Function

    'limpa todos os controles Textbox
    Public Sub LimparCampos(ByVal Controle As Control)

        For Each objeto As Control In Controle.Controls

            If objeto.Controls.Count > 0 Then

                LimparCampos(objeto)

            Else

                If (TypeOf objeto Is TextBox) Then

                    objeto.Text = ""

                End If

                If (TypeOf objeto Is CheckBox) Then  ' Or (TypeOf objeto Is RadioButton) Then

                    EstadoControleChekBox(objeto, False)

                End If

            End If

        Next

    End Sub

    Private Sub EstadoControleChekBox(objChk As CheckBox, bolEstadoChecked As Boolean)
        objChk.Checked = bolEstadoChecked
    End Sub

    ''' <summary>
    ''' Bloqueia os controles de entrada de dados
    ''' </summary>
    ''' <param name="Controle">O controle do formulario a ser bloqueado</param>
    ''' <remarks></remarks>
    Public Sub BloquearCampo(ByVal Controle As System.Object)
        Dim Objeto As Object

        If (TypeOf Controle Is TextBox) Then

            Objeto = CType(Controle, TextBox)
            Controle.readonly = True

        ElseIf (TypeOf Controle Is MaskedTextBox) Then

            Objeto = CType(Controle, MaskedTextBox)
            Controle.readonly = True

        ElseIf (TypeOf Controle Is ComboBox) _
                Or (TypeOf Controle Is CheckBox) _
                Or (TypeOf Controle Is NumericUpDown) _
                Or (TypeOf Controle Is RadioButton) _
                Or (TypeOf Controle Is DateTimePicker) Then

            Controle.enabled = False

        End If

    End Sub

    ''' <summary>
    ''' desbloqueia os controles de entrada de dados
    ''' </summary>
    ''' <param name="Controle">O controle a ser desbloqueado</param>
    ''' <remarks></remarks>
    Public Sub DesbloquearCampo(ByVal Controle As System.Object)

        'Controle.readonly = False
        Dim Objeto As Object
        If (TypeOf Controle Is TextBox) Then

            Objeto = CType(Controle, TextBox)
            Controle.readonly = False

        ElseIf (TypeOf Controle Is MaskedTextBox) Then

            Objeto = CType(Controle, MaskedTextBox)
            Controle.readonly = False

        ElseIf (TypeOf Controle Is ComboBox) _
            Or (TypeOf Controle Is CheckBox) _
            Or (TypeOf Controle Is NumericUpDown) _
            Or (TypeOf Controle Is RadioButton) _
            Or (TypeOf Controle Is DateTimePicker) Then

            Controle.enabled = True

        End If

    End Sub

    'converte uma data no formato DD/MM/AAAA para AAAA/MM/DD, aceita pelo sqlServer
    Public Function DataInvertida(ByVal strData As String)
        Dim strNovaData As String
        strNovaData = strData.Substring(6, 4) + "/" + strData.Substring(3, 2) + "/" + strData.Substring(0, 2)
        Return strNovaData
    End Function

    'converte uma data no formato DD/MM/AAAA para AAAA/MM/DD, aceita pelo sqlServer
    Public Function DataHoraInvertida(ByVal strData As String)
        Dim strNovaData As String
        '12/08/2015 19:24:00
        strNovaData = strData.Substring(6, 4) + "/" + strData.Substring(3, 2) + "/" + strData.Substring(0, 2) + " " + strData.Substring(11, 8)
        Return strNovaData
    End Function

    'converte uma data no formato DD/MM/AAAA para AAAA/MM/DD, aceita pelo sqlServer
    Public Function DataHoraSQL(ByVal strData As String)
        Dim strNovaData As String
        '12/08/2015 19:24:00
        '20150812 19:24:00
        strNovaData = strData.Substring(6, 4) + strData.Substring(3, 2) + strData.Substring(0, 2) + " " + strData.Substring(11, 8)
        Return strNovaData
    End Function

    ' Troca o ponto por vírgula nas casas decimais
    Public Sub PontoParaVirgula(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim strDigitos As String = "0123456789"

        If e.KeyChar <> Microsoft.VisualBasic.Chr(8) Then
            If e.KeyChar = "." Then
                System.Windows.Forms.SendKeys.Send(",")
            Else
                If InStr(strDigitos, e.KeyChar) = 0 Then
                    e = Nothing
                End If
            End If
        End If
    End Sub

    ' Troca a vírgula nas casas decimais por ponto
    Public Function VirgulaParaPonto(ByVal strValor As String)
        Dim ValorTemp As String
        ValorTemp = strValor.Replace(",", ".")
        Return ValorTemp
    End Function

    ' Limpa controles CheckBox atribuindo o valor False à propriedade Checked
    Public Sub LimparCheckBox(ByVal Controle As Control)

        For Each Objeto As Object In Controle.Controls

            If Objeto.Controls.Count > 0 Then

                LimparCheckBox(Objeto)

            Else

                If (TypeOf Objeto Is CheckBox) Then

                    Objeto.Checked = False

                End If

            End If

        Next Objeto

    End Sub

    Public sAppDPoint As String
    Public sAppTPoint As String

    Function RemoveFormatacao(ByVal Value As String) As Double

        Dim I As Integer
        Dim s1 As String = ""
        Dim s2 As String = ""
        Dim FlagDecimalPoint As Boolean

        FlagDecimalPoint = True

        If Trim(Value) = "" Then
            RemoveFormatacao = 0
            Exit Function
        End If

        If Not IsNumeric(Value) Then
            RemoveFormatacao = 0
            Exit Function
        End If

        For I = Len(Value) To 1 Step -1

            s1 = Mid(Value, I, 1)

            Select Case s1
                Case sAppDPoint
                    If FlagDecimalPoint Then
                        s2 = s1 + s2
                        FlagDecimalPoint = False
                    End If
                Case sAppTPoint
                    If FlagDecimalPoint Then
                        s2 = sAppDPoint + s2
                        FlagDecimalPoint = False
                    End If
                Case Else
                    s2 = s1 + s2
            End Select
        Next

        RemoveFormatacao = CDbl(s2)

    End Function

    Function Formatar(ByVal Value As Double,
                        Optional nDecimal As Byte = 2,
                        Optional FlagThousand As Boolean = False,
                        Optional FlagNotZeros As Boolean = False) As String

        Dim I As Integer
        Dim s1 As String = ""
        Dim s2 As String = ""
        Dim sValue As String = ""
        Dim sMask As String = ""

        Dim FlagDecimalPoint As Boolean

        If String.IsNullOrEmpty(Value) Then
            Formatar = ""
            Exit Function
        End If

        If Value = 0 And FlagNotZeros = True Then
            Formatar = ""
            Exit Function
        End If

        sMask = "##0"
        FlagDecimalPoint = False

        If nDecimal > 0 Then

            FlagDecimalPoint = True

            '//___Number decimal digits
            For I = 1 To nDecimal

                If I = 1 Then
                    sMask = sMask + "."
                End If

                sMask = sMask + "0"
            Next
        End If

        '//___Thousand separator
        If FlagThousand Then
            sMask = "#," + sMask
        End If

        sValue = Format(Math.Round(Value, nDecimal), sMask)

        For I = Len(sValue) To 1 Step -1

            s1 = Mid(sValue, I, 1)

            Select Case s1
                Case "."
                    If FlagDecimalPoint Then
                        s2 = "," + s2
                        FlagDecimalPoint = False
                    Else
                        s2 = s1 + s2
                    End If
                Case ","
                    If FlagDecimalPoint Then
                        s2 = s1 + s2
                        FlagDecimalPoint = False
                    Else
                        s2 = "." + s2
                    End If
                Case Else
                    s2 = s1 + s2
            End Select
        Next

        Formatar = s2

    End Function

    Public Function ConfiguracoesSistema(ByRef ConexaoAtiva As SqlConnection) As ConfiguracoesSistema
        Dim strComandoSQL As String
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader
        Dim retObjetoTemp As Object = Nothing
        Dim ConfigTemp As New ConfiguracoesSistema

        Try

            strComandoSQL = "SELECT "
            strComandoSQL += " * "
            strComandoSQL += " FROM ConfiguracoesCarrossel "
            cmdComandoSQL = New SqlCommand(strComandoSQL, ConexaoAtiva)

            rdrRegistro = cmdComandoSQL.ExecuteReader()
            rdrRegistro.Read()

            If rdrRegistro.HasRows() Then

                ConfigTemp = New ConfiguracoesSistema(
                                                        rdrRegistro("CARROSSEL_PESAGEM_MAXIMA"),
                                                        rdrRegistro("NUMERO_MAXIMO_BATCHS_CRIAR_ORDEM"),
                                                        rdrRegistro("CAR_HABILITAR_DIGITACAO"),
                                                        rdrRegistro("CAR_EXIBIR_ALERTA_VERIF_EQUIPAMENTO"),
                                                        rdrRegistro("CAR_BALANCA_CONFERENCIA_ABASTECIMENTO"),
                                                        rdrRegistro("CAR_CONFIRMA_PESAGEM_CODIGO_TAMBOR_ITEM_LOTE"),
                                                        rdrRegistro("CAR_EMITIR_TICKET_PESAGEM"),
                                                        rdrRegistro("CAR_ENVIAR_IMPRESSORA_TICKET_PESAGEM"),
                                                        rdrRegistro("CAR_NUMERO_COPIAS_TICKET_PESAGEM"),
                                                        rdrRegistro("CAR_TICKET_PESAGEM_GERAR_PDF"),
                                                        rdrRegistro("CAR_TICKET_PESAGEM_LOCAL_PDF"),
                                                        rdrRegistro("ABASTECIMENTO_HABILITA_DIGITACAO"),
                                                        IIf(IsDBNull(rdrRegistro("NOME_IMPRESSORA_PADRAO")), "", rdrRegistro("NOME_IMPRESSORA_PADRAO"))
                                                    )

            End If

            cmdComandoSQL.Dispose()
            rdrRegistro.Close()

            retObjetoTemp = ConfigTemp

        Catch ex As Exception

            MsgBox("ConfiguracoesSistema() gerou o erro: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Aviso")

        End Try

        Return retObjetoTemp

    End Function

    Public Function RetornaCapacidadeMaximaMisturador(ByVal IdMisturadorTemp As Integer, ByRef ConexaoAtiva As SqlConnection) As Double
        Dim strComandoSQLtemp As String = ""
        Dim cmdComandoSQL As SqlCommand
        Dim rdrRegistro As SqlDataReader
        Dim retCapacidadeMaxima As Double = 0
        Dim sqlCapMaxMist As String = ""

        Try
            sqlCapMaxMist = "SELECT "
            sqlCapMaxMist += "PesoMaximo "
            sqlCapMaxMist += "FROM CadastroMisturadores "
            sqlCapMaxMist += "WHERE id = " & IdMisturadorTemp

            cmdComandoSQL = New SqlCommand(sqlCapMaxMist, ConexaoAtiva)
            rdrRegistro = cmdComandoSQL.ExecuteReader()
            rdrRegistro.Read()
            If rdrRegistro.HasRows() Then
                If Not String.IsNullOrEmpty(rdrRegistro("PesoMaximo")) Then
                    retCapacidadeMaxima = Convert.ToDouble(rdrRegistro("PesoMaximo")).ToString("0.000")
                End If
            End If
            rdrRegistro.Close()
            cmdComandoSQL.Dispose()

        Catch ex As Exception

            MsgBox("Erro: " & ex.Message,
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly,
                   "RetornaCapacidadeMaximaMisturador")

        End Try
        Return retCapacidadeMaxima
    End Function

End Class
