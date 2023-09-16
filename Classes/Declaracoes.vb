
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Net

''' <summary>
''' Modulo de declarações de variaveis publicas utilizadas no sistema
''' </summary>
''' <remarks></remarks>
Module Declaracoes

    Public Const LINHA_SALA_BINS = 1
    Public Const LINHA_SALA_CARROSSEL = 2

    Public Const NIVEL_ADMINISTRADOR = 1
    Enum LogTipo
        ArquivoTxt = 1
        BancoDeDados = 2
    End Enum

#Region "Variaveis Publicas"
    Public LogGravarTipo As LogTipo
    Public LogGeracaoAtivada As Boolean
    Public LogNomeArquivoTxt As String
    Public strTabelaVerificarPermissoes As String
    Public TrocarUsuario As Boolean
    Public strUsuarioLogado As String
    Public strTextoExibirFormMsg As String
    Public CodigoProducao As Double
    Public ProcessouTrocaSilo As Boolean
    Public oProducao(50, 34) As String

    Public TurnoSelecionadoID As Integer
    Public TurnoSelecionadoDescricao As String

    '-- dados do computador
    Public NomeDoComputador As String = My.Computer.Name.ToString
    Public HabilitarAcessoRemoto As Boolean = False

    Public SenhaDesenvolvedorParteInicial = "TN@"
    Public SenhaDesenvolvedor As String
    Public NivelAdministrador As Integer = 1
    Public DesenvolvedorLogado As Boolean
    Public Versao As String = "Versão 2.0.3 - 01/09/2020"

    Public NomeArquivoConfig As String = Application.StartupPath & "\CONFIG.INI"


    '-- estados da pesagem do batch
    Public Const PESAGEM_AGUARDANDO = 0
    Public Const PESAGEM_EM_ANDAMENTO = 1
    Public Const PESAGEM_CONCLUIDA = 2
    Public Const PESAGEM_CANCELADA = 3

    Public bolMostraErroMsgsBox As Boolean = False

    Public Configuracoes2 As New ConfiguracoesSistema

    Public ListaTurnos As New List(Of Turno)
    Public TurnoAtual As Turno

    Public UsuarioLogadoID As Integer
    Public UsuarioLogadoLogin As String

    Public LinhaNumero As Integer

    Public MateriaPrimaSelecionada As Boolean

