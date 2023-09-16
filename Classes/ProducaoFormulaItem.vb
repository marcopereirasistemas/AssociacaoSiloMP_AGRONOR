
Public Class ProducaoFormulaItem
    Enum Linhas
        SujaCocciciostatico = 1
        SujaPromotor = 2
        Limpa = 3
    End Enum
    Private _ordemProducao As String
    Public Property OrdemProducao() As String
        Get
            Return _ordemProducao
        End Get
        Set(ByVal value As String)
            _ordemProducao = value
        End Set
    End Property

    Private _codigoFormula As String
    Public Property CodigoFormula() As String
        Get
            Return _codigoFormula
        End Get
        Set(ByVal value As String)
            _codigoFormula = value
        End Set
    End Property

    Private _codigoMateriaPrima As String
    Public Property CodigoMateriaPrima() As String
        Get
            Return _codigoMateriaPrima
        End Get
        Set(ByVal value As String)
            _codigoMateriaPrima = value
        End Set
    End Property

    Private _quantidade As Double
    Public Property Quantidade() As Double
        Get
            Return _quantidade
        End Get
        Set(ByVal value As Double)
            _quantidade = value
        End Set
    End Property

    Private _quantidadePerc As Double
    Public Property QuantidadePerc() As Double
        Get
            Return _quantidadePerc
        End Get
        Set(ByVal value As Double)
            _quantidadePerc = value
        End Set
    End Property

    Private _quantidadeReal As Double
    Public Property QuantidadeReal() As Double
        Get
            Return _quantidadeReal
        End Get
        Set(ByVal value As Double)
            _quantidadeReal = value
        End Set
    End Property

    Private _totalFormula As Double
    Public Property TotalFormula() As Double
        Get
            Return _totalFormula
        End Get
        Set(ByVal value As Double)
            _totalFormula = value
        End Set
    End Property

    Private _itemID As Integer
    Public Property ItemID() As Integer
        Get
            Return _itemID
        End Get
        Set(ByVal value As Integer)
            _itemID = value
        End Set
    End Property

    Private _linhaID As Linhas
    Public Property LinhaID() As Linhas
        Get
            Return _linhaID
        End Get
        Set(ByVal value As Linhas)
            _linhaID = value
        End Set
    End Property

    Private _numeroSacos As Integer
    Public Property NumeroSacos() As Integer
        Get
            Return _numeroSacos
        End Get
        Set(ByVal value As Integer)
            _numeroSacos = value
        End Set
    End Property

    Private _tamanhoSaco As Double
    Public Property TamanhoSaco() As Double
        Get
            Return _tamanhoSaco
        End Get
        Set(ByVal value As Double)
            _tamanhoSaco = value
        End Set
    End Property

    Private _obs As String
    Public Property Obs() As String
        Get
            Return _obs
        End Get
        Set(ByVal value As String)
            _obs = value
        End Set
    End Property

#Region "Contrutores"
    Sub New()
    End Sub

    Sub New(ByVal xordemproducao As String, _
            ByVal xcodigoformula As String, _
            ByVal xcodigomateriaprima As String, _
            ByVal xquantidade As Double, _
            ByVal xquantidadeper As Double, _
            ByRef xquantidadereal As Double, _
            ByVal xtotalformula As Double, _
            ByVal xitemid As Integer, _
            ByVal xlinhaid As Linhas, _
            ByVal xnumerosacos As Integer, _
            ByVal xtamanhosaco As Double, _
            ByVal xobs As String)

        _ordemProducao = xordemproducao
        _codigoFormula = xcodigoformula
        _codigoMateriaPrima = xcodigomateriaprima
        _quantidade = xquantidade
        _quantidadePerc = xquantidadeper
        _quantidadeReal = xquantidadereal
        _totalFormula = xtotalformula
        _itemID = xitemid
        _linhaID = xlinhaid
        _numeroSacos = xnumerosacos
        _tamanhoSaco = xtamanhosaco
        _obs = xobs
    End Sub

#End Region

End Class
