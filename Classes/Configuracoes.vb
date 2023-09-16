Public Class Configuracoes

    Public Sub Carregar()

    End Sub
    Private _unidadeCodigo As String
    Public Property UnidadeCodigo() As String
        Get
            Return _unidadeCodigo
        End Get
        Set(ByVal value As String)
            _unidadeCodigo = value
        End Set
    End Property

    Private _unidadeFilial As String
    Public Property UnidadeFilial() As String
        Get
            Return _unidadeFilial
        End Get
        Set(ByVal value As String)
            _unidadeFilial = value
        End Set
    End Property

    Private _unidadeDescricao As String
    Public Property UnidadeDescricao() As String
        Get
            Return _unidadeDescricao
        End Get
        Set(ByVal value As String)
            _unidadeDescricao = value
        End Set
    End Property

    Private _unidadeExibirLogo As Integer
    Public Property UnidadeExibirLogo() As Integer
        Get
            Return _unidadeExibirLogo
        End Get
        Set(ByVal value As Integer)
            _unidadeExibirLogo = value
        End Set
    End Property


    Private _unidadeLogo As String
    Public Property UnidadeLogo() As String
        Get
            Return _unidadeLogo
        End Get
        Set(ByVal value As String)
            _unidadeLogo = value
        End Set
    End Property


    Private _logAtivar As Integer
    Public Property LogAtivar() As Integer
        Get
            Return _logAtivar
        End Get
        Set(ByVal value As Integer)
            _logAtivar = value
        End Set
    End Property

    Private _logGerarTxtBD As Integer
    Public Property LogGerarTxtBD() As Integer
        Get
            Return _logGerarTxtBD
        End Get
        Set(ByVal value As Integer)
            _logGerarTxtBD = value
        End Set
    End Property

    Private _logArquivoTxt As String
    Public Property LogArquivoTxt() As String
        Get
            Return _logArquivoTxt
        End Get
        Set(ByVal value As String)
            _logArquivoTxt = value
        End Set
    End Property

    Public Enum SimuladorIfix
        Simulador = 1
        IFix = 2
    End Enum

    Private _supervidorioSimuladorIfix As SimuladorIfix
    Public Property SupervisorioSimuladorIfix() As SimuladorIfix
        Get
            Return _supervidorioSimuladorIfix
        End Get
        Set(ByVal value As SimuladorIfix)
            _supervidorioSimuladorIfix = value
        End Set
    End Property

    Private _supervisorioNode As String
    Public Property SupervisorioNode() As String
        Get
            Return _supervisorioNode
        End Get
        Set(ByVal value As String)
            _supervisorioNode = value
        End Set
    End Property

    Private _producaoOrdemAutoManual As Integer
    Public Property ProducaoOrdemAutoManual() As Integer
        Get
            Return _producaoOrdemAutoManual
        End Get
        Set(ByVal value As Integer)
            _producaoOrdemAutoManual = value
        End Set
    End Property

    Private _producaoEnvioOrdemCadastro As Integer
    Public Property ProducaoEnvioOrdemCadastro() As Integer
        Get
            Return _producaoEnvioOrdemCadastro
        End Get
        Set(ByVal value As Integer)
            _producaoEnvioOrdemCadastro = value
        End Set
    End Property

    Private _producaoHabilitarTrocaSilo As String
    Public Property ProducaoHabilitarTrocaSilo() As String
        Get
            Return _producaoHabilitarTrocaSilo
        End Get
        Set(ByVal value As String)
            _producaoHabilitarTrocaSilo = value
        End Set
    End Property

    Private _producaoHabilitarTrocarLote As Integer
    Public Property ProducaoHabilitarTrocarLote() As Integer
        Get
            Return _producaoHabilitarTrocarLote
        End Get
        Set(ByVal value As Integer)
            _producaoHabilitarTrocarLote = value
        End Set
    End Property



    Public Enum HabilitarLeitorDigitacao
        Leitor = 1
        Digitacao = 2
    End Enum

    Private _producaoHabilitarLeitorDigitacao As HabilitarLeitorDigitacao
    Public Property ProducaoHabilitarLeitorDigitacao() As HabilitarLeitorDigitacao
        Get
            Return _producaoHabilitarLeitorDigitacao
        End Get
        Set(ByVal value As HabilitarLeitorDigitacao)
            _producaoHabilitarLeitorDigitacao = value
        End Set
    End Property



End Class