#End Region

    ''' <summary>
    ''' Enum das colunas da tabela de produção
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ProducaoColunas
        ProducaoID = 0
        Item = 1
        CodigoFormula = 2
        DescricaoFormula = 3
        CodigoProduto = 4
        DescricaoProduto = 5
        CodigoMateriaPrima = 6
        DescricaoMateriaPrima = 7
        DescricaoReduzidaMateriaPrima = 8
        Quantidade = 9
        BalancaNumero = 10
        BalancaDescricao = 11
        SiloID = 12
        Associado = 13
        SiloNumero = 14
        SiloDescroicao = 15
        QtdeDesejada = 16
        QtdeReal = 17
        BatchNumero = 18
        TamanhoBatch = 19
        BatchsDesejado = 20
        OrdemProducao = 21
        ErroDosagemPercentual = 22
        ErroKg = 23
        ErroPercentual = 24
        BalancaIndice = 25
        LoteAtual = 26
        TagIndice = 27
        OrdemProducaoAbreviada = 28
        PercentualQuantidadeDesejada = 29
        TanqueSaldoAtual = 30
        SaldoInsuficiente = 31
        TamanhoSaco = 32
        NumeroSacos = 33
    End Enum

    ''' <summary>
    ''' Permite somente numeros digitado em um campo
    ''' </summary>
    ''' <param name="Keyascii"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SoNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890,.", Chr(Keyascii)) = 0 Then
            SoNumeros = 0
        Else
            SoNumeros = Keyascii
        End If

        Select Case Keyascii
            Case 8 ' backspace
                SoNumeros = Keyascii
            Case 13 ' enter
                SoNumeros = Keyascii
            Case 32 'space
                SoNumeros = Keyascii
        End Select

    End Function

    Public Function SoNumerosSinais(ByVal Keyascii As Short) As Short
        If InStr("1234567890,.-+", Chr(Keyascii)) = 0 Then
            SoNumerosSinais = 0
        Else
            SoNumerosSinais = Keyascii
        End If

        Select Case Keyascii
            Case 8 ' backspace
                SoNumerosSinais = Keyascii
            Case 13 ' enter
                SoNumerosSinais = Keyascii
            Case 32 'space
                SoNumerosSinais = Keyascii
        End Select

    End Function

    ''' <summary>
    ''' Carrega as configurações do sistema
    ''' </summary>
    ''' <param name="conexaoValida"></param>
    ''' <remarks></remarks>
    Public Sub CarregarConfiguracoesSistema(conexaoValida As SqlConnection)
        Dim strComando1 As String
        Dim cmdComandoSQL1 As SqlCommand
        Dim rdrRegistro1 As SqlDataReader

        strComando1 = "SELECT * FROM Configuracoes"

        cmdComandoSQL1 = New SqlCommand(strComando1, conexaoValida)

        rdrRegistro1 = cmdComandoSQL1.ExecuteReader
        rdrRegistro1.Read()
        If rdrRegistro1.HasRows Then
            If Not IsDBNull(rdrRegistro1("Log_Ativar")) Then
                LogGeracaoAtivada = IIf(rdrRegistro1("Log_Ativar") = 1, True, False)
            Else
                LogGeracaoAtivada = False
            End If

            If IsDBNull(rdrRegistro1("Log_GerarTxt_BD")) Then
                LogGravarTipo = LogTipo.ArquivoTxt
            Else
                If rdrRegistro1("Log_GerarTxt_BD") = 1 Then
                    LogGravarTipo = LogTipo.ArquivoTxt
                End If

                If rdrRegistro1("Log_GerarTxt_BD") = 2 Then
                    LogGravarTipo = LogTipo.BancoDeDados
                End If
            End If

            If Not IsDBNull(rdrRegistro1("Log_ArquivoTxt")) Then
                LogNomeArquivoTxt = rdrRegistro1("Log_ArquivoTxt").ToString.Trim
            Else
                LogNomeArquivoTxt = ""
            End If
        End If
        rdrRegistro1.Close()
        cmdComandoSQL1.Dispose()

    End Sub

    ''' <summary>
    ''' Gravar mensagem de log em arquivo txt
    ''' </summary>
    ''' <param name="strMensagemTexto">Mensagem a ser gravarda</param>
    ''' <remarks></remarks>
    Public Sub EscreveMsgLog(strMensagemTexto As String)

        If LogGeracaoAtivada Then

            If LogGravarTipo = LogTipo.ArquivoTxt Then

                GravarLogTxt(strMensagemTexto)

            End If

            'If LogGravarTipo = LogTipo.BancoDeDados Then

            '    GravarLogBD(strMensagemTexto, BDTemp)

            'End If

        End If

    End Sub

    ''' <summary>
    ''' Escreve mensagens de log no arquivo txt
    ''' </summary>
    ''' <param name="strTexto"></param>
    ''' <remarks></remarks>
    Public Sub GravarLogTxt(ByVal strTexto As String)
        On Error Resume Next
        FileOpen(9, LogNomeArquivoTxt & "\" & My.Application.Info.AssemblyName & "_" & Trim$(Now.ToString("ddMMyyyy")) & ".txt", OpenMode.Append)
        PrintLine(9, Now.ToString("HH:mm:ss"), SPC(2), strTexto)
        FileClose(9)
    End Sub

    Public Function CarregaTurnos(conexaoValida As SqlConnection) As List(Of Turno)
        Dim cmdTurnos As SqlCommand
        Dim rdrTurnos As SqlDataReader
        Dim aturnos As New List(Of Turno)

        Try

            cmdTurnos = New SqlCommand("SELECT * FROM CadastroTurnos", conexaoValida)
            rdrTurnos = cmdTurnos.ExecuteReader

            If rdrTurnos.HasRows Then

                While rdrTurnos.Read()

                    aturnos.Add(New Turno(rdrTurnos("ID") _
                                          , rdrTurnos("descricao") _
                                          , Convert.ToDateTime(rdrTurnos("inicio")).ToString("HH:mm:ss") _
                                          , Convert.ToDateTime(rdrTurnos("final")).ToString("HH:mm:ss") _
                                          , rdrTurnos("status") _
                                          )
                                )
                End While

            End If

            rdrTurnos.Close()
            cmdTurnos.Dispose()

        Catch ex As Exception

            Throw New ApplicationException("Erro ao carregar a tabela de turnos" + ex.Message & vbCrLf)

            aturnos = Nothing

        End Try

        Return aturnos

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

                ConfigTemp = New ConfiguracoesSistema( _
                                                        rdrRegistro("CARROSSEL_PESAGEM_MAXIMA"), _
                                                        rdrRegistro("NUMERO_MAXIMO_BATCHS_CRIAR_ORDEM"), _
                                                        rdrRegistro("CAR_HABILITAR_DIGITACAO"), _
                                                        rdrRegistro("CAR_EXIBIR_ALERTA_VERIF_EQUIPAMENTO"), _
                                                        rdrRegistro("CAR_BALANCA_CONFERENCIA_ABASTECIMENTO"), _
                                                        rdrRegistro("CAR_CONFIRMA_PESAGEM_CODIGO_TAMBOR_ITEM_LOTE"), _
                                                        rdrRegistro("CAR_EMITIR_TICKET_PESAGEM"), _
                                                        rdrRegistro("CAR_ENVIAR_IMPRESSORA_TICKET_PESAGEM"), _
                                                        rdrRegistro("CAR_NUMERO_COPIAS_TICKET_PESAGEM"), _
                                                        rdrRegistro("CAR_TICKET_PESAGEM_GERAR_PDF"), _
                                                        rdrRegistro("CAR_TICKET_PESAGEM_LOCAL_PDF"), _
                                                        rdrRegistro("ABASTECIMENTO_HABILITA_DIGITACAO"), _
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

    Public Function CarregaTurnoAtual(ByRef conexaoValida As SqlConnection) As Turno
        Dim cmdTurnos As SqlCommand
        Dim rdrTurnos As SqlDataReader
        Dim TurnoTemp As New Turno
        Dim parHoraValidar As DateTime = Now.ToString("HH:mm:ss")
        Dim sqlTurno As String = ""

        Try

            sqlTurno = "SELECT "
            sqlTurno += " * "
            sqlTurno += " FROM CadastroTurnos "
            sqlTurno += " ORDER BY id"

            cmdTurnos = New SqlCommand(sqlTurno, conexaoValida)
            rdrTurnos = cmdTurnos.ExecuteReader

            If rdrTurnos.HasRows Then

                While rdrTurnos.Read()

                    If parHoraValidar >= CDate(rdrTurnos("Inicio")).ToString("HH:mm:ss") _
                        And parHoraValidar <= CDate(rdrTurnos("Final")).ToString("HH:mm:ss") Then

                        With TurnoTemp
                            .ID = rdrTurnos("ID")
                            .Descricao = rdrTurnos("descricao")
                            .Inicio = Convert.ToDateTime(rdrTurnos("inicio"))
                            .Final = Convert.ToDateTime(rdrTurnos("final"))
                            .Status = rdrTurnos("status")
                        End With

                        'TurnoTemp = New Turno(rdrTurnos("ID") _
                        '                        , rdrTurnos("descricao") _
                        '                        , Convert.ToDateTime(rdrTurnos("inicio")) _
                        '                        , Convert.ToDateTime(rdrTurnos("final")) _
                        '                        , rdrTurnos("status")
                        '                    )

                        Exit While

                        '-- turno passa de um dia pro outro
                    ElseIf parHoraValidar >= CDate(rdrTurnos("Inicio")).ToString("HH:mm:ss") _
                        And CDate(rdrTurnos("Inicio")).ToString("HH:mm.ss") > CDate(rdrTurnos("Final")).ToString("HH:mm:ss") Then

                        'TurnoTemp = New Turno(rdrTurnos("ID") _
                        '                        , rdrTurnos("descricao") _
                        '                        , Convert.ToDateTime(rdrTurnos("inicio")) _
                        '                        , Convert.ToDateTime(rdrTurnos("final")) _
                        '                        , rdrTurnos("status")
                        '                    )

                        With TurnoTemp
                            .ID = rdrTurnos("ID")
                            .Descricao = rdrTurnos("descricao")
                            .Inicio = Convert.ToDateTime(rdrTurnos("inicio"))
                            .Final = Convert.ToDateTime(rdrTurnos("final"))
                            .Status = rdrTurnos("status")
                        End With

                        Exit While

                    End If

                End While

            End If

            rdrTurnos.Close()
            cmdTurnos.Dispose()

        Catch ex As Exception

            Throw New ApplicationException("Erro ao carregar a tabela de turnos" + ex.Message & vbCrLf)

        End Try

        Return TurnoTemp

    End Function

End Module
