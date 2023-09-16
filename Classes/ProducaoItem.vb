Public Class ProducaoItem

    Public Sub New(xProducaoId As Double, _
                    xOrdemProducaoID As String, _
                    xMateriaPrimaID As Integer, _
                    xDescricaoMateriaPrima As String, _
                    xQtde As Double, _
                    xSiloId As Integer, _
                    xDescricaoSilo As String, _
                    xBatchId As Integer, _
                    xLote As String)

        _producaoID = xProducaoId
        _ordemProducaoID = xOrdemProducaoID
        _materiaPrimaId = xMateriaPrimaID
        _descricaoMateriaPrima = xDescricaoMateriaPrima
        _qtde = xQtde
        _siloID = xSiloId
        _descricaoSilo = xDescricaoSilo
        _batchID = xBatchId
        _lote = xLote

    End Sub

    Private _producaoID As Double
    Public Property ProducaoID() As Double
        Get
            Return _producaoID
        End Get
        Set(ByVal value As Double)
            _producaoID = value
        End Set
    End Property

    Private _ordemProducaoID As String
    Public Property OrdemProducaoID() As String
        Get
            Return _ordemProducaoID
        End Get
        Set(ByVal value As String)
            _ordemProducaoID = value
        End Set
    End Property

    Private _materiaPrimaId As Integer
    Public Property MateriaPrimaID() As Integer
        Get
            Return _materiaPrimaId
        End Get
        Set(ByVal value As Integer)
            _materiaPrimaId = value
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

    Private _siloID As Integer
    Public Property SiloID() As Integer
        Get
            Return _siloID
        End Get
        Set(ByVal value As Integer)
            _siloID = value
        End Set
    End Property

    Private _descricaoSilo As String
    Public Property DescricaoSilo() As String
        Get
            Return _descricaoSilo
        End Get
        Set(ByVal value As String)
            _descricaoSilo = value
        End Set
    End Property

    Private _batchID As Integer
    Public Property BatchID() As Integer
        Get
            Return _batchID
        End Get
        Set(ByVal value As Integer)
            _batchID = value
        End Set
    End Property

    Private _lote As String
    Public Property Lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property


End Class
