
Imports System.Data.SqlClient

''' <summary>
''' Classe para acesso ao banco de dados, neste caso SQL Server
''' </summary>
''' <remarks></remarks>
Public Class ClasseBancoDados
    Private ConexaoBD As SqlConnection
    Private Comandos As SqlCommand
    Private DataAdapter As SqlDataAdapter
    Private strComandoSQL, strOperacao, strChavePesquisa As String

    'construtor
    Public Sub New(ByVal strConexao As String)

        ConexaoBD = New SqlConnection(strConexao)

        strOperacao = ""

    End Sub

    ''' <summary>
    ''' Abertura do banco de dados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Abrir()

        Try

            ConexaoBD.Open()

        Catch excecao As SqlException

            'formErroNaRede.ShowDialog()
            'formErroNaRede.Dispose()

            MsgBox("NÃO FOI POSSÍVEL CONECTAR AO BANCO DE DADOS." & vbCrLf & vbCrLf & _
                   "Verifique se há algum problema com rede." & vbCrLf & vbCrLf & _
                   "Uma exceção foi gerada: " + excecao.Message & vbCrLf & vbCrLf & "Será encerrado.", _
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, _
                   "Aviso")
            End

        Catch ex As Exception

            MsgBox("NÃO FOI POSSÍVEL CONECTAR AO BANCO DE DADOS." & vbCrLf & vbCrLf & _
                   "Verifique se há algum problema com rede." & vbCrLf & vbCrLf & _
                   "Uma exceção foi gerada: " + ex.Message & vbCrLf & vbCrLf & "Será encerrado.", _
                   MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, _
                   "Aviso")
            End
        End Try

    End Sub

    ''' <summary>
    ''' Fechamento do banco de dados
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Fechar()

        ConexaoBD.Close()

    End Sub

    ''' <summary>
    ''' Ajusta membro da operacao
    ''' </summary>
    ''' <value>Tipo de operação no cadastro</value>
    ''' <returns>Retorna o tipo de operação</returns>
    ''' <remarks></remarks>
    Public Property Operacao As String

        Get
            Return strOperacao
        End Get

        Set(value As String)
            strOperacao = value
        End Set

    End Property

    ''' <summary>
    ''' Executa um script sql e retorna uma DataTable
    ''' </summary>
    ''' <param name="parConexao">Conexao ativa</param>
    ''' <param name="parScriptSelect">Script SQL, select</param>
    ''' <param name="parTabelaNome">Nome da tabela</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RetornaDataTable(ByRef parConexao As SqlConnection, _
                                      ByVal parScriptSelect As String, _
                                      ByVal parTabelaNome As String) As DataTable
        Dim comando As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dataTableTemp As New DataTable

        Try

            comando.Connection = parConexao
            comando.CommandType = CommandType.Text
            comando.CommandText = parScriptSelect

            da.SelectCommand = comando
            da.Fill(ds, parTabelaNome)

            dataTableTemp = ds.Tables(parTabelaNome)

        Catch ex As Exception

            Throw New Exception("Falha ao carregar o DataTable")

        End Try

        Return dataTableTemp

    End Function

    'ajusta o membro "strComandoSQL"
    Public Property ComandoSQL As String

        Get
            Return strComandoSQL
        End Get

        Set(value As String)

            strComandoSQL = value

        End Set

    End Property

    'cria o objeto cmdComandoSQL
    Public Sub CriaComandoSQL()

        Comandos = New SqlCommand(strComandoSQL, ConexaoBD)

    End Sub

    'apaga todos os parametros que existem no objeto comandos
    Public Sub LimparParametros()

        Comandos.Parameters.Clear()

    End Sub

    'adiciona o parametro ao objeto comandos
    Public Sub AdicionarParametro(ByVal strNomeParametro As String, ByVal strValor As String)
        Try

            Comandos.Parameters.AddWithValue(strNomeParametro, strValor)

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execucao: " + excecao.Message)

        End Try
    End Sub

    'adiciona o parametro ao objeto comandos
    Public Sub AdicionarParametroNumero(ByVal strNomeParametro As String, ByVal dblValor As Double)
        Try

            Comandos.Parameters.AddWithValue(strNomeParametro, dblValor)

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execucao: " + excecao.Message)

        End Try
    End Sub

    'adiciona o parametro ao objeto comandos
    Public Sub AdicionarParametroNumeroInteiro(ByVal strNomeParametro As String, ByVal intValor As Integer)

        Try

            Comandos.Parameters.AddWithValue(strNomeParametro, intValor)

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execucao: " + excecao.Message)

        End Try

    End Sub

    'adiciona o parametro ao objeto comandos
    Public Sub AdicionarParametroString(ByVal strNomeParametro As String, ByVal strValor As String)

        Try

            Comandos.Parameters.AddWithValue(strNomeParametro, strValor)

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execucao: " + excecao.Message)

        End Try

    End Sub

    'adiciona o parametro ao objeto comandos
    Public Sub AdicionarParametroDataHora(ByVal strNomeParametro As String, ByVal datValor As DateTime)

        Try

            Comandos.Parameters.AddWithValue(strNomeParametro, datValor)

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execucao: " + excecao.Message)

        End Try

    End Sub

    'executa o comando de dados
    Public Sub ExecutaSQL()

        Try

            Comandos.ExecuteNonQuery()

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execução: " + excecao.Message)

        End Try

        Comandos.Dispose()

    End Sub

    'executa o comando de dados
    Public Function ExecutaSQL_ComRetorno() As Double
        Dim dblRetorno As Double = 0

        Try

            dblRetorno = Comandos.ExecuteScalar()

        Catch excecao As SqlException

            MsgBox("Erro em tempo de execução: " + excecao.Message)


        End Try

        Comandos.Dispose()

        ExecutaSQL_ComRetorno = dblRetorno

    End Function

    'retorna a conexao criada com o banco de dados
    Public Function ConexaoAtiva()
        Return ConexaoBD
    End Function

    'cria objeto DataAdapter
    Public Sub CriaDataAdapter()
        DataAdapter = New SqlDataAdapter
    End Sub

    'atribui a propriedade SelectCommand de DataTable e conteudo de Comandos
    Public Sub DataAdapterComando()
        DataAdapter.SelectCommand = Comandos
    End Sub

    'preencha uma tabela com dados retornados
    Public Sub PreencherDataSet(ByVal MeuDataSet As System.Data.DataTable)
        DataAdapter.Fill(MeuDataSet)
    End Sub

End Class
