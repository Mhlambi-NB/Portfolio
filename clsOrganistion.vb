Public Class clsOrganisation
    Private _OrgID As Integer
    Private _OrgName As String
    Private _ContactPerson As String
    Private _ContactNumber As String
    Private _Email As String
    Private _Address As String
    Public Property OrgID As Integer
        Get
            Return _OrgID
        End Get
        Set(value As Integer)
            _OrgID = value
        End Set
    End Property
    Public Property OrgName As String
        Get
            Return _OrgName
        End Get
        Set(value As String)
            _OrgName = value
        End Set
    End Property
    Public Property ContactPerson As String
        Get
            Return _ContactPerson
        End Get
        Set(value As String)
            _ContactPerson = value
        End Set
    End Property
    Public Property ContactNumber As String
        Get
            Return _ContactNumber
        End Get
        Set(value As String)
            _ContactNumber = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property
    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            _Address = value
        End Set
    End Property
End Class
