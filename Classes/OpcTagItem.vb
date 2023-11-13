Public Class OpcTagItem
    Private _linhaID As Integer
    Public Property LinhaID() As Integer
        Get
            Return _linhaID
        End Get
        Set(ByVal value As Integer)
            _linhaID = value
        End Set
    End Property

    Private _grupoOpc As String
    Public Property GrupoOPC() As String
        Get
            Return _grupoOpc
        End Get
        Set(ByVal value As String)
            _grupoOpc = value
        End Set
    End Property
    Private _indiceGrupo As Integer
    Public Property IndiceGrupo() As Integer
        Get
            Return _indiceGrupo
        End Get
        Set(ByVal value As Integer)
            _indiceGrupo = value
        End Set
    End Property
    Private _indice As Integer
    Public Property Indice() As Integer
        Get
            Return _indice
        End Get
        Set(ByVal value As Integer)
            _indice = value
        End Set
    End Property

    Private _apelido As String
    Public Property Apelido() As String
        Get
            Return _apelido
        End Get
        Set(ByVal value As String)
            _apelido = value
        End Set
    End Property

    Private _tag As String
    Public Property TAG() As String
        Get
            Return _tag
        End Get
        Set(ByVal value As String)
            _tag = value
        End Set
    End Property

    Private _indexado As Integer
    Public Property Indexado() As Integer
        Get
            Return _indexado
        End Get
        Set(ByVal value As Integer)
            _indexado = value
        End Set
    End Property

    Private _indeceMatriz As Integer
    Public Property IndiceMatriz() As Integer
        Get
            Return _indeceMatriz
        End Get
        Set(ByVal value As Integer)
            _indeceMatriz = value
        End Set
    End Property

    Private _valor As VariantType
    Public Property Valor() As VariantType
        Get
            Return _valor
        End Get
        Set(ByVal value As VariantType)
            _valor = value
        End Set
    End Property

    Private _numeroElementos As Integer
    Public Property NumeroElementos() As Integer
        Get
            Return _numeroElementos
        End Get
        Set(ByVal value As Integer)
            _numeroElementos = value
        End Set
    End Property

    Private _limpar As Integer
    Public Property Limpar() As Integer
        Get
            Return _limpar
        End Get
        Set(ByVal value As Integer)
            _limpar = value
        End Set
    End Property

    Private _status As Integer
    Public Property Status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Public Sub New()
    End Sub



End Class
