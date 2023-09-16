
''' <summary>
''' Classe que ira gerenciar os itens da formula
''' </summary>
''' <remarks></remarks>
Public Class Formula


    Public Sub New(ByVal xitem As Integer, _
               ByVal xCodigoMateriaPrima As String, _
               ByVal xDecricaoMateriaPrima As String, _
               ByVal xQtde As Double, _
               ByVal xCodigoSilo As Double, _
               ByVal xNumeroSilo As Double, _
               ByVal xNumeroBalanca As Integer)

        _item = xitem
        _codigoMateriaPrima = xCodigoMateriaPrima
        _descricaoMateriaPrima = xDecricaoMateriaPrima
        _qtde = xQtde
        _codigoSilo = xCodigoSilo
        _numeroSilo = xNumeroSilo
        _numeroSilo = xNumeroBalanca

    End Sub

    Private _item As Integer
    Public Property Item() As Integer
        Get
            Return _item
        End Get
        Set(ByVal value As Integer)
            _item = value
        End Set
    End Property


    Private _codigoMateriaPrima As Integer
    Public Property CodigoMateriaPrima() As Integer
        Get
            Return _codigoMateriaPrima
        End Get
        Set(ByVal value As Integer)
            _codigoMateriaPrima = value
        End Set
    End Property

    Private _descricaoMateriaPrima As String
    Public Property DescricaoMateriaPrima() As String
        Get
            Return _descricaoMateriaPrima
        End Get
        Set(ByVal value As String)
            _descricaoMateriaPrima = value
        End Set
    End Property

    Private _qtde As Double
    Public Property Qtde() As Double
        Get
            Return _qtde
        End Get
        Set(ByVal value As Double)
            _qtde = value
        End Set
    End Property

    Private _codigoSilo As Integer
    Public Property CodigoSilo() As Integer
        Get
            Return _codigoSilo
        End Get
        Set(ByVal value As Integer)
            _codigoSilo = value
        End Set
    End Property

    Private _numeroSilo As Integer
    Public Property NumeroSilo() As Integer
        Get
            Return _numeroSilo
        End Get
        Set(ByVal value As Integer)
            _numeroSilo = value
        End Set
    End Property

    Private _numeroBalanca As Integer
    Public Property NumeroBalanca() As Integer
        Get
            Return _numeroBalanca
        End Get
        Set(ByVal value As Integer)
            _numeroBalanca = value
        End Set
    End Property


End Class
